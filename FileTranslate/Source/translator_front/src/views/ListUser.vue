<template>

 <div>
             <Header/>       
               <br>
                <h3> Hello {{admin}}, {{data.name}}</h3> 

                <table class="table table-hover">
                <thead>
                    <tr>
                        <th scope="col">ID</th>
                        <th scope="col">Name</th>
                        <th scope="col">Name File</th>
                        <th scope="col">Link</th>
                        <th scope="col">Created Date</th>
                        <th scope="col">End Date</th>
                        <th scope="col">Status</th>
                  
                    </tr>
                </thead>
                <tbody>
                    <tr v-for="user in empleados" :key="user.id"  >
                        <th scope="row">{{ user.id}}</th>
                        <td>{{ data.name }}</td>
                        <td>{{ user.nameFile }}</td>
                        <td><a>{{ user.link }}</a></td>
                        <td>{{ user.createdDate }}</td>
                          <td>{{ user.endDate }}</td>
                            <td>{{ user.status }}</td>
                           
                        
                    </tr>
            
                </tbody>
                </table>
         
       


    </div>
</template>
<script>
import axios from "axios";
import Header from '@/components/Header'
   export default {
     components:{
       Header
     },
    data(){
        return{
           admin: '',
            empleados:null
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
      },
    mounted:function(){
        let direccion = "https://localhost:44394/api/file/"+this.$store.state.data.data.id;
        axios.get( direccion).then(data =>{        
         this.empleados=data.data.updateFile;     
        })
    }
}

</script>

<style  scoped>
    .izquierda{
        text-align: left;
    }

    
</style>



          
