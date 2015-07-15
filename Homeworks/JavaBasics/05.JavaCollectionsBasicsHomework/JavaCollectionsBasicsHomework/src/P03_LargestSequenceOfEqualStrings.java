import java.util.Currency;
import java.util.Scanner;


public class P03_LargestSequenceOfEqualStrings {

	public static void main(String[] args) {
		Scanner in = new Scanner(System.in);
		
		String input = in.nextLine();
		
		String[] seqOfString = input.split("\\s+");
		
		int counter = 0;
		String currResult = "";
		int max = Integer.MIN_VALUE;
		String result = "";
		for (int i = 0; i < seqOfString.length; i++) {
			for (int j = 0; j < seqOfString.length; j++) {
				if (seqOfString[i].equals(seqOfString[j])) {
					counter++;
					currResult += seqOfString[j] + " ";
				}
				if (counter > max) {
					result = currResult;
					max = counter;
				}
			}
			currResult = "";
			counter = 0;
		}
		System.out.println(result);
	}
}
