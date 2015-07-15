import java.util.ArrayList;
import java.util.Scanner;
import java.util.TreeMap;


public class P03_LegoBlocks {

	public static void main(String[] args) {
		Scanner in = new Scanner(System.in);
		
		TreeMap<String, TreeMap<String, Integer>> usrLogs = new TreeMap<>();
		ArrayList<String> allIps = new ArrayList<String>();
		int loopSize = 0;
		String ip = "";
		while (true) {
			String input = in.nextLine();
			if (input.equals("end")) {
				break;
			}
			String[] users = input.split("[^a-zA-z0-9]+");
			String[] ips = input.split("\\W+");
			String user = users[users.length - 1];
			if (user.equals("mother")) {
				ip = ips[1] + ":" + 
						ips[2] + ":" + 
						ips[3] + ":" + 
						ips[4] + ":" + 
						ips[5] + ":" + 
						ips[6] + ":" + 
						ips[7] + ":" + 
						ips[8];
			} else{
				ip = ips[1] + "." + ips[2] + "." + ips[3] + "." + ips[4];
			}
			allIps.add(ip);
			
			if (!usrLogs.containsKey(user)) {
				usrLogs.put(user, new TreeMap<>());
			}
			usrLogs.get(user).put(ip, 0);	
			loopSize = usrLogs.get(user).values().size();
		}

		for (String user: usrLogs.keySet()) {
			int counter = 0;
			System.out.println(user + ":");
			loopSize = usrLogs.get(user).values().size();
			for (String ipLoop : usrLogs.get(user).keySet()) {
				for (String string : allIps) {
					if (ipLoop.equals(string)) {
						counter++;
					}
				}
				if (loopSize <= 1) {
					System.out.print(ipLoop + " => " + counter + ".");
				} else{
					System.out.print(ipLoop + " => " + counter + ", ");
					System.out.println();
				}
				counter = 0;
				loopSize--;
			}
			System.out.println();	
		}
	}

}
