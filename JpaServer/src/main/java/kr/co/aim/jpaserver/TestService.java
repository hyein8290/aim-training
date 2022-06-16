package kr.co.aim.jpaserver;


import java.nio.ByteBuffer;

import javax.annotation.PostConstruct;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Component;

import kr.co.aim.jpaserver.proxy.parser.DefaultMessageParser;
import kr.co.aim.jpaserver.proxy.parser.MessageParser;
import kr.co.aim.jpaserver.repository.MemberRepository;

@Component
public class TestService {
	
	@Autowired
    private MemberRepository memberRepository;
	
//	private final MessageParser messageParser = new DefaultMessageParser();

//    @PostConstruct
	public void test() {
//		Member member = new Member();
//		member.setName("sadasd");
//		memberRepository.save(member);
    	
//    	byte[] typeBytes = this.messageParser.objectToByteArray(4);
//    	byte[] typeBytes = this.messageParser.objectToByteArray("안녕");
//    	System.out.println(typeBytes);
//    	System.out.println(ByteBuffer.wrap(typeBytes).getInt());
//    	System.out.println(this.messageParser.byteArrayToInt(typeBytes));
//    	System.out.println(this.messageParser.byteArrayToObject(typeBytes));
	}
}
