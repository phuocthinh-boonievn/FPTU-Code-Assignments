package Management;

import Model.Nurse;
import Model.Patient;
import Utils.MyValidation;
import java.util.Collections;
import java.util.HashMap;
import java.util.Map;
import java.util.Scanner;

/**
 *
 * @author boonie-pt
 */
public class NurseManager {
    public static void displayNurses(HashMap<Integer, Nurse> nurses) {
        System.out.println("-----------------------------------------------------------------------------------------------------------------------------------");
        System.out.printf("| %-3s | %-20s | %-4s | %-5s | %-20s | %-4s | %-20s | %-7s | %-15s |%n",
                "No.", "Name", "Age", "Gender", "Address", "Staff ID", "Department", "Shift", "Salary");
        System.out.println("-----------------------------------------------------------------------------------------------------------------------------------");
        for (Nurse nurse : nurses.values()) {
            System.out.printf("| %-3s | %-20s | %-4s | %-5s | %-20s | %-9s | %-20s | %-7s | %-15.0f |%n",
                    nurse.getId(), nurse.getName().trim(), nurse.getAge(), nurse.getGender(), nurse.getAddress(),
                    nurse.getStaffId(),nurse.getDepartment().trim(), nurse.getShift().trim(), nurse.getSalary());
        }
        System.out.println("-----------------------------------------------------------------------------------------------------------------------------------");
    }
    
