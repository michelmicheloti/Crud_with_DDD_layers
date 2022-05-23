<template>
  <div id="main">
    <Header></Header>
    <Content></Content>
    <Footer></Footer>
  </div>
</template>

<script>
// import axios from "./config/axios";
import Header from "./components/Header.vue";
import Content from "./components/Content.vue";
import Footer from "./components/Footer.vue";

export default {
  name: "App",
  components: { Header, Content, Footer },
  data: function () {
    return {};
  },
  methods: {},
  created() {},
};
</script>

<style>
body {
  margin: 0;
  padding: 0;
}

#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
}

#main {
  height: 100vh;
  display: grid;
  grid-template-rows: 64px 1fr 60px;
  grid-template-columns: 1fr;
  grid-template-areas:
    "header"
    "content"
    "footer";
}

#main.hide-template {
  grid-template-areas:
    "content"
    "content"
    "content";
}

.table {
  color: white !important;
}
</style>
