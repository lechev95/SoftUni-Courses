import java.util.Scanner;

public class Task6 {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        int firstMax = Integer.parseInt(scanner.nextLine());
        int secondMax = Integer.parseInt(scanner.nextLine());
        int thirdMax = Integer.parseInt(scanner.nextLine());

        for (int i = 2; i <= firstMax; i += 2) {
            for (int j = 2; j <= secondMax; j++) {
                if (isPrime(j)) {
                    for (int k = 2; k <= thirdMax; k += 2) {
                        System.out.printf("%d %d %d%n", i, j, k);
                    }
                }
            }
        }
    }

    public static boolean isPrime(int n) {
        if (n <= 1) {
            return false;
        }
        for (int i = 2; i <= Math.sqrt(n); i++) {
            if (n % i == 0) {
                return false;
            }
        }
        return true;
    }
}
