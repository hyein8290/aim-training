package kr.co.aim.chatting.repository;

import java.util.List;

import org.springframework.data.jpa.repository.JpaRepository;

import kr.co.aim.chatting.entity.ChattingData;

public interface ChattingDataRepository extends JpaRepository<ChattingData, Integer> {
	List<ChattingData> findByRoomId(int roomId);
	
	// TODO 들어온 시간이랑 메시지 보낸 시간 비교하는 쿼리...
}
