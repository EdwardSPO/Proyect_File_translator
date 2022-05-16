<template>
  <v-app>
    
      <v-container>
          <router-view/>
      </v-container>
    <v-content>
    </v-content>
  </v-app>
</template>

<script>

export default {
  name: 'App',

  data: () => ({
    //
  }),
};
</script>
