package Main;

import Model.Flower;
import Utils.Menu;
import Utils.FileDAO;
import Manager.FlowersManager;
import java.util.Scanner;
import java.util.HashMap;
import java.util.HashSet;
import java.util.Set;
/**
 *
 * @author boonie-pt
 */
public class FlowerStoreManagement {
    final static String FILE_FLOWERS = "flowers.dat";
    final static String FILE_ORDERS = "orders.dat";
    
    public static void main(String[] args) throws Exception {
        Menu menu = new Menu();
        menu.add("FLOWER STORE MANAGEMENT");
        menu.add("     Manage Flower");
        menu.add("  1. Add a flower");
        menu.add("  2. Find a flower");
        menu.add("  3. Update a flower");
        menu.add("  4. Delete a flower");
        menu.add("     Manage Order");
        menu.add("  5. Add an order");
        menu.add("  6. Display orders");
        menu.add("  7. Sort orders");
        menu.add("     Data management");
        menu.add("  8. Save data");
        menu.add("  9. Load data");
        menu.add("     Others - Exit");
        Set<Flower> flowersSet = FileDAO.loadFlowerData(FILE_FLOWERS);
//        HashMap<Integer, Order> orders = FileDAO.loadNursesFromFile(FILE_ORDERS);
        
        boolean cont = true;
        do{
            int choice = menu.getUserChoice();
            switch (choice) {
                case 1:
                    FlowersManager.addFlower(flowersSet);
                    break;
                case 2:
                    FlowersManager.searchFlower(flowersSet);
                    break;
                case 3:
                    FlowersManager.updateFlower(flowersSet);
                    break;
                case 4:
                    FlowersManager.deleteFlower(flowersSet);
                    break;
                case 5:
                    
                    break;
                case 6:
                    
                    break;
                case 7:
                    
                    break;
                case 8:
                    FileDAO.displayFlowers(flowersSet);
                    break;
                case 9:
                    FileDAO.displayFlowers(flowersSet);
                    break;
                default:
                    Scanner sc = new Scanner(System.in);
                    System.out.println("Do yo really want to exit the application?");
                    String input = sc.nextLine();
                    if (input.equals("yes") || input.equals("y")) {
                        FileDAO.saveFlowersToFile();
                        FileDAO.saveOrdersToFile();
                        cont = false;
                        break;
                    }
                    else {
                        cont = true;
                    }
            }
        }
        while (cont == true);
    }
}