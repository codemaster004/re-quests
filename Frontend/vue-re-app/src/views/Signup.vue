<template>
    <div class="auth-view">
        <div class="logo-box">
            <img src="../assets/gif.gif" alt="" />
        </div>
        <h2 class="auth-title">Sign Up</h2>
        <form @submit="handdleSubmit">
            <div class="input-group">
                <AuthInput placeholder="Username" inputType="text" />
                <AuthInput placeholder="Email" inputType="email" />
                <AuthInput placeholder="Password" inputType="password" />
                <AuthInput placeholder="Confirm" inputType="password" />
                <!-- <p>Forgot Password</p> -->
            </div>

            <AuthButton text="Sign up" />
        </form>
    </div>
</template>

<script>
import AuthInput from "../components/AuthInput";
import AuthButton from "../components/AuthButton";

export default {
    export: {
        name: "Signup",
    },
    components: {
        AuthInput,
        AuthButton,
    },
    methods: {
        handdleSubmit(e) {
            e.preventDefault();
            console.log("submit");
        },
    },
};
</script>

<style scoped>
.auth-view {
    min-height: calc(100vh - 50px);
    width: 100vw;
    background-color: #fff;
    padding-top: 50px;
}

.logo-box {
    width: 114px;
    height: 114px;
    margin: 0 auto;

    background: #ffffff;
    box-shadow: 0px 0px 25px rgba(0, 0, 0, 0.1);
    border-radius: 200px 200px 69px 69px;
}

.logo-box img {
    height: 100%;
}

.input-group {
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
