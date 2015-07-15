import java.util.ArrayList;
import java.util.Scanner;


public class P09_CombineListsOfLetters {

	public static void main(String[] args) {
		Scanner in = new Scanner(System.in);
		
		char[] l1Input = in.nextLine().replace(" ", "").toCharArray();
		char[] l2Input = in.nextLine().replace(" ", "").toCharArray();
		
		ArrayList<Character> l1 = new ArrayList<Character>();
		ArrayList<Character> l2 = new ArrayList<Character>();
		
		for (Character character : l1Input) {
			l1.add(character);
			l2.add(character);
		}
		
		for (Character character : l2Input) {
			if (!(l2.contains(character))) {
				l1.add(character);
			}
		}
		
		for (Character character : l1) {
			System.out.print(character + " ");
		}
	}
}
