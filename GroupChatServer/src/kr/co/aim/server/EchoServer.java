package kr.co.aim.server;

import java.io.IOException;
import java.net.ServerSocket;
import java.net.Socket;
import java.util.InputMismatchException;
import java.util.Scanner;
import java.util.concurrent.ConcurrentHashMap;

public class EchoServer {

	private static ConcurrentHashMap<Long, ConcurrentHashMap<Long, User>> groups;	// 그룹 해시맵
	private static long groupSequence = 0L;		// 방번호
	private static long userSequence = 0L; 		// 유저번호
	private final int GROUP_NUM = 2; 			// 방  개수

	private ServerSocket serverSocket;
	private Scanner scanner;
			
	/**
	 * EchoServer 생성자
	 * serverSocket을 생성
	 */
	public EchoServer() {
		setGroups(GROUP_NUM);
		createServerSocket();
	}

	/**
	 * 서버를 실행하는 메소드
	 */
	public void run() {
		try {
			System.out.println("[서버 시작] 클라이언트 대기중..");
			
			while(true) {
				Socket clientSocket = serverSocket.accept();
				ConcurrentHashMap<Long, User> group = joinGroup(clientSocket);
				Thread thread = new Thread(new EchoServerThread(clientSocket, group));
				thread.start();
			}
			
		} catch (IOException e) {
			e.printStackTrace();
		}
	}

	/**
	 * port번호를 입력받고 serverSocket을 생성하는 메소드
	 */
	private void createServerSocket() {
		try {
			scanner = new Scanner(System.in);

			System.out.println("================그룹서버================");
			
			System.out.print("Open할 Port번호를 입력해주세요: ");
			int port = scanner.nextInt();

			serverSocket = new ServerSocket(port);
			
		} catch (InputMismatchException e) {
			System.out.println("숫자만 입력");
		} catch (IllegalArgumentException e) {
			System.out.println("0~65535 사이의 값을 입력해주세요.");
		} catch (IOException e) {
			e.printStackTrace();
		}
	}

	/**
	 * 클라이언트의 그룹을 정해주는 메소드
	 * @param client 클라이언트
	 * @return		 정해진 그룹
	 */
	private ConcurrentHashMap<Long, User> joinGroup(Socket client) {
		Long userId = ++userSequence;
		Long groudId = userId % GROUP_NUM + 1;
		
		User user = new User();
		user.setSocket(client);
		
		ConcurrentHashMap<Long, User> group = groups.get(groudId);
		
		group.put(userId, user);
		
		return group;
	}

	/**
	 * 그룹을 생성하는 메소드
	 * @param groupNums 그룹의 개수
	 */
	private void setGroups(int groupNums) {
		groups = new ConcurrentHashMap<Long, ConcurrentHashMap<Long, User>>();
		while(groupNums-- > 0) {
			groups.put(++groupSequence, new ConcurrentHashMap<Long, User>());
		}
	}

}