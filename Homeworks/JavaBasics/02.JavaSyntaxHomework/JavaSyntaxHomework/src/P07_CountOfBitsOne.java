import java.util.Scanner;


public class P07_CountOfBitsOne {

	public static void main(String[] args) {
		Scanner in = new Scanner(System.in);
		
		int number = in.nextInt();
		
		int count = 0;
		while(number > 0){
			int bit = number & 1;
			if (bit == 1) {
				count++;
			}
			number >>= 1;
		}
		
		System.out.println(count);
	}

}
