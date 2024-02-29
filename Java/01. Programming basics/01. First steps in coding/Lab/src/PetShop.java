import java.text.DecimalFormat;
import java.util.Scanner;

public class PetShop {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int dogFood = Integer.parseInt(scanner.nextLine());
        int catFood = Integer.parseInt(scanner.nextLine());

        double dogCost = dogFood * 2.5;
        int catCost = catFood * 4;

        double total = dogCost + catCost;

        System.out.printf("%f lv.", total);
    }
}
