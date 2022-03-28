<template>
           <div>
          <Header />
            <div class="container">
                <form action="" class="form-horizontal">
                    <div class="form-group left">
                       <label for="" class="control-label col-sm-2">Surnames</label>
                       <div class="col-sm-10">
                          <input type="text" class="form-control" name="Surnames" id="Surnames" v-model="form.Surnames">
                       </div>
                    </div>
                    <div class="form-group left">
                       <label for="" class="control-label col-sm-2">Names</label>
                       <div class="col-sm-10">
                          <input type="text" class="form-control" name="Names" id="nNames" v-model="form.Names">
                       </div>
                    </div>
                    <div class="form-group left row">
                      <div class="col">
                            <label for="" class="control-label col-sm-3">Full Name</label>
                            <div class="col-sm-7">
                                <input type="text" class="form-control" name="Full_name" id="Full_name" v-model="form.Full_name" disabled>
                            </div>
                        </div>
                        <div class="col">
                          <label for="" class="control-label col-sm-5">Birthdate</label>
                          <div class="col-sm-7">
                              <input type="text" class="form-control" name="Birthdate" id="Birthdate" v-model="form.Birthdate">
                          </div>
                        </div> 
                    </div>
                    <div class="form-group left row">
                         <div class="col">
                            <label for="" class="control-label col-sm-2">Position</label>
                            <div class="col-sm-7">
                                <input type="text" class="form-control" name="Position" id="Position" v-model="form.Position">
                            </div>
                          </div>
                         <div class="col">
                              <label for="" class="control-label col-sm-2">Area</label>
                              <div class="col-sm-7">
                                   <select class="form-select" name="Area" id="Area"  v-model="form.Area">
                            <option value="development">development</option>
                            <option value="design">design</option>
                     
                         </select>
                              </div>
                        </div>
                    </div>
                        <div class="form-group left row">
                         <div class="col">
                            <label for="" class="control-label col-sm-2">Email</label>
                            <div class="col-sm-7">
                                <input type="text" class="form-control" name="Email" id="Email" v-model="form.Email" disabled>
                            </div>
                          </div>
                         <div class="col">
                              <label for="" class="control-label col-sm-2">Active</label>
                              <div class="col-sm-7">
                                  <select class="form-select" name="Active" id="Active"  v-model="form.Active">
                            <option value="true">Yes</option>
                            <option value="false">No</option>
                     
                         </select>
                              </div>
                        </div>
                    </div><br/><br/>
               


                    <div class="form-group ">
                      <button type="button" class="btn btn-primary" v-on:click="editar()" >Editar</button>
                      <button type="button" class="btn btn-danger margen" v-on:click="eliminar()" >Eliminar</button>
                      <button type="button" class="btn btn-dark margen" v-on:click="salir()"  >Salir</button>
                    </div> 
                </form>
            </div>
          <!-- <Footer />   -->
        </div>
    
    
</template>
<script>
import Header from '@/components/Header.vue';
import axios from 'axios';

export default {
  name:"Editar",
  components:{
    Header
  
  },
  data:function(){
    return {
          form:{
              "id":"",
               "Surnames": "",
        "Names": "",
        "Full_name": "",
        "Birthdate": "",
        "Position": "",
        "Area": "",
        "Email": "",
        "Active": ""
          }
        }
    
  },
  methods:{
      editar(){
        axios.put("http://localhost:19280/api/Department",this.form)
        .then( data =>{
            console.log(data);
            this.$router.push("/");
        })
      },
      salir(){
          this.$router.push("/");
      },
          eliminar(){
       
        axios.delete("http://localhost:19280/api/Department/"+this.form.id )
        .then( datos => {
            console.log(datos);
           this.$router.push("/");
        });
       }
  },
 
  mounted:function(){
      this.form.id = this.$route.params.id;
    axios.get("http://localhost:19280/api/Department/"+this.form.id)
    .then(datos =>{
       this.form.Surnames = datos.data[0].Surnames;
        this.form.Names = datos.data[0].Names;
         this.form.Full_name = datos.data[0].Full_name;
          this.form.Birthdate = datos.data[0].Birthdate;
           this.form.Position = datos.data[0].Position;
            this.form.Area = datos.data[0].Area;
             this.form.Email = datos.data[0].Email;
              this.form.Active = datos.data[0].Active;
       console.log(this.form);
    })
      
     
  }  
}
</script>
<style scoped>
 .left{
   text-align: left;
 };
 .margen{
   margin-left: 15px;
   margin-right: 15px;;
 }
</style>