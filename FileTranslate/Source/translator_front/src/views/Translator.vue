<template>
  <div>
    <!-- CSS only -->
<link href="https://cdn.jsdelivr.net/npm/bootstrap@5.2.0-beta1/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-0evHe/X+R7YkIZDRvuzKMRqM+OrBnVFBL6DOitfPri4tjfHxaWutUpFmBp4vmVor" crossorigin="anonymous">
    <Header /> 
    <br><h3> Hello {{admin}}, {{data.name}}</h3><br>
              
    <div id="contenedor">
    <h1>{{titulo}}</h1>
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
          <label class="input-group-text" for="inputGroupSelect01" id="from">
            Translate from</label
          >
          <select v-model="Seleccionado" class="form-select" id="Translatefrom">
            <option v-for="data in datos" :value="data" :key="data">
              {{ data.name }}
            </option>
          </select>
        </div>
        <div class="flex-wrap input-group mb-3">
          <label class="input-group-text" for="inputGroupSelect01" id="into"
            >Translate into</label
          >
          <select class="form-select" id="TranslateInto">
            <option selected></option>
            <option v-for="data in datos" :value="data" :key="data">
              {{ data.name }}
            </option>
          </select>
        </div>
        <br />
        <div
          class="flex-wrap btn-group"
          role="group"
          aria-label="Basic mixed styles example"
        >
        <!-- <div v-if="loading">
          <p id="cargado">Cargando...</p>
        </div> -->
          <button
            id="traduccion"
            type="button"
            value="cargar"
            class="btn btn-primary"
            @click="saveTranslate($event)"
          >
            Traducir
          </button>
        </div>
      </div>
    </div>
  </div>
</template>
<script>

import Header from "@/components/Header.vue";
import global from "../../config.js";
import axios from "axios";
const crear ="https://localhost:5024/api/FileList/listTranslate";



export default {
  data() {
    return {
      titulo: "Translate file",
      uploadURL: global.URL_FILE,
      urlTranslate: global.URL_TRANSLATE,
      file: "",
      isCreate: false,
      PropertyName: "PropertyName",
      Seleccionado: {},
      datos: [],
      groups: [],
      loading: false,
      admin: '',
         updateFile: [],
      updateFiles:{}
    };
  },
   computed:{
        data(){
          if (this.$store.state.data.data.idRol==1){
            this.admin = "Administrator"
          }else{
            this.admin = "User"
          }
          return this.$store.state.data.data;
        }
      },
    components: {
      Header,
    },
  mounted: function () {
    let direccion = global.API_LANGUAGES;
    axios.get(direccion).then((data) => {
      this.datos = data.data;
      this.groups = this.getTranslate();
       
    });
  },
  methods: {
     clearFile() {
        this.updateFiles.Id = 0;
      this.updateFiles.Link = "";
       this.updateFiles.NameFile = "";
        this.updateFiles.Status = "";
      },
    getFile(event) {
      var formFile = document.getElementById("formFile");
      var archivoRuta = formFile.value;
      var extPermitidas = /(.docx|.txt)$/i;
      if (!extPermitidas.exec(archivoRuta)) {
        alert("Asegurese de haber seleccionado un archivo tipo docx o txt");
        formFile.value = "";
        return false;
      }
      var ValidationFile = document.getElementById("formFile").files[0].size;
      if (ValidationFile > 500000000) {
        alert("El archivo no debe pesar mas de 500MB");
      } else {
        this.file = event.target.files[0];
        console.log(this.file);
         console.log(this.items)
      
      }
    },
    submitForm(event) {
      event.preventDefault();
      let formData = new FormData();
      formData.append("file", this.file);
      let config = {
        headers: {
          "Content-Type": "multipart/form-data",
        },
      };
      this.$http
        .post(this.uploadURL, formData, config)
        .then(function (response) {
          if (response.status === 200) {
            console.log(response.data);
          }
        });
    },
    getTranslate(event) {
      event.preventDefault();
      let formData = new FormData();
      formData.append("file", this.file);
      let config = {
        headers: {
          "Content-Type": "multipart/form-data",
        },
      };
      this.$http
        .post(this.urlTranslate, formData, config)
        .then(function (response) {
          if (response.status === 200) {
            console.log(response.data);
            window.location=response.data.translatedFileUrl; 
          }
        })
         axios.post(crear,this.updateFiles,
      this.updateFiles.NameFile= document.getElementById('formFile').files[0].name,
      this.updateFiles.Link="")
    },
    saveTranslate(event) {
         this.submitForm(event), this.getTranslate(event)
          if(this.getTranslate!= null){
           this.loading=true;
         }else{
           this.loading=false;
         }
       },
  },
};
</script>
<style scoped>
* {
  margin: 0px;
  padding: 0px;
}
h1 {
  position: absolute;
  color: #2f6bd9;
  top: 150px;
  left: 820px;
}
.form-control {
  position: absolute;
  top: 232px;
  left: 320px;
  width: 450px;
  height: 40px;
}
.form-select {
  position: absolute;
  top: 190px;
  left: 165px;
  width: 690px;
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
  top: 49px;
  left: 1181px;
}
.barraStyle {
  position: absolute;
  width: 150px;
  color: rgb(202, 55, 10);
  height: 40px;
  top: 456px;
  left: 950px;
}
#charge {
  position: absolute;
  top: 465px;
  left: 850px;
  color: rgb(5, 83, 5);
}
  /* #contenedor {
  top: 200px;
  position: absolute;
  left: 500px;
  width: 980px;
  height: 600px;
  border: 2px solid;
  border-color: #2f6bd9;
  border-radius: 15px;
  background-color: rgb(244, 241, 241);
}   */
#Translatefrom {
  position: absolute;
  top: 97px;
  left: 596px;
  width: 200px;
  height: 40px;
}
#TranslateInto {
  position: absolute;
  top: 85px;
  left: 936px;
  width: 200px;
  height: 40px;
}
#from {
  position: absolute;
  top: 97px;
  left:465px;
  width: 130px;
}
#into {
  position: absolute;
  top: 85px;
  left:805px;
  width: 130px;
}
/* #cargado{
  position: absolute;
  top: 395px;
  left: 200px;
} */
</style>