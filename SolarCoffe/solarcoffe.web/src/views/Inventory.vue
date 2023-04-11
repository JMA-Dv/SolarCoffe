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

            <SolarBtn @click="showShipmentModal" id="receiveShipmentBtn">
                Receive shipment</SolarBtn>


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


        <new-product-modal v-if="isNewProductVisible" />
        <shipment-modal v-if="isShipmentVisible" />
    </div>
</template>

<script lang="ts">
import Component from 'vue-class-component';
import Vue from 'vue';
//Since it's not a default export it's wrapped in a curly sintax
import { IProductInventory } from '@/types/Product';
import SolarBtn from '@/components/SolarBtn.vue';

@Component({
    name: 'Inventory',
    components: { SolarBtn }
})

export default class Inventory extends Vue {
    isNewProductVisible: boolean = false;
    isShipmentVisible: boolean = false;


    inventory: IProductInventory[] = [
        {
            id: 1,
            idealQuantity: 2, quantityOnHand: 2,
            product: {
                name: "Product example", dateCreated: new Date(),
                dateUpdated: new Date(),
                description: "This is mock data",
                id: 1, isArchived: false, isTaxable: true, price: 20
            }
        },
        {
            id: 2,
            idealQuantity: 4, quantityOnHand: 3,
            product: {
                name: "Product super nice", dateCreated: new Date(),
                dateUpdated: new Date(),
                description: "This is mock data for all purpouses",
                id: 2, isArchived: false, isTaxable: false, price: 50
            }
        }
    ];

}

// showNewProductModal(){

// }

// showShipmentModal(){

// }
</script>

<style scoped>
.inventoryTitle {
    font-size: 30px;
}
</style>