package kr.co.aim.jpaserver.data;

import java.io.IOException;
import java.util.List;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.OneToMany;
import javax.persistence.Transient;

import kr.co.aim.jpaserver.proxy.ClientHandler;

@Entity
public class Member {
	
	@Id @GeneratedValue(strategy = GenerationType.SEQUENCE)
	private int id;
	
	@Column(name="name")
	private String name;
	
	@OneToMany(mappedBy = "member")
	private List<InRoom> inRoomList;

	@Transient
	private Room cuurentRoom;
	
	@Transient
	private ClientHandler clientHandler;

	public ClientHandler getClientHandler() {
		return clientHandler;
	}

	public void setClientHandler(ClientHandler clientHandler) {
		this.clientHandler = clientHandler;
		this.clientHandler.setMember(this);
	}

	// 이 메소드 있어야 할까?
	public void enterRoom(Room room) {
		room.enterMember(this);
		this.cuurentRoom = room;
	}

	public void exitRoom(Room room) throws IOException {
		this.cuurentRoom = null;
		this.clientHandler.send("kicked out of the room");
	}

	public void sendMessage(Object object) throws IOException {
		this.clientHandler.send(object);
	}

	public int getId() {
		return id;
	}

	public void setId(int id) {
		this.id = id;
	}
	
	public String getName() {
		return name;
	}

	public void setName(String name) {
		this.name = name;
	}
	
}
