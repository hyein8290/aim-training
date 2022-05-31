package kr.co.aim.jpaserver.manager;

import java.util.Map;
import java.util.concurrent.locks.ReentrantLock;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Component;

import com.google.common.collect.Maps;

import kr.co.aim.jpaserver.data.Member;
import kr.co.aim.jpaserver.utils.IDGenerator;

@Component
public class MemberManager {

	// 왜 자바에서 제공하는 해시맵 안 쓰셨을까? -> 직관적, 버그 발생률 낮음, 편함
	private final Map<Integer, Member> memberMap = Maps.newHashMap();
	private final ReentrantLock lock = new ReentrantLock();

	@Autowired
	private RoomManager roomManager;

	public Member create() {

		int roomId = roomManager.getRoomId(clientId);

		Member member = this.memberMap.get(clientId);
		if (member == null) {
			member = new Member();
			member.setId(clientId);
			member.setRoomId(roomId);
			this.memberMap.put(member.getId(), member);
			System.out.printf("유저의 아이디(방아이디): %s(%s)\n", member.getId(), member.getRoomId());
		}

		return member;
	}

	public Member getMember(int id) {
		this.lock.lock();
		try {
			return this.memberMap.get(id);
		} finally {
			this.lock.unlock();
		}
	}

	public void remove(int id) {
		this.lock.lock();
		try {
			this.memberMap.remove(id);
		} finally {
			this.lock.unlock();
		}
	}
}
