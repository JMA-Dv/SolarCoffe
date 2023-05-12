
<template>
    <div>
        <div id="invoiceTitle">
            Create Invoice
        </div>
        <div class="invoice-step" v-if="invoiceStep === 1">

            <h2>Step 1: Select customers</h2>
            <div class="invoice-step-detail" v-if="customers.length > 0">
                <label for="customer">Customer:</label>
                <select class="invoice-customers" v-model="selectedCustomerId" id="customer">
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
                    Save Product
                </solar-btn>
                <solar-btn :disabled="!lineItems.length" @button:click="finalizeOrder">
                    Finalize Order
                </solar-btn>

            </div>
            <div class="invoice-order-list" v-if="lineItems.length">
                <div class="running-total">
                    <h3>Running Total</h3>
                    {{ runningTotal | price }}
                </div>
                <hr />

                <invoice-table :lineItem="lineItems"></invoice-table>


            </div>
        </div>
        <div class="invoice-step" v-if="invoiceStep === 3">
            <h2>Step 3: Review and suubmit </h2>
            <solar-btn @button:click="submitInvoice">Submit Invoice</solar-btn>
            <hr>
            <div class="invoice-step-detail" id="invoice" ref="invoice">
                <div class="invoice-logo">
                    <img id="imgLogo" alt="Coffe Logo" src="../assets/images/logo.jpg" />

                    <h3>123 somewhere</h3>
                    <h3>Somewhere whereas here</h3>
                    <h3>This countr</h3>
                    <div class="invoice-order-list" v-if="lineItems.length">
                        <div class="invoice-header">
                            <h3>Invoice {{ getCurrentDate | fDate }}</h3>
                            <h3>Customer: {{ fullName(selectedCustomer?.firstName, selectedCustomer?.lastName) }} </h3>
                            <h3>Address: {{ selectedCustomer.customerAddress.addressLine }}</h3>
                            <h3>Address:
                                {{ selectedCustomer.customerAddress.city }}
                                {{ selectedCustomer.customerAddress.state }}
                                {{ selectedCustomer.customerAddress.postalCode }}
                            </h3>
                            <h3>
                                {{ selectedCustomer.customerAddress.country }}
                            </h3>
                        </div>
                        <invoice-table :lineItem="lineItems">
                            <template v-slot:grandTotal>
                                <th colspan="4"></th>
                                <th>Grand Total</th>
                            </template>
                            <template v-slot:tableFooter>
                                <tr>
                                    <td colspan="4" class="due">Balance due upon receipt:</td>
                                    <td class="price-final">{{ runningTotal | price }}</td>
                                </tr>
                            </template>
                        </invoice-table>
                    </div>
                </div>
            </div>
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
import InvoiceTable from '@/components/tables/InvoiceTable.vue';
import html2canvas from 'html2canvas';
import Vue from 'vue'

import { jsPDF } from "jspdf";


import Component from 'vue-class-component';
const customerService = new CustomerService();
const inventoryService = new InventoryService();
const invoiceService = new InvoiceService();

@Component({
    components: { SolarBtn, InvoiceTable }
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


    get runningTotal(): number {
        return this.lineItems
            .reduce((a, b) => a + (b['product']!['price'] * b['quantity']), 0);
    }

    get getCurrentDate(): Date {
        return new Date();
    }
    get canGoPrev(): boolean {
        return this.invoiceStep !== 1;
    }
    public get canGoNext(): boolean {
        if (this.invoiceStep === 1) {
            return this.selectedCustomerId !== 0;
        }
        console.log("Aqui llega 1")

        if (this.invoiceStep === 2) {
            return this.lineItems.length > 0;
        }
        console.log("Aqui llega 2")

        if (this.invoiceStep === 3) {
            console.log("Aqui llega  ", this.invoiceStep)
            return false;
        }
        return false;
    }

    get selectedCustomer(): ICustomer {
        let currentCustomer = this.customers.find(item => item.id === this.selectedCustomerId)
        if (currentCustomer) {
            return currentCustomer;
        }
        throw new Error("Could not find customer");
    }
    async submitInvoice(): Promise<void> {
        this.inovice = {
            customerId: this.selectedCustomerId,
            lineItems: this.lineItems,
            dateCreated: new Date(),

        };

        await invoiceService.makeNewInvoice(this.inovice);
        this.downloadPfg();
        await this.$router.push('/orders');
    }
    downloadPfg() {
        let pdf = new jsPDF("p", "pt", "a4", true);
        let invoice = document.getElementById('invoice')!;

        if (typeof (invoice) !== null) {

            html2canvas(invoice).then(canvas => {
                let image = canvas.toDataURL("image/png");
                pdf.addImage(image, "PNG", 0, 0, 940 * 0.55, 940 * 0.55);
                pdf.save('invoice')
            })
        }

    }
    fullName(firstName?: string, lastName?: string) {
        return `${firstName} - ${lastName}`
    }



    startOver(): void {
        this.inovice = { customerId: 0, lineItems: [], id: 0, dateCreated: new Date() };
        this.invoiceStep = 1;
    }

    subTotal(price: number, quantity: number): number {
        return (price * quantity);
    }
    addLineItem() {
        let newItem: ILineItem = {
            product: this.newItem.product,
            quantity: this.newItem.quantity
        };

        let existingItems = this.lineItems.map(item => item.product.id);

        if (existingItems.includes(newItem.product.id)) {
            let lineItem = this.lineItems
                .find(
                    item => item.product.id === newItem.product.id);

            lineItem!.quantity += newItem.quantity;
        } else {
            this.lineItems.push(this.newItem);
        }

        this.newItem = {
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
        }

        console.log("Line items ", this.lineItems);
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
@import '@/scss/global.scss';

.invoice-steps-actions {
    display: flex;
    width: 100%;
}


.invoice-order-list {
    margin-top: 1.2rem;
    padding: 0.8rem;

    .line-item {
        display: flex;
        border-bottom: 1px dashed #ccc;
        padding: 0.8rem;
    }

    .item-col {
        flex-grow: 1;
    }
}

.invoice-item-actions {
    display: flex;
}

.price-pre-tax {
    font-weight: bold;
}


.invoice-step-detail {
    margin: 1.2rem;
}



.invoice-header {
    width: 100%;
    margin-bottom: 1.2rem;
}

.invoice-logo {
    padding-top: 1.4rem;
    text-align: center;

    img {
        width: 280px;
    }
}
</style>