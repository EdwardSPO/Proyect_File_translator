<template>
    <div>
        <Header />
          
 <div class="container">
        <div class="row">
            <div class="col">               
                <div class="shadow-lg p-3 mb-5 mt-4 bg-body rounded">                                    
                    <div class="p-3 mb-2 bg-primary bg-gradient fw-bold text-white">Create Users</div>
                    <form class="row g-3 needs-validation" novalidate>
                         <div class="col-md-4 position-relative">
                            <label for="nombre" class="form-label">Name</label>
                          <input type="text" class="form-control" name="name" id="name" v-model="form.name">
                            <!-- Mensajes para validación   -->
                            <div class="valid-tooltip">¡Campo válido!</div>
                            <div class="invalid-tooltip">Debe completar los datos.</div>
                        </div>
                        <div class="col-md-4 position-relative">
                            <label for="nombre" class="form-label">lastName</label>
                          <input type="text" class="form-control" name="lastName" id="lastName" v-model="form.lastName">
                            <!-- Mensajes para validación   -->
                            <div class="valid-tooltip">¡Campo válido!</div>
                            <div class="invalid-tooltip">Debe completar los datos.</div>
                        </div>
                        <div class="col-md-4 position-relative">
                            <label for="apellido" class="form-label">Email</label>
                               <input type="email" class="form-control" name="email" id="email" v-model="form.email">
                            <!-- Mensajes para validación   -->
                            <div class="valid-tooltip">¡Campo válido!</div>
                            <div class="invalid-tooltip">Debe completar los datos.</div>
                        </div>                                             
                        <div class="col-md-4 position-relative">
                            <label for="pais" class="form-label">Password</label>
                                  <input type="text" class="form-control" name="password" id="password" v-model="form.password">
                           
                            <!-- Mensajes para validación   -->
                            <div class="valid-tooltip">¡Campo válido!</div>
                            <div class="invalid-tooltip">Debe completar los datos.</div>
                        </div>                   
                        <div class="col-12">
                     
                          <button type="button" class="btn btn-primary fw-bold float-end" v-on:click="guardar()" >Guardar</button>
               
                      <button type="button" class="btn btn-dark margen fw-bold float-end" v-on:click="salir()"  >Salir</button>
                        </div>
                    </form>
                </div>
            </div>
        </div>
    </div>
        
        <Footer/>       
    </div>
</template>
<script>
import Header from '@/components/Header.vue'
import Footer from '@/components/Footer.vue'
import axios from 'axios';
export default {
    name:"Nuevo",
   
    data:function(){
        return {
           form:{
    
               "name": "",
               "lastName": "",
             "email":"",
             "password":""
          },
        }
    },
    components:{
        Header,
        Footer
    },
    methods:{
        guardar(){
            axios.post("http://localhost:36777/api/user",this.form)
            .then(data =>{
                console.log(data);
                console.log(this.form);
                this.makeToast("Hecho","Usuario creado","success");
                this.$router.push("/");
            }).catch( e =>{
                console.log(e);
                 this.makeToast("Error","Error al guardar","error");
            })
        },
        salir(){
            this.$router.push("/");
        },
        makeToast(titulo,texto,tipo) {
            this.toastCount++
            this.$bvToast.toast(texto, {
            title: titulo,
            variant: tipo,
            autoHideDelay: 5000,
            appendToast: true
            })
        }
        
    }
}
</script>
<style scoped>
.left{
    text-align:  left;
}
</style>