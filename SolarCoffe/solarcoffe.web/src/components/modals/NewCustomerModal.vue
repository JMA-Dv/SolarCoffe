<template>
    <solar-modal>
        <template v-slot:header>
            Add New Customer
        </template>
        <template v-slot:body>
            <ul>
                <li>
                    <label for="firstName">First Name</label>
                    <input type="text" id="firstName" v-model="customer.firstName">

                </li>
                <li>
                    <label for="lastName">Last Name</label>
                    <input type="text" id="lastName" v-model="customer.lastName">

                </li>
                <li>
                    <label for="addressLine">Address Line</label>
                    <input type="text" id="addressLine" v-model="customer.customerAddress.addressLine">

                </li>

                <li>
                    <label for="city">City</label>
                    <input type="text" id="city" v-model="customer.customerAddress.city">

                </li>
                <li>
                    <label for="country">Country</label>
                    <input type="text" id="country" v-model="customer.customerAddress.country">

                </li>
                <li>
                    <label for="postalCode">Postal code</label>
                    <input type="number" id="postalCode" v-model="customer.customerAddress.postalCode">

                </li>
                <li>
                    <label for="state">State</label>
                    <input type="text" id="state" v-model="customer.customerAddress.state">

                </li>
            </ul>
        </template>
        <template v-slot:footer>
            <solar-btn type="button" @button:click="save" aria-label="save new customer">
                Save Customer
            </solar-btn>
            <solar-btn type="button" @button:click="close" aria-label="Close modal">
                Close
            </solar-btn>


        </template>
    </solar-modal>
</template>
<script lang="ts">
import Component from 'vue-class-component';
import SolarBtn from '../SolarBtn.vue';
import Vue from 'vue';
import SolarModal from './SolarModal.vue';
import { ICustomer } from '@/types/Customer';

@Component({
    name: 'NewCustomerModal',
    components: { SolarBtn, SolarModal }
})

export default class NewCustomerModal extends Vue {

    customer: ICustomer = {
        id: 0,
        firstName: '',
        lastName: '',
        customerAddress: {
            id: 0,
            addressLine: '',
            city: '',
            state: '',
            postalCode: '',
            country: ''
        },

        dateCreated: new Date()
    };

    save() {
        this.$emit('save:customer', this.customer);
    }
    close() {
        this.$emit('close')
    }
}
</script>

<style scoped lang="scss">
.newCustomer {
    display: flex;
    flex-wrap: wrap;
    list-style: none;
    padding: 0;
    margin: 0;

    input {
        width: 80%;
        height: 1.8rem;
        margin-right: 2rem;
        font-size: 1.1rem;
        line-height: 1.3rem;
        padding: 0.2rem;
        color: #555;


    }

    label {
        font-weight: bold;
        margin: 0.8rem;
        display: block;
    }
}
</style>