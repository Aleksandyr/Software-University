import java.util.ArrayList;
import java.util.Random;
import java.util.Scanner;


public class P06_RandomHandsOf5Cards {

	public static void main(String[] args) {
		Scanner in = new Scanner(System.in);
		
		char[] suits = { '\u2663', '\u2666', '\u2660', '\u2764' };
		String[] deg = {"2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A", };
		
		ArrayList<String> temp = new ArrayList<String>();
		for (int i = 0; i < deg.length; i++) {
			for (int j = 0; j < suits.length; j++) {
				temp.add(deg[i] + suits[j]);
			}
		}
		
		String[] cards = temp.toArray(new String[temp.size()]);
		
		int n = in.nextInt();
		
		for (int i = 0; i < n; i++) {
			int index1 = RandomNumber();
			int index2 = RandomNumber();
			if (index1 == index2) {
				index2++;
			}
			int index3 = RandomNumber();
			if (index3 == index1 || index3 == index2) {
				index3++;
			}
			int index4 = RandomNumber();
			if (index4 == index1 || index4 == index2 || index4 == index3) {
				index4++;
			}
			int index5 = RandomNumber();
			if (index5 == index1 || index5 == index2 || index4 == index5 || index5 == index4) {
				index5++;
			}
			
			String hand = cards[index1] + 
						  cards[index2] + 
						  cards[index3] + 
						  cards[index4] + 
						  cards[index5]; 
			
			System.out.println(hand);
		}
	}
	public static int RandomNumber(){
		Random random = new Random();
			
		int randomNum = random.nextInt(47) + 0;
		return randomNum;
	}
}

