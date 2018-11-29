export default {

    install(Vue) {
  
      let stateController = new Vue({
        data: { $workouts: [] }
      });
  
      Vue.mixin({
        computed: {
          $workouts: {
            get: function () { return stateController.$data.$workouts },
            set: function (workouts) { stateController.$data.$workouts = workouts }
          }
        }        
      })
    }
  }
  