package aim.springserver.domain;

import java.util.concurrent.ConcurrentHashMap;
import java.util.concurrent.atomic.AtomicInteger;

import lombok.Getter;
import lombok.Setter;

@Getter @Setter
public class Room {
	private int id;
	private String name;
	private ConcurrentHashMap<Integer, User> userMap;
	
	public Room() {
		userMap = new ConcurrentHashMap<>();
	}
	
	public Room(int id) {
		this.id = id;
		userMap = new ConcurrentHashMap<>(); 
	}
	
	public Room(String name) {
		this.name = name;
		userMap = new ConcurrentHashMap<>();
	}

	public Room(int id, String name) {
		this.id = id;
		this.name = name;
		userMap = new ConcurrentHashMap<>();
	}
	
	public void enterUser(User user) {
		userMap.put(user.getId(), user);
	}
	
}
