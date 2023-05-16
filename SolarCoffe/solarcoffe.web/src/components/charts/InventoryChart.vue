<template>
    <div>
        <apexchart v-if="isTimelineBuilt" type="area" :width="'100%'" height="300" :options="options" :series="series">

        </apexchart>

    </div>
</template>

<script lang="ts">
import VueApexCharts from 'vue-apexcharts';
import Component from 'vue-class-component';
import Vue from 'vue';

import { IInventoryTimeline } from '@/types/InventoryGraph';
import { Sync, Get } from 'vuex-pathify';
Vue.component('apexchart', VueApexCharts)

@Component({
    name: 'InventoryChart',
    components: {}
})

export default class InventoryChart extends Vue {

    @Sync("snapshotTimeline")
    snapshotTimeline?: IInventoryTimeline;

    @Get("isTimelineBuilt")
    isTimelineBuilt?: boolean;

    get options() {
        return {
            dataLabels: {
                enabled: false
            },
            fill: {
                type: 'gradient'
            },
            stroke: {
                curve: 'smooth'
            },
            xaxis: {
                categories: this.snapshotTimeline?.timeline,
                type: 'datetime'
            },
        }
    }

    get series() {
        return this.snapshotTimeline?.productInventorySnapshots.map(item => ({
            name: item.productId,
            data: item.quantityOnHand
        }));
    }

    created() {
        this.$store.dispatch("assignSnapshots");
    }
}
</script>
<style scoped lang="scss"></style>