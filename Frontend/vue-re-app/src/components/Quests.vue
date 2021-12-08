<template>
  <section>
    <div v-for="quest in quests" :key="quest.id">
      <QuestCard :quest="quest" />
    </div>
  </section>
</template>

<script>
import QuestCard from "./QuestCard";

export default {
  name: "Quests",
  props: {
    quests: Array,
  },
  components: {
    QuestCard,
  },
};
</script>

<style scoped>
section {
  margin-top: 20px;

  display: flex;
  align-items: center;
  flex-direction: column;
}
</style>
