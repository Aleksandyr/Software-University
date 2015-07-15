import java.util.Scanner;


public class P06_CountSpecifiedWord {

	public static void main(String[] args) {
		Scanner in = new Scanner(System.in);
		
		String input = in.nextLine().toLowerCase();
		String word = in.nextLine().toLowerCase();
		
		String[] allWords = input.split("[^a-zA-Z]+");
		
		int counter = 0;
		for (int i = 0; i < allWords.length; i++) {
			if (allWords[i].equals(word)) {
				counter++;
			}
		}
		System.out.println(counter);
	}

}
