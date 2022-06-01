package kr.co.aim.jpaserver.repository;

import java.util.List;
import java.util.Optional;

import org.springframework.data.jpa.repository.JpaRepository;

import kr.co.aim.jpaserver.data.InRoom;

public interface InRoomRepository extends JpaRepository<InRoom, Integer>{
	List<InRoom> findByMemberId(int memberId);
}
