package kr.co.aim.chatting.proxy;

import javax.annotation.PostConstruct;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Component;

import kr.co.aim.chatting.entity.ChattingData;
import kr.co.aim.chatting.parser.MessageParser;

@Component
public class TcpProxy implements MessageCallBack {
	
	private TcpInterface tcpInterface;
	
	@Autowired
	private MessageParser messageParser;
	
	private final int port = 9000;
	
	@PostConstruct
	private void open() {
		this.tcpInterface = new TcpInterface(port, messageParser, this);
		this.tcpInterface.open();

		System.out.println(String.format("Start Server Port=%d", port));
	}
	
	@Override
	public void onMessage(Object msg) {
		if(!(msg instanceof ChattingData)) {
			return;
		}
		
		ChattingData chattingData = (ChattingData)msg;
	}
}
