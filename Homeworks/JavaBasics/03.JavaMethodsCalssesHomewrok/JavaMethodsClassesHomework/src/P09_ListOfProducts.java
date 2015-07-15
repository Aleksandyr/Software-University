import java.io.BufferedReader;
import java.io.BufferedWriter;
import java.io.FileReader;
import java.io.FileWriter;
import java.util.ArrayList;
import java.util.Collections;
import java.util.List;

public class P09_ListOfProducts {

	public static void main(String[] args) {
		ArrayList<Product> products = new ArrayList<Product>();
		try {
			BufferedReader reader = new BufferedReader(new FileReader("P09_InputProducts.txt"));
			BufferedWriter writer = new BufferedWriter(new FileWriter("P09_OutputProducts.txt"));
			String input;
			
			while ((input = reader.readLine()) != null) {
				String[] splited = input.split(" ");
				products.add(new Product(splited[0], Double.parseDouble(splited[1])));
			}
			
			Collections.sort(products);
			
			for (Product product : products) {
				writer.write(product.getPrice() + " " + product.getName() + "\n");
			}
			
			reader.close();
			writer.close();
		} catch (Exception e) {
			System.err.println("Error");
		}
	}

}
