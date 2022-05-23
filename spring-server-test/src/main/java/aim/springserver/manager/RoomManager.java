package aim.springserver.manager;

import java.util.concurrent.ConcurrentHashMap;
import java.util.concurrent.atomic.AtomicInteger;

import org.springframework.stereotype.Component;

import aim.springserver.domain.Room;
import aim.springserver.domain.User;

@Component
public class RoomManager {
	
	private ConcurrentHashMap<Integer, Room> roomMap;
	private AtomicInteger atomicInteger;
	
	public Room createRoom() {
		int roomId = atomicInteger.incrementAndGet();
		Room room = new Room(roomId);
		roomMap.put(roomId, room);
		return room;
	}
	
	
}
