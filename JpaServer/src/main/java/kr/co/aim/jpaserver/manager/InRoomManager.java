package kr.co.aim.jpaserver.manager;

import java.util.Date;
import java.util.List;

import org.springframework.stereotype.Component;

import kr.co.aim.jpaserver.data.InRoom;
import kr.co.aim.jpaserver.data.Member;
import kr.co.aim.jpaserver.data.Room;
import kr.co.aim.jpaserver.repository.InRoomRepository;

@Component
public class InRoomManager {
	
	private final InRoomRepository inRoomRepository;
	
	public InRoomManager(InRoomRepository inRoomRepository) {
		this.inRoomRepository = inRoomRepository;
	}
	
	public InRoom create(Room room, Member member) {
		InRoom inRoom = new InRoom();
		inRoom.setRoom(room);
		inRoom.setMember(member);
		inRoom.setInTime(new Date());
		return inRoomRepository.save(inRoom);
	}
	
	public List<InRoom> getByMemberId(int memberId) {
		return inRoomRepository.findByMemberId(memberId);
	}
	
	public void remove(int inRoomId) {
		inRoomRepository.deleteById(inRoomId);
	}

}
