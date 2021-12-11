<template>
    <div class="user-data">
        <div class="quest-stat-info" v-for="quest in quests" :key="quest.id">
            <div class="quest-circle" :style="{ background: createRing(quest.completed) }">
                <div class="quest-bgc absolute-center">
                    <img src="" alt="" class="reward-medal" />
                </div>
            </div>
            <h4>{{ quest.title }}</h4>
            <p>{{ quest.completed }}%</p>
        </div>
    </div>
</template>

<script>
export default {
    name: "QuestsStats",
    props: {
        quests: Array,
    },
    methods: {
        createRing(progress) {
            return `conic-gradient(#efdebc ${(360 * progress) / 100}deg, #61aa88 ${(360 * progress) / 100}deg)`;
        },
    },
};
</script>

<style scoped>
.user-data {
    max-height: 60vh;
    overflow: scroll;

    background: #4c866b;
    border-radius: 50px 50px 0px 0px;
    text-align: left;

    padding: 20px;
    display: flex;
    flex-wrap: wrap;
    justify-content: space-around;
}

.quest-circle {
    width: 120px;
    height: 120px;

    position: relative;

    /* background: conic-gradient(#efdebc 20deg, #61aa88 20deg); */
    border-radius: 50%;
}

.quest-bgc {
    width: 115px;
    height: 115px;

    background-color: #4c866b;
    border-radius: 50%;
}

h4 {
    padding: 10px 0;

    font-family: Montserrat;
    font-style: normal;
    font-weight: 600;
    font-size: 15px;
    line-height: 17px;
    text-align: center;

    color: #ffffff;
}

p {
    font-family: Montserrat;
    font-style: normal;
    font-weight: 500;
    font-size: 11px;
    line-height: 13px;

    text-align: center;

    color: #ffffff;
}
</style>
