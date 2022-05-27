package kr.co.aim.shadowserver.manager;

import java.util.Map;
import java.util.concurrent.locks.ReentrantLock;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Component;

import com.google.common.collect.Maps;

import kr.co.aim.shadowserver.data.User;
import kr.co.aim.shadowserver.utils.IDGenerator;

@Component
public class UserManager {

	// 왜 자바에서 제공하는 해시맵 안 쓰셨을까? -> 직관적, 버그 발생률 낮음, 편함
	private final Map<Integer, User> userMap = Maps.newHashMap();
	private final ReentrantLock lock = new ReentrantLock();

	@Autowired
	private RoomManager roomManager;

	public User create() {

		this.lock.lock();
		try {
			int clientId = IDGenerator.getId();
			int roomId = roomManager.getRoomId(clientId);

			User user = this.userMap.get(clientId);
			if (user == null) {
				user = new User();
				user.setId(clientId);
				user.setRoomId(roomId);
				this.userMap.put(user.getId(), user);
				System.out.printf("유저의 아이디(방아이디): %s(%s)\n", user.getId(), user.getRoomId());
			}

			return user;
		} finally {
			this.lock.unlock();
		}
	}

	public User getUser(int id) {
		this.lock.lock();
		try {
			return this.userMap.get(id);
		} finally {
			this.lock.unlock();
		}
	}

	public void remove(int id) {
		this.lock.lock();
		try {
			this.userMap.remove(id);
		} finally {
			this.lock.unlock();
		}
	}
}
