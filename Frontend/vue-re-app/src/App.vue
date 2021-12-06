<template>
	<main>
		<Header />
		<section>
			<QuestCard title="Paper Busket" desc="In this week remeber to use paper bags only." questLength=7 questProgress=3 />
		</section>
	</main>
</template>

<script>
import Header from './components/Header'
import QuestCard from './components/QuestCard'

export default {
  name: 'App',
  components: {
		Header,
		QuestCard
  },
	data() {
		return {
			cards: []
		}
	},
	created() {
		this.cards = [
			{
				title: 'Paper Busket',
				desc: 'In this week remeber to use paper bags only.',
				questLength: 7,
				questProgress: 3
			}
		]
	}
}
</script>

<style scoped>
	section {
		display: flex;
		align-items: center;
		justify-content: center;
		margin-top: 10px;
	}
</style>

<style>
@import url('https://fonts.googleapis.com/css2?family=Montserrat:wght@300;400;500;600;700&family=Oswald:wght@300;400;500;600;700&display=swap');

* {
  margin: 0;
  padding: 0;
  box-sizing: border-box;	
}

body {
	background-color: #4C866B;
}

#app {
  font-family: 'Montserrat', sans-serif;
	background-color: #4C866B;
	background: linear-gradient(180deg, #4C866B 0%, #337053 100%);
	min-height: -webkit-fill-available;
}

.absolute-center {
	position: absolute;
	top: 50%;
	left: 50%;
	transform: translate(-50%, -50%);
}

.title {
	font-family: Oswald;
	font-style: normal;
	font-weight: 500;
	font-size: 34px;
}

.sub-title {
	font-family: Montserrat;
	font-style: normal;
	font-weight: 600;
	font-size: 13px;
}

.header {
	font-family: Oswald;
	font-style: normal;
	font-weight: 500;
	font-size: 20px;
	line-height: 30px;
}

.sub-header {
	font-family: Montserrat;
	font-style: normal;
	font-weight: 600;
	font-size: 11px;
	line-height: 13px;
}

.action-button {
	height: 40px;
	
	font-family: Oswald;
	font-style: normal;
	font-weight: 500;
	font-size: 17px;
	line-height: 40px;
	text-align: center;
	
	background: #EFDEBC;
	border-radius: 10px;
	color: #FFFFFF;
}

</style>
