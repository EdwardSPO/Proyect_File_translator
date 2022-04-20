<template>
<div>
 <!-- Navbar -->
<nav class="navbar navbar-expand-lg navbar-light bg-light">
  <!-- Container wrapper -->
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
          <a class="nav-link" href="http://localhost:8080/dashboard">Dashboard</a>
        </li>
          <li class="nav-item">
          <a class="nav-link" href="http://localhost:8080/translator">Translator</a>
        </li>
  
      </ul>

      <div class="d-flex align-items-center">
        
        <button type="button" class="btn btn-primary me-3">
          Sign-off
        </button>
       
      </div>
    </div>
  </div>
</nav>
</div>  
</template>