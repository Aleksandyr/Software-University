import java.util.Scanner;


public class P05_AngleUnitConverter {

	public static void main(String[] args) {
		Scanner in = new Scanner(System.in);
		
		int n = in.nextInt();
		
		double[] value = new double[n];
		String[] mesure = new String[n];
		
		for (int i = 0; i < n; i++) {
			value[i] = in.nextDouble();
			mesure[i] = in.next();
		}
		
		for (int i = 0; i < n; i++) {	
			if (mesure[i].equals("deg")) {
				System.out.printf("%.6f %s\n", ConvertDegreeToRadians(value[i]), mesure[i]);
			} else {
				System.out.printf("%.6f %s\n", ConvertRadiansToDegrees(value[i]), mesure[i]);
			}
		}
		
	}
	
	public static double ConvertDegreeToRadians(double degrees){
		return degrees / (180 / Math.PI);
	}
	
	public static double ConvertRadiansToDegrees(double radians){
		return radians * (180 / Math.PI);
	}
}
