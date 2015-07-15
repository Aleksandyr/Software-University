import java.util.Scanner;
import java.util.TreeMap;


public class P04_LogsAggregator {

	public static void main(String[] args) {
		Scanner in = new Scanner(System.in);
		
		int n = in.nextInt();
		TreeMap<String, TreeMap<Integer, String>> logs = new TreeMap<>();
		for (int i = 0; i < n; i++) {
			//String[] input = in.nextLine().split("[0-9]*\\.[0-9]*\\.[0-9]*\\.[0-9]+\\s+[a-z]+[0-9]+");
			String[] ip = in.nextLine().split("[^0-9]+\\.[^0-9]+\\.[^0-9]+\\.[^0-9]+");
		}
	}

}
