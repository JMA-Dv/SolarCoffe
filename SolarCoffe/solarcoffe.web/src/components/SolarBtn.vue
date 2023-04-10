<template>
    <div class="btn-link">
        <button :class="['solar-btn', { 'full-width': isFullWidth }]" v-on:click="visitRoute">
            <slot></slot>
        </button>
    </div>
</template>

<script lang="ts">
import Component from 'vue-class-component';
import Vue from 'vue';
import { Prop } from 'vue-property-decorator';


@Component({
    name: 'SolarBtn',
    components: {}
})

export default class SolarBtn extends Vue {
    @Prop({ required: false, type: String })
    link?: string;
    @Prop({ required: false, type: Boolean, default: false })
    isFullWidth?: string;

    //TODO: Replace prop link to 'to'
    visitRoute(): void {
        this.$router.push(this.link);
    }

}
</script>

<style scoped lang="scss">
@import "@/scss/global.scss";

.solar-btn {
    background-color: lighten($color: $solar-blue, $amount: 10%);
    color: white;
    padding: 0.8rem;
    transition: background-color 0.5s;
    margin: 0.3rem 0.2rem;
    display: inline-block;
    cursor: pointer;
    font-size: 1rem;
    min-width: none;
    border-radius: 2px solid darken($solar-blue, 20%);
    border-radius: 3px;
}


.btn-link {
    width: 100%;
}

.full-width {
    display: block;
    width: 100%;
}
</style>