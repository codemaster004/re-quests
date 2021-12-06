<template>
    <section>
        <div :key="quest.id" v-for="quest in quests">
            <QuestCard :quest="quest" />
        </div>
    </section>
</template>

<script>
import QuestCard from "./QuestCard";

export default {
    name: 'Quests',
    props: {
        quests: Array
    },
    components: {
        QuestCard
    }
}
</script>

<style scoped>
	section {
		margin-top: 10px;
        
		display: flex;
		align-items: center;
        flex-direction: column;
	}
</style>