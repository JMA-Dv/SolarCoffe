import Vue from "vue";
import VueRouter, { RouteConfig } from "vue-router";

Vue.use(VueRouter);

const routes: Array<RouteConfig> = [
  {
    path: "/orders",
    name: "order",
    component: () => import("../views/Orders.vue")
  },
  {
    path: "/",
    name: "home",
    // route level code-splitting
    // this generates a separate chunk (about.[hash].js) for this route
    // which is lazy-loaded when the route is visited.
    component: () =>
      import(/* webpackChunkName: "about" */ "../views/Inventory.vue"),
  },

  {
    path: "/inventory",
    name: "inventory",
    component: () => import("@/views/Inventory.vue")
  },
  {
    path: "/customers",
    name: "customers",
    component: () => import("@/views/Customers.vue")
  },
  {
    path: "/invoice/new",
    name: "create-invoice",
    component: () => import("@/views/CreateInvoice.vue")
  },

];

const router = new VueRouter({
  mode: "history",
  base: process.env.BASE_URL,
  routes,
});

export default router;
