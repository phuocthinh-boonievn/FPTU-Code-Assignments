import Model.Order;
import Model.OrderDetail;
import java.io.BufferedReader;
import java.io.FileReader;
import java.io.IOException;
import java.time.LocalDate;
import java.util.ArrayList;
import java.util.List;

public class Main {
    public static void main(String[] args) {
        List<Order> orders = loadOrderData("orders.dat");
        displayOrders(orders);
    }

    public static List<Order> loadOrderData(String fileName) {
        List<Order> orders = new ArrayList<>();

        try (BufferedReader reader = new BufferedReader(new FileReader(fileName))) {
            String line;
            Order currentOrder = null;

            while ((line = reader.readLine()) != null) {
                line = line.trim();

                if (line.isEmpty()) {
                    // Empty line denotes the end of an order block
                    if (currentOrder != null) {
                        orders.add(currentOrder);
                        currentOrder = null;
                    }
                } else {
                    String[] data = line.split(",");
                    if (data.length == 3) {
                        // Order header information
                        int orderId = Integer.parseInt(data[0].trim());
                        LocalDate orderDate = LocalDate.parse(data[1].trim());
                        String customerName = data[2].trim();

                        currentOrder = new Order(orderId, orderDate, customerName);
                    } else if (data.length == 4) {
                        // Order detail information
                        int orderDetailId = Integer.parseInt(data[0].trim());
                        String flowerId = data[1].trim();
                        int quantity = Integer.parseInt(data[2].trim());
                        double flowerCost = Double.parseDouble(data[3].trim());

                        if (currentOrder != null) {
                            OrderDetail orderDetail = new OrderDetail(orderDetailId, flowerId, quantity, flowerCost);
                            currentOrder.addOrderDetail(orderDetail);
                        }
                    }
                }
            }

            // Add the last order (if any)
            if (currentOrder != null) {
                orders.add(currentOrder);
            }

        } catch (IOException e) {
            e.printStackTrace();
        }

        return orders;
    }

    public static void displayOrders(List<Order> orders) {
        if (orders.isEmpty()) {
            System.out.println("No orders found.");
        } else {
            System.out.println("---------------------------------------------------------------------------------------------------------------------");
            System.out.printf("| %-8s | %-12s | %-20s | %-8s | %-12s | %-10s |\n",
                    "Order ID", "Order Date", "Customer Name", "Detail ID", "Flower ID", "Quantity");
            System.out.println("---------------------------------------------------------------------------------------------------------------------");

            for (Order order : orders) {
                List<OrderDetail> orderDetails = order.getOrderDetails();

                System.out.printf("| %-8d | %-12s | %-20s | %-8s | %-12s | %-10s |\n",
                        order.getOrderId(), order.getOrderDate(), order.getCustomerName(),
                        orderDetails.get(0).getOrderDetailId(), orderDetails.get(0).getFlowerId(),
                        orderDetails.get(0).getQuantity());

                for (int i = 1; i < orderDetails.size(); i++) {
                    System.out.printf("| %-8s | %-12s | %-20s | %-8s | %-12s | %-10s |\n",
                            "", "", "",
                            orderDetails.get(i).getOrderDetailId(), orderDetails.get(i).getFlowerId(),
                            orderDetails.get(i).getQuantity());
                }
            }

            System.out.println("---------------------------------------------------------------------------------------------------------------------");
        }
    }   
}
