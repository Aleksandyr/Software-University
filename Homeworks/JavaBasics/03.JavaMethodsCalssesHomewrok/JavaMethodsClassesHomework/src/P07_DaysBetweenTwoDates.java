import java.text.DateFormat;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.Date;
import java.util.Scanner;


public class P07_DaysBetweenTwoDates {

	public static void main(String[] args) throws ParseException {
		Scanner in = new Scanner(System.in);
		
		String firsInput = in.nextLine();
		String secondInput = in.nextLine();
		
		DateFormat date = new SimpleDateFormat("dd/MM/yyyy");
		
		Date startDate = null;
		Date endDate = null;
		
		startDate = date.parse(firsInput);
		endDate = date.parse(secondInput);
		
		int daysDifference = (int)((endDate.getTime() - startDate.getTime()) / 
				(1000 * 60 * 60 * 24));
		
		
		System.out.println(daysDifference);
	}

}
