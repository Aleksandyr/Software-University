import java.util.Scanner;

import javax.swing.plaf.basic.BasicInternalFrameTitlePane.MaximizeAction;


public class P04_LongestIncreasingSequence {

	public static void main(String[] args) {
		Scanner in = new Scanner(System.in);
		
		String input = in.nextLine();
		
		String[] currSeqOfNums = (input.split("\\s+"));
		int[] seqOfNums = new int[currSeqOfNums.length];
		
		for (int i = 0; i < seqOfNums.length; i++) {
			seqOfNums[i] = Integer.parseInt(currSeqOfNums[i]);
		}
		
		int counter = 1;
		int max = Integer.MIN_VALUE;
		int indexNum = 0;
		System.out.print(seqOfNums[0]+ " ");
		for (int i = 1; i < seqOfNums.length; i++) {
			if (seqOfNums[i] > seqOfNums[i - 1]) {
				System.out.print(seqOfNums[i] + " ");
				counter++;
			} else{
				System.out.println();
				System.out.print(seqOfNums[i] + " ");
				counter = 1;
			}
			if (counter > max) {
				max = counter;
				indexNum = i;
			}
		}
		
		System.out.println();
		System.out.print("Longest: ");
		int startIndex = indexNum - (max - 1);
		if (counter > 1) {
			for (int i = 0; i < max; i++) {
				System.out.print(seqOfNums[startIndex] + " ");
				startIndex++;
			}
		} else{
			System.out.println(seqOfNums[0]);
		}
	}

}
