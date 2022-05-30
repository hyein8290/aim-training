package kr.co.aim.shadowserver.service;

import java.io.IOException;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Component;

import kr.co.aim.shadowserver.data.ChattingData;
import kr.co.aim.shadowserver.data.Room;
import kr.co.aim.shadowserver.data.User;
import kr.co.aim.shadowserver.manager.RoomManager;
import kr.co.aim.shadowserver.manager.UserManager;

@Component(value="ChattingService")
public class ChattingService {

	@Autowired
	private UserManager userManager;
	
	@Autowired
	private RoomManager roomManager;

	public void echo(ChattingData data) throws IOException {
		User user = this.userManager.getUser(data.getClientId());
		
		if (user == null) {
			return;
		}
		
		// 자기한테만 보낸 메시지를 방에 있는 사람한테 브로드캐스트 하도록!
		Room room = roomManager.getRoom(user.getRoomId());
		room.broadcast(data.getMessageContent());

		//user.sendMessage(data.getMessageContent());
	}
}
