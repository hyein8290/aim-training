package aim.springserver.domain;

import lombok.Getter;
import lombok.Setter;

@Getter @Setter
public class Packet {
	private final int HEADER_LENGTH = 4;
	
	private byte[] header;
	private byte[] body;
}
