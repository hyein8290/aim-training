package kr.co.aim.chatserver.data;

import java.io.IOException;
import java.util.List;

import com.google.common.collect.Lists;

public class Room {
	private int id;
	private List<Member> memberList;

	public Room(int roomid) {
		this.setId(roomid);
		this.memberList = Lists.newArrayList();
	}

	public void enterMember(Member member) {
		// 우선 멤버 enterRoom 주석처리하자
		//member.enterRoom(this);
		//this.memberList.add(member);
		memberList.add(member);
	}

	public void exitMember(Member member) throws IOException {
		member.exitRoom(this);
		this.memberList.remove(member);
	}

	public void broadcast(Object message) throws IOException {
		for (Member member : memberList) {
			member.sendMessage(message);
		}
	}

	public int getId() {
		return id;
	}

	public void setId(int id) {
		this.id = id;
	}

	public void close() throws IOException {

		for (Member member : this.memberList) {
			member.exitRoom(this);
		}

		this.memberList.clear();
	}
}
