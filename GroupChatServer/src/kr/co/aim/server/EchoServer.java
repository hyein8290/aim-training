package kr.co.aim.server;

import java.io.IOException;
import java.net.ServerSocket;
import java.net.Socket;
import java.util.InputMismatchException;
import java.util.Scanner;
import java.util.concurrent.ConcurrentHashMap;

public class EchoServer {

	// TODO 주석으로 설명달기
	private static ConcurrentHashMap<Long, ConcurrentHashMap<Long, User>> groups;
	private static long groupSequence = 0L;	// 방번호
	private static long userSequence = 0L; // 유저번호
	private final int GROUP_NUM = 2; // 방  개수

	private ServerSocket serverSocket;
	private Socket clientSocket;
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
	 * thread를 사용하여 클라이언트 다중 접속이 가능하도록 한다.
	 */
	public void run() {		
		try {
			System.out.println("[서버 시작] 클라이언트 대기중..");
			
			while(true) {
				// 지역변수로?
				clientSocket = serverSocket.accept();
				ConcurrentHashMap<Long, User> group = joinGroup(clientSocket);
				EchoServerThread thread = new EchoServerThread(clientSocket, group);
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
			System.out.println("================그룹서버================");

			scanner = new Scanner(System.in);
			
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
	
	/*
	 * 클라이언트가 접속하면 그룹을 정해주도록 하자
	 */
	private ConcurrentHashMap<Long, User> joinGroup(Socket client) {
		Long userId = ++userSequence;
		Long groudId = userId % GROUP_NUM + 1;
		
		User user = new User();
		user.setSocket(client);
		
		// 한 번만 꺼내자]
		// 한번 꺼내서 확인한 다음에 
		// get 했을 때 값이 없으면 null(에러 , 근데 null에 넣으려고 하면 에러
		groups.get(groudId).put(userId, user);
		
		return groups.get(groudId);
	}
	
	/*
	 * 서버가 만들어지면 그룹들이 생성되도록 하자
	 */
	private void setGroups(int groupNums) {
		groups = new ConcurrentHashMap<Long, ConcurrentHashMap<Long, User>>();
		while(groupNums-- > 0) {
			groups.put(++groupSequence, new ConcurrentHashMap<Long, User>());
		}
	}

}