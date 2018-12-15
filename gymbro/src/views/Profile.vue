<template>
    <div>
        <div>
            <h1>Your details</h1>
            <form>
                <div>
                    <label for="userId">UserId</label>
                    <input v-model="profile.userId" type="text" name="userId" id="userId">
                </div>
                <div>
                    <label for="Age">Age</label>
                    <input v-model="profile.age" type="text" name="age" id="age">
                </div>
                <div>
                    <label for="weight">Weight</label>
                    <input v-model="profile.weight" type="text" name="weight" id="weight">
                </div>
                <div>
                    <label for="height">Height</label>
                    <input v-model="profile.height" type="text" name="height" id="height">
                </div>
                <button 
                    v-on:click="updateProfile"
                    type="button">
                    Update profile
                </button>
            </form>
        </div>
    </div>
</template>

<script>
import axios from "axios"

export default {
    mounted: function () {
    axios.get("profile").then(r => this.profile = r.data);    
  }, 

    name: 'profile',
    data: function() {
        return {
            profile: {userId: "", age: "", height: "", weight: ""}
        }
    },

    methods: {
        updateProfile() {
            this.profile.push(this.profile);
            axios.put("profile", this.profile).then(this.$router.push({name: "profile", params: {id: this.profile.id}}));
        }
    }
}
</script>
