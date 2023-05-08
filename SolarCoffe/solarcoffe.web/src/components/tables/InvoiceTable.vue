<template>
    <div>
        <table class="table">
            <thead>
                <tr>
                    <th>Product</th>
                    <th>Description</th>
                    <th>Qty</th>
                    <th>Price</th>
                    <th>Subtotal</th>
                </tr>
            </thead>
            <tr v-for="item in lineItem" :key="item.product.id">
                <td>{{ item.product.name }}</td>
                <td>{{ item.product.description }}</td>
                <td>{{ item.quantity }} </td>
                <td>{{ item.product.price }}</td>

                <td>{{ subTotal(item.product.price, item.quantity) | price }}</td>
            </tr>

            <tr>
                <slot name="grandTotal"></slot>
            </tr>

            <tfoot>
                <slot name="tableFooter">

                </slot>
            </tfoot>
        </table>
    </div>
</template>
<script lang="ts">
import Component from 'vue-class-component';
import Vue from 'vue'
import { Prop } from 'vue-property-decorator';
import { ILineItem } from '@/types/IInvoice';

@Component({ name: "InvoiceTable" })

export default class InvoiceTable extends Vue {

    @Prop({ required: true })
    lineItem: ILineItem[] = [];

    subTotal(price: number, quantity: number): number {
        return (price * quantity);
    }
}
</script>


<style lang="scss">
@import '@/scss/global.scss';

.due {
    font-weight: bold;
}

.price-final {
    font-weight: bold;
    color: $solar-green;
}

.invoice-step-detail {
    margin: 1.2rem;
}

.due {
    font-weight: bold;
}
</style>