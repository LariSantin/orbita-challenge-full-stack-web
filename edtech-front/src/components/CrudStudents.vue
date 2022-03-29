<template>
  <v-data-table
    :headers="headers"
    :items="students"
    sort-by="calories"
    class="elevation-1"
  >
    <template v-slot:top>
      <v-toolbar
        flat
      >
        <v-toolbar-title>Alunos</v-toolbar-title>
        <v-divider
          class="mx-4"
          inset
          vertical
        ></v-divider>
        <v-spacer></v-spacer>
        <v-dialog
          v-model="dialog"
          max-width="500px"
        >
          <template v-slot:activator="{ on, attrs }">
            <v-btn
              color="#00008b"
              dark
              class="mb-2"
              v-bind="attrs"
              v-on="on"
            >
              Cadastrar Aluno
            </v-btn>
          </template>
          <v-card>
            <v-card-title>
              <span class="text-h5">{{ formTitle }}</span>
            </v-card-title>

    
            <v-card-text>
              <v-container>
                <v-row>
                  <v-col
                    cols="12"
                    sm="10"
                    md="8"
                  >
                    <v-text-field
                      v-model="editedStudent.name"
                      label="Nome"
                      :rules="nameRules"
                      :counter="40"
                      required
                    ></v-text-field>
                  </v-col>

                  <v-col
                    cols="12"
                    sm="10"
                    md="8"
                  >
                    <v-text-field
                      v-model="editedStudent.email"
                      label="E-mail"
                      :rules="emailRules"
                      required
                    ></v-text-field>
                  </v-col>
                  <v-col
                    cols="12"
                    sm="10"
                    md="8"
                  >
                    <v-text-field
                      v-model="editedStudent.academicRecord"
                      label="Registro Acadêmico"
                      type="number"
                      :disabled="editedStudent.academicRecord != '' && editedStudent.id != ''"
                      :rules="FieldRules"
                      required
                    ></v-text-field>
                  </v-col>
                  <v-col
                    cols="12"
                    sm="10"
                    md="8"
                  >
                    <v-text-field
                      v-mask="'###.###.###-##'"                
                      v-model="editedStudent.cpf"
                      label="CPF"
                      :disabled="editedStudent.cpf != '' && editedStudent.id != ''"
                       :rules="FieldRules"
                      required
                    ></v-text-field>
                  </v-col>
                  <v-col
                    cols="12"
                    sm="8"
                    md="6"
                  >
            
                  </v-col>
                </v-row>
              </v-container>
            </v-card-text>

            <v-card-actions>
              <v-spacer></v-spacer>
              <v-btn
                color="blue darken-1"
                text
                @click="close"
              >
                Cancelar
              </v-btn>
              <v-btn
                color="blue darken-1"
                text
                @click="save"
              >
                Salvar
              </v-btn>
            </v-card-actions>
          </v-card>
        </v-dialog>
        <v-dialog v-model="dialogDelete" max-width="500px">
          <v-card>
            <v-card-title class="text-h5">Deletar aluno?</v-card-title>
            <v-card-actions>
              <v-spacer></v-spacer>
              <v-btn color="blue darken-1" text @click="closeDelete">Cancelar</v-btn>
              <v-btn color="blue darken-1" text @click="deleteItemConfirm">OK</v-btn>
              <v-spacer></v-spacer>
            </v-card-actions>
          </v-card>
        </v-dialog>
      </v-toolbar>
    </template>
    <template  v-slot:[`item.actions`]="{ item }">
      <v-icon
        small
        class="mr-2"
        @click="editItem(item)"
      >
        mdi-pencil
      </v-icon>
      <v-icon
        small
        @click="deleteItem(item)"
      >
        mdi-delete
      </v-icon>
    </template>
  </v-data-table>
</template>

<script>
import Student from '../services/students';

  export default {
    mounted(){
      this.list()
    },
    data: () => ({
      dialog: false,
      dialogDelete: false,
      headers: [
        {
          text: 'Registro Acadêmico',
          align: 'start',
          sortable: false,
          value: 'academicRecord',
        },
        { text: 'Nome', value: 'name' },
        { text: 'CPF', value: 'cpf' },
        { text: 'Actions', value: 'actions', sortable: false },
      ],
      students: [],
      errors: [],
      editedIndex: -1,
      editedStudent: {
         id: '',
        name: '',
        email: '',
        academicRecord: '',
        cpf: '',
      },
      defaultItem: {
        id: '',
        name: '',
        email: '',
        academicRecord: '',
        cpf: '',
      },
      nameRules: [
        v => !!v || 'Campo obrigatório',
        v => v.length <= 40 || 'O Nome deve ter menos que 40 caracteres'
      ],
      emailRules: [ 
        v => !!v || 'Campo obrigatório',
        v => !v || /^\w+([.-]?\w+)*@\w+([.-]?\w+)*(\.\w{2,3})+$/.test(v) || 'E-mail deve ser valido'
      ],
      FieldRules: [
        v => !!v || 'Campo obrigatório',
      ]

    }),

    computed: {
      formTitle () {
        return this.editedIndex === -1 ? 'Novo aluno' : 'Editar aluno'
      },
    },

    watch: {
      dialog (val) {
        val || this.close()
      },
      dialogDelete (val) {
        val || this.closeDelete()
      },
    },

    methods: {
      editItem (item) {
        this.editedIndex = this.students.indexOf(item)
        this.editedStudent = Object.assign({}, item)
        this.dialog = true
      },

      deleteItem (item) {
        this.editedIndex = this.students.indexOf(item)
        this.editedStudent = Object.assign({}, item)
        this.dialogDelete = true
      },

      deleteItemConfirm () {
        Student.delete(this.editedStudent.id).then(resposta => {
          this.closeDelete();
          this.list();
          console.log(resposta);
          //this.errors = [];
        })
        //.catch(e => {
            //this.errors = e.response.data.errors;
       // })
        
      },

      close () {
        this.dialog = false
        this.$nextTick(() => {
          this.editedStudent = Object.assign({}, this.defaultItem)
          this.editedIndex = -1
        })
      },

      closeDelete () {
        this.dialogDelete = false
        this.$nextTick(() => {
          this.editedStudent = Object.assign({}, this.defaultItem)
          this.editedIndex = -1
        })
      },

      save () {
        if (this.editedIndex > -1) {
             Student.update(this.editedStudent).then(r => {
            this.errors = [];
            alert('Atualizado com sucesso');
            this.list()
            console.log(r);

          }).catch(e => {
             alert("Não foi possível atualizar os dados.Confira!")
            console.log(e);
            this.errors = e;
          });
        } else {

          Student.add(this.editedStudent).then(r => {
            this.errors = [];
            alert("Salvo com sucesso");
            this.list()
            console.log(r);

          }).catch(e => {
            alert("Não foi possível salvar os dados.Confira!")
            console.log(e);
            this.errors = e;
          })
        }
        this.close()
      },

      list(){
        Student.get().then(resposta => {
          this.students = resposta.data;
        })
      },
    },
  }
</script>