package kr.co.aim.shadowserver.data;

import java.io.IOException;

import kr.co.aim.shadowserver.proxy.ClientHandler;

public class User {
	private int id;
	private String name;
	private int roomId;

	private Room room;
	private ClientHandler clientHandler;

	public ClientHandler getClientHandler() {
		return clientHandler;
	}

	public void setClientHandler(ClientHandler clientHandler) {
		this.clientHandler = clientHandler;
		this.clientHandler.setUser(this);
	}

	public void enterRoom(Room room) {
		room.enterUser(this);
		this.room = room;
	}

	public void exitRoom(Room room) throws IOException {
		this.room = null;
		this.clientHandler.send("kicked out of the room");
	}

	public void sendMessage(Object object) throws IOException {
		this.clientHandler.send(object);
	}

	public int getRoomId() {
		return roomId;
	}

	public void setRoomId(int roomId) {
		this.roomId = roomId;
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
