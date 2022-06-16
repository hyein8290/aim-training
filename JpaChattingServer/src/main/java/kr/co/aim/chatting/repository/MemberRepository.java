package kr.co.aim.chatting.repository;

import org.springframework.data.jpa.repository.JpaRepository;

import kr.co.aim.chatting.entity.Member;

public interface MemberRepository extends JpaRepository<Member, Integer> {	
}
