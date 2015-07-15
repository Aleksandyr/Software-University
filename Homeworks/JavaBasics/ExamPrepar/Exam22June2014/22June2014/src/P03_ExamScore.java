import java.util.Scanner;
import java.util.TreeMap;


public class P03_ExamScore {

	public static void main(String[] args) {
		Scanner in = new Scanner(System.in);
		
		in.nextLine();
		in.nextLine();
		in.nextLine();
		
		TreeMap<Integer, TreeMap<String, Double>> points = new TreeMap<>();
		while (true) {
			String[] input = in.nextLine().split("\\s*\\|\\s*");
			if (input.length < 4) {
				break;
			}
			String student = input[1];
			int score = Integer.parseInt(input[2]);
			double grade = Double.parseDouble(input[3]);
			if (!points.containsKey(score)) {
				points.put(score, new TreeMap<>());
			}
			points.get(score).put(student, grade);
		}
		for (Integer score : points.keySet()) {
			System.out.print(score + " -> " + points.get(score).keySet() + ";");
			double sum = 0;
			for (Double grade: points.get(score).values()) {
				sum += grade;
			}
			double avg = sum / points.get(score).values().size();
			System.out.printf(" avg=%.2f", avg);
			System.out.println();
		}
	}
}
