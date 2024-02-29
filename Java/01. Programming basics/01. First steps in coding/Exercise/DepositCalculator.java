import java.util.Scanner;

public class DepositCalculator {
    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);

        double deposit = Double.parseDouble(input.nextLine());
        int term = Integer.parseInt(input.nextLine());
        double ypp = Double.parseDouble(input.nextLine());

        double total = deposit + term * ((deposit * ypp/100)/12);

        System.out.println(total);
    }
}
