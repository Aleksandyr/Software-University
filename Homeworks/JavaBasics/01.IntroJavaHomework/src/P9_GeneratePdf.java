import com.itextpdf.text.BaseColor;
import com.itextpdf.text.Document;
import com.itextpdf.text.DocumentException;
import com.itextpdf.text.Element;
import com.itextpdf.text.Font;
import com.itextpdf.text.FontFactory;
import com.itextpdf.text.Paragraph;
import com.itextpdf.text.pdf.BaseFont;
import com.itextpdf.text.pdf.PdfPTable;
import com.itextpdf.text.pdf.PdfWriter;

import java.io.*;

public class P9_GeneratePdf {

	public static void main(String[] args) throws FileNotFoundException, DocumentException {
		
		Document document = new Document();	
		PdfPTable table = new PdfPTable(14);
		
		table.setWidthPercentage(100);
		table.getDefaultCell().setFixedHeight(50);
		
		char[] suits = { '\u2663', '\u2666', '\u2660', '\u2764' };
		String[] cards = {"2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A", };
		
		for (int i = 0; i < cards.length; i++) {
			for (int j = 0; j < suits.length; j++) {
				table.addCell(cards[i] + "" + suits[j]);
			}
			System.out.println();
		}
		
		PdfWriter.getInstance(document, new FileOutputStream(
				"Dec-Of-Cards.pdf"));
		
		document.open();
		document.add(table);
		document.close();
	}

}