    public static boolean isStaffIdDuplicated (HashMap<Integer, Nurse> nurses, String staffID){
        for (HashMap.Entry<Integer, Nurse> entry : nurses.entrySet()) {
            Nurse nurse = entry.getValue();
            String nurseStaffId = nurse.getStaffId().toLowerCase().trim();
            return nurseStaffId.contains(staffID);
        }
        return false;
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
    
    public static void addNurse(HashMap<Integer, Nurse> nurses) {
        Scanner sc = new Scanner(System.in);
        
        boolean continueAdding = true;
        int nextId = getNextNurseId(nurses);
        int id = nextId++;
        int age = 0;
        String gender = "";
        String shift = "";
        String address = "";
        String phone = "";
        String staffId = "";
        String department = "";
        double salary = 0;
        
        while (continueAdding) {
            System.out.println("\nAdd a new nurse");
            System.out.println("-------------------------------");
            
            //ID auto incremental
            System.out.println("ID: " + id);

            System.out.print("Name: ");
            String name = sc.nextLine().trim();
            if (name.equals("")) {
                System.out.println("Name must not be null!");
                continue; 
            }
            else if (MyValidation.isNumeric(name)){
                System.out.println("Name cannot be number!");
                continue; 
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
            
            boolean validStaffId = false;
            while (!validStaffId){
                System.out.print("Staff ID: ");
                staffId = sc.nextLine().trim();
                if (staffId.equals("")) {
                    System.out.println("Staff ID must not be null.");
                    continue;
                }
                else if (isStaffIdDuplicated(nurses, staffId)) {
                    System.out.println("The staff ID is already in use. Please enter a unique staff ID.");
                    continue; 
                }
                validStaffId = true;
            }
            
            
            boolean validDepartment = false;
            while (!validDepartment){
                System.out.print("Department: ");
                department = sc.nextLine().trim();
                if (department.equals("")) {
                    System.out.println("Department must not be null.");
                    continue;
                } else if (department.length() < 3 || department.length() > 50) {
                    System.out.println("Department length must be between 3 and 50 characters.");
                    continue;
                }
                validDepartment= true;
            }

            boolean validShift = false;
            while (!validShift){
                System.out.print("Shift: ");
                shift = sc.nextLine().trim();
                if (shift.equals("")) {
                    System.out.println("Shift must not be null.");
                    continue;
                }
                validShift = true;
            }
            
            
            boolean validSalary = false;
            while (!validSalary) {
                try {
                    System.out.print("Salary: ");
                    salary = Double.parseDouble(sc.nextLine().trim());
                    //Check positive age or not 
                    if (salary <= 0) {
                        System.out.println("Salary must be a positive number.");
                    } else if (Double.toString(salary).equals("")) {
                        System.out.println("Salary must not be null.");
                    }
                    validSalary = true;
                } catch (NumberFormatException e) {
                    System.out.println("Invalid input. Salary must be a number.");
                    validSalary = false;
                }
            }

            Nurse nurse = new Nurse(id, name, age, gender, address, phone, staffId, department, shift, salary);

            nurses.put(id, nurse);

            System.out.println("Nurse added successfully! Updated nurses list:");
            displayNurses(nurses);
            
            System.out.print("Do you want to add another nurse? (yes/no): ");
            String choice = sc.nextLine().trim();
            if (!choice.equalsIgnoreCase("yes")) {
                continueAdding = false;
            }
        }
    }
    
    public static void updateNurse(HashMap<Integer, Nurse> nurses) {
        Scanner sc = new Scanner(System.in);
        System.out.print("Enter staff ID of the nurse to update: ");
        String staffId = sc.nextLine().trim().toLowerCase();

        boolean nurseExists = false;
        boolean continuteUpdate = false;
        boolean validSalary = false;
//        while (continueAdding) {
//            
//        }
        for (HashMap.Entry<Integer, Nurse> entry : nurses.entrySet()) {
            Nurse nurse = entry.getValue();
            String originalNurse = nurse.getStaffId().trim();
            try {
                if (originalNurse.equalsIgnoreCase(staffId)) {
                nurseExists = true;
                
                System.out.print("Enter nurse "+ originalNurse +"'s new name:");
                String newName = sc.nextLine().trim();
                nurse.setName(newName);
                
                System.out.print("Enter nurse "+ originalNurse +"'s new age:");
                int newAge = Integer.parseInt(sc.nextLine().trim());
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
            } catch(Exception e){
                System.out.println("Failed to update nurse!");
                MyValidation.getEnter("Press Enter to enter again...");
            }
            
        }
        if (!nurseExists) {
            System.out.println("The nurse does not exist.");
        }
    }
    
    public static void deleteNurse(HashMap<Integer, Nurse> nurses, HashMap<Integer, Patient> patients) {
        Scanner scanner = new Scanner(System.in);
        System.out.println("\nNURSES LIST:");
        displayNurses(nurses);
        System.out.print("Enter the staff ID of the nurse to delete: ");
        String staffId = scanner.nextLine().trim().toLowerCase();

        boolean nurseExists = false;
        int nurseIdToDelete = -1;

        // Check if the nurse exists 
        for (Map.Entry<Integer, Nurse> entry : nurses.entrySet()) {
            if (entry.getValue().getStaffId().trim().toLowerCase().equals(staffId)) {
                nurseExists = true;
                nurseIdToDelete = entry.getKey();
                break;
            }
        }

        if (nurseExists) {
            Nurse nurse = nurses.get(nurseIdToDelete);

            // Check if the nurse is assigned in patients (nurse name exists in patients)
            boolean hasTasks = false;
            for (Patient patient : patients.values()) {
                if (patient.getAssignedNurse().trim().equalsIgnoreCase(nurse.getName().trim())) {
                    hasTasks = true;
                    break;
                }
            }

            if (hasTasks) {
                System.out.println("Cannot delete the nurse. She/he is already assigned to a patient.");
            } else {
                // Confirmation message
                System.out.println("Are you sure you want to delete the nurse? (y/n): ");
                String choice = scanner.nextLine().trim();

                if (choice.equalsIgnoreCase("yes") || choice.equalsIgnoreCase("y")) {
                    nurses.remove(nurseIdToDelete);
                    System.out.println("Nurse deleted successfully! Updated list:");
                    displayNurses(nurses);
                } else {
                    System.out.println("Deletion canceled.");
                }
            }
        } else {
            System.out.println("The nurse does not exist.");
        }
    }
   
    public static int getNextNurseId(HashMap<Integer, Nurse> nurses) {
        if (nurses.isEmpty()) {
            return 1; 
        }
        return Collections.max(nurses.keySet()) + 1;
    }
}
