<template>
    <section>
        <div class="section-content">
            <div>
                <div v-if="!quests.length">You haven't started any quests yet.</div>
                <div v-for="quest in quests" :key="quest.id">
                    <QuestCard @card-hover="cardHovered" :quest="quest" />
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
            <h3 class="sub-header">{{ questInfo.title }}</h3>
            <h3 class="header">Do this every day. Why?</h3>
            <img :src="require(`../assets/${questInfo.img}`)" alt="" v-if="questInfo.img" />
            <p>
                {{ questInfo.description }}
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
    methods: {
        cardHovered(e, id) {
            let quest = this.quests.filter((quest) => quest.id == id);
            if (quest[0]) {
                this.questInfo.title = quest[0].title;
                this.questInfo.desc = quest[0].desc;
                this.questInfo.img = quest[0].imgUrl;
            }
        },
    },
    data() {
        return {
            questsNew: [],
            questInfo: {
                title: "",
                description: "",
                img: "",
            },
        };
    },
    async created() {
        try {
            let token = localStorage.getItem("accessToken");

            const { data } = await axios.get("/api/Quests/available", {
                headers: { Authorization: `Bearer ${token}` },
            });

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
        object-fit: contain;
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
</style>
