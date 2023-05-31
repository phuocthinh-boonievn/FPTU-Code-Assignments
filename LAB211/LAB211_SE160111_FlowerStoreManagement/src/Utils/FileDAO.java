/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package Utils;

import Model.Flower;
import java.io.BufferedReader;
import java.io.FileReader;
import java.io.IOException;
import java.time.LocalDate;
import java.util.HashMap;

/**
 *
 * @author PC
 */
public class FileDAO {
    public static void saveFlowersToFile(){
         
    }
    public static void saveOrdersToFile(){
         
    }
    
    public static HashMap<Integer, Flower> loadFlowersFromFile(String fileName) throws Exception {
        HashMap<Integer, Flower> flowers = new HashMap<>();

        try (BufferedReader reader = new BufferedReader(new FileReader(fileName))) {
            String line;
            while ((line = reader.readLine()) != null) {
                String[] data = line.split(",");
                int id = Integer.parseInt(data[0].trim());
                String flowerId = data[1];
                String description = data[2];
                LocalDate importDate = MyValidation.checkDate(data[3].trim());
                double unitPrice = Double.parseDouble(data[4].trim());
                String category = data[5];

                Flower flower = new Flower(id, flowerId, description, importDate, unitPrice, category);
                flowers.put(id, flower);
            }
        } catch (IOException e) {
        }

        return flowers;
    }
    
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
     
     
}
