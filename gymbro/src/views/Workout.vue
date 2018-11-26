<template>
  <div class="flex items-center justify-between">
    <div>{{workout.date | formatDate }}</div>
    <button class="rounded bg-green px-4 py-2 text-white" @click="addExercise">Add exercise</button>
    <ul>
      <li v-for="ex in workout.exercises" v-bind:key="ex">{{ex.name}} ({{ex.equipment}})</li>
    </ul>
  </div>
</template>

<script>
import state from "../state";

export default {
    mounted: function() {
        this.workout = state.workout;
    },
    data : function() {
        return {
            workout: {}
        }
    },
    methods : {
        addExercise : function () {
            state.exercise = null;
            this.$router.push({name: "exercise-details"});
        }
    }
}
</script>

