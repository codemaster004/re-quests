<template>
    <nav>
        <div class="nav-bar" v-if="screenSize <= 1000">
            <button @click="burgerClicked()" class="burger">
                <div class="burger-line"></div>
                <div class="burger-line"></div>
            </button>
            <Header title="Login" :large="false" />
            <div class="nav-icon"></div>
        </div>
        <div class="nav-link-box">
            <div v-for="item in links" :key="item.name">
                <router-link :to="item.to">
                    <NavLink @link-clicked="burgerClicked()" :linkData="item" />
                </router-link>
            </div>
        </div>
    </nav>
</template>

<script>
import NavLink from "./NavLink";
import Header from "./Header";

export default {
    name: "Nav",
    components: {
        NavLink,
        Header,
    },
    methods: {
        burgerClicked() {
            if (this.screenSize < 1000) {
                this.$emit("burger-clicked");
            }
        },
        resizeWindowHandler(e) {
            this.screenSize = window.innerWidth;
        },
    },
    data() {
        return {
            links: [],
            headerLarge: false,
            screenSize: window.innerWidth,
        };
    },
    created() {
        this.links = [
            { linkTo: "Main", to: "/home", active: true, icon: "" },
            { linkTo: "Profile", to: "/user", active: false, icon: "" },
            { linkTo: "About", to: "/", active: false, icon: "" },
            { linkTo: "Log in", to: "/login", active: false, icon: "" },
            { linkTo: "Sign up", to: "/signup", active: false, icon: "" },
            // { linkTo: "Progress", to: "/progress", active: false, icon: "" },
        ];
        window.addEventListener("resize", this.resizeWindowHandler);
    },
    destroyed() {
        window.removeEventListener("resize", this.resizeWindowHandler);
    },
};
</script>

<style scoped>
nav {
    position: absolute;
    top: 0;
    left: 0;
    width: 100%;
}

.nav-bar {
    padding: 0 25px;
    width: 100%;

    display: flex;
    align-items: flex-start;
    flex-direction: row;
    justify-content: space-between;
}

.nav-link-box {
    margin-top: 10vh;
    padding-left: 25px;
    position: relative;
    z-index: 10;
}

.nav-icon {
    width: 26px;
}

.burger {
    -webkit-appearance: none;
    border: none;
    background-color: transparent;
    position: relative;
    z-index: 100;
    height: auto;
    margin-top: 20px;
}

.burger .burger-line {
    width: 26px;
    height: 2px;

    background-color: #fff;
}
.burger .burger-line:last-child {
    width: 16px;
    margin-top: 8px;
}
</style>
