package Utils;

import Model.Patient;
import Model.Nurse;
import Utils.MyValidation;
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
    public static HashMap<Integer, Patient> loadPatients(String fileName) throws Exception {
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
            String patientID = data[6];
            String diagnosis = data[7];
            LocalDate admissionDate = MyValidation.checkDate(data[8].trim());
            LocalDate dischargeDate = MyValidation.checkDate(data[9].trim());
            String nurseAssigned = data[10];

            Patient patient = new Patient(id, name, age, gender, address, phone,
                    patientID, diagnosis, admissionDate, dischargeDate, nurseAssigned);
            patients.put(id, patient);
        }
    } catch (IOException e) {
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
                String staffID = data[6];
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
    
    public static void displayAllData(HashMap<Integer, Patient> patients, HashMap<Integer, Nurse> nurses) {
        System.out.println("NURSE DATA:");
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

        System.out.println("\nPATIENT DATA:");
        System.out.println("-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------");
        System.out.printf("| %-3s | %-10s | %-15s | %-3s | %-5s | %-20s | %-20s | %-15s | %-20s | %-20s | %-20s | %-15s |%n",
                 "No.","Patient ID", "Name", "Age", "Gender", "Address", "Diagnosis", "Admission Date", "Discharge Date", "Nurse Assigned", "Address", "Phone");
        System.out.println("-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------");
        for (Patient patient : patients.values()) {
            System.out.printf("| %-3s |%-11s | %-15s | %-3s | %-6s | %-20s | %-20s | %-15s | %-20s | %-20s | %-20s | %-15s |%n",
                    patient.getId(),patient.getPatientID(), patient.getName(), patient.getAge(), patient.getGender(), patient.getAddress(),
                    patient.getDiagnosis(), patient.getAdmissionDate(), patient.getDischargeDate(),
                    patient.getNurseAssigned(), patient.getAddress(), patient.getPhone());
        }
        System.out.println("-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------");
    }
}
