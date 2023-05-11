<template>
    <div>
        <h1 id="ordersTitle">
            Sales Orders
        </h1>
        <hr>
        <table id="sales-orders" class="table" v-if="orders.length">
            <thead>
                <tr>Customer</tr>
                <tr>
                    OrderId
                </tr>
                <tr>Order Total</tr>
                <th>Order Status</th>
                <th>Mark Complete</th>
            </thead>
            <tr v-for="item in orders" :key="item.id">
                <td>{{ item.customer.id }}</td>
                <td>{{ item.id }}</td>
                <td>{{ getTotal(item) }}</td>
            </tr>


        </table>
    </div>
</template>

<script lang="ts">
import Vue from "vue";
import Component from "vue-class-component";
import { ISalesOrder } from '@/types/SalesOrder';
import { OrderService } from "@/services/OrderService";
const orderService = new OrderService();
@Component({
    name: 'Orders'
})
export default class Order extends Vue {
    orders: ISalesOrder[] = [];

    getTotal(order: ISalesOrder) {
        return order.salesorderItems.reduce((a, b) => a + (b["product"]["price"] * b["quantity"]), 0);
    }
    async init() {
        this.orders = await orderService.GetOrders();
    }

    created() {
        this.init();
    }
}
</script>

<style lang="scss"></style>