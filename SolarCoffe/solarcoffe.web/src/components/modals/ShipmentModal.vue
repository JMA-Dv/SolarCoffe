<template></template>
<script lang="ts">
import Vue from "vue";
import Component from "vue-class-component";
import SolarBtn from "../SolarBtn.vue";
import SolarModal from "./SolarModal.vue";
@Component({
    name: 'ShipmentModal',
    components: { SolarModal, SolarBtn }
})

export default class ShipmentModal extends Vue {

}
</script>
