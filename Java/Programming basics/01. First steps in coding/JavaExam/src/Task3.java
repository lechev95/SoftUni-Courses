import java.util.Scanner;

public class Task3 {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int peopleCount = Integer.parseInt(scanner.nextLine());
        String season = scanner.nextLine();
        double price = 0.0;

        switch (season){
            case "spring":
                if(peopleCount <= 5){
                    price = peopleCount * 50;
                } else {
                    price = peopleCount * 48;
                }
                break;
            case "summer":
                if(peopleCount <= 5){
                    price = peopleCount * 48.50;
                } else {
                    price = peopleCount * 45;
                }
                break;
            case "autumn":
                if(peopleCount <= 5){
                    price = peopleCount * 60;
                } else {
                    price = peopleCount * 49.50;
                }
                break;
            case "winter":
                if(peopleCount <= 5){
                    price = peopleCount * 86;
                } else {
                    price = peopleCount * 85;
                }
                break;
        }

        if(season.equals("summer")){
            price -= price * 15/100;
        }

        if(season.equals("winter")){
            price += price * 8/100;
        }

        System.out.printf("%.2f leva.", price);
    }
}
