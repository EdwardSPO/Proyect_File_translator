<template>
<div>
<nav class="navbar navbar-expand-lg navbar-light bg-light">
  <div class="container">
    <button
      class="navbar-toggler"
      type="button"
      data-mdb-toggle="collapse"
      data-mdb-target="#navbarButtonsExample"
      aria-controls="navbarButtonsExample"
      aria-expanded="false"
      aria-label="Toggle navigation"
    >
      <i class="fas fa-bars"></i>
    </button>
    <div class="collapse navbar-collapse" id="navbarButtonsExample">
      <ul class="navbar-nav me-auto mb-2 mb-lg-0">
        <li class="nav-item">
          <a class="nav-link" v-on:click="Dashboard()">Dashboard</a>
        </li>
          <li class="nav-item">
          <a class="nav-link"  v-on:click="Translator()">Translator</a>
        </li>
      </ul>
      <div class="d-flex align-items-center">
            <button type="button" class="btn btn-primary margen fw-bold float-end" v-on:click="Sign()">Sign-off</button>
      </div>
    </div>
  </div>
</nav>
</div>  
</template>
<script>


export default {
  
  name: 'Header',
  components: {
  },
  props:{
     valorRecibido: null
  },
  methods:{
             Sign(){
             this.$router.push('/');  
            },
             Dashboard(){
             this.$router.push('/dashboard');  
            },
             Translator(){
             this.$router.push('/translator/:id');  
            }


  },


}
</script>