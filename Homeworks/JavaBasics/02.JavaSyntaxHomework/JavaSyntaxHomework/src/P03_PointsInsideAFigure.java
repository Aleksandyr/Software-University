import java.util.Scanner;


public class P03_PointsInsideAFigure {

	public static void main(String[] args) {
		Scanner in = new Scanner(System.in);
		
		String input = in.nextLine();
		String[] points = input.split(" ");
		
		float firstPoint = Float.parseFloat(points[0]);
		float SecondPoint = Float.parseFloat(points[1]);
		
		boolean firstFigure = firstPoint >= 12.5 && firstPoint <= 22.5 &&
				SecondPoint >= 6 && SecondPoint <= 8.5;
		
		boolean secondFigure = firstPoint >= 12.5 && firstPoint <= 17.5 &&
				SecondPoint >= 8.5 && SecondPoint <= 13.5;
		
		boolean thirdFigure = firstPoint >= 20 && firstPoint <= 22.5 &&
				SecondPoint >= 8.5 && SecondPoint < 13.5;
		
		if (firstFigure || secondFigure || thirdFigure) {
			System.out.println("Inside");
		}
		else{
			System.out.println("Outside");
		}
	}

}
