import java.util.Scanner;

public class Task2 {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int absentDays = Integer.parseInt(scanner.nextLine());
        int food = Integer.parseInt(scanner.nextLine());
        double firstDeerFood = Double.parseDouble(scanner.nextLine());
        double secondDeerFood = Double.parseDouble(scanner.nextLine());
        double thirdDeerFood = Double.parseDouble(scanner.nextLine());

        double firstDeer = absentDays * firstDeerFood;
        double secondDeer = absentDays * secondDeerFood;
        double thirdDeer = absentDays * thirdDeerFood;
        double totalFood = Math.ceil(firstDeer + secondDeer + thirdDeer);

        if (totalFood > food){
            System.out.printf("%s more kilos of food are needed.", (int)(totalFood - food));
        } else{
            System.out.printf("%d kilos of food left.", (int)(food - totalFood));
        }
    }
}
