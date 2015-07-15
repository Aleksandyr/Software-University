import java.util.Scanner;

public class P02_SequencesOfEqualStrings {

	public static void main(String[] args) {
		Scanner in = new Scanner(System.in);
		
		String input = in.nextLine();
		String[] seqOfStr = input.split("\\s+");
		
		for (int i = 0; i < seqOfStr.length - 1; i++) {
			if (seqOfStr[i].equals(seqOfStr[i + 1])) {
				System.out.print(seqOfStr[i] + " ");
			} else{
				System.out.println(seqOfStr[i]);
			}
		}
		
		System.out.println(seqOfStr[seqOfStr.length - 1]);
	}
}
