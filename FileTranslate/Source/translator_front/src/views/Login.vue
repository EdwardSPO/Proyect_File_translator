<template>
 <v-card class="mx-auto"  max-width="444" >

  <v-form
    ref="form"
    v-model="valid"
    lazy-validation
  >
    <v-card-text>
       <v-text-field v-model="email" :rules="emailRules" label="E-mail" required></v-text-field>
    <v-text-field v-model="password"  :rules="paswwordRules" label="Password" required ></v-text-field>
   <v-btn  :disabled="!valid"  color="success"   class="mr-4"  @click="validate">Login</v-btn>

    
    </v-card-text>
  </v-form>
  </v-card>
</template>
<script>
import axios from "axios";
import swal from 'sweetalert';
  export default {

    data: () => ({
      password:'',
      paswwordRules: [
        v => !!v || 'Password is required'
      ],
      email:'',
      emailRules: [
        v => !!v || 'E-mail is required'
      ]
    }),

    methods: {
      validate () {
        this.$refs.form.validate()

          let json = {
          "email" : this.email,
          "password": this.password
        };
        axios.post('https://localhost:44394/api/user/login', json)
        .then( data =>{
           if(data.status == "201"){
            // console.log(data);
           
              //console.log(data);
    //    this.NumeroInsertadoPadre=this.Numero;
      //   this.NumeroAEnviar=this. NumeroInsertadoPadre
           this.$store.commit("getUser", data);
           this.$router.push('/Home');
           }else{
            // console.log(data);
                swal({title: "Warning",  text: "The email or password is not correct",
                   icon: "warning",
                   })              
             this.error = true;
           
           }
        })
      },
  
   

    },
  }
</script>