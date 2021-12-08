<template>
<header>
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
  padding: 0 25px;
}

.title {
  height: 50px;
  
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