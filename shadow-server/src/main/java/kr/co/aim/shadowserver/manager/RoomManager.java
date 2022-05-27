package kr.co.aim.shadowserver.manager;

import java.io.IOException;
import java.util.Map;
import java.util.concurrent.locks.ReentrantLock;

import javax.annotation.PostConstruct;

import org.springframework.stereotype.Component;

import com.google.common.collect.Maps;

import kr.co.aim.shadowserver.data.Room;

@Component
public class RoomManager {
	private final Map<Integer, Room> roomMap = Maps.newHashMap();
	// 아토믹 안 쓴 이유가 락 걸어서 그런건가...?
//	private AtomicInteger atomicInteger;
	private final ReentrantLock lock = new ReentrantLock();
	private final int capa = 2;

	private int intGenerator = 0;

	public RoomManager() {
	}

	@PostConstruct
	private void init() {

		for (int i = 0; i < this.capa; i++) {
			this.createRoom();
		}
	}

	private Room createRoom() {

		this.lock.lock();
		try {
			int roomId = ++intGenerator;

			Room room = this.roomMap.get(roomId);
			if (room == null) {
				room = new Room(roomId);
				this.roomMap.put(room.getId(), room);
			}

			return room;
		} finally {
			this.lock.unlock();
		}
	}

	public Room getRoom(int roomid) {

		this.lock.lock();
		try {
			return this.roomMap.get(roomid);
		} finally {
			this.lock.unlock();
		}
	}

	public void removeRoom(int roomid) throws IOException {

		this.lock.lock();
		try {
			Room room = this.roomMap.remove(roomid);
			if (room != null) {
				room.close();
			}
		} finally {
			this.lock.unlock();
		}
	}

	public int getRoomId(int clientId) {
		return (clientId % this.capa) + 1;
	}
}
