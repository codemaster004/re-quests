<template>
	<main>
		<div id="bgc"></div>
		<Header />
		<Quests :quests="quests" />
	</main>
</template>

<script>
import Header from './components/Header'
import Quests from './components/Quests'

export default {
  name: 'App',
  components: {
		Header,
		Quests
  },
	data() {
		return {
			quests: []
		}
	},
	created() {
		this.quests = [
			{
				id: 0,
				title: 'Paper Busket',
				desc: 'In this week remeber to use paper bags only.',
				questLength: 7,
				questProgress: 3
			}, {
				id: 1,
				title: 'Sometinhg Else',
				desc: 'Lorem ipsum dolores abridge.',
				questLength: 4,
				questProgress: 3
			},
		]
	}
}
</script>

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
}

#bgc {
	background-color: #4C866B;
	background: linear-gradient(180deg, #4C866B 0%, #337053 100%);
	min-height: -webkit-fill-available;
	position: fixed;
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
