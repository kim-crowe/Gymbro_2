<template>
  <div id="app">
    <div id="nav">
      <nav class="font-sans flex flex-col text-center sm:flex-row sm:text-left sm:justify-between bg-indigo sm:items-baseline py-4 px-6">
        <div class="mb-2 sm:mb-0">
          <a href="/" class="text-lg no-underline text-white hover:text-grey">Gymbro</a>
        </div>
        <div>
          <a href="/profile" class="text-lg no-underline text-white hover:text-grey">Profile</a>
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
