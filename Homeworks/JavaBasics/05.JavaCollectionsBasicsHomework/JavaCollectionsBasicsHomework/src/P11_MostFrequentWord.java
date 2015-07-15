import java.util.Scanner;
import java.util.TreeMap;


public class P11_MostFrequentWord {

	public static void main(String[] args) {
		Scanner in = new Scanner(System.in);
		
		String input = in.nextLine().toLowerCase();
		String[] text = input.split("[^a-zA-Z]+");
		
		TreeMap<String, Integer> result = new TreeMap<String, Integer>();
		
		int max = Integer.MIN_VALUE;
		for (String word : text) {
			Integer counter = result.get(word);
			if (counter == null) {
				counter = 0;
			}
			result.put(word, counter + 1);
			if (result.get(word) > max) {
				max = result.get(word);
			}
		}

		for (String key : result.keySet()) {
			if (result.get(key) == max) {
				System.out.println(key + " -> " + result.get(key));
			}
		}
	}
}
