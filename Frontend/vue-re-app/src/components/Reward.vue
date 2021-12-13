<template>
    <div class="user-data">
        <div
            class="reward"
            v-for="reward in rewards"
            :key="reward.id"
            :style="{
                background: createGradient(reward.color),
                'border-radius': createRadius(),
            }"
        >
            <img
                :src="require(`../assets/${reward.imgUrl}`)"
                alt=""
                class="reward-medal"
                v-if="['Bottle.png', 'Can.png', 'PaperBag.png'].includes(reward.imgUrl)"
            />
            <img src="../assets/MedalTransparent.gif" alt="" class="reward-medal" v-else />
        </div>
    </div>
</template>

<script>
export default {
    name: "Reward",
    props: {
        rewards: Array,
    },
    methods: {
        createRadius() {
            let radius = "";
            for (let _ of [0, 0]) {
                let random = Math.floor(Math.random() * 75 + 7);
                radius += `${random}% ${100 - random}% `;
            }
            radius += ` / `;
            let random1 = Math.floor(Math.random() * 75 + 7);
            radius += `${random1}% `;
            let random2 = Math.floor(Math.random() * 75 + 7);
            radius += `${random2}% ${100 - random2}% `;
            radius += `${100 - random1}%`;

            return radius;
        },
        createGradient(color) {
            switch (color) {
                case "red":
                    return "linear-gradient(180deg, #F87F7F 0%, #B94141 100%)";
                case "orange":
                    return "linear-gradient(180deg, #F2DA5C 0%, #C8940D 100%)";
                case "yellow":
                    return "linear-gradient(180deg, #FAF46F 0%, #D3C222 100%)";
                case "green":
                    return "linear-gradient(180deg, #62E3A7 0%, #29AE70 100%)";
                case "blue":
                    return "linear-gradient(180deg, #6082FA 0%, #4060D5 100%)";
                case "cyan":
                    return "linear-gradient(180deg, #5DF0E7 0%, #39B3AB 100%)";
                case "pink":
                    return "linear-gradient(180deg, #EB56D3 0%, #B11298 100%)";
                case "violet":
                    return "linear-gradient(180deg, #B45EF8 0%, #7A26BC 100%)";
                default:
                    return "linear-gradient(180deg, #F87F7F 0%, #B94141 100%)";
            }
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

.reward {
    height: 120px;
    display: inline-block;
    padding: 20px;

    margin: 10px;
}

.reward-medal {
    height: 80px;
    width: 80px;
}
</style>
