<template>
    <div>
        <h1 id="ordersTitle">
            Sales Orders
        </h1>
        <hr>
        <table id="sales-orders" class="table" v-if="orders.length">
            <thead>
                <tr>

                    <th>Customer</th>
                    <th>
                        OrderId
                    </th>
                    <th>Order Total</th>
                    <th>Order Status</th>
                    <th>Mark Complete</th>
                </tr>
                <tr v-for="item in orders" :key="item.id">
                    <td>{{ item.customer.id }}</td>
                    <td>{{ item.id }}</td>
                    <td>{{ getTotal(item) }}</td>
                    <td :class="{ 'green': item.isPaid }">{{ getStatus(item.isPaid) }}</td>
                    <td>
                        <div v-if="!item.isPaid" class="lni lni-checkmark-circle green order-complete"
                            @click="markAsComplete(item.id)">

                        </div>
                    </td>
                </tr>

            </thead>

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
        return order.salesOrderItems.reduce((a, b) => a + b["product"]["price"] * b["quantity"], 0);
    }

    getStatus(isPaid: boolean): string {
        return (isPaid) ? "Paid in full" : "Un paid";
    }

    async init() {
        this.orders = await orderService.GetOrders();
    }

    async markAsComplete(id: number): Promise<void> {
        await orderService.MarkAsCompleted(id);
        await this.init();
    }
    created() {
        this.init();
    }
}
</script>

<style lang="scss" scoped>
@import "@/scss/global.scss";

.green {
    font-weight: bold;
    color: $solar-green;
}

.order-complete {
    cursor: pointer;
    text-align: center;

}
</style>