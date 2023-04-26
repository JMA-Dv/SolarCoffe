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
            <tr v-for="item in customers" :key="item.id">
                <td>{{ fullName(item.firstName, item.lastName) }} </td>
                <td>{{ item.customerAddress.addressLine }}</td>
                <td>{{ item.customerAddress.state }}</td>
                <td>{{ item.dateCreated | fDate }}}</td>
                <td>
                    <div class="lni lni-cross-circle customer-delete" @click="deleteCustomer(item.id)">

                    </div>
                </td>

            </tr>
        </table>
    </div>
</template>

<script lang="ts">
import SolarBtn from "@/components/SolarBtn.vue";
import { Component, Vue } from "vue-property-decorator";
import { ICustomer } from "@/types/Customer";
import { CustomerService } from "@/services/CustomerService";
const customerService = new CustomerService();

@Component({
    name: 'Customers',
    components: { SolarBtn }
})



export default class Customers extends Vue {

    customers: ICustomer[] = [];

    isCustomerModalVisible: boolean = false;

    fullName(name: string, lastName: string): string {
        return `${name} - ${lastName}`
    }
    showNewCustomerModal() {
        this.isCustomerModalVisible = true;
    }

    async delete(id: number) {
        await customerService.deleteCustomer(id);
        this.init();
    }
    async init() {
        this.customers = await customerService.GetCustomers();
    }

    created() {
        this.init();
    }
}
</script>

<style scoped lang="scss">
@import "@/scss/global.scss";

.customer-actions {
    display: flex;
    margin-bottom: 0.8rem;

    div {
        margin-right: 0.8rem;
    }

}

.customer-delete {
    cursor: pointer;
    font-weight: bold;
    font-size: 1.2rem;
    color: $solar-red;
}
</style>