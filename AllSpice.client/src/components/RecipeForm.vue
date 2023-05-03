<template>
  <div class="modal-header">
        <h1 class="modal-title fs-5" id="exampleModalLabel">
              Create Recipe
            </h1>
            <button title="Close" type="button" class="btn-close btn-light" data-bs-dismiss="modal" aria-label="Close"></button>
          </div>

  <form @submit.prevent="createRecipe()">
            <div class="modal-body text-dark">
    <div class="form-floating mb-3">
    <input type="text" class="form-control" id="title" placeholder="Title"  required v-model="editable.title"
          minlength="3" maxlength="25" />
        <label for="title">Title</label>
      </div>
      <div class="form-floating mb-3">
        <textarea class="form-control" id="instructions" placeholder="Instructions" name="instructions" required
          style="height: 300px" v-model="editable.instructions" minlength="5" maxlength="1000"></textarea>
        <label for="instructions">Instructions</label>
      </div>
      <div class="mb-3">
        <select v-model="editable.category" required class="form-select" aria-label="Default select example">
                <option selected value="Pasta">Pasta</option>
                <option value="Italian">Italian</option>
                <option value="Soup">Soup</option>
                <option value="Salads">Salads</option>
                <option value="Chicken">Chicken</option>
                <option value="Cheese">Cheese</option>
                <option value="Mexican">Mexican</option>
                <option value="Specialty Coffee">Specialty Coffee</option>
              </select>
        <!-- <label for="instruction">Instruction</label> -->
        </div>
      <div class="form-floating mb-3">
        <input type="url" class="form-control" id="img" placeholder="Img" name="img" v-model="editable.img"
          @input="previewImage" />
        <label for="img">Recipe Picture</label>
        <br />
        <img class='img-preview' :src="imagePreview" v-if="imagePreview" />
      </div>
      <div class="my-3 text-end">
      <button data-bs-dismiss="modal" class="btn btn-success" type="submit">
        Create!
      </button>
    </div>
    </div>
  </form>
</template>


<script>
import { ref } from "vue";
import { recipesService } from "../services/RecipesService";
import Pop from "../utils/Pop";
import { logger } from "../utils/Logger";

export default {
  setup(){
const editable = ref({})
const imagePreview = ref(null);


    return {
      editable,
      imagePreview,
      previewImage() {
        imagePreview.value = editable.value.img;
      },
      async createRecipe() {
        try {
          const recipeData = editable.value
          // logger.log(recipeData)
          const newRecipe = await recipesService.createRecipe(recipeData)
          Pop.toast('Successfully created a recipe', 'success', 'center')
          editable.value = {}
        }
        catch (error){
          Pop.error(error);
        }
      }
    }
  }
}
</script>


<style lang="scss" scoped>
.img-preview {
  width: 100%;
  height: 40vh;
  object-fit: cover;
  object-position: center;
}
</style>