import { createRouter, createWebHashHistory, RouteRecordRaw } from "vue-router";
import { usePermissStore } from '../store/permiss'
import Home from "../views/home.vue";

const routes: RouteRecordRaw[] = [
    {
        path: "/",
        name: "Home",
        component: Home,
        children: [
            {
                path: '/',
                name: 'user',
                meta: {
                    title: '个人中心'
                },
                component: () => import(/* webpackChunkName: "user" */ '../views/user.vue')
            }, 
            {
                path: '/DoctorManager',
                name: 'DoctorManager',
                meta: {
                    title: '医生信息管理'
                },
                component: () => import(/* webpackChunkName: "user" */ '../views/DoctorManager.vue')
            },
            {
                path: '/PatientManager',
                name: 'PatientManager',
                meta: {
                    title: '病人信息管理'
                },
                component: () => import(/* webpackChunkName: "user" */ '../views/PatientManager.vue')
            },
            {
                path: '/MedicalManager',
                name: 'MedicalManager',
                meta: {
                    title: '药品信息管理'
                },
                component: () => import(/* webpackChunkName: "user" */ '../views/MedicalManager.vue')
            },
            {
                path: '/MedicalOrderManager',
                name: 'MedicalOrderManager',
                meta: {
                    title: '医嘱信息管理'
                },
                component: () => import(/* webpackChunkName: "user" */ '../views/DoctorOrderManager.vue')
            },
            {
                path: '/PrescriptionManager',
                name: 'PrescriptionManager',
                meta: {
                    title: '处方信息管理'
                },
                component: () => import(/* webpackChunkName: "user" */ '../views/PrescriptionManager.vue')
            },
        ]
    },
    {
        path: "/login",
        name: "Login",
        meta: {
            title: '登录'
        },
        component: () => import( /* webpackChunkName: "login" */ "../views/login.vue")
    },
];

const router = createRouter({
    history: createWebHashHistory(),
    routes
});

router.beforeEach((to, from, next) => {
    document.title = `${to.meta.title} | vue-manage-system`;
    const role = localStorage.getItem('ms_username');
    if (!role && to.path !== '/login') {
        next('/login');
    } 
     else {
        next();
    }
});

export default router;