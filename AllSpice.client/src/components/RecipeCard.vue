<template>
  <div data-bs-toggle="modal" data-bs-target="#activeRecipe" class="card text-bg-dark my-2 elevation-4" @click="activeRecipe(recipe.id)">
    <img :src="recipe.img" class="card-img" :alt="recipe.title">
    <div class="card-img-overlay d-flex flex-column justify-content-between">
      <div class="d-flex justify-content-between align-items-center">
        <h6 class="card-text p-1 px-3 rounded-pill">{{ recipe.category }}</h6>
        <!-- <p class="fs-4">❤️</p> -->
      </div>
      <h5 class="card-title card-text p-2 rounded">{{ recipe.title }}</h5>
      <!-- <p class="card-text"><small>Last updated 3 mins ago</small></p> -->
    </div>
  </div>
  <Modal id="activeRecipe" size="modal-lg">
    <ActiveRecipe/>
  </Modal>
</template>


<script>
import { computed } from "vue";
import { Recipe } from "../models/Recipe";
import { AppState } from "../AppState";
import Modal from "./Modal.vue";
import ActiveRecipe from "./ActiveRecipe.vue";

export default {
    props: {
        recipe: { type: Recipe, required: true }
    },
    setup() {
        return {
            recipes: computed(() => AppState.recipes)
        };
    },
    components: { Modal, ActiveRecipe }
}
</script>


<style lang="scss" scoped>

.card {
  border-width: 0;
}
.card-img {
  height: 40vh;
  width: 100%;
  object-fit: cover;
  object-position: center;
}

.card-text {
  backdrop-filter: blur(30px);
  border: 1px solid #BBBBBB;
  text-shadow: 1px 1px black, 1px 1px 2px #212529, -3px 2px 6px rgb(104 87 45 / 50%);

}
</style>