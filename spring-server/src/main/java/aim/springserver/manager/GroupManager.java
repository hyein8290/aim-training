package aim.springserver.manager;

import java.util.concurrent.ConcurrentHashMap;
import java.util.concurrent.atomic.AtomicLong;

import aim.springserver.domain.Group;
import aim.springserver.domain.User;

public class GroupManager {

//	private static AtomicLong atomicLong;
	
	private static ConcurrentHashMap<Long, Group> groups;	// 그룹 해시맵
	private static long groupSequence = 0L;		// 방번호
	private static long userSequence = 0L; 		// 유저번호
	private final int GROUP_NUM = 2; 			// 방  개수
	
	/**
	 * 클라이언트의 그룹을 정해주는 메소드
	 * @param client 클라이언트
	 * @return		 정해진 그룹
	 */
	private Group joinGroup(User user) {
		Long userId = ++userSequence;
		Long groudId = userId % GROUP_NUM + 1;
		
		Group group = groups.get(groudId);
		group.getUserMap().put(userId, user);
		
		return group;
	}
	
	/**
	 * 그룹을 생성하는 메소드
	 * @param groupNums 그룹의 개수
	 */
	private void setGroups(int groupNums) {
		groups = new ConcurrentHashMap<Long, Group>();
		while(groupNums-- > 0) {
			groups.put(++groupSequence, new Group());
		}
	}
}
