<template>
    <div style="overflow: scroll; height: 100%; min-height: 100%">
        <div :class="{ 'blur-content': blurBackground }" style="transition: 0.5s linear">
            <Header v-if="screenSize > 1000" title="Login" :large="false" />
            <Quests :quests="quests" />
        </div>

        <div
            class="medal-container"
            :class="{
                'showing-popup': medalState.showing,
                'showed-popup': medalState.showed,
                'hiding-popup': medalState.hidding,
                'hiden-popup': medalState.hiden,
            }"
        >
            <div class="medal-box">
                <div>
                    <img src="/MedalAnimation.gif" alt="" srcset="" />
                    <h2>Congrats!</h2>
                    <p>You completed the quest</p>
                    <p>
                        <b>"{{ medalTitle }}"</b>
                    </p>
                </div>

                <input @click="hidingMedal()" type="submit" class="auth-button" value="Collect reward" />
            </div>
        </div>
    </div>
</template>

<script>
import Quests from "../components/Quests";
import Header from "../components/Header";
import axios from "axios";

export default {
    name: "Home",
    components: {
        Quests,
        Header,
    },
    prompt: {
        quests: Array,
    },
    methods: {
        resizeWindowHandler(e) {
            this.screenSize = window.innerWidth;
        },
        showMedal() {
            this.medalState = {
                hidding: false,
                hiden: false,
                showing: true,
                showed: false,
            };
            setTimeout(this.showedMedal, 1500);
        },
        showedMedal() {
            this.medalState = {
                hidding: false,
                hiden: false,
                showing: false,
                showed: true,
            };
        },
        async hidingMedal() {
            this.medalState = {
                hidding: true,
                hiden: false,
                showing: false,
                showed: false,
            };

            try {
                let token = localStorage.getItem("accessToken");
                const receiveResponse = await axios.post(`/api/Quests/${this.medalId}/receive`, "", {
                    headers: { Authorization: `Bearer ${token}` },
                });
            } catch (e) {
                console.log(e);
            }

            setTimeout(this.hidenMedal, 1000);
        },
        hidenMedal() {
            this.medalState = {
                hidding: false,
                hiden: true,
                showing: false,
                showed: false,
            };
            this.blurBackground = false;
        },
    },
    data() {
        return {
            quests: [],
            screenSize: window.innerWidth,
            medalState: {
                hidding: false,
                hiden: true,
                showing: false,
                showed: false,
            },
            medalTitle: "",
            medalId: 0,
            blurBackground: false,
        };
    },
    async created() {
        try {
            let token = localStorage.getItem("accessToken");

            const response = await axios.get("/api/Quests/uncompleted", {
                headers: { Authorization: `Bearer ${token}` },
            });

            for (let quest of response.data) {
                this.quests.push({
                    id: quest.questId,
                    title: quest?.questName ?? "",
                    desc: quest?.questDescription ?? "",
                    questLength: quest?.duration ?? 1,
                    questProgress: quest?.sinceStart ?? 0,
                    daysLeft: quest?.duration - quest?.sinceStart,
                    wasWinReceived: quest.wasWinReceived,
                });
            }

            let willShowMedal = false;
            this.quests.forEach((quest) => {
                if (quest?.questLength - quest?.questProgress <= 0 && !quest?.wasWinReceived) {
                    willShowMedal = true;
                    this.medalTitle = quest.title;
                    this.medalId = quest.id;
                }
            });
            if (willShowMedal) {
                this.blurBackground = true;
                setTimeout(this.showMedal, 100);
            }
        } catch (e) {
            console.log(e);
        }

        this.medalId = 0;
        this.blurBackground = true;
        setTimeout(this.showMedal, 100);

        window.addEventListener("resize", this.resizeWindowHandler);
    },
    destroyed() {
        window.removeEventListener("resize", this.resizeWindowHandler);
    },
};
</script>

<style scoped>
.blur-content {
    filter: blur(10px);
}

.medal-container {
    width: 100%;
    height: 100%;
    position: absolute;
    display: none;
    top: 0;
    left: 0;
    z-index: 300;
    padding-top: 200px;
    opacity: 0;
    transform: translateY(100%);
}

.medal-box {
    height: 120%;
    padding: 30px;

    background-color: #fff;
    border-radius: 30px 30px 0 0;
    display: flex;
    text-align: center;
    justify-content: space-between;
    flex-direction: column;
}

.medal-box img {
    height: 300px;
}

.medal-box h2 {
    font-family: Oswald;
    font-style: normal;
    font-weight: 500;
    font-size: 39px;
    line-height: 58px;
    text-align: center;

    color: #000000;
}

.medal-box p {
    min-width: 100%;

    font-family: Montserrat;
    font-style: normal;
    font-weight: 600;
    font-size: 15px;
    line-height: 16px;
    text-align: center;

    color: #999999;
}
.medal-box b {
    line-height: 25px;
    color: #4c866b;
}

.auth-button {
    width: calc(100% - 30px * 2);
    height: 55px;
    margin: 0 auto;
    margin-bottom: 20px;
    position: fixed;
    bottom: 0;
    left: 50%;

    transform: translateX(-50%);
    transition: 0.3s;

    background: #efe2c8;
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

@keyframes show-popup {
    0% {
        display: none;
        opacity: 0;
        transform: translateY(50%);
    }
    1% {
        display: block;
        opacity: 0;
        transform: translateY(50%);
    }
    50% {
        opacity: 1;
        display: block;
    }
    100% {
        opacity: 1;
        display: block;
        transform: translateY(0);
    }
}

.showing-popup {
    animation: show-popup 1s 0.5s;
    display: block;
    animation-timing-function: cubic-bezier(0.68, -0.55, 0.265, 1.55);
}
.showed-popup {
    opacity: 1;
    display: block;
    transform: translateY(0);
}
.hiding-popup {
    animation: show-popup 1s reverse;
    display: block;
    animation-timing-function: cubic-bezier(0.3, -0.55, 0.265, 2);
}
.hiden-popup {
    opacity: 0;
    transform: translateY(50%);
    display: none;
}

@media screen and (min-width: 1000px) {
    .medal-container {
        padding: 100px 0;
    }

    .medal-box {
        width: 60%;
        height: 90%;
        margin: auto;
        position: relative;
        border-radius: 30px;
        border: 3px solid #e0e0e0;
    }

    .auth-button {
        width: calc(60% - 30px * 2);
        position: absolute;
    }
}
</style>
