import java.util.Scanner;


public class P05_DecimalToHexadecimal {
	public static void main(String[] args) {
		Scanner in = new Scanner(System.in);
		
		int decimalNum = in.nextInt();
		String hexNum = Integer.toHexString(decimalNum).toUpperCase();
		
		System.out.println(hexNum);
	}
}
