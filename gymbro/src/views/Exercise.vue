<template>
  <div class="mx-6">
    <div class="mb-4">
      <label class="block text-grey-darker text-sm font-bold mb-2">Name</label>
      <input
        v-model="exercise.name"
        class="shadow appearance-none border rounded w-full py-2 px-3 text-grey-darker leading-tight focus:outline-none focus:shadow-outline"
        type="text"
      >
    </div>
    <div class="mb-6">
      <label class="block text-grey-darker text-sm font-bold mb-2" for="password">Equipment</label>
      <input
        v-model="exercise.equipment"
        class="shadow appearance-none border border rounded w-full py-2 px-3 text-grey-darker mb-3 leading-tight focus:outline-none focus:shadow-outline"
        type="text"
      >
    </div>
    <div class="flex items-center justify-between">
      <button
        class="bg-green hover:bg-green-dark text-white font-bold py-2 px-4 w-1/2 mr-2 rounded focus:outline-none focus:shadow-outline"
        type="button"
        @click="submit"
      >{{okText}}</button>
      <button
        class="bg-red hover:bg-red-dark text-white font-bold py-2 px-4 w-1/2 ml-2 rounded focus:outline-none focus:shadow-outline"
        type="button"
      >Cancel</button>
    </div>
  </div>
</template>

<script>
import axios from "axios";
import state from "../state";

export default {
    mounted: function() {
        if(state.exercise !== null) {
            this.exercise = state.exercise;
            this.okText = "Update"
        }
    },
    data: function() {
        return {
            exercise: { name: "", equipment: "", sets: [] },
            okText: "Create"
        }
    },
    methods : {
        submit: function() {
            if(this.okText == "Create") {
                state.workout.exercises.push(this.exercise);
                axios.put("/workouts", state.workout).then(this.$router.replace({name: "exercise"}));
            }
        }
    }
}
</script>
