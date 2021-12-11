<template>
  <div style="overflow: scroll; height: 100%">
    <Header v-if="screenSize > 1000" title="Login" :large="false" />
    <Quests :quests="quests" />
  </div>
</template>

<script>
import Quests from "../components/Quests";
import Header from "../components/Header";
import axios from "axios";

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
  async created() {
    try {
      let token = localStorage.getItem("accessToken");
      // console.log(token);

      const response = await axios.get("/api/Quests/begun", {
        headers: { Authorization: `Bearer ${token}` },
      });

      console.log("Success");
      console.log(response);

      for (let quest of response.data) {
        this.quests.push({
          id: quest.questId,
          title: quest?.questName ?? "",
          desc: quest?.questDescription ?? "",
          questLength: quest?.duration ?? 1,
          questProgress: quest?.sinceStart ?? 0,
          daysLeft: quest?.duration - quest?.sinceStart,
        });
      }
    } catch (e) {
      console.log(e);
    }

    window.addEventListener("resize", this.resizeWindowHandler);
  },
  destroyed() {
    window.removeEventListener("resize", this.resizeWindowHandler);
  },
};
</script>
