<template>
<header>
  <div class="burger">
    <div class="burger-line"></div>
    <div class="burger-line"></div>
  </div>
  <div>
    <h1 class="title">Hello, Filip</h1>
    <p class="sub-title">Stay on your Goal</p>
  </div>
</header>
</template>

<script>
export default {
  name: 'Header',
}
</script>

<style scoped>
header {
  padding: 25px;
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

.title {
  height: 50px;
  margin-top: 15px;
  
  color: #ffffff;
  line-height: 50px;
}

.sub-title {
  height: 16px;
  margin-top: 3px;
  
  line-height: 16px;
  color: #DDDDDD;
}
</style>