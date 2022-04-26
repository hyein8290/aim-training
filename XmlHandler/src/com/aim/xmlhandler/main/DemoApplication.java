package com.aim.xmlhandler.main;

import org.jdom2.Element;

import com.aim.xmlhandler.parser.JdomParser;

public class DemoApplication {
	
	private static final String FILENAME = "./file/Array-DryEtch.xml";

	public static void main(String[] args) {
		
		JdomParser parser = new JdomParser(FILENAME);
		
		//xml을 객체화
		parser.load();
		
		//특정 element를 찾음
		Element rootNode = parser.getRootNode();
		Element element = parser.findElement(rootNode, "MultiBlock", "Name", "L4_MB_MachineModeChangeCommand"); 
		
		//element의 attribute의 값을 변경
		parser.update(element, "Action", "R");
		
		//element 추가
		Element newElement= parser.addElement(element, "Block", "Name", "TestAddElement", "Test");
		
		//element의 값을 변경(PCDATA)
		parser.update(newElement, "Update");
		
		//xml 출력
		parser.print();
		
		//xml 다른 이름으로 저장
		String newFileName = "./file/rename.xml";
		
		parser.renameFile(FILENAME, newFileName);
		
	}

}
