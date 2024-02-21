/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package Manager;

import Model.Flower;
import Model.Order;
import Model.OrderDetail;
import Utils.FileDAO;
import Utils.MyValidation;
import java.time.DateTimeException;
import java.time.LocalDate;
import java.util.ArrayList;
import java.util.Comparator;
import java.util.List;
import java.util.Scanner;
import java.util.Set;

/**
 *
 * @author boonie-pt
 */
public class OrdersManager {
    final static String FILE_ORDERS = "orders.dat";
    public static int incrementOrderNoId(List<Order> orders) {
        if (orders.isEmpty()) {
            return 1;
        }
        int maxId = 0;
        for (Order order : orders) {
            if (order.getId() > maxId) {
                maxId = order.getId();
            }
        }
        return maxId + 1;
    }
    
    public static boolean isOrderIdDuplicated(List<Order> orders, String orderId) {
        for (Order order : orders) {
            String existingOrderId = order.getOrderId().toLowerCase().trim();
            if (existingOrderId.equals(orderId.toLowerCase().trim())) {
                return true;
            }
        }
        return false;
    }
    
    public static boolean isOrderDetailIdDuplicated(Order order, String detailId) {
        List<OrderDetail> orderDetails = order.getOrderDetails();
        for (OrderDetail detail : orderDetails) {
            String existingDetailId = detail.getOrderDetailId().toLowerCase().trim();
            if (existingDetailId.equals(detailId.toLowerCase().trim())) {
                return true;
            }
        }
        return false;
    }
    
