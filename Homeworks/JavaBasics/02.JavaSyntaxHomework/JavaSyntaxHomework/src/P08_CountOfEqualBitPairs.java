import java.util.Scanner;


public class P08_CountOfEqualBitPairs {
	public static void main(String[] args) {
		Scanner in = new Scanner(System.in);
		
		int number = in.nextInt();
		
		int counter = 0;
		while(number > 0){
			int bit = number & 1;
			if (bit == 1 && ((number >> 1) & 1) == 1 || 
					bit == 0 && ((number >> 1) & 1) == 0) {
				counter++;
			}
			number >>= 1;
		}
		
		System.out.println(counter);
	}
}
