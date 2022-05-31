package kr.co.aim.jpaserver.data;

import java.io.IOException;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.Transient;

import kr.co.aim.jpaserver.proxy.ClientHandler;

@Entity
public class Member {
	
	@Id @GeneratedValue(strategy = GenerationType.AUTO)
	private int id;
	
	@Column(name="name")
	private String name;

	@Transient
	private Room room;
	
	@Transient
	private ClientHandler clientHandler;

	public ClientHandler getClientHandler() {
		return clientHandler;
	}

	public void setClientHandler(ClientHandler clientHandler) {
		this.clientHandler = clientHandler;
		this.clientHandler.setMember(this);
	}

	public void enterRoom(Room room) {
		room.enterMember(this);
		this.room = room;
	}

	public void exitRoom(Room room) throws IOException {
		this.room = null;
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
