import java.util.Scanner;


public class P01_SymmetricNumbersInRange {

	public static void main(String[] args) {
		Scanner in = new Scanner(System.in);
		
		int start = in.nextInt();
		int end = in.nextInt();
		
		if (start < end) {
			
			for (int i = start; i <= end; i++) {
				char[] digits = Integer.toString(i).toCharArray();
				
				if (digits.length == 1) {
					System.out.print(i + " ");
				}
				if (digits.length == 2 && digits[0] == digits[1]) {
					System.out.print(i + " ");
				}
				if (digits.length == 3 && digits[0] == digits[2]) {
					System.out.print(i + " ");
				}
			}
			
		} else {

		}
	}

}
