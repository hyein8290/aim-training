package kr.co.aim.chatting.repository;

import org.springframework.data.jpa.repository.JpaRepository;

import kr.co.aim.chatting.entity.Room;

public interface RoomRepository extends JpaRepository<Room, Integer> {
}