import java.util.Scanner;

public class VacationBooksList {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        int totalPages = Integer.parseInt(scanner.nextLine());
        int pagesPerHour = Integer.parseInt(scanner.nextLine());
        int daysToComplete = Integer.parseInt(scanner.nextLine());

        int total = totalPages / pagesPerHour / daysToComplete;

        System.out.println(total);
    }
}
