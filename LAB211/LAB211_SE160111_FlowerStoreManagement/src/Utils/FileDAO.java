package Utils;

import Model.Flower;
import Model.Order;
import Model.OrderDetail;
import java.io.BufferedReader;
import java.io.BufferedWriter;
import java.io.FileOutputStream;
import java.io.FileReader;
import java.io.FileWriter;
import java.io.IOException;
import java.io.ObjectOutputStream;
import java.time.LocalDate;
import java.time.format.DateTimeFormatter;
import java.util.ArrayList;
import java.util.List;
import java.util.Set;
import java.util.TreeSet;

/**
 *
 * @author PC
 */
public class FileDAO {
    public static DateTimeFormatter dateFormatter = DateTimeFormatter.ofPattern("dd/MM/yyyy");
    public static void saveFlowerData(Set<Flower> flowers) {
        try (BufferedWriter writer = new BufferedWriter(new FileWriter("flowers.dat"))) {
            for (Flower flower : flowers) {
                String line = String.format("%s,%s,%s,%s,%s,%s",
                        flower.getId(),
                        flower.getFlowerId(),
                        flower.getDescription(),
                        flower.getImportDate().format(dateFormatter),
                        flower.getUnitPrice(),
                        flower.getCategory());
                writer.write(line);
                writer.newLine();
            }
            System.out.println("Flower data saved successfully.");
        } catch (IOException e) {
            System.out.println("Error occurred while saving flower data: " + e.getMessage());
        }
    }


    public static void saveOrderData(List<Order> orders) {
        try (BufferedWriter writer = new BufferedWriter(new FileWriter("orders.dat"))) {
            for (Order order : orders) {
                String line = String.format("%s,%s,%s,%s",
                        order.getId(),
                        order.getOrderId(),
                        order.getOrderDate().format(dateFormatter),
                        order.getCustomerName());
                writer.write(line);
                writer.newLine();
                for (OrderDetail detail : order.getOrderDetails()) {
                    writer.write(detail.getOrderDetailId() + "," +
                            detail.getFlowerId() + "," +
                            detail.getQuantity());
                    writer.newLine();
                }
                writer.newLine();
            }
            System.out.println("Order data saved successfully.");
        } catch (IOException e) {
            System.out.println("Error occurred while saving order data: " + e.getMessage());
        }
    }

    public static double getFlowerPrice(String flowerId) throws Exception {
        Set<Flower> flowers = FileDAO.loadFlowerData("flowers.dat");
        for (Flower flower : flowers) {
            if (flower.getFlowerId().trim().equalsIgnoreCase(flowerId)) {
                return flower.getUnitPrice();
            }
        }
        return 0; // Return 0 if the flower ID is not found
    }
    
    public static List<Order> loadOrderData(String fileName) throws Exception {
        List<Order> orders = new ArrayList<>();

        try (BufferedReader reader = new BufferedReader(new FileReader(fileName))) {
            String line;
            Order currentOrder = null;
            double totalPrice = 0.0;
            int totalQuantity = 0;

            while ((line = reader.readLine()) != null) {
                line = line.trim();

                if (line.isEmpty()) {
                    // Empty line denotes the end of an order block
                    if (currentOrder != null) {
                        currentOrder.setTotalQuantity(totalQuantity);
                        currentOrder.setTotalPrice(totalPrice);
                        orders.add(currentOrder);
                        currentOrder = null;
                        totalPrice = 0.0;
                        totalQuantity = 0;
                    }
                } else {
                    String[] data = line.split(",");
                    if (data.length == 3) {
                        String orderDetailId = data[0].trim();
                        String flowerId = data[1].trim();
                        int quantity = Integer.parseInt(data[2].trim());
                        double flowerCost = quantity * getFlowerPrice(flowerId);

                        if (currentOrder != null) {
                            OrderDetail orderDetail = new OrderDetail(orderDetailId, flowerId, quantity, flowerCost);
                            currentOrder.addOrderDetail(orderDetail);
                            totalPrice += flowerCost;
                            totalQuantity += quantity;
                        }
                    } else if (data.length == 4) {
                        int id = Integer.parseInt(data[0].trim());
                        String orderId = data[1].trim();
                        LocalDate orderDate = MyValidation.checkDate(data[2].trim());
                        String customerName = data[3].trim();

                        currentOrder = new Order(id, orderId, orderDate, customerName);
                    }
                }
            }
            // Add the last order (if any)
            if (currentOrder != null) {
                currentOrder.setTotalQuantity(totalQuantity);
                currentOrder.setTotalPrice(totalPrice);
                orders.add(currentOrder);
            }

        } catch (IOException e) {
            e.printStackTrace();
        }

        return orders;
    }

    public static Set<Flower> loadFlowerData(String fileName) throws Exception {
        Set<Flower> flowers = new TreeSet<>((flower1, flower2) -> Integer.compare(flower1.getId(), flower2.getId()));

        try (BufferedReader reader = new BufferedReader(new FileReader(fileName))) {
            String line;
            while ((line = reader.readLine()) != null) {
                String[] data = line.split(",");
                int id = Integer.parseInt(data[0].trim());
                String flowerId = data[1];
                String description = data[2];
                LocalDate importDate = MyValidation.checkDate(data[3].trim());
                double unitPrice = Double.parseDouble(data[4].trim());
                String category = data[5];

                Flower flower = new Flower(id, flowerId, description, importDate, unitPrice, category);
                flowers.add(flower);
            }
        } catch (IOException e) {
        }

        return flowers;
    }
    
