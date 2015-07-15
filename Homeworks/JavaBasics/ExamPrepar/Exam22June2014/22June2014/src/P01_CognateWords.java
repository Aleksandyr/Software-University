import java.util.HashSet;
import java.util.Scanner;

import org.omg.PortableServer.POAPackage.WrongAdapter;


public class P01_CognateWords {

	public static void main(String[] args) {
		Scanner in = new Scanner(System.in);

		String input = in.nextLine();
		String[] words = input.split("[^a-zA-Z]+");
		
		HashSet<String> result = new HashSet<String>();
		boolean haveEqualWords = false;
		for (int i = 0; i < words.length; i++) {
			for (int j = 0; j < words.length - 1; j++) {
				for (int j2 = 0; j2 < words.length; j2++) {
					if (i != j) {
						boolean check = (words[i] + words[j]).equals(words[j2]);
						if (check) {
							result.add(words[i] + "|" + words[j] + "=" + words[j2]);
							haveEqualWords = true;
						}
					}
				}
			}
		}
		if (result.size() == 0) {
			System.out.println("No");
		} else{
			for (String res : result) {
				System.out.println(res);
			}
		}
	}

}
