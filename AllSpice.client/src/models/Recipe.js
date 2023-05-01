
export class Recipe {
  constructor(data) {
    this.id = data.id
    this.title = data.title
    this.instruction = data.instruction
    this.img = data.img
    this.category = data.category
    this.creatorId = data.creatorId
    this.favoriteId = data.favoriteId
  }
}