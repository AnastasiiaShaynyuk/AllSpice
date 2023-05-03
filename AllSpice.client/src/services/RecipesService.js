import { AppState } from "../AppState.js"
import { Recipe } from "../models/Recipe.js"
import { logger } from "../utils/Logger.js"
import { api } from "./AxiosService.js"


class RecipesService {
  async getAllRecipes() {
    const res = await api.get('api/recipes')
    // logger.log('getting all recipes', res.data)
    AppState.recipes = res.data.map(r => new Recipe(r))
  }
  
  async createRecipe(recipeData) {
    const res = await api.post('api/recipes', recipeData)
    // logger.log('creating a recipe', res.data)
    AppState.recipes.push(new Recipe(res.data))
    return res.data
  }

  async setActiveRecipe(recipeId) {
    // logger.log(recipeId)
    AppState.activeRecipe = AppState.recipes.find(r => r.id == recipeId)
    logger.log(AppState.activeRecipe)
  }
}

export const recipesService = new RecipesService()
