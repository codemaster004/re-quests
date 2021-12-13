import { createRouter, createWebHistory, createWebHashHistory } from "vue-router";
import Home from "../views/Home";
import Login from "../views/Login";
import Signup from "../views/Signup";
import Progress from "../views/Progress";
import Profile from "../views/User";
import Landing from "../views/Landing";

const routes = [
    {
        path: "/home",
        name: "Home",
        component: Home,
    },
    {
        path: "/progress",
        name: "Progress",
        component: Progress,
    },
    {
        path: "/login",
        name: "",
        component: Login,
    },
    {
        path: "/signup",
        name: "",
        component: Signup,
    },
    {
        path: "/user",
        name: "Profile",
        component: Profile,
    },
    {
        path: "/",
        name: "Landing",
        component: Landing,
    },
];

const router = createRouter({
    history: createWebHashHistory(),
    routes,
});

export default router;
