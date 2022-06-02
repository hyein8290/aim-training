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

import com.google.common.collect.Lists;

@Entity
public class Room {
	
	@Id @GeneratedValue(strategy = GenerationType.AUTO)
	private int id;
	
	@Column
	private String name;

	@OneToMany(mappedBy = "room")
	private List<InRoom> inRoomList;
	
	@Transient
	private List<Member> memberList;

//	public Room(int roomid) {
//		this.setId(roomid);
////		this.memberList = Lists.newArrayList();
//	}

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

	public String getName() {
		return name;
	}

	public void setName(String name) {
		this.name = name;
	}
	
	public void close() throws IOException {

//		for (Member member : this.memberList) {
//			member.exitRoom(this);
//		}
//
//		this.memberList.clear();
	}
}
