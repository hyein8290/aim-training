package kr.co.aim.chatserver.data;

import java.time.LocalDateTime;

public class InRoom {
	private int id;
	private int memberId;
	private int roomId;
	private LocalDateTime inTime;
	
	public int getId() {
		return id;
	}
	
	public void setId(int id) {
		this.id = id;
	}
	
	public int getMemberId() {
		return memberId;
	}
	
	public void setMemberId(int memberId) {
		this.memberId = memberId;
	}
	
	public int getRoomId() {
		return roomId;
	}
	
	public void setRoomId(int roomId) {
		this.roomId = roomId;
	}
	
	public LocalDateTime getInTime() {
		return inTime;
	}
	
	public void setInTime(LocalDateTime inTime) {
		this.inTime = inTime;
	}
}
