<template>
    <section>
        <div v-if="!quests.length">You haven't started any quests yet.</div>
        <div v-for="quest in quests" :key="quest.id">
            <QuestCard :quest="quest" />
        </div>
        <p class="header">Start New Quests</p>
        <div v-for="quest in questsNew" :key="quest.id">
            <QuestNew :quest="quest" />
        </div>
    </section>
</template>

<script>
import QuestCard from "./QuestCard";
import QuestNew from "./QuestNew.vue";
import axios from "axios";

export default {
    name: "Quests",
    props: {
        quests: Array,
    },
    components: {
        QuestCard,
        QuestNew,
    },
    data() {
        return {
            questsNew: [],
        };
    },
    async created() {
        try {
            let token = localStorage.getItem("accessToken");

            const { data } = await axios.get("/api/Quests/available", {
                headers: { Authorization: `Bearer ${token}` },
            });
            console.log(data);

            for (let quest of data) {
                this.questsNew.push({
                    id: quest.id,
                    title: quest.name,
                    description: quest.description,
                });
            }

            console.log(this.questsNew);
        } catch (e) {
            console.log(e);
        }
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

section > .header {
    color: #fff;
    margin-bottom: 15px;
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
