package aim.springserver.domain;

import java.net.Socket;

import lombok.Getter;
import lombok.Setter;

@Getter @Setter
public class User {
	private int id;
	private String name;
	private Socket socket;
}
