<template>
    <div class="hero-container">
        <div class="bgc-box">
            <div class="left" id="bg-black"></div>
            <div class="right">
                <div id="bg-gradient">
                    <div id="bg-blur"></div>
                </div>
            </div>
        </div>
        <nav>
            <div class="left">
                <h4>Re-Quests</h4>
                <div>
                    <a href="#">Home</a>
                    <a href="#">About</a>
                    <a href="#">Technologies</a>
                    <a href="#">Future</a>
                </div>
            </div>
            <div class="right">
                <router-link to="/login">Login</router-link>
                <router-link to="/signup">Signup</router-link>
            </div>
        </nav>
        <header>
            <div class="left">
                <div class="header-box">
                    <h1>
                        Re-Quests <br />
                        Challenge <span>yourself</span>!
                    </h1>
                    <p>If you are ready to take up the challenge, try out your willpower and endurance, you must take part in our Re-Quests app!</p>
                    <div class="button-box">
                        <router-link to="/signup">
                            <div class="btn btn-main">Create account</div>
                        </router-link>
                        <div class="btn btn-hide">Read more</div>
                    </div>
                </div>
            </div>
            <div class="right">
                <div class="mockup-box">
                    <img src="../assets/ladninggora-2.png" alt="" />
                    <img src="../assets/ladninggora-1.png" alt="" />
                </div>
            </div>
        </header>
    </div>
</template>

<script>
export default {
    name: "Landing",
};
</script>

<style scoped>
* {
    box-sizing: border-box;
    margin: 0;
    padding: 0;
}

.left {
    width: 60%;
}
.right {
    width: 40%;
}

.bgc-box {
    width: 100%;
    height: 100%;
    display: flex;
    position: absolute;
    top: 0;
    left: 0;
}
.bgc-box > div:last-of-type {
    position: relative;
}
.bgc-box #bg-black {
    background: linear-gradient(to top right, #060606, #121212);
}
.bgc-box #bg-gradient,
.bgc-box #bg-blur {
    position: absolute;
    top: 0;
    left: 0;
}
.bgc-box #bg-gradient {
    width: 100%;
    height: 100%;
    background-image: url("../assets/blackGreenGradient.png");
    background-size: cover;
    background-position: center;
    /* backdrop-filter: blur(5px); */
    /* filter: blur(5px); */
}
.bgc-box #bg-blur {
    width: 100%;
    height: 100%;
    backdrop-filter: blur(30px);
    -webkit-backdrop-filter: blur(30px);
}

.hero-container {
    padding: 30px 90px;
}
nav {
    display: flex;
    color: #9e9e9e;
    position: relative;
    z-index: 100;
}
nav a {
    text-decoration: none;
    color: #9e9e9e;
    padding: 0 30px;
    font-family: Montserrat;
    font-style: normal;
    font-weight: 600;
    font-size: 17px;
}

nav .left {
    display: flex;
    justify-content: space-between;
    padding-right: 30px;
}
nav .right {
    text-align: right;
}

header {
    position: relative;
    z-index: 50;
    display: flex;
    height: calc(100vh - 150px);
    color: #fff;
    align-items: center;
    justify-content: flex-start;
}

header .right {
    display: flex;
    align-items: center;
    justify-content: center;
    pointer-events: none;
}

header .header-box h1 {
    font-family: Oswald;
    font-style: normal;
    font-weight: bold;
    font-size: 70px;
    line-height: 115%;
}

header .header-box p {
    width: 60%;
    padding-top: 30px;

    font-family: Montserrat;
    font-style: normal;
    font-weight: 500;
    font-size: 18px;
    line-height: 37px;
    /* or 195% */

    color: #a3a3a3;
}

.button-box {
    padding-top: 30px;
}

.btn {
    height: 50px;
    line-height: 50px;
    border-radius: 10px;
    width: 180px;
    display: inline-block;
    margin-right: 20px;
    text-align: center;
}
.btn-main {
    background: linear-gradient(94.1deg, #3caa75 0%, #248864 99.97%);

    font-family: Montserrat;
    font-style: normal;
    font-weight: 500;
    font-size: 17px;
    line-height: 50px;

    color: #000000;
}

.mockup-box {
    width: 700px;
    height: 800px;
    position: relative;
}

.mockup-box img {
    height: 100%;

    position: absolute;
    top: 0;
    left: 0;
}

.mockup-box img:last-of-type {
    transform: translate(-40%, 0%);
}
.mockup-box img:first-of-type {
    transform: translate(0, 10%);
}
</style>
