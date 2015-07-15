import java.util.HashMap;
import java.util.Iterator;
import java.util.Map.Entry;
import java.util.Scanner;
import java.util.*;

public class P12_CardsFrequencies {

	public static void main(String[] args) {	
		Scanner in = new Scanner(System.in);
		
		String input = in.nextLine();
		String[] cards = input.split("\\W+");
		
		LinkedHashMap<String, Integer> cardCount = new LinkedHashMap<String, Integer>();
		for (String card : cards) {
			Integer counter = cardCount.get(card);
			if (counter == null) {
				counter = 0;
			}
			cardCount.put(card, counter + 1);
		}
		
		for (Map.Entry<String, Integer> card : cardCount.entrySet()) {
			float percentage = ((float)card.getValue() / (float)cards.length) * 100;
			System.out.printf("%s -> %.2f", card.getKey(), percentage);
			System.out.print("%\n");
		}
	}

}
