package aim.springserver.domain;

import lombok.Data;

@Data
public class Packet {

	private final int HEADER_LENGTH = 4;
	
	private byte[] header;
	private byte[] body;
}
