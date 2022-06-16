package kr.co.aim.chatting.entity;

import java.util.List;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.OneToMany;
import javax.persistence.Transient;

import lombok.Getter;

@Entity
@Getter
public class Room {
	
	@Id @GeneratedValue(strategy = GenerationType.SEQUENCE)
	private int id;
	
	@Column(name="name")
	private String name;

	@OneToMany(mappedBy = "room")
	private List<InRoom> inRoomList;
}
