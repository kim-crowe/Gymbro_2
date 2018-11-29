<template>
  <div id="app">
    <div id="nav">
      <nav class="px-2 py-4 bg-indigo text-white">
        <div class="container mx-auto">
        <a class="text-white no-underline text-3xl font-bold" href="/">Gymbro</a>
        </div>
      </nav>
    </div>
    <div class="container mx-auto py-2">
      <router-view/>
    </div>
  </div>
</template>

<script>
import axios from 'axios';

export default {
  mounted: function () {
    axios.get("workouts").then(r => this.$workouts = r.data);    
  }
}
</script>
