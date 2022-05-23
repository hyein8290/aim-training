package aim.springserver.domain;

import java.io.IOException;
import java.io.InputStream;
import java.nio.ByteBuffer;

import lombok.Getter;
import lombok.Setter;

@Getter @Setter
public class Packet {
	private final int HEADER_BYTE_COUNTS = 4;
	
	private byte[] header;
	private byte[] body;
	
	public Packet() {
		this.header = new byte[HEADER_BYTE_COUNTS];
	}
	

}
