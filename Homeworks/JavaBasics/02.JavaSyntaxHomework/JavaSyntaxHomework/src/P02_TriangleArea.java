import java.util.Scanner;


public class P02_TriangleArea {

	public static void main(String[] args) {
		Scanner in = new Scanner(System.in);
		int aX = in.nextInt();
		int aY = in.nextInt();
		int bX = in.nextInt();
		int bY = in.nextInt();
		int cX = in.nextInt();
		int cY = in.nextInt();
		
		int areaOfTriangle = Math.abs((aX * (bY - cY) + bX * (cY - aY) + cX * (aY - bY)) / 2);
		
		System.out.println(areaOfTriangle);
		
	}

}
