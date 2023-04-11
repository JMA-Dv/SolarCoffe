<template>
    <solar-modal>
        <template v-slot:header>
            Receive Shipment
        </template>
        <template v-slot:body>
            <label for="product">Product Received</label>
            <select v-model="selectedProduct" class="shipmentItems" id="product">
                <option disabled value="">Plase select one</option>
                <option v-for="item in inventory" :value="item" :key="item.id">
                    {{ item. }}

                </option>
            </select>
            <label for="qtyReceived">Quantity Received: </label>
            <input type="number" id="qtyReceived" v-model="qtyReceived">
        </template>
        <template v-slot:footer>
            <solar-btn type="button" @button:click="save" aria-label="save new shipment">

                Save Received Shipment
            </solar-btn>

            <solar-btn type="button" @button:click="close" aria-label="Close modal">
                Close
            </solar-btn>
        </template>
    </solar-modal>
</template>

<script lang="ts">
import Vue from "vue";
import Component from "vue-class-component";
import SolarBtn from "../SolarBtn.vue";
import SolarModal from "./SolarModal.vue";
import { Prop } from "vue-property-decorator";
import { IProduct, IProductInventory } from "@/types/Product";
@Component({
    name: 'ShipmentModal',
    components: { SolarModal, SolarBtn }
})

export default class ShipmentModal extends Vue {

    @Prop({ required: true, type: Array as () => IProductInventory[] })
    inventory!: IProductInventory

    close() {
        this.$emit("close");
    }

    selectedProduct: IProduct = {
        dateCreated: new Date(),
        dateUpdated: new Date(),
        id: 0,
        description: "",
        isArchived: true,
        isTaxable: false,
        name: "",
        price: 20,

    };
    qtyReceived: number = 0;

}
</script>
