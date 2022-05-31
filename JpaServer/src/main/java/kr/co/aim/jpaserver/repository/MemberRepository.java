package kr.co.aim.jpaserver.repository;

import org.springframework.data.jpa.repository.JpaRepository;

import kr.co.aim.jpaserver.data.Member;

public interface MemberRepository extends JpaRepository<Member, Integer> {	
}
