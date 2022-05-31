package kr.co.aim.jpaserver.data;

import java.util.Date;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.Table;
import javax.persistence.Temporal;
import javax.persistence.TemporalType;

@Entity
@Table(name="CHATTINGDATA")
public class ChattingData {

	// 기본키 생성전략 뭘로 해야 되지?
	@Id @GeneratedValue(strategy = GenerationType.AUTO)
	private int id;
	
	@Column(name="roomId")
	private int roomId;
	
	@Column(name="memberId")
	private int clientId;
	
	@Column(name="content")
	private String content;
	
	@Temporal(TemporalType.TIMESTAMP)
	private Date sendTime;

	public int getId() {
		return id;
	}

	public void setId(int id) {
		this.id = id;
	}
	
	public String getContent() {
		return content;
	}

	public void setContent(String content) {
		this.content = content;
	}

	public int getRoomId() {
		return roomId;
	}

	public void setRoomId(int roomId) {
		this.roomId = roomId;
	}

	public int getClientId() {
		return clientId;
	}

	public void setClientId(int clientId) {
		this.clientId = clientId;
	}

	public Date getSendTime() {
		return sendTime;
	}

	public void setSendTime(Date sendTime) {
		this.sendTime = sendTime;
	}

}