    public static void displayAllData(Set<Flower> flowers, List<Order> orders) {
        if (flowers.isEmpty()) {
            System.out.println("\nEMPTY FLOWER LIST!");
        }
        else if (orders.isEmpty()) {
            System.out.println("\nEMPTY ORDER LIST!");
        } 
        else {
            System.out.println("--------------------------------------------------------------------------------------------------");
            System.out.printf("| %-3s | %-10s | %-20s | %-15s | %-15s | %-15s |%n",
                    "No.", "Flower ID", "Description", "Import Date", "Flower Price ($)", "Category");
            System.out.println("--------------------------------------------------------------------------------------------------");            for (Flower flower : flowers) {
                System.out.printf("| %-3s | %-10s | %-20s | %-15s | %-16s | %-15s |%n",
                        flower.getId(), flower.getFlowerId().trim(), flower.getDescription().trim(), flower.getImportDate(),
                         "$ " + flower.getUnitPrice() , flower.getCategory().trim());
            }
            System.out.println("--------------------------------------------------------------------------------------------------");       
            System.out.println("\n----------------------------------------------------------------------------------------------------------------------");
            System.out.printf("| %-3s | %-10s | %-15s | %-20s | %-10s | %-10s | %-10s | %-15s |%n",
                    "No.", "Order ID", "Order Date", "Customer Name", "Detail ID", "Flower ID", "Quantity", "Flower Price");
            System.out.println("----------------------------------------------------------------------------------------------------------------------");
            for (Order order : orders) {
                System.out.printf("| %-3s | %-10s | %-15s | %-20s | %-10s | %-10s | %-10s |%n",
                        order.getId(), order.getOrderId(), order.getOrderDate(), order.getCustomerName(), "", "", "");
                List<OrderDetail> details = order.getOrderDetails();
                for (OrderDetail detail : details) {
                    System.out.printf("|     |            |                 |                      | %-10s | %-10s | %-10s | %-15s |%n",
                            detail.getOrderDetailId(), detail.getFlowerId(), detail.getQuantity(), "$ " + detail.getFlowerCost());
                }

                System.out.println("|     |            |                 |                      |------------|------------|------------|-----------------|");
                System.out.printf("|     |            |                 |                      | %-10s | %-10s | %-10s | %-15s |%n",
                        "Total", "", order.getTotalQuantity(), "$ " + order.getTotalPrice());
                System.out.println("----------------------------------------------------------------------------------------------------------------------");
            }
        }
    }
    
    public static void displayFlowers(Set<Flower> flowers) {
        if (flowers.isEmpty()) {
            System.out.println("\nEMPTY FLOWER LIST!");
        } else {
            System.out.println("--------------------------------------------------------------------------------------------------");
            System.out.printf("| %-3s | %-10s | %-20s | %-15s | %-15s | %-15s |%n",
                    "No.", "Flower ID", "Description", "Import Date", "Flower Price ($)", "Category");
            System.out.println("--------------------------------------------------------------------------------------------------");            for (Flower flower : flowers) {
                System.out.printf("| %-3s | %-10s | %-20s | %-15s | %-16s | %-15s |%n",
                        flower.getId(), flower.getFlowerId().trim(), flower.getDescription().trim(), flower.getImportDate(),
                         "$ " + flower.getUnitPrice() , flower.getCategory().trim());
            }
            System.out.println("--------------------------------------------------------------------------------------------------");        }
    }
    
    public static void displayOrders(List<Order> orders) {
        if (orders.isEmpty()) {
            System.out.println("\nEMPTY ORDER LIST!");
        } else {
            System.out.println("----------------------------------------------------------------------------------------------------------------------");
            System.out.printf("| %-3s | %-10s | %-15s | %-20s | %-10s | %-10s | %-10s | %-15s |%n",
                    "No.", "Order ID", "Order Date", "Customer Name", "Detail ID", "Flower ID", "Quantity", "Flower Price");
            System.out.println("----------------------------------------------------------------------------------------------------------------------");
            for (Order order : orders) {
                System.out.printf("| %-3s | %-10s | %-15s | %-20s | %-10s | %-10s | %-10s |%n",
                        order.getId(), order.getOrderId(), order.getOrderDate(), order.getCustomerName(), "", "", "");

                double totalOrder = 0.0; // Variable to store the total order value
                int totalQuanity = 0; // Variable to store the total order value
                List<OrderDetail> details = order.getOrderDetails();
                for (OrderDetail detail : details) {
                    System.out.printf("|     |            |                 |                      | %-10s | %-10s | %-10s | %-15s |%n",
                            detail.getOrderDetailId(), detail.getFlowerId(), detail.getQuantity(), detail.getFlowerCost());
                    totalOrder += detail.getFlowerCost();
                    totalQuanity += detail.getQuantity();
                }

                System.out.println("|     |            |                 |                      |------------|------------|------------|-----------------|");
                System.out.printf("|     |            |                 |                      | %-10s | %-10s | %-10s | %-15s |%n",
                        "Total", "", totalQuanity, totalOrder);
                System.out.println("----------------------------------------------------------------------------------------------------------------------");
            }
        }
    }
}
