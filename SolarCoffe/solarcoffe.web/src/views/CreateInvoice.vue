<template>
    <div>

        <div id="invoiceTitle">
            Create Invoice
        </div>
        <div class="invoice-step" v-if="invoiceStep === 1">

            <h2>Step 1: Select customers</h2>
            <div class="invoice-step-detail" v-if="customers.length > 0">
                <label for="customer">Customer:</label>
                <select class="invoiceCustomers" id="customer">
                    <option disabled value="">Plase select a customer</option>
                    <option v-for="item in customers" :value="item.id">{{ fullName(item.firstName, item.lastName) }}
                    </option>
                </select>

            </div>
        </div>
        <div class="invoice-step" v-if="invoiceStep === 2">

        </div>
        <div class="invoice-step" v-if="invoiceStep === 3">

        </div>
    </div>
</template>

<script lang="ts">
import { CustomerService } from '@/services/CustomerService';
import { InventoryService } from '@/services/InventoryService.';
import InvoiceService from '@/services/InvoiceService';
import { ICustomer } from '@/types/Customer';
import { IInvoice, ILineItem } from '@/types/IInvoice';
import { IProductInventory } from '@/types/Product';
import { Vue, Component } from 'vue-property-decorator';
const customerService = new CustomerService();
const inventoryService = new InventoryService();
const invoiceService = new InvoiceService();

@Component({
    name: "CreateInvoice"
})


export default class CreateInvoice extends Vue {
    invoiceStep: number = 1;
    inovice: IInvoice = {
        customerId: 0,
        lineItems: [],
        id: 0,
        dateCreated: new Date()
    };
    customers: ICustomer[] = [];
    inventory: IProductInventory[] = [];
    lineItems: ILineItem[] = [];
    newItem: ILineItem = { product: undefined, quantiry: 0 };
    selectedCustomerId: number = 0;

    fullName(firstName: string, lastName: string) {
        return `${firstName} - ${lastName}`
    }

    async init(): Promise<void> {
        this.customers = await customerService.GetCustomers();
        this.inventory = await inventoryService.GetInventory();
    }
    created() {
        this.init();

    }
    computed() {


    }


}
</script>
<style lang="scss"></style>