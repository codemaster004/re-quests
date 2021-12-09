<template>
  <div>
    <input :type="inputType" class="input-box" :placeholder="placeholder" />
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
  margin-bottom: 30px;

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
