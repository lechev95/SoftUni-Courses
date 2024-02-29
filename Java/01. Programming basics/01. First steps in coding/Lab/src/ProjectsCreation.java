import java.util.Scanner;

public class ProjectsCreation {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        String name = scanner.nextLine();
        int project = Integer.parseInt(scanner.nextLine());
        int time = project * 3;

        System.out.printf("The architect %s will need %d hours to complete %s project/s.", name, time, project);
    }
}
