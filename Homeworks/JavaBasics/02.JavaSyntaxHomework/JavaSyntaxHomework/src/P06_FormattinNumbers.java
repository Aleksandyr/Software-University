import java.util.Scanner;


public class P06_FormattinNumbers {
	public static void main(String[] args) {
		Scanner in = new Scanner(System.in);
		
		int a = in.nextInt();
		float b = in.nextFloat();
		float c = in.nextFloat();
		
		String aInBinary = Integer.toBinaryString(a);
		
		System.out.printf("|%-10X|%010d|%10.2f|%-10.3f|", a, Integer.parseInt(aInBinary), b, c);
	}
}
