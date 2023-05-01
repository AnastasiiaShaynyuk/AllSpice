<template>
  <div class="container-fluid">
    <section class="row justify-content-center px-md-5 mt-5">
      <div v-for="rec in recipes" class="col-md-4">
        <RecipeCard :recipe="rec"/>
      </div>
    </section>
  </div>

</template>

<script>
import Pop from "../utils/Pop";
import {recipesService} from '../services/RecipesService'
import { computed, onMounted } from "vue";
import { AppState } from "../AppState";
import RecipeCard from "../components/RecipeCard.vue";

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
            recipes: computed(() => AppState.recipes)
        };
    },
    components: { RecipeCard }
}
</script>

<style scoped lang="scss">
.home {
  display: grid;
  height: 80vh;
  place-content: center;
  text-align: center;
  user-select: none;

  .home-card {
    width: 50vw;

    >img {
      height: 200px;
      max-width: 200px;
      width: 100%;
      object-fit: contain;
      object-position: center;
    }
  }
}
</style>
