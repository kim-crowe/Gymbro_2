<template>
    <div>
        {{workout.date|formatDate}}
    </div>
</template>

<script>
export default {
    computed : {
        workout : function() {
            var id = this.$route.params.id;
            return this.$workouts.find(x => x.id == id);
        }
    }
}
</script>
