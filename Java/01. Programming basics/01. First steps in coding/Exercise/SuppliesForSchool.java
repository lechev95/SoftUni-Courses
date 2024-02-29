import java.util.Scanner;

public class SuppliesForSchool {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        int penPackage = Integer.parseInt(scanner.nextLine());
        int markerPackage = Integer.parseInt(scanner.nextLine());
        int gel = Integer.parseInt(scanner.nextLine());
        int discount = Integer.parseInt(scanner.nextLine());

        double total = penPackage * 5.8 + markerPackage * 7.2 + gel * 1.2;
        System.out.println(total - total * discount / 100);
    }
}
