<template>
  <div>
    <div class="logo-box">
      <img src="" alt="" />
    </div>
    <h2 class="auth-title">Log In</h2>
    <div class="input-group">
      <AuthInput placeholder="Username" inputType="text" />
      <AuthInput placeholder="Password" inputType="password" />
      <p>Forgot Password</p>
    </div>

    <AuthButton text="Log in" />
  </div>
</template>

<script>
import AuthInput from "../components/AuthInput";
import AuthButton from "../components/AuthButton";

export default {
  export: {
    name: "Login",
  },
  components: {
    AuthInput,
    AuthButton,
  },
};
</script>

<style scoped>
.logo-box {
  width: 114px;
  height: 114px;
  margin: 0 auto;

  background: #ffffff;
  box-shadow: 0px 0px 25px rgba(0, 0, 0, 0.1);
  border-radius: 200px 200px 69px 69px;
}

.input-group {
  height: 180px;
  margin-top: 25px;
  padding: 0 30px;

  display: flex;
  flex-direction: column;
  justify-content: space-between;
}

.input-group p {
  display: block;

  font-family: Montserrat;
  font-style: normal;
  font-weight: 600;
  font-size: 13px;
  line-height: 13px;
  text-align: right;

  color: #4c866b;
}

h2.auth-title {
  margin-left: 30px;
  margin-top: 36px;

  font-family: Oswald;
  font-style: normal;
  font-weight: 500;
  font-size: 28px;
  line-height: 41px;

  color: #000000;
}
</style>
