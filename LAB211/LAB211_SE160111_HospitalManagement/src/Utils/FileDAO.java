package Utils;

import Model.Patient;
import Model.Nurse;
import java.io.BufferedReader;
import java.io.FileReader;
import java.io.FileWriter;
import java.io.IOException;
import java.time.LocalDate;
import java.time.format.DateTimeFormatter;
import java.util.Collections;
import java.util.HashMap;

/**
 *
 * @author boonie-pt
 */
public class FileDAO {
    
    public static int incrementNurseId(HashMap<Integer, Nurse> nurses) {
        if (nurses.isEmpty()) {
            return 1; 
        }
        return Collections.max(nurses.keySet()) + 1;
    }
    
    public static int incrementPatientId(HashMap<Integer, Patient> patients) {
        if (patients.isEmpty()) {
            return 1; 
        }
        return Collections.max(patients.keySet()) + 1;
    }
    
    public static HashMap<Integer, Patient> loadPatientsFromFile(String fileName) throws Exception {
    HashMap<Integer, Patient> patients = new HashMap<>();

    try (BufferedReader reader = new BufferedReader(new FileReader(fileName))) {
        String line;
        while ((line = reader.readLine()) != null) {
            String[] data = line.split(",");
            int id = Integer.parseInt(data[0].trim());
            String name = data[1];
            int age = Integer.parseInt(data[2].trim());
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

    
    public static HashMap<Integer, Nurse> loadNursesFromFile(String fileName) {
        HashMap<Integer, Nurse> nurses = new HashMap<>();

        try (BufferedReader reader = new BufferedReader(new FileReader(fileName))) {
            String line;
            while ((line = reader.readLine()) != null) {
                String[] data = line.split(",");
                int id = Integer.parseInt(data[0].trim());
                String name = data[1];
                int age = Integer.parseInt(data[2].trim());
                String gender = data[3];
                String address = data[4];
                String phone = data[5];
                String staffID = data[6];
                String department = data[7];
                String shift = data[8];
                double salary = Double.parseDouble(data[9].trim());

                Nurse nurse = new Nurse(id, name, age, gender, address, phone,
                        staffID, department, shift, salary);
                nurses.put(id, nurse);
            }
        } catch (IOException e) {
        }

        return nurses;
    }
    
    public static void saveNursesToFile(HashMap<Integer, Nurse> nurses) {
        try (FileWriter writer = new FileWriter("nurse.dat")) {
            for (Nurse nurse : nurses.values()) {
                StringBuilder sb = new StringBuilder();
                sb.append(nurse.getId()).append(",")
                        .append(nurse.getName()).append(",")
                        .append(nurse.getAge()).append(",")
                        .append(nurse.getGender()).append(",")
                        .append(nurse.getAddress()).append(",")
                        .append(nurse.getPhone()).append(",")
                        .append(nurse.getStaffId()).append(",")
                        .append(nurse.getDepartment()).append(",")
                        .append(nurse.getShift()).append(",")
                        .append(String.format("%.0f", nurse.getSalary()));
                writer.write(sb.toString());
                writer.write(System.lineSeparator());
            }
            System.out.println("Nurses saved successfully.");
        } catch (IOException e) {
            System.out.println("Failed to save nurses data!");
            e.printStackTrace();
        }
    }

    public static void savePatientsToFile(HashMap<Integer, Patient> patients) {
        DateTimeFormatter dateFormatter = DateTimeFormatter.ofPattern("dd/MM/yyyy");
        try (FileWriter writer = new FileWriter("patient.dat")) {
            for (Patient patient : patients.values()) {
                StringBuilder sb = new StringBuilder();
                sb.append(patient.getId()).append(",")
                        .append(patient.getName()).append(",")
                        .append(patient.getAge()).append(",")
                        .append(patient.getGender()).append(",")
                        .append(patient.getAddress()).append(",")
                        .append(patient.getPhone()).append(",")
                        .append(patient.getPatientId()).append(",")
                        .append(patient.getDiagnosis()).append(",")
                        .append(patient.getAdmissionDate().format(dateFormatter)).append(",")
                        .append(patient.getDischargeDate().format(dateFormatter)).append(",")
                        .append(patient.getNurseAssigned());
                writer.write(sb.toString());
                writer.write(System.lineSeparator());
            }
            System.out.println("Patients data saved successfully.");
        } catch (IOException e) {
            System.out.println("Failed to save patients data!");
        }
    }
    
    public static void displayAllData(HashMap<Integer, Patient> patients, HashMap<Integer, Nurse> nurses) {
        System.out.println("LIST OF NURSES:");
        System.out.println("---------------------------------------------------------------------------------------------------------------------------------------------");
        System.out.printf("| %-3s | %-20s | %-4s | %-5s | %-30s | %-4s | %-20s | %-7s | %-15s |%n",
                "No.", "Name", "Age", "Gender", "Address", "Staff ID", "Department", "Shift", "Salary");
        System.out.println("---------------------------------------------------------------------------------------------------------------------------------------------");
        for (Nurse nurse : nurses.values()) {
            System.out.printf("| %-3s | %-20s | %-4s | %-6s | %-30s | %-8s | %-20s | %-7s | %-15.0f |%n",
                    nurse.getId(), nurse.getName().trim(), nurse.getAge(), nurse.getGender().trim(), nurse.getAddress().trim(),
                    nurse.getStaffId().trim(), nurse.getDepartment().trim(), nurse.getShift().trim(), nurse.getSalary());
        }
        System.out.println("---------------------------------------------------------------------------------------------------------------------------------------------");

        System.out.println("\nLIST OF PATIENTS:");
        System.out.println("-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------");
        System.out.printf("| %-3s | %-10s | %-15s | %-3s | %-5s | %-30s | %-15s | %-20s | %-15s | %-20s | %-20s |%n",
                "No.", "Patient ID", "Name", "Age", "Gender", "Address", "Phone", "Diagnosis", "Admission Date", "Discharge Date", "Nurse Assigned", "Phone");
        System.out.println("-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------");
        for (Patient patient : patients.values()) {
            System.out.printf("| %-3s | %-10s | %-15s | %-3s | %-6s | %-30s | %-15s | %-20s | %-15s | %-20s | %-20s |%n",
                    patient.getId(), patient.getPatientId().trim(), patient.getName().trim(), patient.getAge(), patient.getGender().trim(), 
                    patient.getAddress().trim(), patient.getPhone(), patient.getDiagnosis().trim(),
                    patient.getAdmissionDate(), patient.getDischargeDate(), patient.getNurseAssigned().trim());
                    
        }
        System.out.println("-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------");
    }
}
