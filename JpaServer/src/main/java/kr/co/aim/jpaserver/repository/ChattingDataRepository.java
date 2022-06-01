package kr.co.aim.jpaserver.repository;

import java.util.List;
import java.util.Optional;

import org.springframework.data.jpa.repository.JpaRepository;

import kr.co.aim.jpaserver.data.ChattingData;

public interface ChattingDataRepository extends JpaRepository<ChattingData, Integer> {
	List<ChattingData> findByRoomId(int roomId);
}
