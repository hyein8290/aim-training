package kr.co.aim.mavenserver;

public class Test {

	public static void main(String[] args) {
		User user = new User();
		user.setName("hi");
		user.setId("1");
		UserDAO dao = new UserDAO();
		System.out.println(dao.add(user));
		
	}
}
