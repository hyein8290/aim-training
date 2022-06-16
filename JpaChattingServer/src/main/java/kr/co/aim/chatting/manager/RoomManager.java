package kr.co.aim.chatting.manager;

import java.util.List;

import org.springframework.stereotype.Component;

import kr.co.aim.chatting.entity.Room;
import kr.co.aim.chatting.repository.RoomRepository;

@Component
public class RoomManager {
	
	private final RoomRepository roomRepository;
	
	// @Autowired
	public RoomManager(RoomRepository roomRepository) {
		this.roomRepository = roomRepository;
	}
	
	public Room createRoom() {
		Room room = new Room();
		return roomRepository.save(room);
	}
	
	public Room getRoom(int roomId) {
		return roomRepository.getById(roomId);
	}
	
	public void removeRoom(int roomId) {
		
	}
	
	// 존재하는 모든 방 찾기,,,
	public List<Room> findAllRoom() {
		return roomRepository.findAll();
	}
}
