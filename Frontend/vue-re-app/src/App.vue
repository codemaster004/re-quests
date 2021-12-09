<template>
  <main>
    <div id="bgc"></div>

    <div
      class="content"
      :class="{
        'content-minimal': navState.hided,
        'content-maximal': navState.showed,
        'content-maximize': navState.hidding,
        'content-minimize': navState.showing,
      }"
    >
      <router-view></router-view>
    </div>
    <Nav @burger-clicked="toggleNav()" />
  </main>
</template>

<script>
import Nav from "./components/Nav";

export default {
  name: "App",
  components: {
    Nav,
  },
  methods: {
    toggleNav() {
      let willHide = this.navState.hided;
      this.navState = {
        hidding: willHide,
        hided: false,
        showing: !willHide,
        showed: false,
      };
      setTimeout(this.afterAnimation, 300, willHide);
    },
    afterAnimation(hidden) {
      this.navState = {
        hidding: false,
        hided: !hidden,
        showing: false,
        showed: hidden,
      };
    },
  },
  data() {
    return {
      navState: {
        hidding: false,
        hided: false,
        showing: false,
        showed: false,
      },
    };
  },
};
</script>

<style>
@import url("https://fonts.googleapis.com/css2?family=Montserrat:wght@300;400;500;600;700&family=Oswald:wght@300;400;500;600;700&display=swap");

* {
  margin: 0;
  padding: 0;
  box-sizing: border-box;
}

body {
  background-color: #4c866b;
}

#app {
  font-family: "Montserrat", sans-serif;
  overflow: hidden;
}

#bgc {
  background-color: #4c866b;
  background: linear-gradient(180deg, #3c7b5f 0%, #2b684a 100%);
  height: -webkit-fill-available;
  width: 100%;
  position: fixed;
  z-index: -1;
}

.content {
  min-height: -webkit-fill-available;
  background: linear-gradient(180deg, #4c866b 0%, #337053 100%);
  overflow-y: hidden;
  padding-top: 50px;
  position: relative;
  z-index: 50;
}

.content-minimize {
  animation: show-menu 0.3s ease-in;
}
.content-maximize {
  animation: hide-menu 0.3s ease-out;
}
.content-minimal {
  box-shadow: -10px 10px 25px 5px rgba(0, 0, 0, 0.06);
  height: 100vh;
  border-radius: 25px;
  transform: scale(0.7) translateX(70%) translateY(5vh);
}
.content-maximal {
  box-shadow: -10px 10px 25px 5px rgba(0, 0, 0, 0.06);
  height: auto;
  border-radius: 0;
  transform: scale(1) translateX(0) translateY(0);
}

.absolute-center {
  position: absolute;
  top: 50%;
  left: 50%;
  transform: translate(-50%, -50%);
}

.title {
  font-family: Oswald;
  font-style: normal;
  font-weight: 500;
  font-size: 34px;
}

.sub-title {
  font-family: Montserrat;
  font-style: normal;
  font-weight: 600;
  font-size: 13px;
}

.header {
  font-family: Oswald;
  font-style: normal;
  font-weight: 500;
  font-size: 20px;
  line-height: 30px;
}

.sub-header {
  font-family: Montserrat;
  font-style: normal;
  font-weight: 600;
  font-size: 11px;
  line-height: 13px;
}

.action-button {
  height: 40px;

  font-family: Oswald;
  font-style: normal;
  font-weight: 500;
  font-size: 17px;
  line-height: 40px;
  text-align: center;

  background: #efdebc;
  border-radius: 10px;
  color: #ffffff;
}

@keyframes show-menu {
  0% {
    box-shadow: -10px 10px 25px 5px rgba(0, 0, 0, 0.06);
    height: auto;
    border-radius: 0;
    transform: scale(1) translateX(0) translateY(0);
  }
  1% {
    height: 100vh;
    border-radius: 25px;
  }
  100% {
    box-shadow: -10px 10px 25px 5px rgba(0, 0, 0, 0.06);
    height: 100vh;
    border-radius: 25px;
    transform: scale(0.7) translateX(70%) translateY(5vh);
  }
}

@keyframes hide-menu {
  0% {
    box-shadow: -10px 10px 25px 5px rgba(0, 0, 0, 0.06);
    height: 100vh;
    border-radius: 25px;
    transform: scale(0.7) translateX(70%) translateY(5vh);
  }
  99% {
    height: 100vh;
    border-radius: 25px;
  }
  100% {
    box-shadow: -10px 10px 25px 5px rgba(0, 0, 0, 0.06);
    height: auto;
    border-radius: 0;
    transform: scale(1) translateX(0) translateY(0);
  }
}
</style>
