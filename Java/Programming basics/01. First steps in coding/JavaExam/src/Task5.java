import java.util.Scanner;

public class Task5 {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        int target = Integer.parseInt(scanner.nextLine());
        int earnedMoney = 0;

        while (true) {
            String command = scanner.nextLine();

            if (command.equals("closed")) {
                break;
            }

            int price = 0;
            switch (command) {
                case "haircut":
                    String haircutType = scanner.nextLine();
                    price = getPrice(haircutType);
                    break;
                case "color":
                    String colorType = scanner.nextLine();
                    price = getPrice(colorType);
                    break;
            }

            earnedMoney += price;

            if (earnedMoney >= target) {
                System.out.println("You have reached your target for the day!");
                System.out.println("Earned money: " + earnedMoney + "lv.");
                return;
            }
        }

        int neededMoney = target - earnedMoney;
        System.out.println("Target not reached! You need " + neededMoney + "lv. more.");
        System.out.println("Earned money: " + earnedMoney + "lv.");
    }

    public static int getPrice(String service) {
        switch (service) {
            case "mens":
                return 15;
            case "ladies":
                return 20;
            case "kids":
                return 10;
            case "touch up":
                return 20;
            case "full color":
                return 30;
            default:
                return 0;
        }
    }
}