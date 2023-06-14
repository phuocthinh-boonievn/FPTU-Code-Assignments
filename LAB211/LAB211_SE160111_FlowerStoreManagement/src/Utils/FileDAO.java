/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package Utils;

import Model.Flower;
import java.io.BufferedReader;
import java.io.EOFException;
import java.io.FileInputStream;
import java.io.FileReader;
import java.io.IOException;
import java.io.ObjectInputStream;
import java.time.LocalDate;
import java.util.HashMap;
import java.util.HashSet;
import java.util.Set;
import java.util.TreeSet;

/**
 *
 * @author PC
 */
public class FileDAO {
    public static void saveFlowersToFile(){
         
    }
    public static void saveOrdersToFile(){
         
    }
    
    public static Set<Flower> loadFlowerData(String fileName) throws Exception {
        Set<Flower> flowers = new TreeSet<>((flower1, flower2) -> Integer.compare(flower1.getId(), flower2.getId()));

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
                flowers.add(flower);
            }
        } catch (IOException e) {
        }

        return flowers;
    }
    
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
}
