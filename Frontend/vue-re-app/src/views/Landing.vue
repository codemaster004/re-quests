<template>
    <div>
        <nav class="mobile-nav">
            <div class="mobile-burger"></div>
            <div class="mobile-links">
                <a href="#">Home</a>
                <a href="#">About</a>
                <a href="#">Technologies</a>
                <a href="#">Future</a>
            </div>
        </nav>
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
                            Challenge <span>yourself</span>
                        </h1>
                        <p>
                            If you are ready to take up the challenge, try out your willpower and endurance, you must take part in our Re-Quests app!
                        </p>
                        <div class="button-box">
                            <div class="btn btn-main">
                                <router-link to="/signup" style="text-decoration: none"><span>Create account</span></router-link>
                            </div>
                            <div class="btn btn-hide"><a href="#" style="color: white; text-decoration: none">Read more</a></div>
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
        <section class="purpose-section">
            <header class="section-header">
                <p>The application was created to help <span>You</span> recycle the rubbish</p>
            </header>
            <div class="purpose">
                <img src="../assets/Landingsrodek-1.png" />
                <img src="../assets/Landingsrodek-2.png" />
                <img src="../assets/Landingsrodek-3.png" />
                <p class="heading">Have you ever asked yourself</p>
                <blockquote><span>"Do I care for the Earth the way that i should?"</span></blockquote>
                <p>
                    If You still do not know answer to this question, download this application. Every day You will receive a task that will help you
                    sort your garbage and more
                </p>
            </div>
        </section>
        <section class="tech-section">
            <header class="section-header"><span>Technologies</span> we used</header>
            <div class="cards-box">
                <div class="card" id="frontend">
                    <h3>Front-end</h3>
                    <img src="../assets/laptopFront.png" alt="" />
                    <p>
                        On frontend we are using Java Script framework Vue for seamless transitions betwean pages and close to instant data loading.
                        As usually website itself is build using html and css and with mobile first approach so it <b><i>shoud</i></b> be perfectly
                        scaleble.
                    </p>
                </div>

                <div class="card" id="backend">
                    <h3>Back-end</h3>
                    <img src="../assets//laptopBack.png" alt="" />
                    <p>
                        For backend we creaeted REST API using C#. We store user data inside PostgreSQL Databse. It cominicates with our frontend
                        using JSON and carefully picked request codes. A few more than 404, 500 and 200. :)
                    </p>
                </div>

                <div class="card" id="design">
                    <h3>Design</h3>
                    <img src="../assets//design.png" alt="" />
                    <p>
                        We used Figma app for UI and UX design. We also generated 3D objects to create awesome medal gifs. All of the icons and logo
                        were drawn on the Ipad pro (show of) in Procreate app.
                    </p>
                </div>
            </div>
        </section>
        <section class="team-section">
            <header>Our <span>Team</span></header>
            <div class="people-box">
                <div class="person-box">
                    <img src="../assets/filip_meme.jpg" alt="" />
                    <div class="person-text-box">
                        <h4>Filip Dąbkowski</h4>
                        <p>Project meganer, Front-end dev</p>
                    </div>
                </div>
                <div class="person-box">
                    <img src="../assets/franke_meme.jpeg" alt="" />
                    <div class="person-text-box">
                        <h4>Franek Łuczkiewicz</h4>
                        <p>UI designer, Graphic</p>
                    </div>
                </div>
                <div class="person-box">
                    <img src="../assets/przemek.jpg" alt="" />
                    <div class="person-text-box">
                        <h4>Przemke Urbanek</h4>
                        <p>Back-end dev</p>
                    </div>
                </div>
                <div class="person-box">
                    <img src="../assets/straszkiewicz.jpg" alt="" />
                    <div class="person-text-box">
                        <h4>Katarzyna Straszkiewicz</h4>
                        <p>Coach</p>
                    </div>
                </div>
            </div>
        </section>
    </div>
</template>

<script>
export default {
    name: "Landing",
};
</script>

