import java.util.Scanner;


public class P05_CountAllWords {

	public static void main(String[] args) {
		Scanner in = new Scanner(System.in);
		
		String input = in.nextLine();
		
		String[] seqOfWords = input.split("[^a-zA-z]+");
		System.out.println(seqOfWords.length);
	}

}
