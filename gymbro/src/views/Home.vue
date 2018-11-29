<template>
  <div class="mx-6">
    <div 
      v-on:click="startWorkout" 
      class="bg-blue hover:bg-blue-dark text-white font-bold py-2 px-4 rounded text-center">New workout</div>      
      <div class="font-bold text-2xl my-2">My workouts</div>
      <div 
      v-on:click="showWorkout(w)"
      v-for="w in $workouts" v-bind:key="w.id">{{w.date | formatDate}}</div>
    </div>
</template>

<script>
import axios from "axios";

export default {
  name: 'home',
  methods: {
    startWorkout: function() {
      axios.post("workouts").then(response => {
        var newWorkout = response.data;
        this.$workouts.push(newWorkout);        
        this.$router.push( {name: "workout", params: { id: newWorkout.id }});
      });
    },
    showWorkout: function(workout) {
        this.$router.push( {name: "workout", params: { id: workout.id} });
    }
  }
}
</script>
