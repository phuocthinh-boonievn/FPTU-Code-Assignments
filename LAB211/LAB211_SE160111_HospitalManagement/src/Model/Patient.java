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
    private String nurseAssigned;

    public Patient(int id, String name, int age, String gender, String address, String phone,
                   String patientID, String diagnosis, LocalDate admissionDate, LocalDate dischargeDate, String nurseAssigned) 
    {
        super(id, name, age, gender, address, phone);
        this.patientId = patientID;
        this.diagnosis = diagnosis;
        this.admissionDate = admissionDate;
        this.dischargeDate = dischargeDate;
        this.nurseAssigned = nurseAssigned;
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

    public String getNurseAssigned() {
        return nurseAssigned;
    }

    public void setNurseAssigned(String nurseAssigned) {
        this.nurseAssigned = nurseAssigned;
    }
}
