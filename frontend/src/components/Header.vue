<template>
  <header class="header">
    <div class="menu">
      <router-link to="/">
        <div class="links-menu">
          <em class="fa fa-home fa-2x"></em>
          <span class="nav-text text-white"> Dashboard </span>
        </div>
      </router-link>
      <!-- <router-link to="/user">
        <div class="links-menu">
          <em class="fa fa-users fa-2x"></em>
          <span class="nav-text text-white"> Usuários </span>
        </div>
      </router-link>
      <router-link to="/card">
        <div class="links-menu">
          <em class="fa fa-address-card fa-2x"></em>
          <span class="nav-text text-white"> Cartões </span>
        </div>
      </router-link>
      <router-link to="#">
        <div class="links-menu" @click.prevent="logout">
          <em class="fa fa-power-off fa-2x"></em>
          <span class="nav-text text-white"> Logout </span>
        </div>
      </router-link> -->
    </div>
    <div id="title"><strong>Car Management</strong></div>
  </header>
</template>

<script>
export default {
  name: "Header-component",
  methods: {
    logout() {
      localStorage.removeItem("key");
      this.$store.commit("setUser", null);
      this.$router.push({ name: "Auth" });
    },
  },
};
</script>

<style scoped>
.header {
  grid-area: header;
  background-color: #262626;
  padding-left: 25px;
  padding-right: 55px;

  display: flex;
  align-items: center;
  justify-content: space-between;
}

.header #title {
  font-size: 1.25rem;
  color: white;
}

.header .menu {
  /* width: 25vw; */
  display: flex;
  flex-direction: row;
  justify-content: space-around;
}

.menu .links-menu {
  width: 150px;
  display: flex;
  flex-direction: row;
  align-items: center;
  justify-content: space-around;
  padding: 5px;
}

a:hover,
a:focus {
  text-decoration: none;
}

em {
  color: white;
}

.links-menu:hover {
  background-color: rgba(255, 255, 255, 0.13);
}
</style>
