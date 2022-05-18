package aim.springserver.domain;

import java.net.Socket;

import lombok.Data;

@Data
public class User {
	
	private Long id;
	private Socket socket;
	private String name;
}