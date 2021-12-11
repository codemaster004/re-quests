<template>
    <div @click="$emit('link-clicked')" class="nav-link">
        <div class="nav-link-box">A</div>
        <p>{{ linkData.linkTo }}</p>
    </div>
</template>

<script>
export default {
    name: "NavLink",
    props: {
        linkData: Object,
    },
};
</script>

<style scoped>
.nav-link {
    min-width: 200px;
    margin-bottom: 32px;
}

.nav-link-box {
    width: 36px;
    height: 36px;
    display: inline-block;

    background: rgba(255, 255, 255, 0.4);
    border-radius: 10px;
    color: #fff;

    font-family: Montserrat;
    font-style: normal;
    font-weight: 600;
    font-size: 18px;
    line-height: 36px;
    text-align: center;
}

p {
    width: 130px;
    height: 23px;
    display: inline-block;
    padding: 0 0 0 10px;

    font-family: Montserrat;
    font-style: normal;
    font-weight: 600;
    font-size: 15px;
    line-height: 18px;

    color: #ffffff;
}

@media screen and (min-width: 1000px) {
    .nav-link.active {
        background-color: #fff;
        border-radius: 10px 0 0 10px;
        padding: 5px;
        box-sizing: content-box;
        min-width: 210px;
    }
    .nav-link.active .nav-icon-box {
        color: #4c866b;
    }
    .nav-link.active p {
        color: #000000;
    }
}
</style>
