<template>
    <!-- Button trigger modal -->
    <!-- <button type="button" class="btn btn-primary" data-bs-toggle="modal" data-bs-target="#exampleModal">
    Launch demo modal
  </button> -->

    <!-- Modal -->
    <div class="modal fade" id="exampleModal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
      <div class="modal-dialog modal-dialog-centered" :class="size">
        <div class="modal-content">
          <slot></slot>

          <!-- <div class="modal-footer"> -->
            <!-- <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button> -->
            <!-- <button type="button" class="btn btn-primary">Save changes</button> -->
          <!-- </div> -->
        </div>
      </div>
    </div>
</template>


<script setup>
const props = defineProps({ size: { type: String, default: 'modal-md' } })
</script>


<style lang="scss" scoped>

</style>