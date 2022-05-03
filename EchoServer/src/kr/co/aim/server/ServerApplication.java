package kr.co.aim.server;

public class ServerApplication {
	
	public static void main(String[] args) {
		
		EchoServer server = new EchoServer();
		
		if(server != null) {
			server.run();
		}
		
	}
}
