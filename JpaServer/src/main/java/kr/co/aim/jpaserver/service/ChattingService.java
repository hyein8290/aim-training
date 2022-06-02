package kr.co.aim.jpaserver.service;

import java.io.IOException;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Component;

import kr.co.aim.jpaserver.data.ChattingData;
import kr.co.aim.jpaserver.data.Member;
import kr.co.aim.jpaserver.data.Room;
import kr.co.aim.jpaserver.manager.MemberManager;
import kr.co.aim.jpaserver.manager.RoomManager;

@Component(value="ChattingService")
public class ChattingService {

	public void echo(ChattingData data) throws IOException {
		Member member = data.getMember();
		if (member == null) {
			return;
		}
		
		Room room = data.getRoom();
		room.broadcast(data.getContent());
	}
}
