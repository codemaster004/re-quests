<template>
    <div class="user-container">
        <div class="user-box">
            <img src="images/user.jpg" alt="" />
            <h3 class="header">{{ username }}</h3>
        </div>

        <div>
            <div class="user-info-box">
                <div class="user-tabs">
                    <div class="tab" :class="{ selected: selected == 'rewads' }" @click="changeUserTab('rewads')">Rewards</div>
                    <div class="line"></div>
                    <div class="tab" :class="{ selected: selected == 'quests' }" @click="changeUserTab('quests')">Quests</div>
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
import axios from "axios";

export default {
    name: "Profile",
    components: { Reward, QuestsStats },
    methods: {
        changeUserTab(toTab) {
            this.selected = toTab;
        },
        async fetchUserData() {
            try {
                const { data } = await axios.get("/api/Users/me", {
                    headers: { Authorization: `Bearer ${this.token}` },
                });
                console.log(data);
                this.username = data.username;
            } catch (e) {
                console.log(e);
            }
        },
        async fetchRewards() {
            try {
                const { data } = await axios.get("/api/Quests/completed", {
                    headers: { Authorization: `Bearer ${token}` },
                });
                console.log(data);
                this.username = data.username;
            } catch (e) {
                console.log(e);
            }
        },
        async fetchQuests() {
            try {
                const { data } = await axios.get("/api/Quests/begun", {
                    headers: { Authorization: `Bearer ${this.token}` },
                });
                console.log(data);
                for (let quest of data) {
                    this.quests.push({
                        title: quest.questName,
                        img: "",
                        completed: quest?.sinceStart < quest?.duration ? quest?.sinceStart / quest?.duration : 100,
                    });
                    console.log(quest?.sinceStart, quest?.duration);
                    console.log(quest?.sinceStart / quest?.duration);
                }
            } catch (e) {
                console.log(e);
            }
        },
    },
    data() {
        return {
            rewards: [],
            quests: [],
            selected: "quests",
            username: "Maja Kowalaska",
        };
    },
    created() {
        this.token = localStorage.getItem("accessToken");
        this.fetchUserData();
        this.fetchQuests();
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
    padding-bottom: 15px;
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
