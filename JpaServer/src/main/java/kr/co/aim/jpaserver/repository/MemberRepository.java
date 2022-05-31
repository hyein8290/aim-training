package kr.co.aim.jpaserver.repository;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Component;

import kr.co.aim.jpaserver.data.Member;

@Component
public interface MemberRepository extends JpaRepository<Member, Integer> {	
}
