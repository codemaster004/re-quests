<template>
	<main>
		<Header />
		<section>
			<ChallengeCard />
		</section>
	</main>
</template>

<script>
import Header from './components/Header'
import ChallengeCard from './components/ChallengeCard'

export default {
  name: 'App',
  components: {
		Header,
		ChallengeCard
  },
}
</script>

<style scoped>
	section {
		display: flex;
		align-items: center;
		justify-content: center;
		margin-top: 45px;
	}
</style>

<style>
@import url('https://fonts.googleapis.com/css2?family=Montserrat:wght@300;400;500;600;700&family=Oswald:wght@300;400;500;600;700&display=swap');

* {
  margin: 0;
  padding: 0;
  box-sizing: border-box;	
}

#app {
  font-family: 'Montserrat', sans-serif;
	background: linear-gradient(180deg, #4C866B 0%, #337053 100%);
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

</style>
