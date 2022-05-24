<template>
    <div>
        <Header />
          
 <div class="container">
        <div class="row">
            <div class="col">               
                <div class="shadow-lg p-3 mb-5 mt-4 bg-body rounded">                                    
                    <div class="p-3 mb-2 bg-primary bg-gradient fw-bold text-white">Create Users</div>
                    <form class="row g-3 needs-validation" novalidate id="form" name="form" v-on:submit.prevent="procesar();" >
                         <div class="col-md-4 position-relative">
                            <label for="nombre" class="form-label">Name</label>
                          <input type="text" class="form-control" name="name" id="name" v-model="form.name" required>
                         <div class="alert alert-danger" role="alert" v-if="submited && !$v.form.name.required" >The field is required </div>
                            <div class="alert alert-danger" role="alert" v-if="submited && !$v.form.name.minLength" >The name must have at least 2 characters </div>
                        </div>
        
                        <div class="col-md-4 position-relative">
                            <label for="nombre" class="form-label">lastName</label>
                          <input type="text" class="form-control" name="lastName" id="lastName" v-model="form.lastName" required>
                           <div class="alert alert-danger" role="alert" v-if="submited && !$v.form.lastName.required" >The field is required</div>
                            <div class="alert alert-danger" role="alert" v-if="submited && !$v.form.lastName.minLength" >The lastName must have at least 2 characters </div>                        
                        </div>
                        <div class="col-md-4 position-relative">
                            <label for="apellido" class="form-label">Email</label>
                               <input type="email" class="form-control" name="email" id="email" v-model="form.email" required>
                                <div class="alert alert-danger" role="alert" v-if="submited && !$v.form.email.required" >The field is required </div>   
                             <div class="alert alert-danger" role="alert" v-if="submited && !$v.form.email.email" >must be an email (example@example.com)</div>                       
                        </div>                                             
                        <div class="col-md-4 position-relative">
                            <label for="pais" class="form-label">Password</label>
                                  <input type="password" class="form-control" name="password" id="password" v-model="form.password" required >

                                  <div class="alert alert-danger" role="alert" v-if="submited && !$v.form.password.required" >The field is required </div>
                            <div class="alert alert-danger" role="alert" v-if="submited && !$v.form.password.minLength" >The lastName must have at least 8 characters  </div>                                                             
                        </div>     
                            <div class="col-md-4 position-relative">
                            <label for="nombre" class="form-label">Rol</label>              
                   
                             <select class="form-select" name="idRol" id="idRol" v-model="form.idRol" required>
                           <option Value="1">Administrator</option>  
                               <option Value="2">User</option>                  
                          
                       
                          </select>                       
                        </div>              
                        <div class="col-12">
                     
                          <button type="submit" class="btn btn-primary fw-bold float-end" v-on:click="guardar()" >Save</button>              
                         <button type="button" class="btn btn-dark margen fw-bold float-end" v-on:click="salir()"  >leave</button>
                      </div>
                    </form>
                </div>
            </div>
        </div>
    </div>        
    </div>

    
</template>
<script src="https://unpkg.com/sweetalert/dist/sweetalert.min.js"></script>
<script>
import Header from '@/components/Header.vue'
import axios from 'axios';
import swal from 'sweetalert';
import {required, minLength , email} from 'vuelidate/lib/validators';

export default {
    name:"Nuevo",
   
    data:function(){
        return {
            submited: false,
           form:{
              "name": "",
              "lastName": "",
              "email":"",
              "password":"",
              "idRol":"",
               errors: []
           
          },
        }
    },
    components:{
        Header
    },
    methods:{     
        guardar(){       
            console.log(this.form)  
            axios.post("https://localhost:44394/api/user",this.form)
            .then(data =>{
                this.makeToast("Hecho","Usuario creado","success"+data);
                this.$router.push("/Home");
        
            }).catch( e =>{
           
             if(e.message=="Request failed with status code 400"){
                    swal({title: "Warning",  text: "Email already exists",
                   icon: "warning",
                   })
                }else{
                console.log(e); 
                }
                if(this.form.email==""){
                    swal({title: "Warning",  text: "you must fill in the empty field",
                   icon: "warning",
                   }) 
                }
                   checkForm();
            });
        },
       procesar(){
            this.submited = true;
            this.$v.$touch();
            if(this.$v.$invalid){
                return false;
            }
    
        },       
       salir(){
            this.$router.push("/Home");
        },
        makeToast(titulo,texto,tipo) {
            this.toastCount++
            this.$bvToast.toast(texto, {
            title: titulo,
            variant: tipo,
            autoHideDelay: 5000,
            appendToast: true
            })
        },        
    },
     validations:{
            form:{
                name:{
                    required,
                    minLength: minLength(2)
                },
                lastName:{
                    required,
                    minLength: minLength(2)
                },
                 email:{
                    required,
                    minLength: minLength(2),
                    email
                },
                 password:{
                    required,
                    minLength: minLength(8)                   
                },
                 idRol:{
                    required   
                }
            }
        }
}
</script>
<style scoped>
.left{
    text-align:  left;
}
</style>