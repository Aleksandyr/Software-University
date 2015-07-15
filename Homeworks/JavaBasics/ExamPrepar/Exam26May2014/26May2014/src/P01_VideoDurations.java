import java.util.Scanner;


public class P01_VideoDurations {

	public static void main(String[] args) {
		Scanner in = new Scanner(System.in);
		
		//int sumHours = 0;
		//int sumMin = 0;
		int totalMinutes = 0;
		while (true) {
			String input = in.nextLine();
			if (input.equals("End")) {
				break;
			}
			String[] videoDur = input.split("[^0-9]+");
			int hour = Integer.parseInt(videoDur[0]);
			int minutes = Integer.parseInt(videoDur[1]);
			totalMinutes += (hour * 60) + minutes;
			
//			sumHours += hour;
//			sumMin += minutes;
//			if (sumMin >= 60) {
//				sumHours++;
//				sumMin -= 60;
//			}
		}
//		if (sumHours < 10) {
//			System.out.println(sumHours + ":0" + sumMin);
//		} else{
//			System.out.println(sumHours + ":" + sumMin);
//		}
		
		System.out.printf("%d:%02d", totalMinutes / 60, totalMinutes % 60);
	}

}
