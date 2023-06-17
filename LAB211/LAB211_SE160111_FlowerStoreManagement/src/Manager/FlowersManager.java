/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package Manager;

import Model.Flower;
import Utils.MyValidation;
import java.time.LocalDate;
import java.util.HashMap;
import java.util.HashSet;
import java.util.Scanner;
import java.util.Set;

/**
 *
 * @author PC
 */
public class FlowersManager {
    
    public static int incrementFlowerId(Set<Flower> flowers) {
        if (flowers.isEmpty()) {
            return 1;
        }
        int maxId = 0;
        for (Flower flower : flowers) {
            if (flower.getId() > maxId) {
                maxId = flower.getId();
            }
        }
        return maxId + 1;
    }
    
    public static boolean isFlowerIdDuplicated(Set<Flower> flowers, String flowerId) {
        for (Flower flower : flowers) {
            String existingFlowerId = flower.getFlowerId().toLowerCase().trim();
            if (existingFlowerId.equals(flowerId.toLowerCase().trim())) {
                return true;
            }
        }
        return false;
    }
    
    public static void displayFlowers(Set<Flower> flowers) {
        if (flowers.isEmpty()) {
            System.out.println("\nEMPTY FLOWER LIST!");
        } else {
            System.out.println("--------------------------------------------------------------------------------------------------");
            System.out.printf("| %-3s | %-10s | %-20s | %-15s | %-15s | %-15s |%n",
                    "No.", "Flower ID", "Description", "Import Date", "Flower Price ($)", "Category");
            System.out.println("--------------------------------------------------------------------------------------------------");            for (Flower flower : flowers) {
                System.out.printf("| %-3s | %-10s | %-20s | %-15s | %-16s | %-15s |%n",
                        flower.getId(), flower.getFlowerId().trim(), flower.getDescription().trim(), flower.getImportDate(),
                         "$ " + flower.getUnitPrice() , flower.getCategory().trim());
            }
            System.out.println("--------------------------------------------------------------------------------------------------");        }
    }
    
