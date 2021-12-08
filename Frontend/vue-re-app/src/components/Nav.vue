<template>
	<nav>
		<div class="burger">
			<div class="burger-line"></div>
			<div class="burger-line"></div>
		</div>
	</nav>
</template>

<script>
// import NavLink from './NavLink'

export default {
    name: 'Nav',
	// components: {
	// 	NavLink,
	// }
}

</script>

<style scoped>
nav {
	margin-top: 25px;
	position: fixed;
	top: 0;
	left: 0;
}

.burger {
	margin-left: 25px;
}

.burger .burger-line {
	width: 26px;
	height: 2px;

	background-color: #fff;
}
.burger .burger-line:last-child {
	width: 16px;
	margin-top: 8px;
}
</style>

<style>

body {
	overflow: hidden;
}

.content {
	transform: scale(0.7) translateX(80%) translateY(10%);
	background: linear-gradient(180deg, #4C866B 0%, #337053 100%);
	border-radius: 25px;
	max-height: 83vh;
	overflow: hidden;
	
	box-shadow: -10px 10px 25px 5px rgba(0, 0, 0, 0.06);
}
</style>