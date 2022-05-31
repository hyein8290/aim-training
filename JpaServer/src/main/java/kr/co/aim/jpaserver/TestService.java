package kr.co.aim.jpaserver;


import javax.annotation.PostConstruct;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Component;
import org.springframework.stereotype.Service;

import kr.co.aim.jpaserver.data.Member;
import kr.co.aim.jpaserver.repository.MemberRepository;


public class TestService {
	
    private MemberRepository memberRepository;

    @Autowired
    public TestService(MemberRepository memberRepository) {
        this.memberRepository = memberRepository;
    }

    @PostConstruct
	public void test() {
		Member member = new Member();
		member.setName("qsdsa");
		memberRepository.save(member);
	}
}
