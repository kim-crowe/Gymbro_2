<template>
    <div>
        {{workout.date|formatDate}}
    </div>
</template>

<script>
import state from "../state";

export default {
    data: function() {
        return {
            workout: {}
        }
    },
    mounted: function() {
        this.workout = state.workout;
    }
}
</script>
