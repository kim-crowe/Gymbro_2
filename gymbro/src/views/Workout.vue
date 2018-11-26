<template>
  <div class="flex items-center justify-between">
    <div>{{workout.date}}</div>
    <button class="rounded bg-green px-4 py-2 text-white" @click="addExercise">Add exercise</button>
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

