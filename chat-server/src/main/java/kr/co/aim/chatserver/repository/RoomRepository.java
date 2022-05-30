package kr.co.aim.chatserver.repository;

import java.util.Optional;

import org.springframework.data.jpa.repository.JpaRepository;

import kr.co.aim.chatserver.data.Room;

public interface RoomRepository extends JpaRepository<Room, Integer> {
	Optional<Room> findByMemberId(int memberId);
}