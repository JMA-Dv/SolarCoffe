<template>
    <div class="inventory-container">
        <h1 class="inventoryTitle">
            Inventory Dashboard
        </h1>
        <hr>
        <inventory-chart></inventory-chart>
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
                <td :class="`${applyColor(item.quantityOnHand, item.idealQuantity)}`">
                    {{ item.quantityOnHand }}
                </td>
                <td>{{ item.product.price | price }} </td>
                <td>

                    <span v-if="item.product.isTaxable">Yes</span>
                    <span v-else>No</span>

                </td>
                <td>
                    <div class="lni lni-cross-circle product-archive" @click="archiveProduct(item.product.id)">

                    </div>
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
import { ProductService } from '@/services/ProductService';
import InventoryChart from '@/components/charts/InventoryChart.vue';

const productService = new ProductService();
const inventoryService = new InventoryService();
@Component({
    name: 'Inventory',
    components: { SolarBtn, ShipmentModal, NewProductModal, InventoryChart }
})

export default class Inventory extends Vue {
    isNewProductVisible: boolean = false;
    isShipmentVisible: boolean = false;
    inventory: IProductInventory[] = [];


    applyColor(current: number, target: number) {
        if (current <= 1) {
            return "red";
        }
        if (Math.abs(target - current) > 8) {
            return "yellow";
        }
        return "green"
    }

    async saveNewProduct(newProduct: IProduct) {
        await productService.saveProduct(newProduct);
        this.isNewProductVisible = false;
        await this.init();
    }
    async archiveProduct(productId: number) {
        await productService.archive(productId);
        await this.init();
    }
    async saveNewShipment(shipment: IShipment) {
        await inventoryService.UpdateInventoryQuantity(shipment);
        this.isShipmentVisible = false;
        await this.init();
    }

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
        this.$store.dispatch("assignSnapshots");
    }
}

</script>

<style scoped lang="scss">
@import "@/scss/global.scss";

.inventoryTitle {
    font-size: 30px;
}

.green {
    font-weight: bold;
    color: $solar-green;
}

.yellow {
    font-weight: bold;
    color: $solar-yellow;
}

.red {
    font-weight: bold;
    color: $solar-red;
}

.inventory-actions {
    display: flex;
    margin-bottom: 0.8rem;
}

.product-archive {
    cursor: pointer;
    font-weight: bold;
    font-size: 1.2rem;
    color: $solar-red;
}
</style>