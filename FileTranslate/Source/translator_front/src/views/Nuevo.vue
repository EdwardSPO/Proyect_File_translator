<template>
    <div>
        <Header />
            <div class="container">
                

             <form action="" class="form-horizontal">
                  <div class="form-group left row">
                         <div class="col">
                            <label for="" class="control-label col-sm-2">Name</label>
                            <div class="col-sm-7">
                                <input type="text" class="form-control" name="name" id="name" v-model="form.name">
                            </div>
                          </div>
                         <div class="col">
                              <label for="" class="control-label col-sm-2">lastName</label>
                              <div class="col-sm-7">
                                  <input type="text" class="form-control" name="lastName" id="lastName" v-model="form.lastName">
                                 
                              </div>
                        </div>
                    </div>

                      <div class="form-group left row">
                         <div class="col">
                            <label for="" class="control-label col-sm-2">Email</label>
                            <div class="col-sm-7">
                                <input type="email" class="form-control" name="email" id="email" v-model="form.email">
                            </div>
                          </div>
                         <div class="col">
                              <label for="" class="control-label col-sm-2">Password</label>
                              <div class="col-sm-7">
                                  <input type="text" class="form-control" name="password" id="password" v-model="form.password">
                              </div>
                        </div>
                    </div>

                                  


                
               <br/><br/>
               


                    <div class="form-group left">
                      <button type="button" class="btn btn-primary" v-on:click="guardar()" >Guardar</button>
               
                      <button type="button" class="btn btn-dark margen" v-on:click="salir()"  >Salir</button>
                    </div> 
                </form>
          
                  

            </div>
        <!-- <Footer /> -->
               
    </div>
</template>
<script>
import Header from '@/components/Header.vue'
//import Footer from '@/components/Footer.vue'
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
        //Footer
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