import Vue from "vue";
import App from "./App.vue";
import router from "./router";
import store from "./store";

import "font-awesome/css/font-awesome.css";
import "./config/axios";
import "./config/bootstrap";
import "./config/msgToast";

Vue.config.productionTip = false;

new Vue({
  router,
  store,
  render: (h) => h(App),
}).$mount("#app");
