import java.util.Scanner;


public class P01_GandalfsStash {

	public static void main(String[] args) {
		Scanner in = new Scanner(System.in);

		int currMoods = in.nextInt();
		in.nextLine();
		String gandalfsFood = in.nextLine();
		String[] gandalfsListOfFood = gandalfsFood.split("[^a-zA-Z0-9]+");
		
		int gandalfMoods = currMoods;
		for (int i = 0; i < gandalfsListOfFood.length; i++) {
			gandalfMoods += pointsOfHappiness(gandalfsListOfFood[i].toLowerCase());
		}
		if (gandalfMoods < -5) {
			System.out.println(gandalfMoods + "\nAngry");
		} else if (gandalfMoods >= -5 && gandalfMoods < 0) {
			System.out.println(gandalfMoods + "\nSad");
		} else if(gandalfMoods >= 0 && gandalfMoods <= 15){
			System.out.println(gandalfMoods + "\nHappy");
		} else{
			System.out.println(gandalfMoods + "\nSpecial JavaScript mood");
		}
	}
	private static int pointsOfHappiness(String food){
		if (food.equals("cram")) {
			return 2;
		} else if(food.equals("lembas")){
			return 3;
		} else if(food.equals("apple")){
			return 1;
		} else if(food.equals("melon")){
			return 1;
		} else if(food.equals("honeycake")){
			return 5;
		} else if(food.equals("mushrooms")){
			return -10;
		} else{
			return -1;
		}
	}
}
