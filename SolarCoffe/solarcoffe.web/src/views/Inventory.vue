<template>
    <div class="inventory-container">
        <h1 class="inventoryTitle">
            Inventory Dashboard
        </h1>
    </div>
</template>

<script lang="ts">
import Component from 'vue-class-component';
import Vue from 'vue';

@Component({
    name: 'Inventory',
    components: {}
})

export default class Inventory extends Vue {

}
</script>

<style scoped>
.inventoryTitle {
    font-size: 30px;
}
</style>