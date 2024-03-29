package kr.co.aim.chatserver.service;

import java.io.IOException;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Component;

import kr.co.aim.chatserver.manager.RoomManager;
import kr.co.aim.chatserver.manager.MemberManager;
import kr.co.aim.chatserver.data.ChattingData;
import kr.co.aim.chatserver.data.Room;
import kr.co.aim.chatserver.data.Member;

@Component(value="ChattingService")
public class ChattingService {

	@Autowired
	private MemberManager memberManager;
	
	@Autowired
	private RoomManager roomManager;

	public void echo(ChattingData data) throws IOException {
		Member member = this.memberManager.getMember(data.getClientId());
		
		if (member == null) {
			return;
		}
		
		// 자기한테만 보낸 메시지를 방에 있는 사람한테 브로드캐스트 하도록!
		Room room = roomManager.getRoom(member.getRoomId());
		room.broadcast(data.getMessageContent());

		// member.sendMessage(data.getMessageContent());
	}
}
