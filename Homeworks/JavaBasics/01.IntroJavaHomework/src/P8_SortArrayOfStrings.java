import java.util.Arrays;
import java.util.Scanner;


public class P8_SortArrayOfStrings {

	public static void main(String[] args) {
		Scanner in = new Scanner(System.in);
		
		int n = in.nextInt();
		in.nextLine();
		String[] listOfStrings = new String[n];
		for (int i = 0; i < n; i++) {
			listOfStrings[i] = in.nextLine();
		}
		
		Arrays.sort(listOfStrings);
		System.out.println("Sorted array:");
		for (String item : listOfStrings) {
			System.out.println(item);
		}
	}

}
