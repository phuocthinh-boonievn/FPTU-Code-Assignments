/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package Management;

import Model.Nurse;
import Utils.MyValidation;
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

}
