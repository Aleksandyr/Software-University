import java.util.Scanner;


public class P02_PythagoreanNumbers {

	public static void main(String[] args) {
		Scanner in = new Scanner(System.in);
		
		int n = in.nextInt();
		int[] nums = new int[n];
		for (int i = 0; i < n; i++) {
			nums[i] = in.nextInt();
		}
		
		boolean isHavePythagoreanNums = false;
		for (int i = 0; i < nums.length; i++) {
			for (int j = 0; j < nums.length; j++) {
				for (int j2 = 0; j2 < nums.length; j2++) {
					int a = nums[i] * nums[i];
					int b = nums[j] * nums[j];
					int c = nums[j2] * nums[j2];
						
					if (a + b == c && a <= b) {
						System.out.println(nums[i] + "*" + nums[i] + " + " + 
										   nums[j] + "*" + nums[j] + " = " +
										   nums[j2] + "*" + nums[j2]);
						isHavePythagoreanNums = true;
					}
				}
			}
		}
		if (!isHavePythagoreanNums) {
			System.out.println("No");
		}
	}
}
