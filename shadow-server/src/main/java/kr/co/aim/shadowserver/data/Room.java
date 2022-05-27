package kr.co.aim.shadowserver.data;

import java.io.IOException;
import java.util.List;

import com.google.common.collect.Lists;

public class Room {
	private int id;
	private List<User> userList;

	public Room(int roomid) {
		this.setId(roomid);
		this.userList = Lists.newArrayList();
	}

	public void enterUser(User user) {
		// 우선 유저 enterRoom 주석처리하자
		//user.enterRoom(this);
		//this.userList.add(user);
		userList.add(user);
	}

	public void exitUser(User user) throws IOException {
		user.exitRoom(this);
		this.userList.remove(user);
	}

	public void broadcast(Object message) throws IOException {
		for (User user : userList) {
			user.sendMessage(message);
		}
	}

	public int getId() {
		return id;
	}

	public void setId(int id) {
		this.id = id;
	}

	public void close() throws IOException {

		for (User user : this.userList) {
			user.exitRoom(this);
		}

		this.userList.clear();
	}
}
