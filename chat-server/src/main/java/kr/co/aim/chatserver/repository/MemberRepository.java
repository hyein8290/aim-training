package kr.co.aim.chatserver.repository;

import org.springframework.data.jpa.repository.JpaRepository;

import kr.co.aim.chatserver.data.Member;

public interface MemberRepository extends JpaRepository<Member, Integer> {	
}
