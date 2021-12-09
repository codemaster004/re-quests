import { createRouter, createWebHistory } from "vue-router";
import Home from "../views/Home";
import Login from "../views/Login";
import Signup from "../views/Signup";

const routes = [
  {
    path: "/",
    name: "Home",
    component: Home,
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
];

const router = createRouter({
  history: createWebHistory(process.env.BASE_URL),
  routes,
});

export default router;
