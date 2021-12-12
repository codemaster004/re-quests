<template>
    <section>
        <div class="section-content">
            <div>
                <div v-if="!quests.length">You haven't started any quests yet.</div>
                <div v-for="quest in quests" :key="quest.id">
                    <QuestCard :quest="quest" />
                </div>
            </div>
            <p class="header">Start New Quests</p>
            <div>
                <div v-for="quest in questsNew" :key="quest.id">
                    <QuestNew :quest="quest" />
                </div>
            </div>
        </div>
        <div class="quest-info">
            <h3 class="sub-header">Paper Bag</h3>
            <h3 class="header">Do this every day. Why?</h3>
            <img src="" alt="" />
            <p>
                Lorem ipsum dolor sit amet, consectetur adipisicing elit. Nihil autem necessitatibus suscipit debitis iste odit, totam nulla tempore
                pariatur vel odio molestias optio adipisci perferendis saepe repudiandae eos magnam soluta.
            </p>
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
    height: 100%;
    min-height: 100%;
}

.section-content {
    margin-top: 20px;
    display: flex;
    flex-direction: column;
}

section > div {
    width: 100%;
    display: flex;
    align-items: center;

    flex-wrap: wrap;
    justify-content: space-around;
}

section > .header {
    color: #fff;
    margin-bottom: 15px;
}

.quest-info {
    display: none;
}

@media screen and (min-width: 1300px) {
    .section-content {
        width: 66%;
        flex-direction: column;
    }

    .section-content > div {
        display: flex;
        width: 100%;
        justify-content: space-around;
    }

    section {
        display: flex;
        align-items: flex-end;
    }

    .quest-info {
        width: 25%;
        height: 80%;
        min-height: 200px;
        margin: 0;
        padding: 15px;

        display: block;
        position: absolute;
        right: 20%;
        bottom: 0;

        display: flex;
        flex-direction: column;
        align-items: flex-start;
        justify-content: flex-start;

        background-color: #337053;
        border-radius: 15px 15px 0 0;
        transform: translateX(50%);

        text-align: letf;
    }

    .quest-info img {
        width: 100%;
        height: 200px;
    }

    .quest-info h3.header,
    .quest-info h3.sub-header {
        color: #fff;
    }

    .quest-info p {
        padding: 10px 0;

        font-family: Montserrat;
        font-style: normal;
        font-weight: 500;
        font-size: 15px;
        line-height: 19px;
        display: flex;
        align-items: center;
        text-align: justify;

        color: #cfcfcf;
    }
}

@media screen and (min-width: 1000px) {
    .quest-info {
        display: none;
    }

    .section-content > div {
        display: flex;
        flex-direction: row;
        justify-content: space-around;
        padding: 0 25px;
        flex-wrap: wrap;
    }

    section p.header {
        color: #000;
        margin-bottom: 15px;
        text-align: center;
    }

    section > div {
        margin: 10px;
    }
}
</style>
