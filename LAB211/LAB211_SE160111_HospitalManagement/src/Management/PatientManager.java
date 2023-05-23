package Management;

import Model.Patient;
import Utils.MyValidation;
import java.time.LocalDate;
import java.time.format.DateTimeFormatter;
import java.time.format.DateTimeParseException;
import java.util.ArrayList;
import java.util.Collections;
import java.util.Comparator;
import java.util.HashMap;
import java.util.LinkedHashMap;
import java.util.List;
import java.util.Map;
import java.util.Scanner;

/**
 *
 * @author boonie-pt
 */
public class PatientManager {
    public static void displayPatients(HashMap<Integer, Patient> patients) {
        if (patients.isEmpty()){
            System.out.println("\nNO VALID PATIENT!");
        }
        else {
            DateTimeFormatter dateFormatter = DateTimeFormatter.ofPattern("dd/MM/yyyy");

            System.out.println("\nPATIENT DATA:");
            System.out.println("------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------");
            System.out.printf("| %-3s | %-10s | %-15s | %-3s | %-5s | %-20s | %-20s | %-15s | %-20s | %-20s | %-20s | %-15s |%n",
                     "No.","Patient ID", "Name", "Age", "Gender", "Address", "Diagnosis", "Admission Date", "Discharge Date", "Nurse Assigned", "Address", "Phone");
            System.out.println("------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------");
            for (Patient patient : patients.values()) {
                System.out.printf("| %-3s |%-11s | %-15s | %-3s | %-6s | %-20s | %-20s | %-15s | %-20s | %-20s | %-20s | %-15s |%n",
                        patient.getId(),patient.getPatientID(), patient.getName(), patient.getAge(), patient.getGender(), patient.getAddress(),
                        patient.getDiagnosis(), patient.getAdmissionDate(), patient.getDischargeDate(),
                        patient.getNurseAssigned(), patient.getAddress(), patient.getPhone());
            }
            System.out.println("------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------");
        }
    }
    
    public static HashMap<Integer, Patient> filterPatientsByDateRange(HashMap<Integer, Patient> patients) throws Exception {
        Scanner sc = new Scanner(System.in);
        LocalDate startDate = null;
        LocalDate endDate = null;

        boolean validInput = false;

        while (!validInput) {
            try {
                System.out.print("Enter the start date (admission date): ");
                String startDateString = sc.nextLine();
                startDate = MyValidation.checkDate(startDateString);

                LocalDate year2000 = LocalDate.of(2000, 1, 1);
                if (startDate.isBefore(year2000)) {
                    throw new IllegalArgumentException("Start date must be on or after January 1, 2000.");
                }

                validInput = true;
            } catch (DateTimeParseException e) {
                System.out.println("Invalid date format. Please enter the date in the format dd/MM/yyyy.");
            } catch (IllegalArgumentException e) {
                System.out.println(e.getMessage());
            }
        }

        validInput = false;

        while (!validInput) {
            try {
                System.out.print("Enter the end date (admission date): ");
                String endDateString = sc.nextLine();
                endDate = MyValidation.checkDate(endDateString);

                if (endDate.isBefore(startDate)) {
                    throw new IllegalArgumentException("End date must not be before the start date.");
                }

                validInput = true;
            } catch (DateTimeParseException e) {
                System.out.println("Invalid date format. Please enter the date in the format dd/MM/yyyy.");
            } catch (IllegalArgumentException e) {
                System.out.println(e.getMessage());
            }
        }
        HashMap<Integer, Patient> filteredPatients = new HashMap<>();

        for (Map.Entry<Integer, Patient> entry : patients.entrySet()) {
            Patient patient = entry.getValue();
            LocalDate admissionDate = patient.getAdmissionDate();
            if (admissionDate.isEqual(startDate) || admissionDate.isEqual(endDate) || (admissionDate.isAfter(startDate) && admissionDate.isBefore(endDate))) {
                filteredPatients.put(entry.getKey(), patient);
            }
        }
        
        return sortPatientsByAdmissionDate(filteredPatients);
    }

    public static HashMap<Integer, Patient> sortPatientsByAdmissionDate(HashMap<Integer, Patient> patients) {
        List<Map.Entry<Integer, Patient>> sortedEntries = new ArrayList<>(patients.entrySet());

        Collections.sort(sortedEntries, Comparator.comparing(entry -> entry.getValue().getAdmissionDate()));

        HashMap<Integer, Patient> sortedPatients = new LinkedHashMap<>();
        for (Map.Entry<Integer, Patient> entry : sortedEntries) {
            sortedPatients.put(entry.getKey(), entry.getValue());
        }

        return sortedPatients;
    }
    
    public static HashMap<Integer, Patient> getUserSortPreferences(HashMap<Integer, Patient> patients) {
        Scanner sc = new Scanner(System.in);
        String  sortField = "";
        boolean validSortField = false;
        while (!validSortField) {
            System.out.print("Enter the sort type (patient ID or patient's name): ");
            sortField = sc.nextLine().trim().toLowerCase();
            if (sortField.equalsIgnoreCase("id") || sortField.equalsIgnoreCase("name")) {
                validSortField = true;
            } else {
                System.out.println("Invalid sort type. Please enter either 'ID' or 'name'.");
            }
        }

        String sortOrder = "";
        boolean validSortOrder = false;
        while (!validSortOrder) {
            System.out.print("Enter the sort order (ASC or DESC): ");
            sortOrder = sc.nextLine().trim().toLowerCase();
            if (sortOrder.equalsIgnoreCase("asc") || sortOrder.equalsIgnoreCase("desc")) {
                validSortOrder = true;
            } else {
                System.out.println("Invalid sort order. Please enter either 'ASC' or 'DESC'.");
            }
        }

        // Sort patients based on the user's input
        return sortPatients(patients, sortField, sortOrder);
    }
    
    public static HashMap<Integer, Patient> sortPatients(HashMap<Integer, Patient> patients, String sortField, String sortOrder) {
        List<Map.Entry<Integer, Patient>> sortedEntries = new ArrayList<>(patients.entrySet());

        if (sortField.equalsIgnoreCase("patient ID")) {
            sortedEntries.sort(Comparator.comparing(entry -> entry.getValue().getPatientID()));
        } else if (sortField.equalsIgnoreCase("name")) {
            sortedEntries.sort(Comparator.comparing(entry -> entry.getValue().getName()));
        }

        if (sortOrder.equalsIgnoreCase("DESC")) {
            Collections.reverse(sortedEntries);
        }

        LinkedHashMap<Integer, Patient> sortedPatients = new LinkedHashMap<>();
        for (Map.Entry<Integer, Patient> entry : sortedEntries) {
            sortedPatients.put(entry.getKey(), entry.getValue());
        }

        return sortedPatients;
    }
    
}
