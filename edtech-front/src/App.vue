<template>
  <v-app>
  <v-row class="row-class">
      <v-app-bar
        color="#6959CD"
        dark
        width="20%"
      >
      <v-div class="text-center">
         <v-h2>
            Módulo Acadêmico
        </v-h2>
      </v-div>   

      </v-app-bar>

      <v-app-bar
          color="#00008B"
          dark
          width="80%"
        >
        
        </v-app-bar>

    </v-row>
  
    <v-main>   
      <v-column>  
        <CrudStudents/>
      </v-column>
    </v-main>
  </v-app>

</template>

<script>
import CrudStudents from './components/CrudStudents';

export default {
  name: 'App',

  components: {
    CrudStudents
  },

  data: () => ({
    //
  }),
};
</script>

<style scoped>
.text-center{
  justify-content: center;
  margin: auto;
  margin-top: 10px;
  font-size: 18px;
}
.row-class{
  flex: 0.16;
}
</style>
