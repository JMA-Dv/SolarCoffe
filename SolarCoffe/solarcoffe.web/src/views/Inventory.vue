<template>
    <div class="inventory-container">
        <h1 class="inventoryTitle">
            Inventory Dashboard
        </h1>
        <hr>
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
                <td>{{ item.product.price }} </td>
                <td>{{ item.product.isTaxable }}</td>
                <td>
                    <div v-if="item.product.isArchived">Check</div>
                    <div v-else>X</div>
                </td>
            </tr>
        </table>
    </div>
</template>

<script lang="ts">
import Component from 'vue-class-component';
import Vue from 'vue';
//Since it's not a default export it's wrapped in a curly sintax
import { IProductInventory } from '@/types/Product';

@Component({
    name: 'Inventory',
    components: {}
})

export default class Inventory extends Vue {

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
                id: 2, isArchived: false, isTaxable: true, price: 50
            }
        }
    ];

}
</script>

<style scoped>
.inventoryTitle {
    font-size: 30px;
}
</style>