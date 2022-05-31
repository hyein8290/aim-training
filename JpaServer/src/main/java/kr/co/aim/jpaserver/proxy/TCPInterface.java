package kr.co.aim.jpaserver.proxy;

import java.io.IOException;
import java.net.ServerSocket;
import java.net.Socket;
import java.util.concurrent.ExecutorService;
import java.util.concurrent.Executors;

import kr.co.aim.jpaserver.data.Member;
import kr.co.aim.jpaserver.data.Room;
import kr.co.aim.jpaserver.manager.MemberManager;
import kr.co.aim.jpaserver.manager.RoomManager;
import kr.co.aim.jpaserver.proxy.parser.DefaultMessageParser;
import kr.co.aim.jpaserver.proxy.parser.MessageParser;

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

	// 2. TCPProxy가 TCPInterface 부름
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

	// 3. 스레드 스타트 호출
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

	// 4. 스레드 실행
	@Override
	public void run() {

		/*
		 * 4.1 클라이언트 접속
		 * 4.2 ClientHandler 생성
		 * 4.3 MemberManager가 member 생성
		 * 		-> DB에 넣어줘야겠다.(Member)
		 * 4.4 RoomManager가 member를 room에 넣어줌.(member가 채팅방에 접속)
		 * 		-> DB에 넣기(InRoom)
		 * 4.5 member에 handler set
		 * 4.6 handler 스레드 실행
		 */
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
