<template>
  <header :class="{ 'header-large': large }">
    <div v-if="large">
      <h1 class="title title-large">Hello, Filip</h1>
      <p class="sub-title">Stay on your Goal</p>
    </div>
    <div v-else>
      <h1 class="title">{{ currentRouteName }}</h1>
    </div>
  </header>
</template>

<script>
import { useRouter, useRoute } from "vue-router";

export default {
  name: "Header",
  props: {
    title: String,
    large: Boolean,
  },
  computed: {
    currentRouteName() {
      const route = useRoute();

      return route.name;
    },
  },
};
</script>

<style scoped>
header {
  padding: 0 25px;
  display: inline-block;

  position: relative;
  z-index: 100;
  text-align: center;
}

.header-large {
  display: block;
}

.title {
  color: #ffffff;
  line-height: 45px;
}

.sub-title {
  height: 16px;
  margin-top: 3px;

  line-height: 16px;
  color: #dddddd;
}

@media screen and (min-width: 1000px) {
  .content .title {
    color: #000000;
  }
}
</style>
