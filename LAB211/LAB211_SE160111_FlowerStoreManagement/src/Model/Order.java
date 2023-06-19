package Model;

import java.time.LocalDate;
import java.util.ArrayList;
import java.util.List;
/**
 *
 * @author boonie-pt
 */
public class Order {
    private int id;
    private String orderId;
    private LocalDate orderDate;
    private String customerName;
    private int totalQuantity;
    private double totalPrice;
    private List<OrderDetail> orderDetails;

    public Order(int id, String orderId, LocalDate orderDate, String customerName, int totalQuanity, double totalPrice) {
        this.id = id;
        this.orderId = orderId;
        this.orderDate = orderDate;
        this.customerName = customerName;
        this.totalQuantity = totalQuanity;
        this.totalPrice = totalPrice;
    }
    
    public Order(int id, String orderId, LocalDate orderDate, String customerName, int totalQuanity, double totalPrice, List<OrderDetail> orderDetails) {
        this.id = id;
        this.orderId = orderId;
        this.orderDate = orderDate;
        this.customerName = customerName;
        this.totalQuantity = totalQuanity;
        this.totalPrice = totalPrice;
        this.orderDetails = orderDetails;
    }

    public Order(int id, String orderId, LocalDate orderDate, String customerName) {
        this.id = id;
        this.orderId = orderId;
        this.orderDate = orderDate;
        this.customerName = customerName;
        this.orderDetails = new ArrayList<>();
    }

    public int getId() {
        return id;
    }

    public void setId(int id) {
        this.id = id;
    }

    public String getOrderId() {
        return orderId;
    }

    public void setOrderId(String orderId) {
        this.orderId = orderId;
    }

    public LocalDate getOrderDate() {
        return orderDate;
    }

    public void setOrderDate(LocalDate orderDate) {
        this.orderDate = orderDate;
    }

    public String getCustomerName() {
        return customerName;
    }

    public void setCustomerName(String customerName) {
        this.customerName = customerName;
    }

    public int getTotalQuantity() {
        return totalQuantity;
    }

    public void setTotalQuantity(int totalQuantity) {
        this.totalQuantity = totalQuantity;
    }

    public double getTotalPrice() {
        return totalPrice;
    }

    public void setTotalPrice(double totalPrice) {
        this.totalPrice = totalPrice;
    }

    public List<OrderDetail> getOrderDetails() {
        return orderDetails;
    }

    public void addOrderDetail(OrderDetail orderDetail) {
        orderDetails.add(orderDetail);
    }

    public void removeOrderDetail(OrderDetail orderDetail) {
        orderDetails.remove(orderDetail);
    }
}

