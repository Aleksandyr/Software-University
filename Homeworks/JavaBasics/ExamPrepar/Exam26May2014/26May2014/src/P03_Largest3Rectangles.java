import java.util.Scanner;


public class P03_Largest3Rectangles {

	public static void main(String[] args) {
		Scanner in = new Scanner(System.in);
		
		String input = in.nextLine();
		String[] inputNums = input.split("[^0-9]+");
		int[] nums = new int[inputNums.length - 1];
		for (int i = 0; i < nums.length; i++) {
			nums[i] = Integer.parseInt(inputNums[i + 1]);
		}
		
		int maxSum = Integer.MIN_VALUE;
		int sum = 0;
		for (int i = 0; i < nums.length - 5; i +=2) {
			int fSumTwoNums = nums[i] * nums[i + 1];
			int sSumOfTwoNums = nums[i + 2] * nums[i + 3];
			int tSumOfTwoNums = nums[i + 4] * nums[i + 5];
			
			sum = fSumTwoNums + sSumOfTwoNums + tSumOfTwoNums;
			if (sum > maxSum) {
				maxSum = sum;
			}
		}
		System.out.println(maxSum);
	}

}
