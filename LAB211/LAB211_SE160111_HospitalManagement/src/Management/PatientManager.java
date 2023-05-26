package Management;

import Model.Nurse;
import Model.Patient;
import Utils.FileDAO;
import Utils.MyValidation;
import java.time.LocalDate;
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
    
    private static final int MAX_PATIENTS_PER_NURSE = 2;
    
    public static void displayPatients(HashMap<Integer, Patient> patients) {
        if (patients.isEmpty()){
            System.out.println("\nEMPTY PATIENT LIST!");
        }
        else {
            System.out.println("------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------");
            System.out.printf("| %-3s | %-10s | %-15s | %-3s | %-5s | %-20s | %-20s | %-15s | %-20s | %-20s | %-20s | %-15s |%n",
                  "No.", "Patient ID", "Name", "Age", "Gender", "Address", "Diagnosis", "Admission Date", "Discharge Date", "Nurse Assigned", "Address", "Phone");
            System.out.println("------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------");
            for (Patient patient : patients.values()) {
              System.out.printf("| %-3s |%-11s | %-15s | %-3s | %-6s | %-20s | %-20s | %-15s | %-20s | %-20s | %-20s | %-15s |%n",
                      patient.getId(), patient.getPatientId().trim(), patient.getName().trim(), patient.getAge(), patient.getGender().trim(), patient.getAddress().trim(),
                      patient.getDiagnosis().trim(), patient.getAdmissionDate(), patient.getDischargeDate(),
                      patient.getNurseAssigned().trim(), patient.getAddress().trim(), patient.getPhone().trim());
            }
            System.out.println("------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------");
      }
    }
    
    public static boolean isPatientIdDuplicated (HashMap<Integer, Patient> patients, String patientId){
        for (HashMap.Entry<Integer, Patient> entry : patients.entrySet()) {
            Patient patient = entry.getValue();
            String patientID = patient.getPatientId().toLowerCase().trim();
            return patientID.contains(patientId);
        }
        return false;
    }
    
    private static boolean isNurseAtMaxCapacity(String nurseAssigned, HashMap<Integer, Patient> patients) {
        int count = 0;
        for (Patient patient : patients.values()) {
            if (patient.getNurseAssigned().equals(nurseAssigned)) {
                count++;
            }
        }
        return count >= MAX_PATIENTS_PER_NURSE;
    }
    
    public static void addPatient(HashMap<Integer, Patient> patients, HashMap<Integer,Nurse> nurses) throws Exception {
        Scanner sc = new Scanner(System.in);
        
        boolean continueAdding = true;
        int nextId = FileDAO.incrementPatientId(patients);
        int id = nextId++;
        String name = "";
        int age = 0;
        String gender = "";
        String address = "";
        String phone = "";
        String patientId = "";
        String diagnosis = "";
        LocalDate admissionDate = null;
        LocalDate dischargeDate = null;
        String nurseAssigned = "";
        
        while (continueAdding) {
            System.out.println("\nAdd a new patient");
            System.out.println("-------------------------------");
            
            //ID auto incremental
            System.out.println("ID: " + id);

            boolean validName = false;
            while (!validName){
                System.out.print("Name: ");
                name = sc.nextLine().trim();
                if (name.equals("")) {
                    System.out.println("Name must not be null!");
                    continue;
                }
                 else if (MyValidation.isNumeric(name)){
                System.out.println("Name cannot be number!");
                continue; 
            }
                validName = true;
            }
            
            boolean validAge = false;
            while (!validAge) {
                try {
                    System.out.print("Age: ");
                    age = Integer.parseInt(sc.nextLine().trim());
                    //Check positive age or not 
                    if (age <= 0) {
                        System.out.println("Age must be a positive number!");
                    } else if (Integer.toString(age).equals("")) {
                        System.out.println("Age must not be null!");
                    }
                    validAge = true;
                } catch (NumberFormatException e) {
                    System.out.println("Invalid input. Age must be a number!");
                    validAge = false;
                }
            }
            
            boolean validGender = false;
            while (!validGender){
                System.out.print("Gender: ");
                gender = sc.nextLine().trim();
                if (gender.equals("")) {
                    System.out.println("Gender must not be null!");
                    continue;
                }
                validGender = true;
            }
            
            
            boolean validAddress = false;
            while (!validAddress){
                System.out.print("Address: ");
                address = sc.nextLine().trim();
                if (address.equals("")) {
                    System.out.println("Address must not be null!");
                    continue;
                }
                validAddress = true;
            }
            
            boolean validPhone = false;
            while (!validPhone){
                System.out.print("Phone: ");
                phone = sc.nextLine().trim();
                if (phone.equals("")) {
                    System.out.println("Phone must not be null!");
                    continue;
                }
                else if (!MyValidation.isPhone(phone)) {
                System.out.println("Invalid phone format. Please enter a valid phone number.");
                continue; 
                }
                validPhone = true;
            }
            
            boolean validPatientId = false;
            while (!validPatientId){
                System.out.print("Patient ID: ");
                patientId = sc.nextLine().trim();
                if (patientId.equals("")) {
                    System.out.println("Patient ID must not be null.");
                    continue;
                }
                else if (isPatientIdDuplicated(patients, patientId)) {
                    System.out.println("The patient ID already exists. Please enter a unique patient ID.");
                    continue; 
                }
                validPatientId = true;
            }
            
            
            boolean validDiagnosis = false;
            while (!validDiagnosis){
                System.out.print("Diagnosis: ");
                diagnosis = sc.nextLine().trim();
                if (diagnosis.equals("")) {
                    System.out.println("Diagnosis must not be null.");
                    continue;
                } 
                validDiagnosis= true;
            }

            boolean validAdmissionDate = false;
            while (!validAdmissionDate) {
                try {
                    System.out.print("Admission date: ");
                    String admissionDateString = sc.nextLine();
                    admissionDate = MyValidation.checkDate(admissionDateString);

                    LocalDate year2000 = LocalDate.of(2000, 1, 1);
                    if (admissionDate.isBefore(year2000)) {
                        throw new IllegalArgumentException("Admission date must be on or after January 1st, 2000.");
                    }

                    validAdmissionDate = true;
                } catch (DateTimeParseException e) {
                    System.out.println("Invalid date format. Please enter the date in the format dd/MM/yyyy.");
                } catch (IllegalArgumentException e) {
                    System.out.println(e.getMessage());
                }
            }

            boolean validDischargeDate = false;
            while (!validDischargeDate) {
                try {
                    System.out.print("Discharge date: ");
                    String dischargeDateString = sc.nextLine();
                    dischargeDate = MyValidation.checkDate(dischargeDateString);

                    if (dischargeDate.isBefore(admissionDate)) {
                        throw new IllegalArgumentException("Discharge date must not be before the admission date.");
                    }

                    validDischargeDate = true;
                } catch (DateTimeParseException e) {
                    System.out.println("Invalid date format. Please enter the date in the format dd/MM/yyyy.");
                } catch (IllegalArgumentException e) {
                    System.out.println(e.getMessage());
                }
            }
            
            System.out.println("Available nurses:");
            NurseManager.displayNurses(nurses);
            
            boolean validNurse = false;
            while (!validNurse){
                System.out.print("Nurse assigned: ");
                nurseAssigned = sc.nextLine().trim();
                if (nurseAssigned.equals("")) {
                    System.out.println("Nurse assigned must not be null!");
                    continue;
                }
                else if (!NurseManager.isNurseNameDuplicated(nurses, nurseAssigned)) {
                    System.out.println("Invalid nurse assigned. Please select a nurse from the available nurses.");
                    continue;
                }
                else if (isNurseAtMaxCapacity(nurseAssigned, patients)) {
                    System.out.println("The nurse is already assigned to the maximum number of patients.");
                    continue;
                }
                validNurse = true;
            }

            Patient patient = new Patient(id, name, age, gender, address, phone, patientId, diagnosis, admissionDate, dischargeDate, nurseAssigned);

            patients.put(id, patient);

            System.out.println("Paitent added successfully! Updated patients list:");
            displayPatients(patients);
            
            System.out.print("Do you want to add another patient? (yes/no): ");
            String choice = sc.nextLine().trim();
            if (!choice.equalsIgnoreCase("yes")) {
                continueAdding = false;
            }
        }
    }
    
    public static void testNurse(HashMap<Integer, Patient> patients, HashMap<Integer,Nurse> nurses) {
        Scanner sc = new Scanner(System.in);
        
        System.out.println("Available nurses:");
        NurseManager.displayNurses(nurses);
        String nurseAssigned = "";
        boolean validNurse = false;
            while (!validNurse){
                System.out.print("Nurse assigned: ");
                nurseAssigned = sc.nextLine().trim();
                if (nurseAssigned.equals("")) {
                    System.out.println("Nurse assigned must not be null!");
                    continue;
                }
                else if (!NurseManager.isNurseNameDuplicated(nurses, nurseAssigned)) {
                    System.out.println("Invalid nurse assigned. Please select a nurse from the available nurses.");
                    continue;
                }
                else if (isNurseAtMaxCapacity(nurseAssigned, patients)) {
                    System.out.println("The nurse is already assigned to the maximum number of patients.");
                    continue;
                }
                validNurse = true;
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
    
    public static HashMap<Integer, Patient> sortPatientsByTypeAndOrder(HashMap<Integer, Patient> patients) {
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
            sortedEntries.sort(Comparator.comparing(entry -> entry.getValue().getPatientId()));
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
