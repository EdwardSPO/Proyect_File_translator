
      <template>
  <div>
    <v-toolbar
      dark
      src="https://cdn.vuetifyjs.com/images/backgrounds/vbanner.jpg">
      <v-toolbar-title>Translate</v-toolbar-title>
     
          <template v-slot:extension>
        <v-tabs align-with-title>
          <v-tab @click="ListBTN()">List Users</v-tab>
          <v-tab @click="TransBTN()">Translator</v-tab>
          <v-tab>Tab 3</v-tab>
        </v-tabs>
      </template>
      <v-spacer></v-spacer>
       <v-btn color="primary"  @click="Salir()">
      Salir
      </v-btn>
    
    </v-toolbar>
  </div>
</template>
<script>

export default {
  name: 'Header',

  methods:{
  
    ListBTN(){
      
       this.$router.push('/Home');
    },
      TransBTN(){
          this.$router.push('/Translator');
      },
      Salir(){
         this.$router.push('/');
      }
  }
}
</script>