    public static void addOrder(List<Order> orders) throws Exception {
        Scanner scanner = new Scanner(System.in);

        boolean continueAdding = true;
        int id = incrementOrderNoId(orders);
        String orderId = "";
        LocalDate orderDate = null;
        String customerName = "";

        while (continueAdding) {
            System.out.println("\nAdding a new order");
            System.out.println("-------------------------------");

            // ID auto incremental
            System.out.println("ID: " + id);

            boolean validOrderId = false;
            while (!validOrderId) {
                System.out.print("Order ID: ");
                orderId = scanner.nextLine().trim();
                if (orderId.equals("")) {
                    System.out.println("Order ID must not be null.");
                    continue;
                } 
                else if (isOrderIdDuplicated(orders, orderId)) {
                    System.out.println("The Order ID already exists. Please enter a unique Order ID.");
                    continue;
                }
                validOrderId = true;
            }

            boolean validOrderDate = false;
            while (!validOrderDate) {
                System.out.print("Order Date (dd/MM/yyyy): ");
                String orderDateStr = scanner.nextLine().trim();
                if (MyValidation.isValidDate(orderDateStr, "dd/MM/yyyy")) {
                    orderDate = MyValidation.checkDate(orderDateStr);
                    validOrderDate = true;
                } 
                else {
                    System.out.println("Invalid date format. Please enter a valid date (dd/MM/yyyy).");
                }
            }

            boolean validCustomerName = false;
            while (!validCustomerName) {
                System.out.print("Customer Name: ");
                customerName = scanner.nextLine().trim();
                if (customerName.equals("")) {
                    System.out.println("Customer Name must not be null!");
                    continue;
                }
                validCustomerName = true;
            }

            Order order = new Order(id, orderId.toUpperCase(), orderDate, customerName);

            boolean continueAddingDetails = true;
            String detailId = "";
            while (continueAddingDetails) {
                System.out.println("\nAdding order detail");
                System.out.println("-------------------------------");

                boolean validOrderDetailId = false;
                while (!validOrderDetailId) {
                    System.out.print("Detail ID: ");
                    detailId = scanner.nextLine().trim();
                    if (detailId.equals("")) {
                        System.out.println("Detail ID must not be null.");
                        continue;
                    } 
                    else if (isOrderDetailIdDuplicated(order, detailId)) {
                        System.out.println("The detail ID already exists. Please enter a unique detail ID.");
                        continue;
                    }
                    validOrderDetailId = true;
                }

                boolean validFlowerId = false;
                String flowerId = "";
                Set<Flower> flowers = FileDAO.loadFlowerData("flowers.dat");
                while (!validFlowerId) {
                    System.out.print("Flower ID: ");
                    flowerId = scanner.nextLine().trim();
                    if (flowerId.equals("")) {
                        System.out.println("Flower ID must not be null.");
                        continue;
                    }
                    else if (!FlowersManager.isFlowerIdDuplicated(flowers, flowerId)) {
                        System.out.println("The flower ID doesn't exists. Please enter an existing flower ID.");
                        continue;
                    }
                    validFlowerId = true;
                }

                boolean validQuantity = false;
                int quantity = 0;
                while (!validQuantity) {
                    try {
                        System.out.print("Quantity: ");
                        quantity = Integer.parseInt(scanner.nextLine().trim());
                        if (quantity <= 0) {
                            System.out.println("Quantity must be a positive number!");
                            continue;
                        }
                        validQuantity = true;
                    } catch (NumberFormatException e) {
                        System.out.println("Invalid input. Quantity must be a number.");
                        validQuantity = false;
                    }
                }

                double flowerCost = FileDAO.getFlowerPrice(flowerId) * quantity;

                OrderDetail detail = new OrderDetail(detailId, flowerId, quantity, flowerCost);
                order.addOrderDetail(detail);

                System.out.println("Order Detail added successfully!");

                System.out.print("Do you want to add another Order Detail? (yes/no): ");
                String choice = scanner.nextLine().trim();
                if (choice.equalsIgnoreCase("yes") || choice.equalsIgnoreCase("y")) {
                    continueAddingDetails = true;
                } else {
                    continueAddingDetails = false;
                }
            }

            orders.add(order);

            System.out.println("Order added successfully! Updated order list:");
            FileDAO.saveOrderData(orders);
            FileDAO.loadOrderData(FILE_ORDERS);
            displayOrders(orders);

            System.out.print("Do you want to add another Order? (yes/no): ");
            String choice = scanner.nextLine().trim();
            if (choice.equalsIgnoreCase("yes") || choice.equalsIgnoreCase("y")) {
                id++;
                continueAdding = true;
            } else {
                continueAdding = false;
            }
        }
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
    
    public static void displayOrdersByImportDate(List<Order> orders) throws Exception {
        if (orders.isEmpty()) {
            System.out.println("\nEMPTY ORDER LIST!");
        } 
        else {
            Scanner sc = new Scanner(System.in);

            boolean validImportDate = false;
            while (!validImportDate) {
                System.out.print("Enter the start date (dd/mm/yyyy): ");
                String startDateString = sc.nextLine().trim();
                System.out.print("Enter the end date (dd/mm/yyyy): ");
                String endDateString = sc.nextLine().trim();
                try{
                    if (MyValidation.isValidDate(startDateString, "dd/MM/yyyy") && MyValidation.isValidDate(endDateString, "dd/MM/yyyy")) {
                        LocalDate startDate = MyValidation.checkDate(startDateString);
                        LocalDate endDate = MyValidation.checkDate(endDateString);

                        List<Order> filteredOrders = new ArrayList<>();
                        for (Order order : orders) {
                            LocalDate orderDate = order.getOrderDate();
                            if (!orderDate.isBefore(startDate) && !orderDate.isAfter(endDate)) {
                                filteredOrders.add(order);
                            }
                        }
                        if (filteredOrders.isEmpty()) {
                            System.out.println("No orders found within the specified date range.");
                            validImportDate = true;
                        } 
                        else {
                            displayOrders(filteredOrders);
                            validImportDate = true;
                        }
                    } 
                    else {
                        System.out.println("Invalid date format. Please enter a valid date (dd/MM/yyyy).");
                    }
                }
                catch (DateTimeException e){
                    System.out.println("Invalid date format. Please enter a valid date (dd/MM/yyyy).");
                }
            }
        }
    }
    
    public static void sortOrders(List<Order> orders) {
        if (orders.isEmpty()) {
            System.out.println("\nEMPTY ORDER LIST!");
        } 
        else {
            Scanner scanner = new Scanner(System.in);
            System.out.print("Enter the field to sort orders by (id / date / name / total price): ");
            String sortField = scanner.nextLine().toLowerCase().trim();
            System.out.print("Enter the sort order (ASC / DESC): ");
            String sortOrder = scanner.nextLine().toUpperCase().trim();

            Comparator<Order> comparator;
            switch (sortField) {
                case "id":
                    comparator = Comparator.comparing(Order::getOrderId);
                    break;
                case "date":
                    comparator = Comparator.comparing(Order::getOrderDate);
                    break;
                case "name":
                    comparator = Comparator.comparing(Order::getCustomerName);
                    break;
                case "total":
                    comparator = Comparator.comparingDouble(Order::getTotalPrice);
                    break;
                default:
                    System.out.println("Invalid sort field. Orders will be displayed without sorting.");
                    return;
            }

            if (sortOrder.equalsIgnoreCase("DESC")) {
                comparator = comparator.reversed();
            }
            orders.sort(comparator);
            displayOrders(orders);
        }
    }
}
