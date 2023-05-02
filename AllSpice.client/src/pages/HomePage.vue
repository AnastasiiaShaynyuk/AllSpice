<template>
  <div class="container-fluid">
    <section class="row justify-content-center px-md-5 mt-5">
      <div v-for="rec in recipes" :key="rec.id" class="col-md-4 trans">
        <RecipeCard :recipe="rec"/>
      </div>
    </section>
  </div>
  <!-- <Modal id="activeRecipe">
    <ActiveRecipe/>
  </Modal> -->

  <button class="btn-rounded position-fixed elevation-4" v-if="account.id" data-bs-toggle="modal" data-bs-target="#create-recipe"><i class="mdi mdi-plus fs-2 "></i></button>

  <Modal id="create-recipe" size="modal-lg">
    <template #header>Create Recipe</template>
    <template #body>
      <RecipeForm />
    </template>
  </Modal>

</template>

<script>
import Pop from "../utils/Pop";
import {recipesService} from '../services/RecipesService'
import { computed, onMounted } from "vue";
import { AppState } from "../AppState";
import RecipeCard from "../components/RecipeCard.vue";
import Modal from "../components/Modal.vue";
import ActiveRecipe from "../components/ActiveRecipe.vue";
import RecipeForm from "../components/RecipeForm.vue";

export default {
    setup() {
        async function getAllRecipes() {
            try {
                await recipesService.getAllRecipes();
            }
            catch (error) {
                Pop.error(error);
            }
        }
        onMounted(() => {
            getAllRecipes();
        });
        return {
          recipes: computed(() => AppState.recipes),
          account: computed(() => AppState.account)
        };
    },
    components: { RecipeCard, Modal, ActiveRecipe, RecipeForm }
}
</script>

<style scoped lang="scss">
.trans {
  transition: all 0.3s ease-in-out;
}
.trans:hover {
  transform: scale(.9);
  border-width: none;
}

.btn-rounded {
  background-color: #527360;
  height: 4em;
  width: 4em;
  border-radius: 50%;
  border: none;
  color: white;
  right: 3em;
  bottom: 3em;
}
</style>
