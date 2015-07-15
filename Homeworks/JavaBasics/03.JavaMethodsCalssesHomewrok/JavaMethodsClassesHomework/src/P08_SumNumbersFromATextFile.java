import java.io.File;
import java.io.FileNotFoundException;
import java.util.Scanner;


public class P08_SumNumbersFromATextFile {

	public static void main(String[] args){	
		try {
			Scanner textFIle = new Scanner(new File("Input.txt"));
			int sum = 0;
			while (textFIle.hasNextInt()) {
				sum += textFIle.nextInt();
			}
				
			System.out.println(sum);
		} catch (FileNotFoundException e) {
			System.err.println("Error");
		}
	}
}
