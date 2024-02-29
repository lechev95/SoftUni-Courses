import java.util.Scanner;

public class Repainting {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        int a = Integer.parseInt(scanner.nextLine());
        int b = Integer.parseInt(scanner.nextLine());
        int c = Integer.parseInt(scanner.nextLine());
        int d = Integer.parseInt(scanner.nextLine());

        double sum = (a + 2) * 1.5 + b * 1.1 * 14.5 + c * 5 + 0.4;
        double total = sum + sum * 0.3 * d;

        System.out.println(total);
    }
}
