package aim.springserver.manager;

import java.io.IOException;
import java.net.ServerSocket;
import java.net.Socket;
import java.util.InputMismatchException;
import java.util.Scanner;

import org.springframework.beans.factory.annotation.Autowired;

import aim.springserver.domain.Room;
import aim.springserver.domain.User;

public class ServerManager {

	private RoomManager roomManager;
	
	private ServerSocket server;
	private Scanner scanner;
	
	@Autowired
	public ServerManager(RoomManager roomManager) {
		this.roomManager = roomManager;
	}
	
	public void run() {
		try {
			System.out.println("================그룹서버================");

			setPort();
			
			System.out.println("[서버 시작] 클라이언트 대기중..");
			
			while(true) {
				User user = new User();
				user.setSocket(server.accept());

				Room room = roomManager.createRoom();
				room.enterUser(user);
				
				Thread thread = new Thread(new ThreadManager(user, room));
				thread.start();
			}
			
		} catch (IOException e) {
			e.printStackTrace();
		}
	}
	
	public void setPort() {
		try {
			scanner = new Scanner(System.in);
			
			System.out.println("Port 입력: ");
			int port = scanner.nextInt();
			
			server = new ServerSocket(port);
			
		} catch (InputMismatchException e) {
			System.out.println("숫자만 입력해주세요");
		} catch (IllegalArgumentException e) {
			System.out.println("0~65535 사이의 값을 입력해주세요.");
		} catch (IOException e) {
			e.printStackTrace();
		}
	}
}
