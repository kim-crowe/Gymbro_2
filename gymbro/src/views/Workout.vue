<template>
    <div v-if="workout">
        <button
         v-on:click="addExercise"  
          class="bg-blue hover:bg-blue-dark text-white font-bold py-2 px-4 rounded text-center">Add exercise</button>
            <span>
                {{workout.date|formatDate}}
            </span>
            <div class="flex md:flex flex-wrap" v-for="ex in workout.exercises" v-bind:key="ex">
                <div class="w-full md:w-3/4 bg-grey p-4 text-center text-grey-lighter">{{ex.name}}</div>
                <div class="w-full md:w-1/4 bg-grey-light p-4 text-center text-grey-darker">{{ex.equipment}}</div>
            </div>

            <!-- <ul class="list-reset">
                <li v-for="ex in workout.exercises" v-bind:key="ex">
                  {{ex.name}} / {{ex.equipment}}  
                </li>
            </ul> -->
    </div>
</template>

<script>
export default {
    name: 'workout',
    computed : {
        workout : function() {
            var id = this.$route.params.id;
            return this.$workouts.find(x => x.id == id);
        }
    },
    methods: {
        addExercise: function() {
            this.$router.push( {name: "exercise", params: {id: this.workout.id}});
        }
    }
}
</script>
