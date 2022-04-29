package co.kr.aim.xmlhandler.parser;

import java.io.File;
import java.io.FileOutputStream;
import java.io.IOException;

import org.jdom2.Attribute;
import org.jdom2.Document;
import org.jdom2.Element;
import org.jdom2.JDOMException;
import org.jdom2.filter.ElementFilter;
import org.jdom2.input.SAXBuilder;
import org.jdom2.output.Format;
import org.jdom2.output.XMLOutputter;

public class JdomParser {
	
	private File file;
	private Document document;
	private XMLOutputter xmlOutputter;
	
	/**
	 * JdomParser 생성자
	 * @param filename		xml파일의 위치
	 */
	public JdomParser(String filename) {
		this.file = new File(filename);
		this.xmlOutputter = new XMLOutputter(Format.getPrettyFormat());
		load();
	}
	
	/**
	 * xml 파일을 로드하는 메소드
	 * @param file 파일 이름
	 */
	public void load() {
		try {
			SAXBuilder saxBuilder = new SAXBuilder();
			this.document = saxBuilder.build(file);
		} catch (IOException | JDOMException e) {
			e.printStackTrace();
		}
	}
	
	/**
	 * xml 파일을 출력
	 */
	public void print() {
		try {
			xmlOutputter.output(document, System.out);			
		} catch (IOException e) {
			e.printStackTrace();
		}
	}
	
	/**
	 * 특정 element의 값(PCDATA)을 변경
	 */
	public void update(Element element, String content) {
		element.setText(content);
	}
	
	/**
	 * 특정 element의 속성값을 수정
	 */
	public void update(Element element, String attrname, String value) {
		element.setAttribute(attrname, value);
	}
	
	/**
	 * 태그 이름, 속성 이름, 속성값을 가진 element 추가
	 * @param parentNode	추가할 element의 부모 element
	 * @param tag 			추가할 element의 태그 이름 
	 * @param attrname		추가할 element의 속성 이름
	 * @param value			추가할 element의 속성값
	 * @return				추가한 element Element 형태로 반환
	 */
	public Element addElement(Element parentNode, String tag, String attrname, String value) {
		Element element = new Element(tag).setAttribute(new Attribute(attrname, value));
		parentNode.addContent(element);
		return element;
	}
	
	/**
	 * 태그 이름, 속성 이름, 속성값, PCDATA를 가진 element 추가
	 * @param parentNode	추가할 element의 부모 element
	 * @param tag			추가할 element의 태그 이름 
	 * @param attrname		추가할 element의 속성 이름
	 * @param value			추가할 element의 속성값
	 * @param content		추가할 element의 PCDATA 값
	 * @return				추가한 element Element 형태로 반환 
	 */
	public Element addElement(Element parentNode, String tag, String attrname, String value, String content) {
		Attribute attr = new Attribute(attrname, value);
		Element element = new Element(tag).setAttribute(attr).setText(content);
		parentNode.addContent(element);
		return element;
	}
	
	/**
	 * 특정 element를 찾아서 반환
	 * @param parentNode	부모 element -> 조상으로 바꿀까..?
	 * @param tag			찾을 element의 태그 이름
	 * @param attrname		찾을 element의 속성 이름
	 * @param value			찾을 element의 속성값
	 * @return				찾은 element, 못 찾으면 null 반환
	 */
	public Element findElement(Element parentNode, String tag, String attrname, String value) {
		
		ElementFilter filter = new ElementFilter(tag);
		
		for(Element element : parentNode.getDescendants(filter)) {
			if(element.getAttributeValue(attrname).equals(value)) {
				return element;
			}	
		}
		return null;
	}
	
	/**
	 * 루트 노드를 찾는 메소드
	 * @return 루트노드
	 */
	public Element getRootNode() {
		return document.getRootElement();
	}
	
	/**
	 * 파일을 다른 이름으로 저장하는 메소드
	 * @param newPath	새로운 파일 경로
	 */
	public void saveAsNewName(String newPath) {
								
		try {
			xmlOutputter.output(document, new FileOutputStream(new File(newPath)));
		} catch (IOException e) {
			e.printStackTrace();
		}
	}

	/**
	 * 파일 이름을 변경하는 메소드
	 * @param path		파일의 원래 경로
	 * @param newPath	새로운 파일 경로
	 */
	public void renameFile(String path, String newPath) {

		File file = new File(path);
		File newFile = new File(newPath);

		file.renameTo(newFile);
	}
}

