import java.util.Scanner;


public class P07_CountSubstringOccurrences {

	public static void main(String[] args) {
		Scanner in = new Scanner(System.in);
		
		String text = in.nextLine().toUpperCase();
		String findStr = in.nextLine().toUpperCase();
		
		int lastIndex = 0;
		int counter = 0;
		
		 while(lastIndex != -1){

	           lastIndex = text.indexOf(findStr,lastIndex);

	           if( lastIndex != -1){
	        	   counter ++;
		           lastIndex ++;
	           }
	    }
	    System.out.println(counter);
	}

}
