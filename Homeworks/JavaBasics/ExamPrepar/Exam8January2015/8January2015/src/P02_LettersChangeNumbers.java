import java.util.Scanner;


public class P02_LettersChangeNumbers {

	public static void main(String[] args) {
		Scanner in = new Scanner(System.in);
		
		String input = in.nextLine();
		String[] arrOfLettersAndNums = input.split("\\s+");
		
		String fSymbol = "";
		String sSymbol = "";
		double totalSum = 0;
		double nextDigit = 0;
		for (int i = 0; i < arrOfLettersAndNums.length; i++) {
			String[] currLetters = arrOfLettersAndNums[i].split("[^a-zA-z]+");
			String[] currNum = arrOfLettersAndNums[i].split("[^0-9]+");
			String fLetter = currLetters[0];
			String sLetter = currLetters[1];
			double num = Double.parseDouble(currNum[1]);
			int digitOfFirsLetter = getLetterDigit(fLetter);
			int digitOfSecondLetter = getLetterDigit(sLetter);
			
			
			if (i % 2 == 0 || i == 0) {
				fSymbol = firstLetterSymbol(fLetter);
				sSymbol = secondLetterSymbol(sLetter);
			} else{
				fSymbol = firstLetterSymbol(fLetter);
			    sSymbol = secondLetterSymbol(sLetter);
			}
			
			nextDigit = getTotalSum(fSymbol, num, digitOfFirsLetter);
			num = nextDigit;
			totalSum += getTotalSum(sSymbol, num, digitOfSecondLetter);
		}
		System.out.printf("%.2f", totalSum);
	}
	private static String firstLetterSymbol(String letter){
		if (letter.equals(letter.toUpperCase())) {
			return "/";
		} else {
			return  "*";
		}
	}
	private static String secondLetterSymbol(String letter){
		if (letter.equals(letter.toUpperCase())) {
			return "-";
		} else{
			return "+";
		}
	}
	private static int getLetterDigit(String letter){
		char letterToLowerCase = (letter.toLowerCase()).charAt(0);
		return (int)letterToLowerCase - 96;
	}
	private static double getTotalSum(String symbol, double num, int digitOfLetter){
		if (symbol.equals("/")) {
			return num / digitOfLetter;
		} else if(symbol.equals("+")){
			return num + digitOfLetter;
		} else if(symbol.equals("-")){
			return num - digitOfLetter;
		} else{
			return num * digitOfLetter;
		}
	}
}
