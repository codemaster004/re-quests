<template>
  <div v-if="inputType == 'text'">
    <input type="text" class="input-box" placeholder="Username" />
  </div>
  <div v-else-if="inputType == 'password'">
    <input type="password" class="input-box" placeholder="Password" />
  </div>
</template>

<script>
export default {
  name: "AuthInput",
  props: {
    placeholder: String,
    inputType: String,
  },
};
</script>

<style scoped>
.input-box {
  /* width: 328px; */
  display: block;
  width: 100%;
  height: 49px;

  background: #f5f5f5;
  border-radius: 50px;
  -webkit-appearance: none;
  border: none;

  font-family: Montserrat;
  font-style: normal;
  font-weight: 600;
  font-size: 13px;
  line-height: 49px;
  text-align: left;
  padding-left: 28px;

  color: #999999;
}
</style>
