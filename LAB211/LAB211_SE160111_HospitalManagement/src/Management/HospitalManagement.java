package Management;

import Model.Patient;
import Model.Nurse;
import Management.PatientManager;
import Management.NurseManager;
import Utils.Menu;
import Utils.FileDAO;
import java.util.Scanner;
import java.util.HashMap;
/**
 *
 * @author boonie-pt
 */
public class HospitalManagement {
    final static String FILE_PATIENT = "patient.dat";
    final static String FILE_NURSE = "nurse.dat";
    
    public static void main(String[] args) throws Exception {
        
        // TODO code application logic here
        Menu menu = new Menu();
        menu.add("HOSPITAL MANAGEMENT");
        menu.add("A. Nurse's management");
        menu.add("  1. Create a nurse");
        menu.add("  2. Find a nurse");
        menu.add("  3. Update a nurse");
        menu.add("  4. Delete a nurse  ");
        menu.add("B. Patient's management");
        menu.add("  5. Add a patient");
        menu.add("  6. Display patients");
        menu.add("  7. Sort the patients list");
        menu.add("C. Data management");
        menu.add("  8. Save data");
        menu.add("  9. Load data");
        menu.add("Others - Exit");
        
        HashMap<Integer, Patient> patients = FileDAO.loadPatients(FILE_PATIENT);
        HashMap<Integer, Nurse> nurses = FileDAO.loadNurses(FILE_NURSE);
        
        
        int choice = 0;
        boolean cont = true;
        do{
            choice = menu.getUserChoice();
            switch (choice) {
                case 1:
                    NurseManager.addNurse(nurses);
                    break;
                case 2:
                    HashMap<Integer, Nurse> searchedNurses = NurseManager.searchNurseByName(nurses);
                    System.out.println("\nSEARCHED NURSES LIST:");
                    NurseManager.displayNurses(searchedNurses);
                    break;
                case 3:
                    NurseManager.updateNurse(nurses);
                    break;
                case 4:
                    NurseManager.deleteNurse(nurses, patients);
                    break;
                case 5:
                    FileDAO.displayAllData(patients, nurses);
                    break;
                case 6:
                    HashMap<Integer, Patient> filteredPatients = PatientManager.filterPatientsByDateRange(patients);
                    HashMap<Integer, Patient> admissionPatientsList = PatientManager.sortPatientsByAdmissionDate(filteredPatients);
                    System.out.println("\nPATIENT LIST BY ADMISSION DATE:");
                    PatientManager.displayPatients(admissionPatientsList);
                    break;
                case 7:
                    HashMap<Integer, Patient> sortedPatientsList = PatientManager.getUserSortPreferences(patients);
                    System.out.println("\nSORTED PATIENT LIST:");
                    PatientManager.displayPatients(sortedPatientsList);
                    break;
                case 8:
                    FileDAO.displayAllData(patients, nurses);
                    break;
                case 9:
                    FileDAO.displayAllData(patients, nurses);
                    break;
                default:
                    System.out.println("\nPATIENT LIST:");
                    Scanner sc = new Scanner(System.in);
                    System.out.println("Do yo really want to exit the application?");
                    String input = sc.nextLine();
                    if (input.equals("yes") || input.equals("y")) {
                        cont = false;
                        break;
                    }
                    else {
                        cont = true;
                    }
            }
        }
        while (cont == true);
    }
}