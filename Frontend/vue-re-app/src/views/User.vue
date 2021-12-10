<template>
  <div class="user-container">
    <div class="user-box">
      <img src="images/user.jpg" alt="" />
      <h3 class="header">{{ username }}</h3>
    </div>

    <div>
      <div class="user-info-box">
        <div class="user-tabs">
          <div
            class="tab"
            :class="{ selected: selected == 'rewads' }"
            @click="changeUserTab('rewads')"
          >
            Rewards
          </div>
          <div class="line"></div>
          <div
            class="tab"
            :class="{ selected: selected == 'quests' }"
            @click="changeUserTab('quests')"
          >
            Quests
          </div>
        </div>
      </div>

      <div v-if="selected == 'rewads'">
        <Reward :rewards="rewards" />
      </div>
      <div v-else-if="selected == 'quests'">
        <QuestsStats :quests="quests" />
      </div>
    </div>
  </div>
</template>

<script>
import Reward from "../components/Reward";
import QuestsStats from "../components/QuestsStats";

export default {
  name: "Profile",
  components: { Reward, QuestsStats },
  methods: {
    changeUserTab(toTab) {
      this.selected = toTab;
    },
  },
  data() {
    return {
      rewards: [
        {
          id: 0,
          img: "",
          color: "red",
        },
        {
          id: 1,
          img: "",
          color: "blue",
        },
        {
          id: 2,
          img: "",
          color: "violet",
        },
      ],
      quests: [
        {
          img: "",
          title: "Paper bag",
          completed: 33,
        },
        {
          img: "",
          title: "Golder plastick",
          completed: 75,
        },
        {
          img: "",
          title: "glossy",
          completed: 100,
        },
      ],
      selected: "rewads",
      username: "Maja Kowalaska",
    };
  },
};
</script>

<style scoped>
.user-container {
  width: 100%;
  height: 100%;
  min-height: 100%;

  padding-top: 100px;
  display: flex;
  flex-direction: column;
  justify-content: space-between;

  background-color: #fff;
}

.user-box {
  text-align: center;
}

h3 {
  font-family: Oswald;
  font-style: normal;
  font-weight: 500;
  font-size: 20px;
  line-height: 30px;

  text-align: center;

  color: #000000;
}

.user-info-box {
  margin-top: 80px;
}

.user-tabs {
  display: flex;
  justify-content: space-around;
  padding: 30px;
}

.tab {
  font-family: Montserrat;
  font-style: normal;
  font-weight: 600;
  font-size: 15px;
  line-height: 17px;
  display: flex;
  align-items: center;
  text-align: center;

  transition: 0.5s;

  color: #000000;
}
.tab.selected {
  color: #4c866b;
  transform: translateY(-10px);
}

.line {
  width: 1px;
  height: 25px;
  background-color: #ddd;
}
</style>
