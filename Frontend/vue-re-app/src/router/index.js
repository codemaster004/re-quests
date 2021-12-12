import { createRouter, createWebHistory, createWebHashHistory } from "vue-router";
import Home from "../views/Home";
import Login from "../views/Login";
import Signup from "../views/Signup";
import Progress from "../views/Progress";
import Profile from "../views/User";

const routes = [
    {
        path: "/",
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
];

const router = createRouter({
    history: createWebHashHistory(),
    routes,
});

export default router;
