/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package Manager;

import Model.Flower;
import java.util.HashMap;

/**
 *
 * @author PC
 */
public class FlowersManager {
    public static void displayFlowers(HashMap<Integer, Flower> flowers) {
        if (flowers.isEmpty()){
            System.out.println("\nEMPTY PATIENT LIST!");
        }
        else {
            System.out.println("------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------");
            System.out.printf("| %-3s | %-10s | %-15s | %-3s | %-5s | %-30s | %-15s | %-20s | %-15s | %-20s | %-20s |%n",
                    "No.", "Patient ID", "Name", "Age", "Gender", "Address", "Phone", "Diagnosis", "Admission Date", "Discharge Date", "Nurse Assigned", "Phone");
            System.out.println("------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------");
            for (Flower flower : flowers.values()) {
                System.out.printf("| %-3s | %-10s | %-15s | %-3s | %-6s | %-30s | %-15s | %-20s | %-15s | %-20s | %-20s |%n",
                        flower.getId(), flower.getFlowerId().trim(), flower.getDescription().trim(), flower.getImportDate(), flower.getUnitPrice(),
                        flower.getCategory().trim(), flower.getCategory(), flower.getCategory().trim(),
                        flower.getCategory(), flower.getCategory(), flower.getCategory().trim());
            }
            System.out.println("------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------");
        }
    }
    
    public static void addFlower(HashMap<Integer, Flower> flowers){
        
    }
    
    public static void findFlowerByIdOrName(HashMap<Integer, Flower> flowers){
        
    }
    
    public static void updateFlower(HashMap<Integer, Flower> flowers){
        
    }
    
    public static void deleteFlower(HashMap<Integer, Flower> flowers){
        
    }
}