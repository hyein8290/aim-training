package aim.springserver.domain;

import java.util.concurrent.ConcurrentHashMap;

import lombok.Getter;
import lombok.Setter;

@Getter @Setter
public class Group {
	private ConcurrentHashMap<Long, User> userMap;
	private int maxSize;
	
	public Group() {
		userMap = new ConcurrentHashMap<>();
	}
	
	public Group(int maxSize) {
		this.maxSize = maxSize;
		userMap = new ConcurrentHashMap<>(maxSize);
	}
}