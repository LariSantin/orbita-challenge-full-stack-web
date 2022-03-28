<template>
  <v-form
    ref="form"
    v-model="valid"
    lazy-validation
  >
    <v-text-field
      v-model="name"
      :counter="10"
      :rules="nameRules"
      label="Name"
      required
    ></v-text-field>

    <v-text-field
      v-model="email"
      :rules="emailRules"
      label="E-mail"
      required
    ></v-text-field>

    <v-text-field
      v-model="academicrecord"
      :rules="raRules"
      label="Registro Acadêmico"
      required
    ></v-text-field>

    <v-text-field
      v-model="cpf"
      :rules="cpfRules"
      label="CPF"
      required
      v-mask= "['###.###.###-##', '##.###.###/####-##']"
    />

    <v-btn
      :disabled="!valid"
      color="success"
      class="mr-4"
      @click="validate"
    >
      Salvar
    </v-btn>

    <v-btn
      color="error"
      class="mr-4"
      @click="reset"
    >
      Cancelar
    </v-btn>

  </v-form>
</template>

<script>
import {} from 'v-mask'

  export default {
    components: {
    },
    data: () => ({
      valid: true,
      name: '',
      nameRules: [
        v => !!v || 'Name is required',
        v => (v && v.length <= 10) || 'Name must be less than 10 characters',
      ],
      email: '',
      emailRules: [
        v => !!v || 'E-mail is required',
        v => /.+@.+\..+/.test(v) || 'E-mail must be valid',
      ],
      academicrecord: '',
      raRules: [
        v => !!v || 'RA is required',
      ],
      cpf: '',
      cpflRules: [
        v => !!v || 'CPF is required',
        v => /[0-9]{3}\.[\d*]{3}\.[\d*]{3}[-]?[0-9]{2}/.test(v) || 'CPF must be valid',
      ]    
    }),

    methods: {
      validate () {
        this.$refs.form.validate()
      },
      reset () {
        this.$refs.form.reset()
      },
    },
  }
</script>