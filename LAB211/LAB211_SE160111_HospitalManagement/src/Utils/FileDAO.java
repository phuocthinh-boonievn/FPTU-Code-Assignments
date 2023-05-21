/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package Utils;

import Model.Patient;
import Model.Nurse;
import java.io.BufferedReader;
import java.io.FileReader;
import java.io.IOException;
import java.util.HashMap;

/**
 *
 * @author PC
 */
public class FileDAO {
    public static HashMap<Integer, Patient> loadPatients(String fileName) {
        HashMap<Integer, Patient> patients = new HashMap<>();

        try (BufferedReader reader = new BufferedReader(new FileReader(fileName))) {
            String line;
            while ((line = reader.readLine()) != null) {
                String[] data = line.split(",");
                int id = Integer.parseInt(data[0]);
                String name = data[1];
                int age = Integer.parseInt(data[2]);
                String gender = data[3];
                String address = data[4];
                String phone = data[5];
                String diagnosis = data[6];
                String admissionDate = data[7];
                String dischargeDate = data[8];
                String nurseAssigned = data[9];

                Patient patient = new Patient(id, name, age, gender, address, phone,
                        diagnosis, admissionDate, dischargeDate, nurseAssigned);
                patients.put(id, patient);
            }
        } catch (IOException e) {
            e.printStackTrace();
        }

        return patients;
    }
    
    public static HashMap<Integer, Nurse> loadNurses(String fileName) {
        HashMap<Integer, Nurse> nurses = new HashMap<>();

        try (BufferedReader reader = new BufferedReader(new FileReader(fileName))) {
            String line;
            while ((line = reader.readLine()) != null) {
                String[] data = line.split(",");
                int id = Integer.parseInt(data[0]);
                String name = data[1];
                int age = Integer.parseInt(data[2]);
                String gender = data[3];
                String address = data[4];
                String phone = data[5];
                int staffID = Integer.parseInt(data[6]);
                String department = data[7];
                String shift = data[8];
                double salary = Double.parseDouble(data[9]);

                Nurse nurse = new Nurse(id, name, age, gender, address, phone,
                        staffID, department, shift, salary);
                nurses.put(id, nurse);
            }
        } catch (IOException e) {
            e.printStackTrace();
        }

        return nurses;
    }
    
    public static void loadAllData(HashMap<Integer, Patient> patients, HashMap<Integer, Nurse> nurses) {


        // Display the loaded nurse data in a table
        System.out.println("NURSE DATA:");
        System.out.println("------------------------------------------------------------");
        System.out.printf("| %-6s | %-20s | %-4s | %-7s | %-20s | %-15s |%n",
                "ID", "Name", "Age", "Gender", "Department", "Salary");
        System.out.println("------------------------------------------------------------");
        for (Nurse nurse : nurses.values()) {
            System.out.printf("| %-6d | %-20s | %-4d | %-7s | %-20s | %-15.2f |%n",
                    nurse.getId(), nurse.getName(), nurse.getAge(), nurse.getGender(),
                    nurse.getDepartment(), nurse.getSalary());
        }
        System.out.println("------------------------------------------------------------");

        // Display the loaded patient data in a table
        System.out.println("\nPATIENT DATA:");
        System.out.println("--------------------------------------------------------------------------------------------------------------------");
        System.out.printf("| %-5s | %-15s | %-3s | %-5s | %-20s | %-15s | %-20s | %-20s | %-20s | %-15s |%n",
                "ID", "Name", "Age", "Gender", "Diagnosis", "Admission Date", "Discharge Date", "Nurse Assigned", "Address", "Phone");
        System.out.println("--------------------------------------------------------------------------------------------------------------------");
        for (Patient patient : patients.values()) {
            System.out.printf("| %-5s | %-15s | %-3s | %-5s | %-20s | %-15s | %-20s | %-20s | %-20s | %-15s |%n",
                    patient.getId(), patient.getName(), patient.getAge(), patient.getGender(),
                    patient.getDiagnosis(), patient.getAdmissionDate(), patient.getDischargeDate(),
                    patient.getNurseAssigned(), patient.getAddress(), patient.getPhone());
        }
        System.out.println("--------------------------------------------------------------------------------------------------------------------");
    }
}
