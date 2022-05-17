<template>
 <div>
<Header/>
<br/>
 <h3> Hello {{admin}}, {{data.name}}</h3> 
  <br/>
        <v-spacer></v-spacer>
       <v-btn color="primary"  @click="NewUser()">
      New User
      </v-btn>
  <v-layout :wrap="true">   
    <v-flex xs12>
      <v-data-table
    :headers="headers"
    :items="desserts"
    :items-per-page="5"
    class="elevation-1"
  ></v-data-table>
    </v-flex>
  </v-layout>
 </div>
</template>

<script>
import axios from "axios";
import Header from '@/components/Header'
   export default {
     components:{
       Header
     },
    
    data () {
      return {
        admin: '',
        desserts: [],
        headers: [
             { text: 'Id', value: 'id' },
          {text: 'Name', value: 'name' },
          { text: 'LastNames', value: 'lastName' },
          { text: 'Email', value: 'email' },
          { text: 'Password', value: 'password' }
          
        
       
        ],
       
      }
    },
    methods:{
     async getUser(){
       let datos = await axios.get('https://localhost:44394/api/user')
       console.log(datos);
       this.desserts=datos.data;
     },
   
    },
    created(){
      this.getUser()
    },
    methods:{
         NewUser(){
       this.$router.push('/Nuevo');
    },
     async getUser(){
       let datos = await axios.get('https://localhost:44394/api/user')   
       this.desserts=datos.data;
     }
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
      }
  }
</script>
