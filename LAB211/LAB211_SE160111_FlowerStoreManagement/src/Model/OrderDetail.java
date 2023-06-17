/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package Model;

/**
 *
 * @author PEATEA
 */
public class OrderDetail {
    private int orderDetailId;
    private String flowerId;
    private int quantity;
    private double flowerCost;

    public OrderDetail(int orderDetailId, String flowerId, int quantity, double flowerCost) {
        this.orderDetailId = orderDetailId;
        this.flowerId = flowerId;
        this.quantity = quantity;
        this.flowerCost = flowerCost;
    }

    public int getOrderDetailId() {
        return orderDetailId;
    }

    public String getFlowerId() {
        return flowerId;
    }

    public int getQuantity() {
        return quantity;
    }

    public double getFlowerCost() {
        return flowerCost;
    }
}
