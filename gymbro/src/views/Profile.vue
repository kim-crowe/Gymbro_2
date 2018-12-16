<template>
    <div>
        <div class="w-full border-l-4 border-green bg-green-lightest text-green rounded relative p-4 m-4 md:max-w-sm md:mx-auto" v-show="wasUpdated">
            <span class="block sm:inline">Your profile has been updated</span>
            <span class="absolute pin-t pin-b pin-r px-4 py-4">
                <button 
                    class="text-green h-6 w-6"
                    v-on:click="closeAlert"
                    type="button">
                    <i class="fas fa-times"></i>
                </button>
            </span>
        </div>
        <div class="w-full bg-white rounded shadow-lg p-8 m-4 md:max-w-sm md:mx-auto">
            <h1 class="block w-full text-center text-grey-darkest mb-6">Your details</h1>
            <form class="mb-4 md:flex md:flex-wrap md:justify-between">
                <div class="flex flex-col mb-4 md:w-full">
                    <label class="mb-2 uppercase font bold text-lg text-grey-darkest" for="Age">Age</label>
                    <input class="border py-2 px-3 text-grey-darkest" v-model="profile.age" type="text" name="age" id="age">
                </div>
                <div class="flex flex-col mb-4 md:w-full">
                    <label class="mb-2 uppercase font bold text-lg text-grey-darkest" for="weight">Weight in lbs</label>
                    <input class="border py-2 px-3 text-grey-darkest" v-model="profile.weight" type="text" name="weight" id="weight">
                </div>
                <div class="flex flex-col mb-4 md:w-full">
                    <label class="mb-2 uppercase font bold text-lg text-grey-darkest" for="height">Height in cm</label>
                    <input class="border py-2 px-3 text-grey-darkest" v-model="profile.height" type="text" name="height" id="height">
                </div>
                <button 
                    class="block bg-indigo hover:bg-indigo-dark text-white uppercase text-lg mx-auto p-4 rounded"
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
            wasUpdated: false,
            profile: {age: "", height: "", weight: ""}
        }
    },

    methods: {
        updateProfile() {     
            this.wasUpdated = false;       
            axios.post("profile", this.profile).then(this.wasUpdated = true);
        },

        closeAlert() {
            this.wasUpdated = false;
        }
    }
}
</script>

<style>
    button:focus {
        outline-style: none;
        border-width: 0px;
    }
</style>
