package kr.co.aim.jpaserver.manager;

import java.util.Optional;
import java.util.concurrent.locks.ReentrantLock;

import org.springframework.beans.factory.annotation.Autowired;

import kr.co.aim.jpaserver.data.Member;
import kr.co.aim.jpaserver.repository.MemberRepository;
//import kr.co.aim.jpaserver.utils.IDGenerator;

// @Transactional
public class TestManager {
	
//	// JPA에서 제공하는 동기화 기법 없을까?
//	// -> JPA는 데이터 동기화 문제를 데이터베이스에 맡깁니다.
//	private final ReentrantLock lock = new ReentrantLock();
//	private final MemberRepository memberRepository;
//	
//    @Autowired
//    public TestManager(MemberRepository memberRepository) {
//        this.memberRepository = memberRepository;
//    }
//	
//	@Autowired 
//	private RoomManager roomManager;
//	
//	public Member create() {
//		this.lock.lock();
//		try {
//			int memberId = IDGenerator.getId();
//			int roomId = roomManager.getRoomId(memberId);
//			
//			Member member = memberRepository.findById(memberId).orElse(null);
//			
//			if(member == null) {
//				member = new Member();
//				member.setId(memberId);
//				member.setRoomId(roomId);
//			}
//			
//			// pk 중복되겠는디?
//			return memberRepository.save(member);
//			
//		} finally {
//			this.lock.unlock();
//		}
//	}
//	
//	private void validateDuplicateMemberId(int memberId) {
//		memberRepository.findById(memberId)
//						.ifPresent(m -> {
//							// id가 중복되면 IDGenerator에서 제대로 안 만들어준거 아닌가
//							// 그러면 id를 올려서 저장? db에 있는 애 반환?
//						});
//	}
//	
//	public Member getMember(int id) {
//		// 여기서 null 처리를 할까?
//		return memberRepository.findById(id).get();
//	}
//	
//	public void remove(int id) {
//		memberRepository.deleteById(id);
//	}
}