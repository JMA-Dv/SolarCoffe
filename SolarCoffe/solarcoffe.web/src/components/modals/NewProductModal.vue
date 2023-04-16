<template>
    <solar-modal>
        <template v-slot:header>
            Add new Product
        </template>
        <template v-slot:body>
            <ul class="newProduct">
                <li>
                    <label for="isTaxeable">Is this product taxable?</label>
                    <input type="checkbox" id="isTaxable" v-model="newProduct.isTaxable">
                </li>
                <li>
                    <label for="productName">Name</label>
                    <input type="text" id="productName" v-model="newProduct.name">
                </li>
                <li>
                    <label for="productDescription">Description</label>
                    <input type="text" id="productDescription" v-model="newProduct.description">
                </li>
                <li>
                    <label for="productPrice">Price</label>
                    <input type="number" id="productPrice" v-model.number="newProduct.price">
                </li>
            </ul>

        </template>
        <template v-slot:footer>
            <solar-btn type="button" @click.native="save" aria-label="save new item">
                Save Product
            </solar-btn>
            <solar-btn type="button" @click.native="close" aria-label="close modal">

                Close modal
            </solar-btn>
        </template>
    </solar-modal>
</template>

<script lang="ts">
import Vue from "vue";
import Component from "vue-class-component";
import SolarBtn from "../SolarBtn.vue";
import SolarModal from "./SolarModal.vue";
import { IProduct } from "@/types/Product";
@Component({
    name: 'NewProductModal',
    components: { SolarModal, SolarBtn }
})

export default class NewProductModal extends Vue {


    close() {
        console.log("🚀 ~ file: NewProductModal.vue:54 ~ NewProductModal ~ close ~ close:")
        this.$emit("close");
    }
    /**
     * TODO://Remove default properties
     */
    newProduct: IProduct = {
        dateCreated: new Date(),
        dateUpdated: new Date(),
        id: 0,
        description: "",
        isArchived: false,
        isTaxable: false,
        name: "",
        price: 0,

    };

    save() {
        this.$emit('save:product', this.newProduct);
    }
}
</script>
<style lang="scss" scoped>
.newProduct {
    list-style: none;
    padding: 0;
    margin: 0;

    input {
        width: 100%;
        height: 1.8rem;
        font-size: 1.1rem;
        line-height: 1.3rem;
        padding: 0.2rem;
        color: #555;
    }

    label {
        font-weight: bold;
        display: block;
        margin-bottom: 0.3rem;
    }
}
</style>