import java.util.Arrays;
import java.util.Scanner;

public class UsdToBgn {
    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);
        double dolars = Double.parseDouble(input.nextLine());
        double levs = dolars * 1.79549;
        System.out.println(levs);
    }
}
