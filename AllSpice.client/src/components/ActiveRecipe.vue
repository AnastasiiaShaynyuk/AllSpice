<template>
  <div v-if="recipe" class="row">
    <div class="col-4 p-0">
      <img :src="recipe.img" :alt="recipe.title">
    </div>
    <div class="col-8">
      <div class="row p-3">
        <div class="col-12 d-flex justify-content-between">
          <div class="d-flex">
            <h3 class="text-color me-3">{{ recipe.title }}</h3>
            <h6 class="card-text px-3 pt-2 rounded-pill">{{ recipe.category }}</h6>
          </div>
            <button title="Close" type="button" class="btn-close btn-light" data-bs-dismiss="modal" aria-label="Close"></button>
        </div>
      </div>
      <div class="row p-3 justify-content-evenly ">
        <div class="col-5 border p-0 rounded bg-inst">
          <h5 class="text-center text-light py-3  bg-title rounded-top">Instructions</h5>
          <p class="px-3 ">{{ recipe.instructions }}</p>
        </div>
        <div class="col-5 border p-0 rounded bg-inst">
          <h5 class="text-center text-light py-3  bg-title rounded-top">Ingredients</h5>
          
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import { computed } from "vue";
import { AppState } from "../AppState.js";

export default {
  setup(){
    return {
      recipe: computed(() => AppState.activeRecipe)
    }
  }
}
</script>


<style lang="scss" scoped>

img {
  min-height: 60vh;
  width: 100%;
  object-fit: cover;
  object-position: center;
  border-bottom-left-radius: 7px;
  border-top-left-radius: 7px;
}

.card-text {
  background-color: #BBBBBB;
  border: 1px solid #BBBBBB;
  // text-shadow: 1px 1px black, 1px 1px 2px #212529, -3px 2px 6px rgb(104 87 45 / 50%);
  color: whitesmoke;

}
.bg-title {
  background-color: #527360;
}

.bg-inst {
  background-color: #F0F4F2;
}

.text-color {
  color: #219653;
}
</style>