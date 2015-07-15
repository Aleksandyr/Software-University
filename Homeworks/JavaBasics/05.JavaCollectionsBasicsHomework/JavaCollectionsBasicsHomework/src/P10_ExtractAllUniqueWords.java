import java.util.Arrays;
import java.util.Scanner;
import java.util.TreeSet;


public class P10_ExtractAllUniqueWords {

	public static void main(String[] args) {
		Scanner in = new Scanner(System.in);
		
		String input = in.nextLine().toLowerCase();
		String[] text = input.split("[^a-zA-Z]+");
	
		TreeSet<String> result = new TreeSet<String>();
		for (String string : text) {
			result.add(string);
		}
		
		for (String string : result) {
			System.out.print(string + " ");
		}
	}

}
