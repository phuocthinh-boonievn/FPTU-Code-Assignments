package Model;

/**
 *
 * @author boonie-pt
 */
public class Nurse extends Person{
    private String staffID;
    private String department;
    private String shift;
    private double salary;

    public Nurse(int id, String name, int age, String gender, String address, String phone,
                 String staffID, String department, String shift, double salary) 
    {
        super(id, name, age, gender, address, phone);
        this.staffID = staffID;
        this.department = department;
        this.shift = shift;
        this.salary = salary;
    }

    // Getters and setters for the additional properties

    public String getStaffID() {
        return staffID;
    }

    public void setStaffID(String staffID) {
        this.staffID = staffID;
    }

    public String getDepartment() {
        return department;
    }

    public void setDepartment(String department) {
        this.department = department;
    }

    public String getShift() {
        return shift;
    }

    public void setShift(String shift) {
        this.shift = shift;
    }

    public double getSalary() {
        return salary;
    }

    public void setSalary(double salary) {
        this.salary = salary;
    }
}
