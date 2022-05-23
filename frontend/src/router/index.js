import Vue from "vue";
import VueRouter from "vue-router";

Vue.use(VueRouter);

const routes = [
  {
    path: "/",
    name: "dashboard",
    component: () => import("../views/Dashboard.vue"),
  },
];

const router = new VueRouter({
  mode: "history",
  routes,
});

export default router;
