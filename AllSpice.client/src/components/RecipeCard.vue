<template>
  <div class="card text-bg-dark my-2 elevation-4">
    <img :src="recipe.img" class="card-img" :alt="recipe.title">
    <div class="card-img-overlay d-flex flex-column">
      <p class="card-text">{{ recipe.category }}</p>
      <h5 class="card-title">{{ recipe.title }}</h5>
      <!-- <p class="card-text"><small>Last updated 3 mins ago</small></p> -->
    </div>
  </div>
</template>


<script>
import { computed } from "vue";
import { Recipe } from "../models/Recipe";
import { AppState } from "../AppState";

export default {
  props: {
    recipe: {type: Recipe, required: true}
  },
  setup() {
    
    return {
      recipes: computed(() => AppState.recipes)
    }
  }
}
</script>


<style lang="scss" scoped>

.card {
  border-width: 0;
  transition: all 0.3s ease-in-out;
}
.card-img {
  height: 40vh;
  width: 100%;
  object-fit: cover;
  object-position: center;
}
</style>