import java.util.Scanner;


public class P02_Generate3LetterWords {

	public static void main(String[] args) {
		Scanner in = new Scanner(System.in);
		
		String word = in.nextLine();
		
		String result = "";
		char[] letters = word.toCharArray();
		for (int i = 0; i < letters.length; i++) {
			for (int j = 0; j < letters.length; j++) {
				for (int k = 0; k < letters.length; k++) {
					result = result + "" + letters[i] + "" + letters[j] + "" +letters[k] + " ";
				}
			}
		}
		System.out.println(result);
	}

}
