import java.util.Scanner;

public class Task4 {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        int models = Integer.parseInt(scanner.nextLine());

        int totalSales = 0;
        double totalRating = 0;

        for (int i = 0; i < models; i++) {
            int currNum = Integer.parseInt(scanner.nextLine());
            int rating = currNum % 10;
            int sales = (currNum - rating) / 10;

            totalSales += calcSales(rating, sales);
            totalRating += rating;
        }

        double avgRating = totalRating / models;
        System.out.printf("%.2f", totalSales * 1.0);
        System.out.println();
        System.out.printf("%.2f", avgRating);
    }

    public static int calcSales(int rating, int sales){
        switch (rating) {
            case 2:
                return 0;
            case 3:
                return (int) (sales * 0.5);
            case 4:
                return (int) (sales * 0.7);
            case 5:
                return (int) (sales * 0.85);
            case 6:
                return sales;
            default:
                return 0;
        }
    }
}
