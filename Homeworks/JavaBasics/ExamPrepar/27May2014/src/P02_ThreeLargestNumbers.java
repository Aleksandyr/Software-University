import java.math.BigDecimal;
import java.util.Arrays;
import java.util.Scanner;


public class P02_ThreeLargestNumbers {

	public static void main(String[] args) {
		Scanner in = new Scanner(System.in);
		
		int n = in.nextInt();
		in.nextLine();
		BigDecimal[] nums = new BigDecimal[n];
		for (int i = 0; i < nums.length; i++) {
			String num = in.nextLine();
			nums[i] = new BigDecimal(num);
		}
		
		Arrays.sort(nums);
		if (nums.length < 3) {
			for (int i = nums.length - 1; i >= 0; i--) {
				System.out.println(nums[i].toPlainString());
			}
		} else{
			for (int i = nums.length - 1; i >= nums.length - 3; i--) {
				System.out.println(nums[i].toPlainString());
			}
		}
	}
}
