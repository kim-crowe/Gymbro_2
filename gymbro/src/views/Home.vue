<template>
  <div class="mx-6">
    <div
      @click="startWorkout"
      class="bg-blue hover:bg-blue-dark text-white font-bold py-2 px-4 rounded text-center"
    >New workout</div>
    <hr>
    <div class="font-bold text-2xl my-2">My workouts</div>
    <div v-for="w in workouts" v-bind:key="w.id">{{w.date}}</div>
  </div>
</template>

<script>
import axios from 'axios';
import state from "../state";

export default {
  name: 'home',
  data: function () {
    return {
      workouts: []
    }
  },
  methods: {
    startWorkout: function() {      
      axios
        .post("workouts")
        .then(r => {
          var newWorkout = r.data;
          this.workouts.push(newWorkout);
          state.workout = newWorkout;
          this.$router.push({ name: "workout" });
        });
    }
  },
  mounted: function () {
    axios.get("workouts").then(r => this.workouts = r.data);
  },
}
</script>
