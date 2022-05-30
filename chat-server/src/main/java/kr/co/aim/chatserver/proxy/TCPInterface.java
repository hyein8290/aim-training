package kr.co.aim.chatserver.proxy;

import java.io.IOException;
import java.net.ServerSocket;
import java.net.Socket;
import java.util.concurrent.ExecutorService;
import java.util.concurrent.Executors;

import kr.co.aim.chatserver.manager.RoomManager;
import kr.co.aim.chatserver.manager.MemberManager;
import kr.co.aim.chatserver.proxy.parser.DefaultMessageParser;
import kr.co.aim.chatserver.proxy.parser.MessageParser;
import kr.co.aim.chatserver.data.Room;
import kr.co.aim.chatserver.data.Member;

public class TCPInterface extends Thread {

	// 여기는 왜 autowired 안 하셨을까, tcpproxy에서 해서 넘겨서 그런건가?
	private final MessageCallBack callBack;
	private final MemberManager memberManager;
	private final RoomManager roomManager;
	private final MessageParser messageParser = new DefaultMessageParser();
	// 스레드의 라이프사이클 제어
	private final ExecutorService workers = Executors.newCachedThreadPool();

	private boolean running = false;
	private ServerSocket listenSocket;

	public TCPInterface(final int portNo, final MemberManager memberManager, final RoomManager roomManager, final MessageCallBack callBack) {
		this.memberManager = memberManager;
		this.roomManager = roomManager;
		this.callBack = callBack;

		try {
			this.listenSocket = new ServerSocket(portNo);
		} catch (IOException e) {
			System.err.println("An exception occurred while creating the listen socket: " + e.getMessage());
			e.printStackTrace();
			System.exit(1);
		}
	}

	public void Open() {

		this.running = true;

		this.start();
	}

	public void close() {

		this.running = false;
		this.workers.shutdownNow();

		try {
			this.join();
		} catch (InterruptedException e) {
		}
	}

	@Override
	public void run() {

		while (this.running) {
			try {
				final Socket clientSock = this.listenSocket.accept();

				// TODO Login Event
				System.out.println("Accepted connection from " + clientSock.getRemoteSocketAddress());

				ClientHandler handler = new ClientHandler(clientSock, this.messageParser, callBack);
				Member member = this.memberManager.create();
				
				// ERROR 여기서 room에 넣어 주는 게 아닌가,,,
				// enterMember는 enterRoom을 부르고, enterRoom은 enterMember를 부르고,,
				Room room = roomManager.getRoom(member.getRoomId());
				member.enterRoom(room);
				// room.enterMember(member);

				member.setClientHandler(handler);
				
				// 이게 뭔 뜻이다냐
				// 핸들러 돌리겠다는 뜻이겠지? worker가 스레드 제어하는 애니까,,
				// 그럼 핸들러의 run이 실행되겠지..?
				this.workers.execute(handler);

			} catch (Exception ex) {
				Thread.yield();
			}
		}
	}


}
