<template>
  <div>

            <Header />
    <h1>{{titulo}}</h1>
   

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
        <select v-model="Seleccionado" class="form-select form-select-lg mb-3" id="data">
           <option selected>Translate from</option>
            <option v-for="data in datos" :value="data" :key="data">{{data.name}}</option>
        </select>
      </div>
      
       <div class="flex-wrap input-group mb-3">
        <select class="form-select form-select-lg mb-3" id="data">
           <option selected>Translate into</option>
            <option v-for="data in datos" :value="data" :key="data">{{data.name}}</option>
        </select>
      </div>

      <br />
    <div class=" flex-wrap progress"></div>
 <h5 id="charge">Progress:</h5> 
  <progress id="progress" value="0" max="100" class="barraStyle" style="background-color=red" ></progress> 


      <div
        class="flex-wrap btn-group"
        role="group"
        aria-label="Basic mixed styles example">
        <button
          id="traduccion"
          type="button"
          value="cargar"
          class="flex-wrap btn btn-success"
          @click="submitForm($event)"
        >
          Traducir
        </button>
      </div>
    </div>
        
  </div>
  
</template>
<script>

import Header from '@/components/Header.vue';
import global from '../../config.js';
import axios from 'axios';

export default {
  data() {
    return {
      titulo: "Traductor",
      TranslateURL: global.urlTranslate,
      uploadURL: global.url,
      PropertyName: "PropertyName",
      isSentCode: true,
      file: "",
      Seleccionado: {},//<-- el seleccionado estará aquí
      datos: [], 

    };
  },
     components:{
        Header
      
    },

    mounted:function(){
        let direccion = global.API_LANGUAGES;
        axios.get( direccion).then(data =>{
          this.datos = data.data;
               
        })
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

      getTranslate(event) {
      var barra = document.getElementById("progress");
      barra.value += 100;

      event.preventDefault();
      let formData = new FormData();
      formData.append("file", this.file);
      let config = {
        headers: {
          "Content-Type": "multipart/form-data",
        },
      };

      this.$http
        .post(this.TranslateURL, formData, config)
        .then(function (response) {
          if (response.status === 200) {
      window.location=response.data.translatedFileUrl;
          
          }
        });
    },

    saveTranslate(event) {
      this.submitForm(event);
      this.getTranslate(event);
    },

      descargar() {
    //window.location = response.data.translatedFileUrl;
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
  left: 75px;
  width: -65px;
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
 background-color:rgb(5, 83, 5);
}
</style>