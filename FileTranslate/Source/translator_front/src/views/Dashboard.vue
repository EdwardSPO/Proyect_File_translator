<template>
    <div>
      <Header />
           
            <div class="container izquierda">
               <button class="btn btn-primary" v-on:click="nuevo()">New User</button>
               <br>

                <table class="table table-hover">
                <thead>
                    <tr>
                        <th scope="col">Id</th>
                        <th scope="col">Name</th>
                        <th scope="col">LastName</th>
                    <th scope="col">Email</th> 
                      <th scope="col">Password</th> 
                    
                    
                    </tr>
                </thead>
                <tbody>
                    <tr>
                        <th scope="row"></th>
                        <td></td>
                        <td></td>
                      
                              
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

export default {
       components:{
        Header,
        Footer
    }
}
</script>

<style  scoped>
  
</style>