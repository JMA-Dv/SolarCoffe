<template>
    <solar-modal>
        <template v-slot:header>
            Receive Shipment
        </template>
        <template v-slot:body>
            <label for="product">Product Received</label>
            <select v-model="selectedProduct" class="shipmentItems" id="product">
                <option disabled value="">Plase select one</option>
                <option v-for="items in inventory" :value="items.product" :key="items.id">
                    {{ items.product.name }}

                </option>
            </select>
            <label for="qtyReceived">Quantity Received: </label>
            <input type="number" id="qtyReceived" v-model.number="qtyReceived">
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
import { IShipment } from "@/types/Shipment";
@Component({
    name: 'ShipmentModal',
    components: { SolarModal, SolarBtn }
})

export default class ShipmentModal extends Vue {

    @Prop({ required: true, type: Array as () => IProductInventory[] })
    inventory!: IProductInventory[]



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


    save(): void {
        console.log("🚀 ~ file: ShipmentModal.vue:50 ~ ShipmentModal ~ save ~ save:", this.selectedProduct)

        let shipment: IShipment = {
            productId: this.selectedProduct.id,
            adjustment: this.qtyReceived
        };
        this.$emit('save:shipment', shipment);
    }
    close() {
        console.log("🚀 ~ file: ShipmentModal.vue:58 ~ ShipmentModal ~ close ~ close:")
        this.$emit("close");
    }




}
</script>