<style scoped>
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
    height: 100vh;
}
.hero-container nav {
    display: flex;
    color: #9e9e9e;
    position: relative;
    z-index: 100;
}
.hero-container nav a {
    text-decoration: none;
    color: #9e9e9e;
    padding: 0 30px;
    font-family: Montserrat;
    font-style: normal;
    font-weight: 600;
    font-size: 17px;
}

.hero-container nav .left {
    display: flex;
    justify-content: space-between;
    padding-right: 30px;
}
.hero-container nav .right {
    text-align: right;
}

.hero-container header {
    position: relative;
    z-index: 50;
    display: flex;
    height: calc(100vh - 150px);
    color: #fff;
    align-items: center;
    justify-content: flex-start;
}

.hero-container header .right {
    display: flex;
    align-items: center;
    justify-content: center;
}

.hero-container header .header-box h1 {
    font-family: Oswald;
    font-style: normal;
    font-weight: bold;
    font-size: 70px;
    line-height: 115%;
}

.hero-container header .header-box p {
    width: 60%;
    padding-top: 30px;

    font-family: Montserrat;
    font-style: normal;
    font-weight: 500;
    font-size: 18px;
    line-height: 35px;
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
    background-color: #3caa75;
    background-image: linear-gradient(94.1deg, #3caa75 0%, #248864 99.97%);

    font-family: Montserrat;
    font-style: normal;
    font-weight: 500;
    font-size: 17px;
    line-height: 50px;

    color: #000000;
}
.btn-main span {
    background-image: none;
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

section {
    position: relative;
    z-index: 300;
}
.purpose-section {
    margin: 0 !important;
    padding-top: 30px;
    background-color: #ffffff;
}
.purpose-section > header {
    line-height: initial;
    font-weight: 500;
}
.purpose {
    margin: auto;
    width: 100%;
    display: grid;
    padding: 2em;
    align-items: flex-end;
    font-family: Montserrat;
    font-weight: 600;
    font-style: normal;
    --img-col-width: calc(var(--img-width) - var(--image-translate));
    grid-template:
        ".    img2 title title" 1fr
        "img1 img2 quote  quote" auto
        "img1 img2 img3  expl " auto
        "img1 img2 img3  .    " auto;
    grid-template-columns: var(--img-col-width) var(--img-width) var(--img-col-width) 1fr;
    padding-bottom: 0;
}
blockquote {
    font-family: monospace;
    font-style: italic;
    padding-bottom: 0.5em;
}
.purpose .heading {
    font-size: var(--heading-size);
    grid-area: title;
    text-align: end;
    padding: 0.5em;
}
.purpose blockquote {
    font-size: var(--quote-size);
    grid-area: quote;
    text-align: end;
}
.purpose p:last-of-type {
    font-size: var(--text-size);
    letter-spacing: 1px;
    text-align: justify;
    grid-area: expl;
    padding: 1em;
}
.purpose img {
    width: var(--img-width);
    height: auto;
}
.purpose img:first-of-type {
    grid-area: img1;
    transform: translateX(0);
}
.purpose img:nth-of-type(2) {
    grid-area: img2;
}
.purpose img:last-of-type {
    grid-area: img3;
    transform: translateX(var(--neg-image-translate));
}
@media (max-width: 599.99px) {
    .purpose {
        width: 100%;
        --image-translate: 20%;
        --neg-image-translate: -20%;
        --img-width: 200px;
        --heading-size: 20px;
        --quote-size: 16px;
        --text-size: 16px;
        grid-template:
            "title title title title title" auto
            ". quote quote quote ." auto
            ". expl  expl  expl  ." auto
            ". .     img2  .     ." 1fr
            ". img1  img2  img3  ." auto
            ". img1  img2  img3  ." auto
            ". img1  img2  img3  ." auto;
        grid-template-columns: 1fr auto auto auto 1fr;
    }

    .purpose img {
        max-width: 100%;
        height: auto;
    }

    .purpose img:first-of-type {
        transform: translateX(var(--image-translate));
    }

    .purpose .heading,
    .purpose blockquote {
        text-align: center;
    }

    .purpose-section > header {
        font-size: 26px;
    }
}
@media (min-width: 600px) and (max-width: 799.99px) {
    .purpose {
        width: 100%;
        --image-translate: 40px;
        --neg-image-translate: -40px;
        --img-width: 200px;
        --heading-size: 32px;
        --quote-size: 16px;
        --text-size: 16px;
        grid-template:
            "title title title title title" auto
            ". quote quote quote ." auto
            ". expl  expl  expl  ." auto
            ". .     img2  .     ." 1fr
            ". img1  img2  img3  ." auto
            ". img1  img2  img3  ." auto
            ". img1  img2  img3  ." auto;
        grid-template-columns: 1fr var(--img-col-width) var(--img-width) var(--img-col-width) 1fr;
    }

    .purpose .heading,
    .purpose blockquote {
        text-align: center;
    }

    .purpose-section > header {
        font-size: 26px;
    }
}
@media (min-width: 800px) {
    .purpose {
        width: 800px;
        --image-translate: 70px;
        --neg-image-translate: -70px;
        --img-width: 200px;
        --heading-size: 25px;
        --quote-size: 16px;
        --text-size: 16px;
    }

    .purpose-section > header {
        font-size: 32px;
    }
}
@media (min-width: 900px) {
    .purpose {
        width: 900px;
        --image-translate: 75px;
        --neg-image-translate: -75px;
        --img-width: 220px;
        --heading-size: 28px;
        --quote-size: 16px;
        --text-size: 18px;
    }

    .purpose-section > header {
        font-size: 36px;
    }
}
@media (min-width: 1200px) {
    .purpose {
        width: 1200px;
        --image-translate: 100px;
        --neg-image-translate: -100px;
        --img-width: 250px;
        --heading-size: 45px;
        --quote-size: 24px;
        --text-size: 24px;
    }

    .purpose-section > header {
        font-size: 42px;
    }
}
@media (min-width: 1600px) {
    .purpose {
        width: 1600px;
        --image-translate: 110px;
        --neg-image-translate: -110px;
        --img-width: 320px;
        --heading-size: 56px;
        --quote-size: 32px;
        --text-size: 28px;
    }
}

.tech-section {
    /* margin-top: 50px; */
    padding-top: 30px;
    min-height: 700px;
    width: 100%;
    padding-bottom: 120px;
    background: linear-gradient(to bottom, #fff, #eeeeee);
}
section > header {
    font-family: Oswald;
    font-style: normal;
    font-weight: 500;
    font-size: 50px;
    line-height: 74px;

    text-align: center;

    color: #000000;
}
.section-header span {
    color: #4c866b;
}
.cards-box {
    width: 100%;
    padding-top: 150px;

    display: flex;
    justify-content: space-around;
    align-items: center;
}
.card {
    width: 300px;
    height: 400px;
    padding: 20px;
    padding-bottom: 40px;
    color: #fff;
    border-radius: 15px;

    display: flex;
    align-items: center;
    justify-content: space-around;
    flex-direction: column;

    box-shadow: 2px 3px 20px 2px rgba(0, 0, 0, 0.205);
}
#frontend {
    background-image: url("../assets/techsGradientGreen.png");
    transform: translateY(-75px);
}
#backend {
    background-image: url("../assets/techsGradientPurple.png");
}
#design {
    background-image: url("../assets/techsGradientBlue.png");
    transform: translateY(75px);
}
.card img {
    width: 80%;
}
.card h3 {
    width: 100%;

    font-family: Oswald;
    font-style: normal;
    font-weight: 500;
    font-size: 30px;
    line-height: 40px;
    text-align: left;
}
.card p {
    font-family: Montserrat;
    font-style: normal;
    font-weight: 600;
    font-size: 12px;
    line-height: 16px;
    text-align: center;
}

