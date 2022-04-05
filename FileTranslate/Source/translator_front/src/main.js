import Vue from 'vue'
import App from './App.vue'
import router from './router'
<<<<<<< HEAD
import { BootstrapVue, IconsPlugin } from 'bootstrap-vue'
import VueAxios from 'vue-axios'

import Axios from 'axios'




=======
import { BootstrapVue, IconsPlugin } from 'bootstrap-vue' 
import VueAxios from 'vue-axios'
import Axios from 'axios'
import Vuelidate from 'vuelidate'
>>>>>>> a4ae3a9c6efce70593d419f0b188c396dad10361


Vue.config.productionTip = false
Vue.use(BootstrapVue);
Vue.use(IconsPlugin);
Vue.use(VueAxios, Axios);
<<<<<<< HEAD
=======
Vue.use(Vuelidate);
>>>>>>> a4ae3a9c6efce70593d419f0b188c396dad10361

import 'bootstrap/dist/css/bootstrap.css'
import 'bootstrap-vue/dist/bootstrap-vue.css'

new Vue({
<<<<<<< HEAD
    router,
    render: h => h(App)
}).$mount('#app')
=======
  router,
  render: h => h(App)
}).$mount('#app')

>>>>>>> a4ae3a9c6efce70593d419f0b188c396dad10361
