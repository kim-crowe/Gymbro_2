<template>
  <div class="mx-6">
    <div 
      v-on:click="startWorkout" 
      class="bg-blue hover:bg-blue-dark text-white font-bold py-2 px-4 rounded text-center">New workout</div>
      <hr/>
      <div class="font-bold text-2xl my-2">My workouts</div>
      <div v-for="w in workouts" v-bind:key="w.id">{{w.date | formatDate}}</div>
    </div>
</template>

<script>
import axios from 'axios';

export default {
  name: 'home',
  methods: {
    startWorkout: function() {
      axios.post("workouts").then(response => {
        var newWorkout = response.data;
        this.workouts.push(newWorkout);
      });
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
