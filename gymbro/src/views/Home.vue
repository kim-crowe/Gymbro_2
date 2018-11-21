<template>
  <div class="home">
    <exercise v-for="ex in exercises" :key="ex.id" :exercise="ex"/>
  </div>
</template>

<script>
import axios from 'axios';
import exercise from "../components/exercise";

export default {
  name: 'home',
  components: {exercise},
  data: function () {
    return {
      exercises: []
    }
  },
  mounted: function () {
    axios
      .get('http://localhost:5000/api/records/by/date?date=2018-11-12')
      .then(response => (this.exercises = response.data))
  }
}
</script>
