import java.util.Scanner;


public class P03_LongestOddEvenSequence {

	public static void main(String[] args) {
		Scanner in = new Scanner(System.in);
		
		String[] numbers = in .nextLine().split("[^0-9]+");
		int[] nums = new int[numbers.length - 1];
		for (int i = 0; i < nums.length; i++) {
			nums[i] = Integer.parseInt(numbers[i + 1]);
		}
	
		int bestLen = 0;
		int len = 0;
		boolean shouldBeOdd = nums[0] % 2 != 0;
		for (int num : nums) {
			boolean isOdd = num % 2 != 0;
			if (isOdd == shouldBeOdd || num == 0) {
				len++;
			} else{
				shouldBeOdd = isOdd;
				len = 1;
			}
			shouldBeOdd = !shouldBeOdd;
			if (len > bestLen) {
				bestLen = len;
			}
		}
		System.out.println(bestLen);
	}
}