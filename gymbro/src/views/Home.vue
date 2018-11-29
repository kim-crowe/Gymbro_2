<template>
  <div class="mx-6">
    <button 
      v-on:click="startWorkout" 
      class="bg-blue hover:bg-blue-dark text-white font-bold py-2 px-4 rounded text-center">New workout</button>
      <hr/>
      <div class="font-bold text-2xl my-2">My workouts</div>
      <div 
      v-on:click="showWorkout(w)"
      v-for="w in workouts" v-bind:key="w.id">{{w.date | formatDate}}</div>
    </div>
</template>

<script>
import axios from "axios";
import state from "../state";

export default {
  name: 'home',
  methods: {
    startWorkout: function() {
      axios.post("workouts").then(response => {
        var newWorkout = response.data;
        this.workouts.push(newWorkout);
        state.workout = newWorkout;
        this.$router.push( {name: "workout"});
      });
    },
    showWorkout: function(workout) {
        state.workout = workout;
        this.$router.push( {name: "workout"});
    }
  },
  data: function () {
    return {
      workouts: []
    }
  },
  mounted: function () {
    axios.get("workouts").then(r => this.workouts = r.data);    
  },
}
</script>
