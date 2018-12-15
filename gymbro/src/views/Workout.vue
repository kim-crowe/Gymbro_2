<template>
    <div v-if="workout">
        <div>
            <h1>Workout details</h1>
            <div class="text-xl text-grey-dark mb-4">{{workout.date|formatDate}}</div>
        </div>
        <button
         v-on:click="addExercise"  
          class="bg-blue hover:bg-blue-dark text-white font-bold py-2 px-4 rounded text-center">Add exercise</button>

          <div class="max-w-sm border-r border-b border-l border-grey-light lg:border-l-0 lg:border-t lg:border-grey-light bg-white rounded-b lg:rounded-b-none lg:rounded-r p-4 flex flex-col justify-between leading-normal" 
          v-for="ex in workout.exercises" v-bind:key="ex">
          <div class="mb-8">
              <!-- border-r border-b border-l border-grey-light lg:border-l-0 lg:border-t lg:border-grey-light bg-white rounded-b lg:rounded-b-none lg:rounded-r p-4 flex flex-col justify-between leading-normal -->
            <div class="px-6 py-4">
                <div class="font-bold text-xl mb-2">{{ex.name}} / {{ex.equipment}}</div>
                <table class="w-full text-left table-collapse">
                <thead>
                    <tr>
                        <th class="text-sm font-semibold text-grey-darker p-2 bg-grey-lightest">Set</th>
                        <th class="text-sm font-semibold text-grey-darker p-2 bg-grey-lightest">Reps</th>
                        <th class="text-sm font-semibold text-grey-darker p-2 bg-grey-lightest">Weight</th>
                    </tr>
                </thead>
                <tbody>
                    <tr>
                        <td class="p-2 border-t border-grey-light font-mono text-xs text-purple-dark whitespace-no-wrap">1</td>
                        <td class="p-2 border-t border-grey-light font-mono text-xs text-purple-dark whitespace-no-wrap">15</td>
                        <td class="p-2 border-t border-grey-light font-mono text-xs text-purple-dark whitespace-no-wrap">30Kg</td>
                    </tr>
                </tbody>
            </table>
                    
            <!-- <div class="px-6 py-4"> -->
        </div>
        </div>
    </div>
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
