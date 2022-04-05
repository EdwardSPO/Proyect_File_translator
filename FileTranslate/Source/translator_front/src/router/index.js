import Vue from 'vue'
import VueRouter from 'vue-router'
import Translator from '../views/Translator'







Vue.use(VueRouter)

const routes = [{
    path: '/',
    name: 'Translator',
    component: Translator
}]

const router = new VueRouter({
    mode: 'history',
    base: process.env.BASE_URL,
    routes
})

export default router