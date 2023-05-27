package Manager;

import Model.Nurse;
import Model.Patient;
import Utils.FileDAO;
import Utils.MyValidation;
import java.util.HashMap;
import java.util.Map;
import java.util.Scanner;

/**
 *
 * @author boonie-pt
 */
public class NurseManager {
    public static void displayNurses(HashMap<Integer, Nurse> nurses) {
        System.out.println("-----------------------------------------------------------------------------------------------------------------------------------------------------");
        System.out.printf("| %-3s | %-25s | %-4s | %-5s | %-30s | %-4s | %-20s | %-15s | %-15s |%n",
                "No.", "Name", "Age", "Gender", "Address", "Staff ID", "Department", "Shift", "Salary");
        System.out.println("----------------------------------------------------------------------------------------------------------------------------------------------------");
        for (Nurse nurse : nurses.values()) {
            System.out.printf("| %-3s | %-25s | %-4s | %-6s | %-30s | %-8s | %-20s | %-15s | %-15.0f |%n",
                    nurse.getId(), nurse.getName().trim(), nurse.getAge(), nurse.getGender().trim(), nurse.getAddress().trim(),
                    nurse.getStaffId().trim(), nurse.getDepartment().trim(), nurse.getShift().trim(), nurse.getSalary());
        }
        System.out.println("----------------------------------------------------------------------------------------------------------------------------------------------------");
    }
    
    public static boolean isStaffIdDuplicated(HashMap<Integer, Nurse> nurses, String staffID){
        for (HashMap.Entry<Integer, Nurse> entry : nurses.entrySet()) {
            Nurse nurse = entry.getValue();
            String nurseStaffId = nurse.getStaffId().toLowerCase().trim();
            return nurseStaffId.contains(staffID.toLowerCase().trim());
        }
        return false;
    }
    
    public static boolean isNurseNameDuplicated(HashMap<Integer, Nurse> nurses, String name){
        for (HashMap.Entry<Integer, Nurse> entry : nurses.entrySet()) {
            Nurse nurse = entry.getValue();
            String nurseName = nurse.getName().trim();
            return nurseName.contains(name);
        }
        return false;
    }
    
