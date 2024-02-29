import java.util.Scanner;

public class YardGreening {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        double meters = Double.parseDouble(scanner.nextLine());
        double discount = meters * 7.61 * 0.18;
        double cost = meters * 7.61 - discount;

        System.out.printf("The final price is: %f lv. %nThe discount is: %f lv.", cost, discount);
    }
}
