package kr.co.aim.chatting.repository;

import java.util.List;

import org.springframework.data.jpa.repository.JpaRepository;

import kr.co.aim.chatting.entity.InRoom;

public interface InRoomRepository extends JpaRepository<InRoom, Integer>{
	List<InRoom> findByMemberId(int memberId);
}
