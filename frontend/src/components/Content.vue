<template>
  <div class="content">
    <router-view></router-view>
  </div>
</template>

<script>
export default {
  name: "Content-component",
};
</script>

<style scoped>
.content {
  grid-area: content;
  background-color: #232b3e;
  padding: 0px;
  margin: 0px;
  overflow: auto;
}
</style>
