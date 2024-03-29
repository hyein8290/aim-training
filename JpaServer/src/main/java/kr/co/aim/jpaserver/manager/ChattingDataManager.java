package kr.co.aim.jpaserver.manager;

import java.util.Date;
import java.util.List;

import org.springframework.stereotype.Component;

import kr.co.aim.jpaserver.data.ChattingData;
import kr.co.aim.jpaserver.data.Member;
import kr.co.aim.jpaserver.data.Room;
import kr.co.aim.jpaserver.repository.ChattingDataRepository;

@Component
public class ChattingDataManager {
	
	private final ChattingDataRepository chattingDataRepository;
	
	public ChattingDataManager(ChattingDataRepository chattingDataRepository) {
		this.chattingDataRepository = chattingDataRepository;
	}
	
	public ChattingData create(Member member, Room room, String content) {
		ChattingData chattingData = new ChattingData();
		chattingData.setMember(member);
		chattingData.setRoom(room);
		chattingData.setContent(content);
		chattingData.setSendTime(new Date());
		return chattingDataRepository.save(chattingData);
	}
	
	// 보통 레포지토리하고 메소드 이름 똑같게 쓰나??
	public List<ChattingData> findByRoomId(int roomId){
		return chattingDataRepository.findByRoomId(roomId);
	}
	
}

