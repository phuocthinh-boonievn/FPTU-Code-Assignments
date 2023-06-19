package Model;

/**
 *
 * @author boonie-pt
 */
public class OrderDetail {
    private String orderDetailId;
    private String flowerId;
    private int quantity;
    private double flowerCost;

    public OrderDetail(String orderDetailId, String flowerId, int quantity) {
        this.orderDetailId = orderDetailId;
        this.flowerId = flowerId;
        this.quantity = quantity;
    }
    
    public OrderDetail(String orderDetailId, String flowerId, int quantity, double flowerCost) {
        this.orderDetailId = orderDetailId;
        this.flowerId = flowerId;
        this.quantity = quantity;
        this.flowerCost = flowerCost;
    }

    public String getOrderDetailId() {
        return orderDetailId;
    }

    public void setOrderDetailId(String orderDetailId) {
        this.orderDetailId = orderDetailId;
    }

    public String getFlowerId() {
        return flowerId;
    }

    public void setFlowerId(String flowerId) {
        this.flowerId = flowerId;
    }

    public int getQuantity() {
        return quantity;
    }

    public void setQuantity(int quantity) {
        this.quantity = quantity;
    }

    public double getFlowerCost() {
        return flowerCost;
    }

    public void setFlowerCost(double flowerCost) {
        this.flowerCost = flowerCost;
    }
    
}