<template>
    <div class="new-quest" :class="{ dissapear: !show }">
        <div>
            <h2 class="header">{{ quest.title }}</h2>
            <p class="sub-header">{{ quest.description }}</p>
        </div>

        <div @click="startQuest()" class="action-button">Start Quest</div>
    </div>
</template>

<script>
import axios from "axios";

export default {
    name: "QuestNew",
    props: {
        quest: Object,
    },
    methods: {
        async startQuest(e) {
            try {
                let token = localStorage.getItem("accessToken");
                const response = await axios.post(`/api/Quests/${this.quest.id}/begin`, "", {
                    headers: { Authorization: `Bearer ${token}` },
                });
                this.hideQuestCard();
            } catch (e) {
                console.log(e);
            }
        },
        hideQuestCard() {
            console.log(false);
            this.show = false;
        },
    },
    data() {
        return {
            show: true,
        };
    },
};
</script>

<style scoped>
.new-quest {
    width: 340px;
    background-color: #fff;
    border-radius: 15px;
    box-shadow: 0px 0px 10px rgba(0, 0, 0, 0.15);
    display: flex;
    align-items: center;
    justify-content: space-between;
    padding: 20px;
    margin: 5px;
    margin-bottom: 20px;
}

.action-button {
    padding: 0 15px;
    font-size: 15px;
    height: 35px;
    line-height: 35px;
    border-radius: 8px;
}

.header {
    height: 30px;

    color: #000000;
}
.sub-header {
    height: 18px;

    color: #999999;
}

.dissapear {
    animation: dessapear 1s ease-out;
    animation-fill-mode: forwards;
}

@keyframes dessapear {
    0% {
        opacity: 1;
        display: block;
        height: auto;
        padding: 20px;
        margin-bottom: 20px;
        visibility: inherit;
    }

    99% {
        opacity: 0;
        display: block;
        height: auto;
        padding: 20px;
        margin-bottom: 20px;
        visibility: inherit;
    }
    100% {
        opacity: 0;
        display: none;
        height: 0;
        margin: 0;
        padding: 0;
        visibility: hidden;
    }
}
</style>
