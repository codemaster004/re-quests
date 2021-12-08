<template>
	<main>
		<div id="bgc"></div>
		<Nav />
		<div class="content">
			<Header />
			<router-view></router-view>
		</div>
		<footer>
			<router-link to="/">Home</router-link>
			<router-link to="/about">About</router-link>
		</footer>
	</main>
</template>

<script>
import Header from './components/Header'
import Nav from './components/Nav'

export default {
	name: 'App',
	components: {
		Header,
		Nav
  	},
	data() {
		return {
			quests: []
		}
	},
}
</script>

<style scoped>
.content {
	padding-top: 50px;
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
  overflow: hidden;
}

#bgc {
	background-color: #4C866B;
	background: linear-gradient(180deg, #3C7B5F 0%, #2B684A 100%);
	height: 100vh;
	width: 100%;
	position: fixed;
	z-index: -1;
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
