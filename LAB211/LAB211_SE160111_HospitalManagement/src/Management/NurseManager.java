/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package Management;

import Model.Nurse;
import Utils.MyValidation;
import java.util.Collections;
import java.util.HashMap;
import java.util.Scanner;

/**
 *
 * @author PC
 */
public class NurseManager {
    public static void displayNurses(HashMap<Integer, Nurse> nurses) {
        System.out.println("------------------------------------------------------------------------------------------------------------------");
        System.out.printf("| %-10s | %-20s | %-4s | %-7s | %-20s | %-4s | %-20s | %-7s | %-15s |%n",
                "No.", "Name", "Age", "Gender", "Address", "Staff ID", "Department", "Shift", "Salary");
        System.out.println("------------------------------------------------------------------------------------------------------------------");
        for (Nurse nurse : nurses.values()) {
            System.out.printf("| %-10s | %-20s | %-4s | %-7s | %-20s | %-4s | %-20s | %-7s | %-15s |%n",
                    nurse.getId(), nurse.getName(), nurse.getAge(), nurse.getGender(), nurse.getAddress(),
                    nurse.getStaffID(),nurse.getDepartment(), nurse.getShift(), nurse.getSalary());
        }
        System.out.println("------------------------------------------------------------------------------------------------------------------");
    }
    
    public static HashMap<Integer,Nurse> searchNurseByName(HashMap<Integer, Nurse> nurses){
        Scanner sc = new Scanner(System.in);
        System.out.print("Enter the nurse's name or part of the name: ");
        String searchName = sc.nextLine().trim().toLowerCase();

        HashMap<Integer, Nurse> nursesResult = new HashMap<>();

        for (HashMap.Entry<Integer, Nurse> entry : nurses.entrySet()) {
            Nurse nurse = entry.getValue();
            String nurseName = nurse.getName().toLowerCase();
            if (nurseName.contains(searchName)) {
                nursesResult.put(entry.getKey(), nurse);
            }
        }

        if (nursesResult.isEmpty()) {
            System.out.println("The nurse does not exist.");
        }
        return nursesResult;
    }

    public static void updateNurse(HashMap<Integer, Nurse> nurses) {
        Scanner sc = new Scanner(System.in);
        System.out.print("Enter staff ID of the nurse to update: ");
        String staffId = sc.nextLine().trim().toLowerCase();

        boolean nurseExists = false;
        boolean validSalary = false;
        
        for (HashMap.Entry<Integer, Nurse> entry : nurses.entrySet()) {
            Nurse nurse = entry.getValue();
            String originalNurse = nurse.getStaffID().trim();
            try {
                if (originalNurse.equalsIgnoreCase(staffId)) {
                nurseExists = true;
                
                System.out.print("Enter nurse "+ originalNurse +"'s new name:");
                String newName = sc.nextLine().trim();
                nurse.setName(newName);
                
                System.out.print("Enter nurse "+ originalNurse +"'s new age:");
                int newAge = sc.nextInt();
                nurse.setAge(newAge);
                
                System.out.print("Enter nurse "+ originalNurse +"'s new phone:");
                String newPhone = sc.nextLine().trim();
                nurse.setPhone(newPhone);
                
                System.out.print("Enter nurse "+ originalNurse +"'s new department:");
                String newDepartment = sc.nextLine().trim();
                nurse.setDepartment(newDepartment);
                
                System.out.print("Enter nurse "+ originalNurse +"'s new shift:");
                String newShift = sc.nextLine().trim();
                nurse.setShift(newShift);
                
                System.out.print("Enter nurse "+ originalNurse +"'s new salary:");
                Double newSalary = sc.nextDouble();
                nurse.setSalary(newSalary);

                System.out.println("Nurse successfully updated!");
                break;
                }
            }catch(Exception e){
                System.out.println("Failed to update nurse!");
                MyValidation.getEnter("Press Enter to enter again...");
            }
            
        }
        if (!nurseExists) {
            System.out.println("The nurse does not exist.");
        }
    }
    
    public static void addNurse(HashMap<Integer, Nurse> nurses) {
        Scanner scanner = new Scanner(System.in);
        
        boolean continueAdding = true;
        int nextId = getNextNurseId(nurses);
        
        while (continueAdding) {
            System.out.println("\nAdd a new nurse");
            System.out.println("-------------------------------");
            
            //ID auto incremental
            int id = nextId++;
            System.out.println("ID: " + id);

            System.out.print("Name: ");
            String name = scanner.nextLine().trim();

            System.out.print("Age: ");
            int age = Integer.parseInt(scanner.nextLine().trim());

            System.out.print("Gender: ");
            String gender = scanner.nextLine().trim();

            System.out.print("Address: ");
            String address = scanner.nextLine().trim();

            System.out.print("Phone: ");
            String phone = scanner.nextLine().trim();
            
            System.out.print("Staff ID: ");
            String staffId = scanner.nextLine().trim();
            
            if (nurses.containsKey(staffId)) {
                System.out.println("The staff ID is already in use. Please enter a unique staff ID.");
                continue; 
            }
            // Is correct phone format
            if (!MyValidation.isPhone(phone)) {
                System.out.println("Invalid phone format. Please enter a valid phone number.");
                continue; 
            }

            System.out.print("Department: ");
            String department = scanner.nextLine().trim();

            // Is correct  department length
            if (department.length() < 3 || department.length() > 50) {
                System.out.println("Department length must be between 3 and 50 characters.");
                continue; 
            }

            System.out.print("Shift: ");
            String shift = scanner.nextLine().trim();

            System.out.print("Salary: ");
            double salary = Double.parseDouble(scanner.nextLine().trim());

            // Check if positive age and salary
            if (age <= 0 || salary <= 0) {
                System.out.println("Age and salary must be positive numbers.");
                continue; 
            }

            Nurse nurse = new Nurse(id, name, age, gender, address, phone, staffId, department, shift, salary);

            nurses.put(id, nurse);

            System.out.println("Nurse added successfully!");

            System.out.print("Do you want to add another nurse? (yes/no): ");
            String choice = scanner.nextLine().trim();
            if (!choice.equalsIgnoreCase("yes")) {
                continueAdding = false;
            }
        }
    }
    
    public static int getNextNurseId(HashMap<Integer, Nurse> nurses) {
        if (nurses.isEmpty()) {
            return 1; // Start from ID 1 if the nurse.dat is empty
        }
        // Get the maximum ID from the existing nurses and increment it by 1
        return Collections.max(nurses.keySet()) + 1;
    }


}
