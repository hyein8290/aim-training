package kr.co.aim.jpaserver;


import javax.annotation.PostConstruct;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Component;
import org.springframework.stereotype.Service;

import kr.co.aim.jpaserver.repository.MemberRepository;
import kr.co.aim.jpaserver.data.Member;

@Component
public class TestService {
	
	@Autowired
    private MemberRepository memberRepository;

    @PostConstruct
	public void test() {
		Member member = new Member();
		member.setName("sadasd");
		memberRepository.save(member);
	}
}
