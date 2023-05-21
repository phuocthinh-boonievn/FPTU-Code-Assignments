/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package Management;

import Model.Patient;
import java.time.LocalDate;
import java.time.format.DateTimeFormatter;
import java.util.ArrayList;
import java.util.Comparator;
import java.util.HashMap;
import java.util.List;

/**
 *
 * @author PC
 */
public class PatientManager {
    public static void displayPatients(List<Patient> patients) {
        if (patients.isEmpty()){
            System.out.println("\nNO VALID PATIENT!");
        }
        else {
            DateTimeFormatter dateFormatter = DateTimeFormatter.ofPattern("dd/MM/yyyy");

            System.out.println("\nPATIENT DATA:");
            System.out.println("--------------------------------------------------------------------------------------------------------------------");
            System.out.printf("| %-3s | %-10s | %-15s | %-3s | %-5s | %-20s | %-15s | %-20s | %-20s | %-20s | %-15s |%n",
                    "No", "PatientID", "Name", "Age", "Gender", "Diagnosis", "Admission Date", "Discharge Date", "Nurse Assigned", "Address", "Phone");
            System.out.println("--------------------------------------------------------------------------------------------------------------------");
            for (Patient patient : patients) {
                String admissionDate = patient.getAdmissionDate().format(dateFormatter);
                String dischargeDate = patient.getDischargeDate().format(dateFormatter);
                System.out.printf("| %-3s |%-10s | %-15s | %-3s | %-5s | %-20s | %-15s | %-20s | %-20s | %-20s | %-15s |%n",
                        patient.getId(), patient.getPatientID(), patient.getName(), patient.getAge(), patient.getGender(),
                        patient.getDiagnosis(), admissionDate, dischargeDate,
                        patient.getNurseAssigned(), patient.getAddress(), patient.getPhone());
            }
        }
        System.out.println("--------------------------------------------------------------------------------------------------------------------");

    }
    
    public static List<Patient> filterPatientsByDateRange(HashMap<Integer, Patient> patients, LocalDate startDate, LocalDate endDate) {
        List<Patient> filteredPatients = new ArrayList<>();

        for (Patient patient : patients.values()) {
            LocalDate admissionDate = patient.getAdmissionDate();
            if (admissionDate.isEqual(startDate) || admissionDate.isEqual(endDate) || (admissionDate.isAfter(startDate) && admissionDate.isBefore(endDate))  ) {
                filteredPatients.add(patient);
            }
        }

        return filteredPatients;
    }

    public static void sortPatientsByAdmissionDate(List<Patient> patients) {
        patients.sort(Comparator.comparing(Patient::getAdmissionDate));
    }
}
