<template></template>

<script>
export default {
    name: "AuthButton",
    props: {
        text: String,
    },
};
</script>

<style scoped>
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
