package kr.co.aim.chatting;

import javax.annotation.PostConstruct;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Component;

import kr.co.aim.chatting.data.Packet;
import kr.co.aim.chatting.parser.MessageParser;
import kr.co.aim.chatting.type.Type;

//@Component
public class Test {

//	@Autowired
	private MessageParser messageParser;
	
//	@PostConstruct
	public void test() {
		
//    	byte[] bodyBytes = messageParser.objectToByteArray(null);
//    	if(bodyBytes == null) {
//    		System.out.println("hello");
//    	}
    	
//    	String msg = (String) messageParser.byteArrayToString(bodyBytes);
//    	System.out.println(msg);
//    	for(int i=0; i<bodyBytes.length; i++) {
//    		System.out.println(bodyBytes[i]);
//    	}
//    	System.out.println("hi");
    	
    	Packet packet = new Packet(messageParser, 1, 1, null);
    	packet.toByteArray();
    	System.out.println("성공");
	}
}