    public static void addFlower(Set<Flower> flowers) throws Exception {
        Scanner sc = new Scanner(System.in);

        boolean continueAdding = true;
        int id = incrementFlowerId(flowers);
        String flowerId = "";
        String description = "";
        LocalDate importDate = null;
        double unitPrice = 0;
        String category = "";

        while (continueAdding) {
            System.out.println("\nAdd a new flower");
            System.out.println("-------------------------------");

            // ID auto incremental
            System.out.println("ID: " + id);
            
            boolean validFlowerId = false;
            while (!validFlowerId){
                System.out.print("Flower ID: ");
                flowerId = sc.nextLine().trim();
                if (flowerId.equals("")) {
                    System.out.println("Flower ID must not be null.");
                    continue;
                }
                else if (isFlowerIdDuplicated(flowers, flowerId)) {
                    System.out.println("The Flower ID already exists. Please enter a unique Flower ID.");
                    continue; 
                }
                validFlowerId = true;
            }

            boolean validDescription = false;
            while (!validDescription) {
                System.out.print("Description: ");
                description = sc.nextLine().trim();
                if (description.equals("")) {
                    System.out.println("Description must not be null!");
                    continue;
                }
                else if (description.length() < 3 || description.length() > 50) {
                    System.out.println("Description length must be between 3 and 50 characters.");
                    continue;
                }
                validDescription = true;
            }

            boolean validImportDate = false;
            while (!validImportDate) {
                System.out.print("Import Date (dd/MM/yyyy): ");
                String importDateStr = sc.nextLine().trim();
                if (MyValidation.isValidDate(importDateStr, "dd/MM/yyyy")) {
                    importDate = MyValidation.checkDate(importDateStr);
                    validImportDate = true;
                } else {
                    System.out.println("Invalid date format. Please enter a valid date (dd/MM/yyyy).");
                }
            }

            boolean validUnitPrice = false;
            while (!validUnitPrice) {
                try {
                    System.out.print("Unit Price: ");
                    unitPrice = Double.parseDouble(sc.nextLine().trim());
                    if (unitPrice <= 0) {
                        System.out.println("Unit Price must be a positive number!");
                        continue;
                    }
                    validUnitPrice = true;
                } catch (NumberFormatException e) {
                    System.out.println("Invalid input. Unit Price must be a number.");
                    validUnitPrice = false;
                }
            }

            boolean validCategory = false;
            while (!validCategory) {
                System.out.print("Category: ");
                category = sc.nextLine().trim();
                if (category.equals("")) {
                    System.out.println("Category must not be null!");
                    continue;
                }
                validCategory = true;
            }

            Flower flower = new Flower(id, flowerId.toUpperCase(), description, importDate, unitPrice, category);
            flowers.add(flower);

            System.out.println("Flower added successfully! Updated flower list:");
            displayFlowers(flowers);

            System.out.print("Do you want to add another flower? (yes/no): ");
            String choice = sc.nextLine().trim();
            if (choice.equalsIgnoreCase("yes") || choice.equalsIgnoreCase("y")) {
                id++;
                continueAdding = true;
            } else {
                continueAdding = false;
            }
        }
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

    public static void updateFlower(Set<Flower> flowers) throws Exception{
        Scanner sc = new Scanner(System.in);
        System.out.print("Enter the flower ID to update: ");
        String flowerId = sc.nextLine().trim();

        boolean flowerExists = false;
        Set<Flower> foundFlower = new HashSet<>();
        
        for (Flower flower : flowers) {
            if (flower.getFlowerId().trim().equalsIgnoreCase(flowerId)) {
                flowerExists = true;
                foundFlower.add(flower);
                displayFlowers(foundFlower);

                boolean validInput = false;
                    

                while (!validInput) {
                    System.out.println("Select the attribute to update:");
                    System.out.println("1. Description");
                    System.out.println("2. Import Date");
                    System.out.println("3. Unit Price");
                    System.out.println("4. Category");
                    System.out.println("5. Cancel");

                    System.out.print("Enter your choice: ");
                    int choice = sc.nextInt();
                    sc.nextLine(); // Consume the newline character

                    switch (choice) {
                        case 1:
                            System.out.print("Enter the new description: ");
                            String newDescription = sc.nextLine().trim();
                            flower.setDescription(newDescription);
                            System.out.println("Description updated!");
                            validInput = true;
                            break;
                        case 2:
                            System.out.print("Enter the new import date (dd/mm/yyyy): ");
                            String newImportDateStr = sc.nextLine().trim();
                            if (MyValidation.isValidDate(newImportDateStr, "dd/MM/yyyy")) {
                                LocalDate newImportDate = MyValidation.checkDate(newImportDateStr.trim());
                                flower.setImportDate(newImportDate);
                                System.out.println("Import date updated!");
                                validInput = true;
                            }
                            System.out.println("Invalid date!");
                            break;
                        case 3:
                            double newPrice = 0;
                            boolean validPrice = false;
                            while (!validPrice){
                                try {
                                    System.out.print("Enter new unit price of flower: ");
                                    newPrice = Double.parseDouble(sc.nextLine().trim());
                                    //Check positive age or not 
                                    if (newPrice <= 0) {
                                        System.out.println("Price must be a positive number.");
                                        continue;
                                    }
                                    else if (Double.toString(newPrice).equals("")) {
                                    System.out.println("Salary must not be null.");
                                        continue;
                                    }
                                    flower.setUnitPrice(newPrice);
                                    System.out.println("Unit price updated!");
                                    validPrice = true;
                                } catch (NumberFormatException e) {
                                    System.out.println("Invalid input. Salary must be a number.");
                                    validPrice = false;
                                }
                            }
                            validInput = true;
                            break;
                        case 4:
                            System.out.print("Enter the new category: ");
                            String newCategory = sc.nextLine().trim();
                            flower.setCategory(newCategory);
                            System.out.println("Category updated!");
                            validInput = true;
                            break;
                        case 5:
                            System.out.println("Update canceled.");
                            validInput = true;
                            break;
                        default:
                            System.out.println("Invalid choice. Please try again.");
                            break;
                    }
                }

                System.out.println("Flower updated!");
                break;
            }
        }

        if (!flowerExists) {
            System.out.println("The flower does not exist.");
        }                           
    }
    
    public static void deleteFlower(Set<Flower> flowers){
        System.out.println("Flower list: ");
        displayFlowers(flowers);
        Scanner scanner = new Scanner(System.in);
    
        System.out.println("Enter the flower ID to delete: ");
        String flowerId = scanner.nextLine();

        // Check if the flower exists
        Flower flowerToDelete = null;
        for (Flower flower : flowers) {
            if (flower.getFlowerId().trim().equalsIgnoreCase(flowerId)) {
                flowerToDelete = flower;
                break;
            }
        }

        if (flowerToDelete == null) {
            System.out.println("The flower does not exist.");
            return;
        }
        // Check if the flower is in any order detail
        // Confirmation message
        System.out.print("Are you sure you want to delete the flower? (Y/N): ");
        String confirmation = scanner.nextLine();

        if (confirmation.equalsIgnoreCase("Y")) {
            // Delete the flower
            flowers.remove(flowerToDelete);
            System.out.println("The flower has been successfully deleted.");
        } else {
            System.out.println("Deletion canceled.");
        }
    }
}