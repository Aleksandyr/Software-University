import java.util.ArrayList;
import java.util.Scanner;


public class P01_CountBeers {

	public static void main(String[] args) {
		Scanner in = new Scanner(System.in);
		
		int totalBeers = 0;
		while (true) {
			String input = in.nextLine();
			if (input.equals("End")) {
				break;
			}
			String[] order = input.split("\\s+");
			int beers = Integer.parseInt(order[0]);
			if (order[1].equals("stacks")) {
				beers *= 20;
			}
			totalBeers += beers;
		}
		
		System.out.printf("%d stacks + %d beers\n", totalBeers / 20, totalBeers % 20);
		
//		ArrayList<String> beers = new ArrayList<String>();
//		while (true) {
//			String input = in.nextLine();
//			if (input.equals("End")) {
//				break;
//			} else{
//				beers.add(input);
//			}
//		}
//		
//		int sum = 0;
//		int stacksCount = 0;
//		for (String beer : beers) {
//			String value = beer.substring(0, beer.length() - 6).replace(" ", "");
//			String beersOrStacks = beer.substring(2).replace(" ", "");
//			if (beersOrStacks.equals("stacks")) {
//				stacksCount += Integer.parseInt(value);
//			} else{
//				sum += Integer.parseInt(value);
//				if (sum >= 20) {
//					stacksCount++;
//					sum -= 20;
//					if (sum >= 20) {
//						for (int i = 0; i < sum / 20; i++) {
//							stacksCount++;
//							sum -= 20;
//						}
//					}
//				}
//			}
//		}
//		System.out.println(stacksCount + " stacks + " + sum + " beers");
//	}
	}
}
