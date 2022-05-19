package aim.springserver.domain;

import java.net.Socket;

import lombok.Getter;
import lombok.Setter;

@Getter @Setter
public class User {
	private Long id;
	private Socket socket;
	private String name;
}