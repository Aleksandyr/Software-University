import java.math.BigDecimal;
import java.util.Scanner;


public class P03_SimpleExpression {

	public static void main(String[] args) {
		Scanner in = new Scanner(System.in);
		
		String input = in.nextLine();
		input = input.replace(" ", "");
		String[] symbols = input.split("[^+-]+");
		String[] numbers = input.split("[^0-90.-9.]+");
		
		BigDecimal sum = new BigDecimal(0);
		for (int i = 0; i < symbols.length; i++) {
			BigDecimal number = new BigDecimal(numbers[i]);
			if (symbols[i].equals("+") || symbols[i].equals("")) {
				sum = sum.add(number);
			} 
			if (symbols[i].equals("-")){
				sum = sum.subtract(number);
			}
		}
		System.out.println(sum);
	}
}