.team-section {
    background: #eeeeee;
}
.team-section header {
    width: 80%;
    margin: 0 auto;

    border-top: 2px solid #248864;
    padding-top: 30px;
}
.people-box {
    display: flex;
    justify-content: space-around;
    padding: 50px 0;
    height: auto;
}
.person-box {
    /* height: 550px; */
    width: 320px;
    display: flex;
    flex-direction: column;
    align-items: center;
}
.person-box img {
    width: 250px;
    height: 250px;
    object-fit: cover;
    border-radius: 50%;
    transform: translateY(15px);
    position: relative;
    z-index: 150;
    box-shadow: 0px 4px 15px rgba(0, 0, 0, 0.25);
}
.person-box .person-text-box {
    width: 100%;
    height: 150px;
    padding: 25px;

    display: flex;
    flex-direction: column;
    justify-content: space-around;

    background-color: #fff;
    border-radius: 20px;
    box-shadow: 0 4px 15px rgba(0, 0, 0, 0.1);

    text-align: center;
}
.person-box .person-text-box h4 {
    font-family: Oswald;
    font-style: normal;
    font-weight: 600;
    font-size: 25px;

    color: #000000;
}
.person-box .person-text-box p {
    font-family: Montserrat;
    font-style: normal;
    font-weight: 500;
    font-size: 20px;
    line-height: 18px;

    color: #000000;
}

