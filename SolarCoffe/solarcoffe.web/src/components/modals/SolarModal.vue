<template>
    <Transition name="modal-fade">

    </Transition>
</template>
<script lang="ts">
import Vue from "vue";
import Component from "vue-class-component";
import SolarBtn from "../SolarBtn.vue";
@Component({
    name: 'SolarModal',
    components: { SolarBtn }
})

export default class SolarModal extends Vue {


    close() {
        this.$emit("close");
    }


}
</script>


<style scoped lang="scss">
@import "@/scss/global.scss";

.modal-fade {
    position: fixed;
    top: 0;
    bottom: 0;
    left: 0;
    right: 0;

    background-color: rgba(0, 0, 0, 0.6);
    display: flex;
    justify-content: center;
    align-items: center;
}

.modal {
    background-color: #fff;
    box-shadow: 2px 2px 20px 1px;
    display: flex;
    flex-direction: column;
    width: 640px;
    border-radius: 3px;
}

.modal-header {
    padding: 15px;
    display: flex;
    color: #fff;
    background-color: $solar-blue;
    font-size: 1.2rem;
    font-weight: bold;
    border-bottom: 1px solid #eee;
    justify-content: space-between;

}

.modal-footer {
    padding: 15px;
    display: flex;
    border-top: 1px solid #eee;
    justify-content: flex-end;
}

.modal-body {
    position: relative;
    padding: 2.4rem;
}
</style>