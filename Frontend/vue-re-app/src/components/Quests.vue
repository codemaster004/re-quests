<template>
    <section>
        <div v-if="!quests.length">You haven't started any quests yet.</div>
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

@media screen and (min-width: 1300px) {
    section {
        width: 66%;
    }
}

@media screen and (min-width: 1000px) {
    section {
        display: flex;
        flex-direction: row;
        justify-content: space-around;
        padding: 0 25px;
        flex-wrap: wrap;
    }

    section > div {
        margin: 10px;
    }
}
</style>
