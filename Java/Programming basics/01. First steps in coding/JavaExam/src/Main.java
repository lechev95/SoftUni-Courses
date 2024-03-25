import java.util.Scanner;

public class Main {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        double cpuDollar = Double.parseDouble(scanner.nextLine());
        double gpuDollar = Double.parseDouble(scanner.nextLine());
        double ramDollar = Double.parseDouble(scanner.nextLine());

        int ramQuantity = Integer.parseInt(scanner.nextLine());
        double discount = Double.parseDouble(scanner.nextLine());

        double convertToBgn = 1.57;

        double cpuBgn = cpuDollar * convertToBgn;
        double gpuBgn = gpuDollar * convertToBgn;
        double ramBgn = ramDollar * convertToBgn;

        cpuBgn = cpuBgn - cpuBgn * discount;
        gpuBgn = gpuBgn - gpuBgn * discount;
        double ram = ramBgn * ramQuantity;
        double total = cpuBgn + gpuBgn + ram;
        System.out.printf("Money needed - %.2f leva.", total);
    }
}