package kr.co.aim.jpaserver.repository;

import java.util.Optional;

import org.springframework.data.jpa.repository.JpaRepository;

import kr.co.aim.jpaserver.data.Room;

public interface RoomRepository extends JpaRepository<Room, Integer> {
	//Optional<Room> findByMemberId(int memberId);
}