import Vue from 'vue'
import App from './App.vue'
import router from './router'
import moment from 'moment' 
import axios from 'axios'
import state from './state'

Vue.config.productionTip = false
axios.defaults.baseURL = "http://localhost:5000/api"

Vue.use(state);

Vue.filter("formatDate", function(value) {
  if (value) { 
    return moment(String(value)).format("DD-MMM-YYYY")
  }
 })

new Vue({
  router,
  render: h => h(App)
}).$mount('#app')
