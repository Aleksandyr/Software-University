
public class P03_FullHouse {

	public static void main(String[] args) {
		char[] suits = { '\u2663', '\u2666', '\u2660', '\u2764' };
		String[] cards = {"2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A", };
		
		int fullHouses = 0;
		for (int three = 0; three < cards.length; three++) {
			for (int two = 0; two < cards.length; two++) {
				if (three != two) {
					for (int firstSuit = 0; firstSuit < suits.length; firstSuit++) {
						for (int secondSuit = firstSuit + 1; secondSuit < suits.length; secondSuit++) {
							for (int thirdSuit = secondSuit + 1; thirdSuit < suits.length; thirdSuit++) {
								for (int fourthSuit = 0; fourthSuit < suits.length; fourthSuit++) {
									for (int fifthSuit = fourthSuit + 1; fifthSuit < suits.length; fifthSuit++) {
										System.out.println(cards[three] + suits[firstSuit] +
														   cards[three] + suits[secondSuit] +
														   cards[three] + suits[thirdSuit] +
														   cards[two] + suits[fourthSuit] +
														   cards[two] + suits[fifthSuit]);
										
										fullHouses++;
									}
								}
							}
						}
					}
				}
			}
		}
		System.out.println(fullHouses + " full houses");
	}

}
