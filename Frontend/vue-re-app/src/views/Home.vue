<template>
  <div>
    <Header v-if="screenSize > 1000" title="Login" :large="false" />
    <Quests :quests="quests" />
  </div>
</template>

<script>
import Quests from "../components/Quests";
import Header from "../components/Header";

export default {
  name: "Home",
  components: {
    Quests,
    Header,
  },
  prompt: {
    quests: Array,
  },
  methods: {
    resizeWindowHandler(e) {
      this.screenSize = window.innerWidth;
    },
  },
  data() {
    return {
      quests: [],
      screenSize: window.innerWidth,
    };
  },
  created() {
    this.quests = [
      {
        id: 0,
        title: "Paper Busket",
        desc: "In this week remeber to use paper bags only.",
        questLength: 7,
        questProgress: 3,
      },
      {
        id: 1,
        title: "Sometinhg Else",
        desc: "Lorem ipsum dolores abridge.",
        questLength: 4,
        questProgress: 3,
      },
    ];
    window.addEventListener("resize", this.resizeWindowHandler);
  },
  destroyed() {
    window.removeEventListener("resize", this.resizeWindowHandler);
  },
};
</script>
