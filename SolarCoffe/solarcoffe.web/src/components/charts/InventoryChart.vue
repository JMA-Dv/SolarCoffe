<template>
    <div>
        <ApexCharts type="area" :width="'100%'" height="300" :options="options" :series="series">

        </ApexCharts>

    </div>
</template>

<script lang="ts">
import Component from 'vue-class-component';
import Vue from 'vue';
import ApexCharts from 'apexcharts';
import { IInventoryTimeline } from '@/types/InventoryGraph';

@Component({
    name: 'InventoryChart',
    components: {}
})

export default class InventoryChart extends Vue {
    snapshotTimeline: IInventoryTimeline;

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
                categories: this.snapshotTimeline.timeline,

                type: 'datetime'

            },

        }

    }
}
</script>
<style scoped lang="scss"></style>