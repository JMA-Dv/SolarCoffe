<template>
    <div>
        <h1 id="customersTitle">
            Manage Customers
        </h1>

        <hr>

        <div class="customer-actions">
            <SolarBtn @button:click="showNewCustomerModal">
                Add customer
            </SolarBtn>
        </div>
        <table id="customers" class="table">
            <tr>
                <th>Customer</th>
                <th>Address</th>
                <th>State</th>
                <th>Since</th>
                <th>Delete</th>
            </tr>
        </table>
    </div>
</template>

<script lang="ts">
import SolarBtn from "@/components/SolarBtn.vue";
import { Component, Vue } from "vue-property-decorator";
import { ICustomer } from "@/types/Customer";

@Component({
    name: 'Customers',
    components: { SolarBtn }
})



export default class Customers extends Vue {

    customers: ICustomer[] = [];

    isCustomerModalVisible: boolean = false;
    showNewCustomerModal() {
        this.isCustomerModalVisible = true;
    }
}
</script>

<style lang="scss"></style>