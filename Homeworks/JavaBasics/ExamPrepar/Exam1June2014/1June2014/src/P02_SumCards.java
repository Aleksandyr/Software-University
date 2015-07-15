import java.util.Scanner;


public class P02_SumCards {

	public static void main(String[] args) {
		Scanner scanner = new Scanner(System.in);
		
		String input = scanner.nextLine().trim();
		String[] faces = input.split("[^0-9JQKA]+");
		
		int value = 0;
		int sum = 0;
		int prevValue = -1;
		int counter = 0;
		for (String face : faces) {
			if (face.equals("J")) {
				value = 12;
			} else if(face.equals("Q")) {
				value = 13;
			} else if(face.equals("K")) {
				value = 14;
			} else if(face.equals("A")) {
				value = 15;
			} else{
				value = Integer.parseInt(face);
			}
			
			if (value == prevValue) {
				counter++;
			}else{
				counter = 1;
			}
			sum += value;
			if (counter == 2) {
				sum += 2 * value;
			}
			if (counter > 2) {
				sum += value;
			}
			
			prevValue = value;
		}
		System.out.println(sum);
	}

}
