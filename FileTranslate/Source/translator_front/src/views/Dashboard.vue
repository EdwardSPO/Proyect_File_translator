<template>
    <div>
      <Header />
           
            <div>
               <button v-on:click="nuevo()">New User</button>
               <br>

                <table>
                <thead>
                    <tr>
                        <th >Id</th>
                        <th >Name</th>
                        <th >LastName</th>
                    <th >Email</th> 
                      <th>Password</th> 
                    
                    
                    </tr>
                </thead>
                <tbody>
               
                        <tr v-for="user in users" :key="user.id" >
                        <th >{{ user.id}}</th>
                        <td>{{ user.name }}</td>
                        <td>{{ user.lastName }}</td>
                        <td>{{ user.email }}</td>
                        <td>{{ user.password }}</td>
    
                      
                              
                    </tr>
            
                </tbody>
                </table>




            </div>

            

        <Footer />
    </div>
</template>
<script>
import Header from '@/components/Header.vue'
import Footer from '@/components/Footer.vue'
import axios from 'axios';
import global from '../../config.js'

export default {
  name: "Dashboard",
     components:{
        Header,
        Footer
    },
     data(){
        return{
            users:null
        
    
        }
        
    },
    mounted:function(){
        let direccion = global.API_USERS;
        axios.get( direccion).then(data =>{
         
           this.users=data.data;

      

      
        })
    }
}
</script>

<style  scoped>
  
</style>