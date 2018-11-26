import Vue from 'vue'
import App from './App.vue'
import router from './router'
import axios from "axios";
import moment from "moment";

axios.defaults.baseURL = "http://localhost:5000/api"
Vue.config.productionTip = false

Vue.filter('formatDate', function (value) {
  if (value) {
    return moment(String(value)).format('DD-MMM-YYYY')
  }
});

new Vue({
  router,
  render: h => h(App)
}).$mount('#app')
