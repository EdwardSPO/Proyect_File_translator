<template>
  <div>
<<<<<<< HEAD
    <h1>{{titulo}}</h1>
    <div class="header"></div>
=======

            <Header />
    <h1>{{titulo}}</h1>
   
>>>>>>> 91fd57fb9c458de7430dbfee62a124d9714181c0

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
          <option value="1" v-on:change="getAzerbaiyan()">Azerbaiyán a Ingles</option>
          <option value="2" v-on:change="getChino()">Chino a Ingles</option>
      
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
<<<<<<< HEAD
          @click="saveEmployee($event)"
=======
          @click="submitForm($event)"
>>>>>>> 91fd57fb9c458de7430dbfee62a124d9714181c0
        >
          Traducir
        </button>
      </div>
    </div>
<<<<<<< HEAD
  </div>
</template>
<script>
const url = "https://localhost:5024/api/File/Upload?";
const urlTr = "https://localhost:5024/api/File/Translate";

=======
        
  </div>
  
</template>
<script>
const url = "https://localhost:5024/api/File/Upload?";
const urlTr = "https://localhost:5024/api/File/Translate?";
import Header from '@/components/Header.vue'
>>>>>>> 91fd57fb9c458de7430dbfee62a124d9714181c0


export default {
  data() {
    return {
      titulo: "Traductor",
<<<<<<< HEAD
      uploadURL: url + "subDirectory=file",
      urlAzerbaiyan: urlTr + "?source=ar&target=en",
      urlChino: urlTr + "source=ch" + "target=en",
      file: "",
      isCreate: false,
    };
  },
=======
      uploadURL: url + "subDirectory=File",
      urlAzerbaiyan: urlTr + "source=az",
      urlChino: urlTr + "target=en",
      file: ""
    };
  },
     components:{
        Header
      
    },
>>>>>>> 91fd57fb9c458de7430dbfee62a124d9714181c0
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
<<<<<<< HEAD
   
   
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
=======
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
>>>>>>> 91fd57fb9c458de7430dbfee62a124d9714181c0
       getAzerbaiyan(event) {
        var barra = document.getElementById('progress')
      barra.value +=100
    
      event.preventDefault();
      let formData = new FormData();
<<<<<<< HEAD
      formData.append("file", this.file);
=======
      formData.append("file", this.source);
>>>>>>> 91fd57fb9c458de7430dbfee62a124d9714181c0
      let config = {
        headers: {
          "Content-Type": "multipart/form-data",
          
        },
      };
      this.$http
        .post(this.urlAzerbaiyan,formData,config)
        .then(function (response) {
          if (response.status === 200) {
            console.log(response.data);
          }
        });
<<<<<<< HEAD
        

    }, 
       saveEmployee(event) {
    
        this.submitForm(event),
        this.getAzerbaiyan(event)

      } 
 
     

   
=======
    },

       getChino(event) {
        var barra = document.getElementById('progress')
      barra.value +=100
    
      event.preventDefault();
      let formData = new FormData();
      formData.append("file", this.target);
      let config = {
        headers: {
          "Content-Type": "multipart/form-data",
          
        },
      };
      this.$http
        .post(this.urlChino,formData,config)
        .then(function (response) {
          if (response.status === 200) {
            console.log(response.data);
          }
        });
    },
>>>>>>> 91fd57fb9c458de7430dbfee62a124d9714181c0

    
  
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
 background-color:rgb(5, 83, 5);
}
</style>