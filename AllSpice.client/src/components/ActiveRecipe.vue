<template>
  <div  data-bs-toggle="modal" data-bs-target="#activeRecipe" class="card mb-3" style="max-width: 540px;">
    <div class="row g-0">
      <div class="col-md-4">
        <img :src="recipe.img" class="img-fluid rounded-start" :alt="recipe.img">
      </div>
      <div class="col-md-8">
        <div class="card-body">
          <h5 class="card-title">{{ recipe.title }}</h5>
          <p class="card-text">This is a wider card with supporting text below as a natural lead-in to additional content. This content is a little bit longer.</p>
          <!-- <p class="card-text"><small class="text-body-secondary">Last updated 3 mins ago</small></p> -->
        </div>
      </div>
    </div>
  </div>
</template>


<script>
import { AppState } from "../AppState";

export default {
  setup(){
    return {
      recipe: computed(() => AppState.activeRecipe)
    }
  }
}
</script>


<style lang="scss" scoped>

</style>