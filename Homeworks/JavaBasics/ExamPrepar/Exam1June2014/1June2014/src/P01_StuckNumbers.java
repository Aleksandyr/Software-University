import java.util.Scanner;


public class P01_StuckNumbers {

	public static void main(String[] args) {
		Scanner scanner = new Scanner(System.in);

		int n = scanner.nextInt();
		
		int[] nums = new int[n];
		for (int i = 0; i < n; i++) {
			nums[i] = scanner.nextInt();
		}
		
		boolean isStuckNum = false;
		for (int i1 = 0; i1 < nums.length; i1++) {
			for (int i2 = 0; i2 < nums.length; i2++) {
				for (int i3 = 0; i3 < nums.length; i3++) {
					for (int i4 = 0; i4 < nums.length; i4++) {
						int a = nums[i1];
						int b = nums[i2];
						int c = nums[i3];
						int d = nums[i4];
						
						if (a != b && a != c && a != d && 
								b != c && b != d && c != d) {
							String firstStr = "" + a + b;
							String secondStr = "" + c + d;
							
							if (firstStr.equals(secondStr)) {
								System.out.printf("%d|%d==%d|%d\n", a, b, c, d);
								isStuckNum = true;
							}
						}
					}
				}
			}
		}
		if (!isStuckNum) {
			System.out.println("No");
		}
	}

}
