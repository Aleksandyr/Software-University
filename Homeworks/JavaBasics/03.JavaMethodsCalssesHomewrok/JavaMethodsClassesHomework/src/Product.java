import java.util.ArrayList;

public class Product implements Comparable<Product> {
	private String name;
	private double price;
	
	public Product(String name, double price) {
		this.name = name;
		this.price = price;
	}
	
	public String getName(){
		return this.name;
	}
	
	public double getPrice(){
		return this.price;
	}

	@Override
	public int compareTo(Product o) {
		if (price < o.price) {
			return -1;
		} else if(price > o.price) {
			return 1;
		} else{
			return 0;
		}
	}
}
