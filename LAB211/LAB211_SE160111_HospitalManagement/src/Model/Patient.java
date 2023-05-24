package Model;

import java.time.LocalDate;

/**
 *
 * @author boonie-pt
 */
public class Patient extends Person{
    private String patientId;
    private String diagnosis;
    private LocalDate admissionDate;
    private LocalDate dischargeDate;
    private String assignedNurse;

    public Patient(int id, String name, int age, String gender, String address, String phone,
                   String patientID, String diagnosis, LocalDate admissionDate, LocalDate dischargeDate, String nurseAssigned) 
    {
        super(id, name, age, gender, address, phone);
        this.patientId = patientID;
        this.diagnosis = diagnosis;
        this.admissionDate = admissionDate;
        this.dischargeDate = dischargeDate;
        this.assignedNurse = nurseAssigned;
    }

    public String getPatientId() {
        return patientId;
    }

    public void setPatientId(String patientId) {
        this.patientId = patientId;
    }

   
    public String getDiagnosis() {
        return diagnosis;
    }

    public void setDiagnosis(String diagnosis) {
        this.diagnosis = diagnosis;
    }

    public LocalDate getAdmissionDate() {
        return admissionDate;
    }

    public void setAdmissionDate(LocalDate admissionDate) {
        this.admissionDate = admissionDate;
    }

    public LocalDate getDischargeDate() {
        return dischargeDate;
    }

    public void setDischargeDate(LocalDate dischargeDate) {
        this.dischargeDate = dischargeDate;
    }

    public String getAssignedNurse() {
        return assignedNurse;
    }

    public void setAssignedNurse(String assignedNurse) {
        this.assignedNurse = assignedNurse;
    }
}
