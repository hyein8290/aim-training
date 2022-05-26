package kr.co.aim.chatserver.manager;

import java.util.HashMap;
import java.util.Map;
import java.util.concurrent.atomic.AtomicInteger;
import java.util.concurrent.locks.ReentrantLock;

import kr.co.aim.chatserver.data.Member;

public class MemberManager {
	
	private final Map<Integer, Member> memberMap = new HashMap<>();
	private final ReentrantLock lock = new ReentrantLock();
	private static AtomicInteger atomicInteger;
	
	private RoomManager roomManager;
	
	public Member create() {
		
		this.lock.lock();
		try {
			int memberId = atomicInteger.incrementAndGet();
			//int roomId = roomManager.getRoomId(memberId);
		} finally {
			// TODO: handle finally clause
		}
		return null;
		
	}
	
}
