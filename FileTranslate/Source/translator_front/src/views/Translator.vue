<template>
  <div>
    <h1>Traductor</h1>
    <div class="header"></div>

    <div class="container">
      <div class="mb-3">
        <input
          class="form-control"
          type="file"
          id="formFile"
          v-on:change="getFile($event)"
        />
      </div>

      <div class="flex-wrap input-group mb-3">
        <label class="input-group-text" for="inputGroupSelect01">Idioma</label>
        <select class="form-select" id="inputGroupSelect01">
          <option selected>Seleccione el idioma</option>
          <option value="1"></option>
          <option value="2"></option>
          <option value="3"></option>
        </select>
      </div>
      
      <br />
    <div class=" flex-wrap progress"></div>
 <h5 id="charge">Progress:</h5> 
  <progress id="progress" value="0" max="100" class="barraStyle" style="background-color=red" ></progress> 


      <div
        class="flex-wrap btn-group"
        role="group"
        aria-label="Basic mixed styles example"
      >
        <button
          id="traduccion"
          type="button"
          value="cargar"
          class="flex-wrap btn btn-success"
          @click="setInterval(submitForm($event),250)"
        >
          Traducir
        </button>
      </div>
    </div>
  </div>
</template>
<script>
const url = "http://localhost:5000/api/File/Upload?";



export default {
  data() {
    return {
      uploadURL: url + "subDirectory=File",
      file: ""
    };
  },
  methods: {
    getFile(event) {
    var formFile = document.getElementById("formFile");
    var archivoRuta = formFile.value;
    var extPermitidas = /(.docx|.txt)$/i;

    if(!extPermitidas.exec(archivoRuta)){
alert('Asegurese de haber seleccionado un archivo tipo docx o txt')
formFile.value=''
return false; 
    }
   
    
      var ValidationFile= document.getElementById("formFile").files[0].size;
       if(ValidationFile > 500000000){
      alert("El archivo no debe pesar mas de 500MB")
    } else{
      this.file = event.target.files[0];
      console.log(this.file);
    }
    },
    submitForm(event) {
        var barra = document.getElementById('progress')
      barra.value +=100
    
      event.preventDefault();
      let formData = new FormData();
      formData.append("file", this.file);

      let config = {
        headers: {
          "Content-Type": "multipart/form-data",

          
        },
      };

      this.$http
        .post(this.uploadURL,formData,config)
        .then(function (response) {
          if (response.status === 200) {
            console.log(response.data);
          }
        });
    },
  
  },
};
</script>
<style scoped>
.header {
  position: absolute;
  background-color: rgb(13, 70, 51);
  width: 2365px;
  height: 65px;
  top: -15px;
}

h1 {
  position: absolute;
  color: darkgreen;
  top: 80px;
  left: 800px;
}

.form-control {
  position: absolute;
  top: 250px;
  left: 320px;
  width: 1365px;
  height: 40px;
}

.form-select {
  position: absolute;
  top: 300px;
  left: 80px;
  width: 100px;
  height: 40px;
}

.input-group-text {
  position: absolute;
  top: 300px;
  left: 10px;
  height: 40px;
}

.btn {
  position: absolute;
  top: 350px;
  left: 650px;
}
.progress {
  position: absolute;
  top: 460px;
  left: 1300px;
}

.barraStyle{
  position: absolute;
   width:150px;
    color:rgb(202, 55, 10);
    height: 40px;
    top:470px;
    left:1310px
}
#charge{
  position:absolute;
 top:475px;
 left:1200px;
 color:rgb(5, 83, 5);
}

#container{
    position:absolute;
 top:435px;
 left:1310px;
 color:rgb(5, 83, 5);
}
</style>