@media screen and (max-width: 1500px) {
    .mockup-box {
        width: 500px;
        height: 600px;
    }

    .mockup-box img:last-of-type {
        transform: translate(-20%, 0%);
    }
    .mockup-box img:first-of-type {
        transform: translate(20%, 10%);
    }
    .hero-container header .header-box h1 {
        font-size: 60px;
    }
    .hero-container header .header-box p {
        font-size: 15px;
        line-height: 25px;
    }

    .btn {
        height: 45px;
        width: 150px;
        font-size: 16px;
    }
    .btn-main {
        line-height: 45px;
    }

    .team-section {
        padding: 0 20px;
    }
    .people-box {
        padding-bottom: 0;
    }
    .person-box {
        width: 275px;
        /* height: 400px; */
    }
    .person-box .person-text-box {
        padding: 20px;
        height: 120px;
    }
    .person-box img {
        width: 200px;
        height: 200px;
    }
    .person-box .person-text-box h4 {
        font-size: 20px;
    }
    .person-box .person-text-box p {
        font-size: 16px;
    }
}

@media screen and (max-width: 1200px) {
    .mockup-box {
        width: 500px;
        height: 600px;
    }

    .mockup-box img:last-of-type {
        transform: translate(-35%, 0%);
    }
    .mockup-box img:first-of-type {
        transform: translate(5%, 10%);
    }
    .hero-container header .header-box h1 {
        font-size: 50px;
    }
    .hero-container header .header-box p {
        font-size: 15px;
        line-height: 25px;
    }

    .btn {
        height: 40px;
        width: 130px;
        font-size: 15px;
    }
    .btn-main {
        line-height: 40px;
    }

    .hero-container nav a {
        padding: 0 10px;
    }

    .card {
        width: 250px;
        height: 350px;
    }

    .team-section {
        height: auto;
    }
    .people-box {
        height: auto;
        flex-wrap: wrap;
    }
    .person-box {
        margin: 10px;
    }
}

