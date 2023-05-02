
<template>
    <div>
        <div id="invoiceTitle">
            Create Invoice
        </div>
        <div class="invoice-step" v-if="invoiceStep === 1">

            <h2>Step 1: Select customers</h2>
            <div class="invoice-step-detail" v-if="customers.length > 0">
                <label for="customer">Customer:</label>
                <select class="invoice-customers" id="customer">
                    <option disabled value="">Plase select a customer</option>
                    <option v-for="item in customers" :value="item.id">{{ fullName(item.firstName, item.lastName) }}
                    </option>
                </select>

            </div>
        </div>
        <div class="invoice-step" v-if="invoiceStep === 2">
            <h2>Step 2: Create Order</h2>
            <div class="invoice-step-detail">
                <label for="product">Product:</label>
                <select id="product" v-model="newItem.product" class="invoice-line-item">
                    <option disabled value="">
                        Plase Select an option
                    </option>
                    <option v-for="p in inventory" :key="p.product.id" :value="p.product">
                        {{ p.product.name }}
                    </option>
                </select>
                <label for="quantity">Quantity: </label>
                <input type="number" v-model.number="newItem.quantity" id="quantity" min="0">

            </div>
            <div class="invoice-item-actions">
                <solar-btn :disabled="!newItem.product || !newItem.quantity" @button:click="addLineItem">
                    Add Line
                </solar-btn>
                <solar-btn :disabled="!lineItems.length" @button:click="finalizeOrder">
                    Finalize Order
                </solar-btn>

            </div>
        </div>
        <div class="invoice-step" v-if="invoiceStep === 3">

        </div>
        <div class="invoice-steps-actions">
            <solar-btn @button:click="prev" :disabled="!canGoPrev">
                Previous
            </solar-btn>
            <solar-btn @button:click="next" :disabled="!canGoNext">
                Next
            </solar-btn>
            <solar-btn @button:click="startOver" :disabled="!startOver">
                Start Over
            </solar-btn>
        </div>
    </div>
</template>

<script lang="ts">
import SolarBtn from '@/components/SolarBtn.vue';
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
    name: "CreateInvoice",
    components: { SolarBtn }
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
    newItem: ILineItem = {
        product: {
            id: 0,
            dateCreated: new Date(),
            dateUpdated: new Date(),
            name: '',
            description: '',
            price: 0,
            isTaxable: false,
            isArchived: false
        }, quantity: 0
    };
    selectedCustomerId: number = 0;
    canGoPrev: any;
    startOver: any;


    public get canGoNext(): boolean {
        if (this.invoiceStep === 1) {
            return this.selectedCustomerId !== 0;
        }

        if (this.invoiceStep === 2) {
            return true;
        }
        if (this.invoiceStep === 3) {
            return false;
        }
        return false;
    }



    fullName(firstName: string, lastName: string) {
        return `${firstName} - ${lastName}`
    }

    addLineItem() {
        let newItem: ILineItem = {
            product: this.newItem.product,
            quantity: this.newItem.quantity
        };

        let existingItems = this.lineItems.map(item => item.product?.id);

        if (existingItems.includes(newItem.product?.id)) {
            let lineItem = this.lineItems
                .find(
                    item => item.product?.id === newItem.product?.id);

            lineItem!.quantity += newItem.quantity;
        } else {
            this.lineItems.push(this.newItem);
        }

        this.newItem = { product: undefined, quantity: 0 }
    }

    finalizeOrder() {
        this.invoiceStep = 3;
    }
    prev(): void {
        if (this.invoiceStep == 1) {
            return;
        }
        this.invoiceStep -= 1
    }
    next(): void {
        if (this.invoiceStep === 3) {
            return;
        }
        this.invoiceStep += 1;
    }

    async init(): Promise<void> {
        this.customers = await customerService.GetCustomers();
        this.inventory = await inventoryService.GetInventory();
    }

    created() {
        this.init();
    }



}
</script>
<style lang="scss">
.invoice-customer {}
</style>