package kr.co.aim.mavenserver;

import javax.annotation.PostConstruct;

import org.springframework.stereotype.Component;

public class ServerApplication {
	
	public void main() {
		
		EchoServer server = new EchoServer();
		
		if(server != null) {
			server.run();
		}
		
	}
}
