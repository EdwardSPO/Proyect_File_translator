import Vue from 'vue'
import VueRouter from 'vue-router'
<<<<<<< HEAD
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
=======

import Dashboard from '../views/Dashboard.vue'
import Login from '../views/Login.vue'
import Nuevo from '../views/Nuevo.vue'

Vue.use(VueRouter)

const routes = [
  {
    path: '/',
    name: 'Login',
    component: Login
  },
  {
    path: '/',
    name: 'Dashboard',
    component: Dashboard
  },

  {
    path: '/nuevo',
    name: 'Nuevo',
    component: Nuevo
  }
]

const router = new VueRouter({
  mode: 'history',
  base: process.env.BASE_URL,
  routes
})

export default router
>>>>>>> a4ae3a9c6efce70593d419f0b188c396dad10361
