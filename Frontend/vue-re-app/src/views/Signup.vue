<template>
    <div class="auth-view">
        <div class="logo-box">
            <img src="../assets/gif.gif" alt="" />
        </div>
        <h2 class="auth-title">Sign Up</h2>
        <form @submit="handdleSubmit">
            <div class="input-group">
                <div>
                    <input class="input-box" type="text" placeholder="Username" v-model="username" />
                </div>
                <div>
                    <input class="input-box" type="email" placeholder="email" v-model="email" />
                </div>
                <div>
                    <input class="input-box" type="password" placeholder="Password" v-model="password" />
                </div>
            </div>

            <div>
                <input type="submit" class="auth-button" />
            </div>
        </form>
    </div>
</template>

<script>
import axios from "axios";
import "vue-router";

export default {
    export: {
        name: "Signup",
    },
    components: {},
    methods: {
        async handdleSubmit(e) {
            const formData = {
                username: this.username,
                password: this.password,
                email: this.email,
            };
            e.preventDefault();
            console.log("submit");

            try {
                const response = await axios.post("api/Users", formData);

                console.log("Success signup");

                this.$router.push("/login");
            } catch (error) {
                console.log(error);
            }
        },
    },
    data() {
        return {
            username: "",
            password: "",
            email: "",
            confirm: "",
        };
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

@media screen and (min-width: 1000px) {
    .auth-view {
        width: 50%;
        margin: 0 auto;
        max-width: 800px;
    }
    .auth-view .auth-button {
        position: relative;
    }
}
</style>
