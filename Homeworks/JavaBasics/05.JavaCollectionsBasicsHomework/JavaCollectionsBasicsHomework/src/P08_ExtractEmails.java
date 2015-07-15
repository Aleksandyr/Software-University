import java.util.Scanner;
import java.util.regex.Matcher;
import java.util.regex.Pattern;


public class P08_ExtractEmails {

	public static void main(String[] args) {
		Scanner in = new Scanner(System.in);
		
		String text = in.nextLine();
		
		String regex = "[a-zA-Z0-9]+[._-]*[a-zA-Z0-9]+\\@[a-zA-z]+[.-]*[a-zA-z]+\\.[a-z]+";
		Pattern pattern = Pattern.compile(regex);
		Matcher matcher = pattern.matcher(text);
		
		while (matcher.find()) {
			System.out.print(matcher.group());
			System.out.println();
		}
	}

}
