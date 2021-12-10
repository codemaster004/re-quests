<template>
  <div class="auth-view">
    <div class="logo-box">
      <img src="" alt="" />
    </div>
    <h2 class="auth-title">Log In</h2>
    <form @submit.prevent="handdleSubmit">
      <div class="input-group">
        <div>
          <input
            class="input-box"
            type="text"
            placeholder="Username"
            v-model="username"
          />
        </div>
        <div>
          <input
            class="input-box"
            type="password"
            placeholder="Password"
            v-model="password"
          />
        </div>
        <p>Forgot Password?</p>
      </div>

      <div>
        <input type="submit" class="auth-button" />
      </div>
    </form>
  </div>
</template>

<script>
import axios from "axios";
import { useRouter, useRoute } from "vue-router";

export default {
  export: {
    name: "Login",
  },
  methods: {
    async handdleSubmit(e) {
      const formData = {
        username: this.username,
        password: this.password,
      };

      const response = await axios.post("/auth/login", formData);

      console.log(response);

      const router = useRouter();
      router.push("/");
    },
  },
  data() {
    return {
      username: "",
      password: "",
    };
  },
};

// https://6e6742f9-7f62-44d8-94da-2b62ae215a49.mock.pstmn.io/
</script>

<style>
.auth-view {
  min-height: calc(100vh - 50px);
  width: 100vw;
  background-color: #fff;
  padding-top: 50px;
}

.auth-view .logo-box {
  width: 114px;
  height: 114px;
  margin: 0 auto;

  background: #ffffff;
  box-shadow: 0px 0px 25px rgba(0, 0, 0, 0.1);
  border-radius: 200px 200px 69px 69px;
}

.auth-view .input-group {
  margin-top: 25px;
  padding: 0 30px;

  display: flex;
  flex-direction: column;
  justify-content: space-between;
}

.auth-view .input-group p {
  display: block;

  font-family: Montserrat;
  font-style: normal;
  font-weight: 600;
  font-size: 13px;
  line-height: 13px;
  text-align: right;

  color: #4c866b;
}

.auth-view h2.auth-title {
  margin-left: 30px;
  margin-top: 36px;

  font-family: Oswald;
  font-style: normal;
  font-weight: 500;
  font-size: 28px;
  line-height: 41px;

  color: #000000;
}

.auth-view .input-box {
  /* width: 328px; */
  display: block;
  width: 100%;
  height: 49px;
  margin-bottom: 30px;
  padding-left: 28px;

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

  color: #000000;
}

.auth-view .input-box::placeholder {
  color: #999999;
}

.auth-view .auth-button {
  width: calc(100% - 30px * 2);
  height: 55px;
  margin: 0 auto;
  margin-bottom: 20px;
  position: fixed;
  bottom: 0;
  left: 50%;

  transform: translateX(-50%);
  transition: 0.3s;

  background: #4c866b;
  box-shadow: 0px 4px 16px rgba(0, 0, 0, 0.2);
  border-radius: 50px;
  -webkit-appearance: none;
  border: none;

  font-family: Montserrat;
  font-style: normal;
  font-weight: 600;
  font-size: 19px;
  line-height: 55px;
  text-align: center;

  color: #ffffff;
}
</style>
