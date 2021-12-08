<template>
  <Quests :quests="quests" />
</template>

<script>
import Quests from "../components/Quests";

export default {
  name: "Home",
  components: {
    Quests,
  },
  prompt: {
    quests: Array,
  },
  data() {
    return {
      quests: [],
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
  },
};
</script>
