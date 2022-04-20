import Vue from 'vue'
import VueRouter from 'vue-router'

import Dashboard from '../views/Dashboard.vue'
import Login from '../views/Login.vue'
import Nuevo from '../views/Nuevo.vue'
import Translator from '../views/Translator'

Vue.use(VueRouter)

const routes = [
  {
    path: '/',
    name: 'Translator',
    component: Translator
},
  {
    path: '/',
    name: 'Login',
    component: Login
  },
  {
    path: '/dashboard',
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
