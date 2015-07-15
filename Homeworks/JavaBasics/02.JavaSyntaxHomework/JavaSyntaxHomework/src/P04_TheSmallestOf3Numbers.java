import java.util.Scanner;


public class P04_TheSmallestOf3Numbers {

	public static void main(String[] args) {
		Scanner in = new Scanner(System.in);
		
		float a = in.nextFloat();
		float b = in.nextFloat();
		float c = in.nextFloat();
		
		if (a < b && a < c) {
			System.out.println(a);
		} else if (b < c && b < a){
			System.out.println(b);
		} else{
			System.out.println(c);
		}
	}

}