    public static HashMap<Integer,Nurse> searchNurseByName(HashMap<Integer, Nurse> nurses){
        System.out.print("LIST OF NURSES: ");
        displayNurses(nurses);
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
        int nextId = FileDAO.incrementNurseId(nurses);
        int id = nextId++;
        String name = "";
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
                        continue;
                    } 
                    else if (age < 18 || age >= 66) {
                        System.out.println("Age must be equal or larger than 18 and equal or less than 65!");
                        continue;
                    } 
                    else if (Integer.toString(age).equals("")) {
                        System.out.println("Age must not be null!");
                        continue;
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
                } 
                else if (department.length() < 3 || department.length() > 50) {
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
                        continue;
                    }
                    else if (salary <= 1000000){
                        System.out.println("Salary too low.");
                        continue;
                    }
                    else if (Double.toString(salary).equals("")) {
                        System.out.println("Salary must not be null.");
                        continue;
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
            if (choice.equalsIgnoreCase("yes") || choice.equalsIgnoreCase("y")) {
                id = ++id;
                continueAdding = true;
            }
            else continueAdding = false;
        }
    }
    
    public static void updateNurse(HashMap<Integer, Nurse> nurses) {
        Scanner sc = new Scanner(System.in);
        System.out.print("Enter staff ID of the nurse to update: ");
        String staffId = sc.nextLine().trim().toLowerCase();

        boolean nurseExists = false;
        for (HashMap.Entry<Integer, Nurse> entry : nurses.entrySet()) {
            Nurse nurse = entry.getValue();
            String originalNurse = nurse.getStaffId().trim();
            try {
                if (originalNurse.equalsIgnoreCase(staffId)) {
                    nurseExists = true;
                    
                    boolean validName = false;
                    while (!validName){
                        System.out.print("Enter nurse "+ originalNurse +"'s new name (press x to skip):");
                        String newName = sc.nextLine().trim();
                        if (newName.equals("x")) {
                            System.out.println("Skipped updating nurse's name.");
                            break;
                        }
                        else if (newName.equals("") || newName.isEmpty()){
                            System.out.println("Name must not be null.");
                            continue;
                        }
                        else if (MyValidation.isNumeric(newName)){
                            System.out.println("Nurse name cannot be number!");
                            continue;
                        }
                        nurse.setName(newName);
                        validName = true;
                        System.out.println("Name updated!");
                    }
                    boolean validAge = false;
                    while (!validAge) {
                        try {
                            System.out.print("Enter nurse "+ originalNurse +"'s new age (press x to skip):");
                            String input = sc.nextLine().trim();

                            if (input.equalsIgnoreCase("x")) {
                                System.out.println("Skipped updating nurse's age.");
                                break;
                            }

                            int newAge = Integer.parseInt(input);
                            if (newAge <= 0) {
                                System.out.println("Age must be a positive number!");
                                continue;
                            }
                            else if (newAge <18 || newAge > 66){
                                System.out.println("Age must be equal or larger than 18 and equal or less than 65!");
                                continue;
                            }
                            nurse.setAge(newAge);
                            validAge = true;
                        } catch (NumberFormatException e) {
                            System.out.println("Invalid input. Age must be a number!");
                            validAge = false;
                        }
                    }
                    boolean validGender = false;
                    while (!validGender){
                        System.out.print("Enter nurse "+ originalNurse +"'s new gender (press x to skip):");
                        String newGender = sc.nextLine().trim();
                        if (newGender.equals("x")) {
                            System.out.println("Skipped updating nurse's gender.");
                            break;
                        }
                        else if (newGender.equals("") || newGender.isEmpty()){
                            System.out.println("Gender must not be null.");
                            continue;
                        }
                        else if (MyValidation.isNumeric(newGender)){
                            System.out.println("Gender cannot be number!");
                            continue;
                        }
                        nurse.setGender(newGender);
                        validGender = true;
                        System.out.println("Gender updated!");
                    }
                    
                    boolean validAddress = false;
                    while (!validAddress){
                        System.out.print("Enter nurse "+ originalNurse +"'s new address (press x to skip):");
                        String newAddress = sc.nextLine().trim();
                        if (newAddress.equals("x")) {
                            System.out.println("Skipped updating nurse's address.");
                            break;
                        }
                        else if (newAddress.equals("") || newAddress.isEmpty()){
                            System.out.println("Address must not be null.");
                            continue;
                        }
                        nurse.setAddress(newAddress);
                        validAddress = true;
                        System.out.println("Address updated!");
                    }
                    boolean validPhone = false;
                    while (!validPhone){
                        System.out.print("Enter nurse "+ originalNurse +"'s new phone (press x to skip):");
                        String newPhone = sc.nextLine().trim();
                        if (newPhone.equals("x")) {
                            System.out.println("Skipped updating nurse's address.");
                            break;
                        }
                        else if (newPhone.equals("")) {
                            System.out.println("Phone must not be null!");
                            continue;
                        }
                        else if (!MyValidation.isPhone(newPhone)) {
                            System.out.println("Invalid phone format. Please enter a valid phone number.");
                            continue; 
                        }
                        nurse.setPhone(newPhone);
                        validPhone = true;
                        System.out.println("Phone updated!");
                    }
                    boolean validDepartment = false;
                    while (!validDepartment){
                        System.out.print("Enter nurse "+ originalNurse +"'s new department (press x to skip):");
                        String newDepartment = sc.nextLine().trim();
                        if (newDepartment.equals("x")){
                            System.out.println("Skipped updating nurse's department.");
                            break;
                        }
                        else if (newDepartment.equals("")) {
                            System.out.println("Department must not be null.");
                            continue;
                        } else if (newDepartment.length() < 3 || newDepartment.length() > 50) {
                            System.out.println("Department length must be between 3 and 50 characters.");
                            continue;
                        }
                        nurse.setDepartment(newDepartment);
                        validDepartment= true;
                        System.out.println("Department updated!");
                    }

                    boolean validShift = false;
                    while (!validShift){
                        System.out.print("Enter nurse "+ originalNurse +"'s new shift (press x to skip):");
                        String newShift = sc.nextLine().trim();
                        if (newShift.equals("x")){
                            System.out.println("Skipped updating nurse's shift.");
                            break;
                        }
                        else if (newShift.equals("")) {
                            System.out.println("Shift must not be null.");
                            continue;
                        }
                        nurse.setShift(newShift);
                        validShift = true;
                        System.out.println("Shift updated!");
                    }

                    boolean validSalary = false;
                    while (!validSalary) {
                        try {
                            System.out.print("Enter nurse "+ originalNurse +"'s new salary (press x to skip):");
                            String input = sc.nextLine().trim();
                            if (input.equalsIgnoreCase("x")) {
                                System.out.println("Skipped updating nurse's age.");
                                break;
                            }
                            double newSalary = Double.parseDouble(input);
                            //Check positive age or not 
                            if (newSalary <= 0) {
                                System.out.println("Salary must be a positive number.");
                                continue;
                            } 
                            else if (newSalary <= 1000000){
                                System.out.println("Salary too low.");
                                continue;
                            }
                            else if (Double.toString(newSalary).equals("")) {
                                System.out.println("Salary must not be null.");
                                continue;
                            }
                            nurse.setSalary(newSalary);
                            validSalary = true;
                            System.out.println("Salary updated!");
                        } catch (NumberFormatException e) {
                            System.out.println("Invalid input. Salary must be a number.");
                            validSalary = false;
                        }
                    }
                    System.out.println("Finished updating nurse! Updated nurses list:");
                    displayNurses(nurses);
                    break;
                }
            } catch(NumberFormatException e){
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

            boolean hasTasks = false;
            for (Patient patient : patients.values()) {
                if (patient.getNurseAssigned().trim().equalsIgnoreCase(nurse.getName().trim())) {
                    hasTasks = true;
                    break;
                }
            }

            if (hasTasks) {
                System.out.println("Cannot delete the nurse. She/he is already assigned to a patient.");
            } else {
                // Confirmation message
                System.out.println("Are you sure you want to delete the nurse? (yes/no): ");
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
   
    
}
