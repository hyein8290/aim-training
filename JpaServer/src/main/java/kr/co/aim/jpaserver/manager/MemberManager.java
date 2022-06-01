package kr.co.aim.jpaserver.manager;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Component;

import kr.co.aim.jpaserver.data.Member;
import kr.co.aim.jpaserver.repository.MemberRepository;

@Component
public class MemberManager {

	private final MemberRepository memberRepository;
	
	public MemberManager(MemberRepository memberRepository) {
		this.memberRepository = memberRepository;
	}

	/*
	 * member를 만드는 메소드
	 * 1. id는 db에서 자동 생성
	 * 2. 이름, 방 넣어줘야겠네
	 * 3. 방 넣어주려면 inroomManager를 사용해야 되나
	 * 4. 우선 방 넣어주고, 나중에 클라이언트가 직접 방 만들고 들어갈 수 있도록 하자
	 * 
	 * 5. 다 아니야 그냥 member 테이블에만 넣자
	 */
	public Member create() {
		Member member = new Member();
		return memberRepository.save(member);
	}

	public Member getMember(int memberId) {
		return memberRepository.getById(memberId);
	}

	// member를 참조하는 inroom, message 먼저 삭제
	// TODO 구현
	public void remove(int memberId) {
		memberRepository.deleteById(memberId);
	}
}
