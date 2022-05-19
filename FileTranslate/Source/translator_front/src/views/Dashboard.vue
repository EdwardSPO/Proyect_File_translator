<template>
    <div>
      <Header />
           <div class="container izquierda">
               <button class="btn btn-primary  fw-bold float-end"  v-on:click="nuevo()">New User</button>
                          
                 <table class="table table-hover">
                <thead>
                    <tr>
                        <th scope="col" >Id</th>
                        <th scope="col" >Name</th>
                        <th scope="col">LastName</th>
                    <th scope="col">Email</th> 
                      <th scope="col">Password</th>                                
                    </tr>
                </thead>
                <tbody>               
                        <tr v-for="user in users" :key="user.id" >
                        <th scope="row" >{{ user.id}}</th>
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
       methods:{
     nuevo(){
           this.$router.push('/nuevo');
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