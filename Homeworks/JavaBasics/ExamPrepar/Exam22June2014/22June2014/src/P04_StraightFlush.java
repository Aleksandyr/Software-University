import java.util.ArrayList;
import java.util.Arrays;
import java.util.HashSet;
import java.util.Scanner;


public class P04_StraightFlush {

	public static void main(String[] args) {
		Scanner in = new Scanner(System.in);
		
		String[] inputCards = in.nextLine().split("\\W+");
		
		HashSet<String> cards = new HashSet<String>();
		cards.addAll(Arrays.asList(inputCards));
		
		boolean isHaveStraight = false;
		for (String card : inputCards) {
			String cardFace = card.substring(0, card.length() - 1);
			String cardSuit = card.substring(card.length() - 1);
			
			ArrayList<String> straightFlush = new ArrayList<String>();
			for (int i = 0; i < 5; i++) {
				straightFlush.add(cardFace + cardSuit);
				cardFace = getNextCard(cardFace);
			}
			if (cards.containsAll(straightFlush)) {
				System.out.println(straightFlush);
				isHaveStraight = true;
			}
		}
		if (!isHaveStraight) {
			System.out.println("No Straight Flushes");
		}
	}
	private static String getNextCard(String cardFace){
		String[] cardFaces = {"2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A"};
		for (int i = 1; i < cardFaces.length; i++) {
			if (cardFaces[i - 1].equals(cardFace)) {
				return cardFaces[i];
			}
		}
		return null;
	}
}
