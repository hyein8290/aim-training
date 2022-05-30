package kr.co.aim.chatserver.utils;

import java.util.concurrent.atomic.AtomicInteger;

public class IDGenerator {

	private static AtomicInteger atomicInteger;

	static {
		atomicInteger = new AtomicInteger();
	}

	public static int getId() {
		return atomicInteger.incrementAndGet();
	}

	public static void reset() {
		atomicInteger.set(0);
	}
}
