package kr.co.aim.jpaserver.manager;

import java.io.IOException;

import javax.annotation.PostConstruct;

import org.springframework.stereotype.Component;

import kr.co.aim.jpaserver.data.Room;
import kr.co.aim.jpaserver.repository.RoomRepository;

@Component
// @RequiredArgsConstructor -> 왜 에러가 날까나
public class RoomManager {
	
	private final RoomRepository roomRepository;
	private final int capa = 2;
	
	public RoomManager(RoomRepository roomRepository) {
		this.roomRepository = roomRepository;
	}

	// 1. 방 만들기
	//		-> DB에 넣어줘야겠네(Room)
	@PostConstruct
	private void init() {
		for (int i = 0; i < this.capa; i++) {
			this.createRoom();
		}
	}

	private Room createRoom() {
		Room room = new Room();
		return roomRepository.save(room);
	}

	// TODO findById vs getById
	// id값이 항상 존재?
	public Room getRoom(int roomId) {
		return roomRepository.getById(roomId);
	}

	// room을 참조하고 있는 inroom, message 먼저 삭제
	// TODO 구현
	public void removeRoom(int roomId) throws IOException {
		roomRepository.deleteById(roomId);
		// room.close();
	}
}
