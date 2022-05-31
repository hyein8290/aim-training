package kr.co.aim.chatserver.manager;

import java.util.Optional;
import java.util.concurrent.locks.ReentrantLock;

import org.springframework.beans.factory.annotation.Autowired;

import kr.co.aim.chatserver.data.Member;
import kr.co.aim.chatserver.repository.MemberRepository;
import kr.co.aim.chatserver.utils.IDGenerator;

// @Transactional
public class TestManager {
	
	// JPA에서 제공하는 동기화 기법 없을까?
	// -> JPA는 데이터 동기화 문제를 데이터베이스에 맡깁니다.
	private final ReentrantLock lock = new ReentrantLock();
	private final MemberRepository memberRepository;
	
    @Autowired
    public TestManager(MemberRepository memberRepository) {
        this.memberRepository = memberRepository;
    }
	
	@Autowired 
	private RoomManager roomManager;
	
	public Member create() {
		this.lock.lock();
		try {
			int memberId = IDGenerator.getId();
			int roomId = roomManager.getRoomId(memberId);
			
			// jpa에서는 optional로 반환하는데, 새로운 객체를 생성하려면 그냥 member타입으로 해야 하고
			// return문을 두 번 써야 하나?
			// TODO 우선 주석처리. validation 문제 고민?
			// Optional<Member> member = memberRepository.findById(memberId);
			
			//if(!member.isPresent()) {
			Member member = new Member();
			member.setId(memberId);
			member.setRoomId(roomId);
			
			return memberRepository.save(member);
			
			//} else {
			//	return member;	
			//}
			
			
		} finally {
			this.lock.unlock();
		}
	}
	
	private void validateDuplicateMemberId(int memberId) {
		memberRepository.findById(memberId)
						.ifPresent(m -> {
							// id가 중복되면 IDGenerator에서 제대로 안 만들어준거 아닌가
							// 그러면 id를 올려서 저장? db에 있는 애 반환?
						});
	}
	
	public Member getMember(int id) {
		// 여기서 null 처리를 할까?
		return memberRepository.findById(id).get();
	}
	
	public void remove(int id) {
		memberRepository.deleteById(id);
	}
}