@media screen and (max-width: 1100px) {
    .hero-container .left {
        width: 90%;
    }
    .hero-container {
        height: calc(300px + 50px + 30px * 2 + 20px + 500px);
    }
    .bgc-box {
        /* header text + header psddin + hero padding + nav + mockup */
        height: calc(300px + 50px + 30px * 2 + 20px + 500px);
    }
    .bgc-box .right {
        width: 100%;
    }
    .bgc-box .left {
        display: none;
    }
    .hero-container nav {
        display: none;
    }
    .hero-container nav a,
    .hero-container nav h4 {
        color: #eee;
    }
    .hero-container .header-box {
        padding-top: 50px;
    }
    .hero-container header .header-box p {
        color: #dfdddd;
    }
    .hero-container header .header-box h1 span {
        color: #000;
    }
    .btn-main {
        font-weight: 600;
        background-color: #000;
        background-image: linear-gradient(to bottom left, #060606, #121212);
    }
    .btn-main span {
        background-image: -webkit-linear-gradient(45deg, #20815e, #38aa73);
        background-size: 100%;
        background-clip: text;
        -webkit-background-clip: text;
        -webkit-text-fill-color: transparent;
    }
    .hero-container header {
        flex-direction: column;
    }

    .mockup-box {
        width: 400px;
        height: 500px;
    }
    .mockup-box img:last-of-type {
        transform: translate(-40%, -5%);
    }
    .mockup-box img:first-of-type {
        transform: translate(0, 5%);
    }

    .mobile-nav {
        position: absolute;
        z-index: 999;
        width: 100%;
    }
    .mobile-nav .mobile-burger {
        padding: 20px;
    }
    .mobile-nav .mobile-burger::after {
        content: "";
        display: block;
        width: 20px;
        height: 2px;
        margin-top: 10px;
        background-color: #fff;
    }
    .mobile-nav .mobile-burger::before {
        content: "";
        display: block;
        width: 30px;
        height: 2px;
        background-color: #fff;
    }
    .mobile-burger.active {
        border-bottom: 1px solid #333;
        background-color: #0e0e0e;
    }
    .mobile-links {
        visibility: hidden;
        padding: 0 50px;
        width: 100%;
    }
    .mobile-links a {
        display: block;
        border-bottom: 1px solid #333;
        width: 100%;
        padding: 10px;
        color: #fff;
        text-decoration: none;
    }
    .mobile-links.active {
        visibility: visible;
        background-color: #0e0e0e;
    }
}

@media screen and (max-width: 900px) {
    .tech-section {
        height: auto;
        min-height: auto;
        padding-bottom: 50px;
    }
    section header {
        font-size: 40px;
    }
    .cards-box {
        padding-top: 50px;
        flex-wrap: wrap;
    }
    .card {
        margin: 20px;
        padding: 15px;
    }
    .card h3 {
        font-size: 25px;
    }
    .card img {
        width: 70%;
    }
    .card p {
        font-size: 11px;
    }
    #frontend {
        transform: translateY(0);
    }
    #design {
        transform: translateY(0);
    }
}

@media screen and (max-width: 845px) {
    .hero-container .left {
        width: 100%;
    }
    .hero-container header .header-box p {
        width: 80%;
    }
    .hero-container {
        height: calc(750px);
    }
    .bgc-box {
        /* header text + header paddin + hero padding + nav + mockup */
        height: calc(250px + 50px + 30px * 2 + 20px + 400px);
    }
    .mockup-box {
        width: 300px;
        height: 400px;
    }
    .mockup-box img:last-of-type {
        transform: translate(-30%, 0%);
    }
    .mockup-box img:first-of-type {
        transform: translate(10%, 10%);
    }
    .hero-container header .header-box h1 {
        font-size: 45px;
    }
    .hero-container header .header-box p {
        font-size: 14px;
        line-height: 21px;
        padding-top: 12px;
    }
    .btn {
        height: 40px;
        width: 120px;
        font-size: 14px;
    }
    .btn-main {
        line-height: 40px;
    }

    .team-section {
        padding-bottom: 30px;
    }
    .people-box {
        padding-top: 0px;
    }
    .person-box {
        margin-top: 20px;
    }
}

@media screen and (max-width: 700px) {
    .mockup-box img:last-of-type {
        transform: translate(-40%, 0%);
    }
    .mockup-box img:first-of-type {
        transform: translate(00%, 10%);
    }
    .btn {
        height: 38px;
        width: 120px;
        font-size: 13px;
    }
    .btn-main {
        line-height: 38px;
    }
}

@media screen and (max-width: 550px) {
    .hero-container {
        padding: 30px 50px;
    }
}

@media screen and (max-width: 549px) {
    .mockup-box {
        display: none;
    }
    .hero-container {
        padding: 30px 20px;
    }
    .btn {
        height: 35px;
        width: 110px;
        font-size: 12px;
    }
    .btn-main {
        line-height: 35px;
    }
    .hero-container {
        height: calc(550px);
    }
    .bgc-box {
        /* header text + header paddin + hero padding + nav + mockup */
        height: calc(550px);
    }
    .hero-container header .header-box p {
        padding-top: 30px;
    }
}

::-webkit-scrollbar {
    width: 12px;
    margin: 10px;
}
::-webkit-scrollbar-thumb {
    background: linear-gradient(to top, #62e3a7, #29ae70);
    border-radius: 6px;
}
</style>
