<template>
    <form class="w-full max-w-xs">
  <div class="md:flex md:items-center mb-6">
    <div class="md:w-1/3">
      <label class="block text-grey font-bold md:text-right mb-1 md:mb-0 pr-4" for="inline-exercise">
        Exercise
      </label>
    </div>
    <div class="md:w-2/3">
      <input
      v-model="exercise.name" 
      class="bg-grey-lighter appearance-none border-2 border-grey-lighter rounded w-full py-2 px-4 text-grey-darker leading-tight focus:outline-none focus:bg-white focus:border-purple" id="inline-exercise" type="text">
    </div>
  </div>
  <div class="md:flex md:items-center mb-6">
    <div class="md:w-1/3">
      <label class="block text-grey font-bold md:text-right mb-1 md:mb-0 pr-4" for="inline-equipment">
        Equipment
      </label>
    </div>
    <div class="md:w-2/3">
      <input
      v-model="exercise.equipment" 
      class="bg-grey-lighter appearance-none border-2 border-grey-lighter rounded w-full py-2 px-4 text-grey-darker leading-tight focus:outline-none focus:bg-white focus:border-purple" id="inline-equipment" type="text">
    </div>
  </div>
   <div class="md:flex md:items-center">
    <div class="md:w-1/3"></div>
    <div class="md:w-2/3">
      <button 
      v-on:click="addExercise"
      class="shadow bg-purple hover:bg-purple-light focus:shadow-outline focus:outline-none text-white font-bold py-2 px-4 rounded" type="button">
        Save exercise
      </button>
    </div>
  </div>
</form>
</template>

<script>
import axios from "axios"

export default {
    name: 'exercise',
    data: function() {
        return {
            exercise: {name: "", equipment: "", sets: []}
        }
    },
    computed : {
        workout : function() {
            var id = this.$route.params.id;
            return this.$workouts.find(x => x.id == id);
        }
    },
    methods: {
        addExercise() {
            this.workout.exercises.push(this.exercise);
            axios.put("workouts", this.workout).then(this.$router.push({name: "workout", params: {id: this.workout.id}}));
        }
    }
}
</script>
