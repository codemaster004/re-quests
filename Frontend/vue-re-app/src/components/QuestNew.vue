<template>
    <div class="new-quest">
        <div>
            <h2 class="header">{{ quest.title }}</h2>
            <p class="sub-header">{{ quest.description }}</p>
        </div>

        <div class="action-button">Start Quest</div>
    </div>
</template>

<script>
export default {
    name: "QuestNew",
    props: {
        quest: Object,
    },
};
</script>

<style scoped>
.new-quest {
    width: 340px;
    background-color: #fff;
    border-radius: 15px;
    box-shadow: 0px 0px 10px rgba(0, 0, 0, 0.2);
    display: flex;
    align-items: center;
    justify-content: space-between;
    padding: 20px;
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
</style>
