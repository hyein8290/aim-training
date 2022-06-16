package kr.co.aim.chatting.proxy;

import java.io.DataInputStream;
import java.io.DataOutputStream;
import java.io.IOException;
import java.net.ServerSocket;
import java.net.Socket;
import java.util.concurrent.ExecutorService;
import java.util.concurrent.Executors;

import org.springframework.beans.factory.annotation.Autowired;

import com.example.chatting.proxy.MessageCallBack;

import kr.co.aim.chatting.data.Packet;
import kr.co.aim.chatting.entity.Room;
import kr.co.aim.chatting.manager.RoomManager;
import kr.co.aim.chatting.parser.MessageParser;
import kr.co.aim.chatting.type.Type;

public class TcpInterface extends Thread{
	
	private MessageCallBack callBack;
	private final ExecutorService workers = Executors.newCachedThreadPool();
	private MessageParser messageParser;
	
	@Autowired
	private RoomManager roomManager;
	
	private boolean running = false;
	private ServerSocket listenSocket;

	public TcpInterface(int port, MessageParser messageParser, MessageCallBack callBack ) {
		try {
			this.listenSocket = new ServerSocket(port);
			this.messageParser = messageParser;
			this.callBack = callBack;
		} catch (IOException e) {
			System.err.println("An exception occurred while creating the listen socket: " + e.getMessage());
			e.printStackTrace();
			System.exit(1);
		}
	}
	
	public void open() {
		this.running = true;
		this.start();
	}
	
	public void close() {
		this.running = false;
		this.workers.shutdownNow();

		try {
			this.join();
		} catch (InterruptedException e) {
			e.printStackTrace();
		}
	}
	
	@Override
	public void run() {
		while(this.running) {
			try {
				final Socket clientSocket = this.listenSocket.accept();
				
				System.out.println("Accepted connection from " + clientSocket.getRemoteSocketAddress());
				
				ClientHandler handler = new ClientHandler(clientSocket, this.messageParser);
				this.workers.execute(handler);

			} catch (Exception e) {
			}
		}
	}
	
	public class ClientHandler implements Runnable {
		
		private final Socket clientSocket;
		private final MessageParser messageParser;
		private final MessageCallBack callBack;
		
		private final DataInputStream memberInput;
		private final DataOutputStream memberOutput;
		
		public ClientHandler(final Socket clientSocket, final MessageParser messageParser, final MessageCallBack callBack) throws IOException {
			this.clientSocket = clientSocket;
			this.messageParser = messageParser;
			this.callBack = callBack;

			memberInput = new DataInputStream(this.clientSocket.getInputStream());
			memberOutput = new DataOutputStream(this.clientSocket.getOutputStream());
		}
		
		@Override
		public void run() {
			try {
				while(memberInput != null) {
					/*
					 * 1. 패킷 까보기
					 * 2. 패킷 타입 뭔지 확인
					 */
					Packet receivePacket = new Packet(memberInput);
					System.out.println("2");
					receivePacket.read();						
					if(memberInput.available()>0) {
						System.out.println("3");
					}
					System.out.println("4");
					int type = receivePacket.getType();
					System.out.println("");
					
					Packet sendPacket = null;
					
					if(type == Type.ROOM_LIST) {
						
					} else if(type == Type.MAKE_ROOM) {
						System.out.println("hi");
						Room room = roomManager.createRoom();
						sendPacket = new Packet(this.messageParser, Type.MAKE_ROOM, room.getId(), null);
						this.memberOutput.write(sendPacket.toByteArray());
						this.memberOutput.flush();
					} else if(type == Type.ENTER_ROOM) {
						
					} else if(type == Type.SET_NAME) {
						
					} else if(type == Type.SEND_MESSAGE) {
						
					}
					
				}
			} catch (Exception e) {
				// TODO: handle exception
				e.printStackTrace();
			}
		}
	}

}
