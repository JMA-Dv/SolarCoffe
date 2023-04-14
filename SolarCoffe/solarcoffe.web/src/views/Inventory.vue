<template>
    <div class="inventory-container">
        <h1 class="inventoryTitle">
            Inventory Dashboard
        </h1>
        <hr>

        <div class="inventory-actions">
            <SolarBtn @click.native="showNewProductModal" id="addNewBtn">
                Add new Item
            </SolarBtn>

            <SolarBtn @click.native="showShipmentModal" id="receiveShipmentBtn">
                Receive shipment
            </SolarBtn>
        </div>

        <table id="inventoryTable" class="table">
            <tr>
                <th>Item</th>
                <th>Quantity On-hand</th>
                <th>Unit Price</th>
                <th>Taxeable</th>
                <th>Delete</th>
            </tr>

            <tr v-for="item in inventory" :key="item.id">
                <td>
                    {{ item.product.name }}
                </td>
                <td>{{ item.quantityOnHand }}</td>
                <td>{{ item.product.price | price }} </td>
                <td>

                    <span v-if="item.product.isTaxable">Yes</span>
                    <span v-else>No</span>

                </td>
                <td>
                    <span v-if="item.product.isArchived">Check</span>
                    <span v-else>X</span>
                </td>
            </tr>
        </table>


        <new-product-modal v-if="isNewProductVisible" @save:product="saveNewProduct" @close="closeModals" />
        <shipment-modal v-if="isShipmentVisible" :inventory="inventory" @save:shipment="saveNewShipment"
            @close="closeModals" />
    </div>
</template>

<script lang="ts">
import Component from 'vue-class-component';
import Vue from 'vue';
//Since it's not a default export it's wrapped in a curly sintax
import { IProduct, IProductInventory } from '@/types/Product';
import SolarBtn from '@/components/SolarBtn.vue';
import ShipmentModal from '@/components/modals/ShipmentModal.vue';
import NewProductModal from '@/components/modals/NewProductModal.vue';
import { IShipment } from '@/types/Shipment';
import { InventoryService } from '@/services/InventoryService.';


const inventoryService = new InventoryService();
@Component({
    name: 'Inventory',
    components: { SolarBtn, ShipmentModal, NewProductModal }
})

export default class Inventory extends Vue {
    isNewProductVisible: boolean = false;
    isShipmentVisible: boolean = false;


    saveNewProduct(newProduct: IProduct) {
        console.log("🚀 ~ file: Inventory.vue:74 ~ Inventory ~ saveNewProduct ~ newProduct:", newProduct)

    }
    saveNewShipment(shipment: IShipment) {
        console.log("🚀 ~ file: Inventory.vue:77 ~ Inventory ~ saveNewShipment ~ shipment:", shipment)

    }
    inventory: IProductInventory[] = [];
    showNewProductModal(): void {

        this.isNewProductVisible = true
    }

    showShipmentModal(): void {
        this.isShipmentVisible = true;

    }

    closeModals(): void {
        this.isShipmentVisible = false;
        this.isNewProductVisible = false;
    }

    created() {
        this.init();
    }

    async init() {

        this.inventory = await inventoryService.GetInventory();
    }
}

</script>

<style scoped>
.inventoryTitle {
    font-size: 30px;
}
</style>