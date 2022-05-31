package kr.co.aim.jpaserver.repository;

import java.util.Optional;

import org.springframework.data.jpa.repository.JpaRepository;

import kr.co.aim.jpaserver.data.InRoom;

public interface InRoomRepository extends JpaRepository<InRoom, Integer>{
//	Optional<InRoom> findByMemberId(int memberId);
//	Optional<InRoom> findByRoomId(int roomId);
}
