/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package Manager;

import Model.Flower;
import java.util.HashMap;
import java.util.HashSet;
import java.util.Scanner;
import java.util.Set;

/**
 *
 * @author PC
 */
public class FlowersManager {
    public static void displayFlowers(Set<Flower> flowers) {
        if (flowers.isEmpty()) {
            System.out.println("\nEMPTY FLOWER LIST!");
        } else {
            System.out.println("------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------");
            System.out.printf("| %-3s | %-10s | %-20s | %-15s | %-10s | %-30s |%n",
                    "No.", "Flower ID", "Description", "Import Date", "Unit Price", "Category");
            System.out.println("------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------");
            for (Flower flower : flowers) {
                System.out.printf("| %-3s | %-10s | %-20s | %-15s | %-10s | %-30s |%n",
                        flower.getId(), flower.getFlowerId().trim(), flower.getDescription().trim(), flower.getImportDate(),
                        flower.getUnitPrice(), flower.getCategory().trim());
            }
            System.out.println("------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------");
        }
    }
    
    public static void addFlower(HashMap<Integer, Flower> flowers){
        
    }
    
    public static void searchFlower(Set<Flower> flowers) {
        Scanner scanner = new Scanner(System.in);

        boolean validChoice = false;
        int choice = 0;

        while (!validChoice) {
            System.out.println("Search flower by:");
            System.out.println("1. Flower ID");
            System.out.println("2. Flower Name");
            System.out.print("Enter your choice: ");
            choice = scanner.nextInt();
            scanner.nextLine();

            if (choice == 1 || choice == 2) {
                validChoice = true;
            } else {
                System.out.println("Invalid choice! Please enter 1 or 2.");
            }
        }

        System.out.print("Enter search term: ");
        String searchTerm = scanner.nextLine();

        Set<Flower> foundFlowers = new HashSet<>();
        if (choice == 1) {
            for (Flower flower : flowers) {
                if (flower.getFlowerId().trim().equalsIgnoreCase(searchTerm)) {
                    foundFlowers.add(flower);
                }
            }
        } else if (choice == 2) {
            for (Flower flower : flowers) {
                if (flower.getDescription().trim().toLowerCase().contains(searchTerm) ) {
                    foundFlowers.add(flower);
                }
            }
        }

        displayFlowers(foundFlowers);
    }


    
    public static void updateFlower(HashMap<Integer, Flower> flowers){
        
    }
    
    public static void deleteFlower(HashMap<Integer, Flower> flowers){
        
    }
}