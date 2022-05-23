package aim.springserver.manager;

import java.io.IOException;
import java.io.InputStream;
import java.io.OutputStream;
import java.nio.ByteBuffer;

import aim.springserver.domain.Packet;
import aim.springserver.domain.Room;
import aim.springserver.domain.User;

public class MessageManager implements Runnable{
	
	private User user;
	private InputStream in;
	private OutputStream out;
	private Room room;
	
	public MessageManager(User user, Room room) {
		this.user = user;
		this.room = room;
	}

	@Override
	public void run() {
		try {
			System.out.println("[클라이언트 접속]");
			in = user.getSocket().getInputStream();
			
			while(true) {
				Packet packet = receive();
				packet.toString();
			}
			
		} catch (Exception e) {
			// TODO: handle exception
		}
	}
	
//	public Packet receive() {
//		Packet packet = new Packet();
//
//		try {
//			in.read(packet.getHeader());			
//			int bodyByteCounts = ByteBuffer.wrap(packet.getHeader()).getInt();
//			packet.setBody(new byte[bodyByteCounts]);
//			in.read(packet.getBody());
//			
//		} catch (IOException e) {
//			e.printStackTrace();
//		}
//		
//		return packet;
//	}
	
	public Packet receive() {
		Packet packet = new Packet();

		try {
			in.read(packet.getHeader());			
			int bodyByteCounts = ByteBuffer.wrap(packet.getHeader()).getInt();
			packet.setBody(new byte[bodyByteCounts]);
			in.read(packet.getBody());
			
		} catch (IOException e) {
			e.printStackTrace();
		}
		
		return packet;
	}
	
}
