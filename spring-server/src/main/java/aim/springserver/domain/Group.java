package aim.springserver.domain;

import java.util.concurrent.ConcurrentHashMap;

import lombok.Data;

@Data
public class Group {

	private Long id;
	private ConcurrentHashMap<Long, User> map;
}