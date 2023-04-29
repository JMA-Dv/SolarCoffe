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
                <td>{{ item.dateCreated | fDate }}</td>
                <td>
                    <div class="lni lni-cross-circle customer-delete" @click="deleteCustomer(item.id)">

                    </div>
                </td>

            </tr>
        </table>
        <new-customer-modal v-if="isCustomerModalVisible" @save:customer="createNewCustomer"
            @close="closeModal"></new-customer-modal>
    </div>
</template>

<script lang="ts">
import SolarBtn from "@/components/SolarBtn.vue";
import { Component, Vue } from "vue-property-decorator";
import { ICustomer } from "@/types/Customer";
import { CustomerService } from "@/services/CustomerService";
import NewCustomerModal from "@/components/modals/NewCustomerModal.vue";
const customerService = new CustomerService();

@Component({
    name: 'Customers',
    components: { SolarBtn, NewCustomerModal }
})



export default class Customers extends Vue {

    customers: ICustomer[] = [];

    isCustomerModalVisible: boolean = false;

    fullName(name: string, lastName: string): string {
        return `${name} - ${lastName}`
    }
    closeModal() {
        this.isCustomerModalVisible = false;
    }
    showNewCustomerModal() {
        this.isCustomerModalVisible = true;
    }

    async deleteCustomer(id: number) {
        await customerService.deleteCustomer(id);
        await this.init();
    }
    async init() {
        this.customers = await customerService.GetCustomers();
    }

    async createNewCustomer(customer: ICustomer) {
        await customerService.saveCustomer(customer);
        this.closeModal();
        await this.init();
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

#customersTitle {
    font-size: 30px;
}

.customer-delete {
    cursor: pointer;
    font-weight: bold;
    font-size: 1.2rem;
    color: $solar-red;
}
</style>