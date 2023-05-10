<template>
    <div>
        <h1 id="ordersTitle">
            Sales Orders
        </h1>
        <hr>
        <table id="sales-orders" class="table" v-if="orders.length">
            <thead>
                <tr>Customer</tr>
                <tr>Is Paid

                </tr>
                <tr>LineItems</tr>
            </thead>


        </table>
    </div>
</template>

<script lang="ts">
import Vue from "vue";
import Component from "vue-class-component";
import { ISalesOrder } from '@/types/SalesOrder';

@Component({
    name: 'Orders'
})
export default class Order extends Vue {
    orders: ISalesOrder[] = [];
}
</script>

<style lang="scss"></style>