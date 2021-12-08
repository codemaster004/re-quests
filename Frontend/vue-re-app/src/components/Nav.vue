<template>
  <nav>
    <button @click="$emit('burger-clicked')" class="burger">
      <div class="burger-line"></div>
      <div class="burger-line"></div>
    </button>
    <div class="nav-box">
      <div v-for="item in links" :key="item.name">
        <router-link :to="item.to"><NavLink :linkData="item" /></router-link>
      </div>
    </div>
  </nav>
</template>

<script>
import NavLink from "./NavLink";

export default {
  name: "Nav",
  components: {
    NavLink,
  },
  data() {
    return {
      links: [],
    };
  },
  created() {
    this.links = [
      { linkTo: "Main", to: "/", active: true, icon: "" },
      { linkTo: "Notification", to: "/about", active: false, icon: "" },
      { linkTo: "Auth", to: "/login", active: false, icon: "" },
    ];
  },
};
</script>

<style scoped>
nav {
  margin-top: 25px;
  position: absolute;
  top: 0;
  left: 0;
}

.nav-box {
  margin-top: 10vh;
  padding-left: 25px;
  position: relative;
  z-index: 10;
}

.burger {
  margin-left: 25px;
  -webkit-appearance: none;
  border: none;
  background-color: transparent;
  position: relative;
  z-index: 100;
}

.burger .burger-line {
  width: 26px;
  height: 2px;

  background-color: #fff;
}
.burger .burger-line:last-child {
  width: 16px;
  margin-top: 8px;
}
</style>
