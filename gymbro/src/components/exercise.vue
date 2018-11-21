<template>
    <div class="card" style="width: 18rem;">
        <div class="card-header">
            {{exercise.exercise}} - {{exercise.equipment}}
        </div>
        <ul class="list-group list-group-flush">
            <li v-for="set in exercise.sets" :key="set.reps" class="list-group-item">{{set.reps}} @ {{set.weight}} kg</li>
        </ul>
    </div>
</template>

<script>
export default {
    name: "exercise",
    props: ["exercise"]
}
</script>
