<template>
  <header class="container elevation-4 rounded-md bg-img">
    <section class="row">
      <div class="col d-flex justify-content-end  text-light">
        <div>Search here</div>
        <Login />
      </div>
    </section>
    <section class="row  text-center text-light font py-md-5 py-4">
      <div class="col-md-12">
        <h1>All-Spice</h1>
        <h3>Cherish Your Family</h3>
        <h3>And Their Cooking</h3>
      </div>
    </section>
    <section class="row">
      <div class="col-6"></div>
    </section>
  </header>
  <main>
    <router-view />
  </main>
   <footer class="text-light">
    Made with 🤍 by Anastasiia Shaynyuk
  </footer>
</template>

<script>
import { computed } from 'vue'
import { AppState } from './AppState'
import Navbar from './components/Navbar.vue'
import Login from "./components/Login.vue"

export default {
  setup() {
    return {
      appState: computed(() => AppState)
    }
  },
  components: { Navbar, Login }
}
</script>
<style lang="scss">
@import "./assets/scss/main.scss";

.font {
  font-family: 'Sahitya', serif;
  text-shadow: 1px 1px black, 1px 1px 2px #212529, -3px 2px 6px rgb(104 87 45 / 50%);
}

.bg-img {
  background-image: url('src/assets/img/unsplash_pqJ21tErTgI.png');
  background-position: center;
  background-size: cover;
  min-height: 50vh;
  margin-top: 1em;
  min-width: 97vw;
}

:root{
  --main-height: calc(100vh - 32px - 64px);
}


footer {
  display: grid;
  place-content: center;
  height: 32px;
  background-color: #527360;
}

@media screen and (max-width: 480px) {
  .bg-img {
    min-height: 35vh;
    margin: 0;

  }
}
</style>
