<template >
    <div class="side-menu-container">

        <router-link to="/">

            <img src="../assets/images/logo.jpg" alt="Loro logo" id="logoImg">
        </router-link>
        <h1>Management Portal</h1>

        <router-link to="/inventory">
            <SolarBtn isFullWidth id="menuInventory">
                Inventory
            </SolarBtn>
        </router-link>


        <router-link to="/customers">

            <SolarBtn isFullWidth id="menuCustomer">
                Manage Customers
            </SolarBtn>
        </router-link>

        <router-link to="/orders">
            <SolarBtn isFullWidth id="menuOrders">
                Orders
            </SolarBtn>
        </router-link>

        <router-link to="/invoice/new">

            <SolarBtn isFullWidth id="menuInvoiceNew">
                New Invoice
            </SolarBtn>
        </router-link>



    </div>
</template>

<script lang="ts">
import { Component, Vue } from 'vue-property-decorator';
import SolarBtn from './SolarBtn.vue';
// import { RouterLink } from 'vue-router';

@Component({
    name: 'SideMenu',
    components: { SolarBtn }
})
export default class SideMenu extends Vue { }

</script>
<style scoped lang="scss">
@import "@/scss/global.scss";

.side-menu-container {
    background-color: #fcfcfc;
    height: 100vh;
    width: $menu-width;
    display: flex;
    flex-direction: column;
    padding: 0.8rem;
    box-shadow: 0 1px 1px rgba(0, 0, 0, 0.12), 0 1px 1px rgba(0, 0, 0, 0.24);
    box-sizing: border-box;
}

#logoImg {
    width: 100%;
}

#menuInventory {}

h1 {
    font-size: 1.2rem;
    margin: 1rem 0;
}
</style>