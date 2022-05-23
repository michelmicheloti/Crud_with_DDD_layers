<template>
  <footer class="footer">
    <p id="footer-title">
      &copy; {{ yearCopyRight }} - Engenharia de Software 2 - Facens
    </p>
  </footer>
</template>

<script>
export default {
  name: "Footer-component",
  computed: {
    yearCopyRight() {
      return new Date().getFullYear();
    },
  },
};
</script>

<style scoped>
.footer {
  grid-area: footer;
  background-color: #262626;
  color: #fff;
  text-align: center;

  display: flex;
  justify-content: center;
  align-content: center;
}

.footer img {
  width: 70px;
  margin-left: 5px;
  vertical-align: middle;
  border-style: none;
}

.footer p {
  display: flex;
  justify-content: center;
  align-items: center;

  margin: 0px;
}

@media (max-width: 522px) {
  .footer #footer-title {
    display: none;
  }
}
</style>
