<template>
  <b-container>
    <b-form>
      <div>
        <b-form-input
          class="mt-3"
          v-model="form.cor"
          placeholder="Digite a Cor"
        ></b-form-input>
        <b-form-input
          class="mt-3"
          v-model="form.marca"
          placeholder="Digite a Marca"
        ></b-form-input>
        <b-form-input
          class="mt-3"
          v-model="form.modelo"
          placeholder="Digite a Modelo"
        ></b-form-input>
        <b-form-input
          class="mt-3"
          v-model="form.placa"
          placeholder="Digite a Placa"
        ></b-form-input>
      </div>
      <b-button class="mt-3 mb-5" size="lg" variant="primary" @click="save">
        Enviar
      </b-button>
    </b-form>
    <!-- Tabela -->
    <b-container fluid>
      <b-row>
        <b-col sm="6" md="6" class="my-1 pl-0">
          <b-form-group
            label="Por Página"
            label-for="pageSelect"
            label-cols-sm="7"
            label-cols-md="5"
            label-cols-lg="4"
            label-cols-xl="3"
            label-align-sm="left pr-0"
            label-size="sm"
            class="mb-0 text-white lbl-page"
          >
            <b-form-select
              class="selectPage"
              id="pageSelect"
              v-model="perPage"
              :options="pageOptions"
              size="sm"
            >
            </b-form-select>
          </b-form-group>
        </b-col>

        <b-col sm="6" md="6" class="my-1 pr-0 pl-0">
          <b-form-group
            label="Filtrar:"
            label-for="filter-input"
            label-cols-sm="6"
            label-cols-md="3"
            label-align-sm="right"
            label-size="sm"
            class="mb-3 text-white"
          >
            <b-input-group size="sm">
              <b-form-input
                id="filter-input"
                v-model="filter"
                type="search"
                placeholder="Pesquisar"
              ></b-form-input>

              <b-input-group-append>
                <b-button :disabled="!filter" @click="filter = ''"
                  ><em class="fa fa-refresh"></em
                ></b-button>
              </b-input-group-append>
            </b-input-group>
          </b-form-group>
        </b-col>
      </b-row>
    </b-container>
    <b-table
      head-variant="dark"
      hover
      sticky-header
      striped
      :current-page="currentPage"
      :fields="fields"
      :filter="filter"
      :items="cars"
      :per-page="perPage"
    >
      <template #cell(actions)="data">
        <b-button variant="light" @click="remove(data.item.id)">
          <em class="fa fa-trash"></em>
        </b-button>
      </template>
    </b-table>
    <b-col
      sm="7"
      md="6"
      class="my-1"
      style="margin-left: auto; margin-right: auto"
    >
      <b-pagination
        v-model="currentPage"
        :total-rows="totalRows"
        :per-page="perPage"
        align="fill"
        size="sm"
        class="my-0"
      ></b-pagination>
    </b-col>
    <!-- Tabela -->
    <b-overlay :show="buttonLoad" no-wrap></b-overlay>
  </b-container>
</template>

<script>
import axios from "@/config/axios";

export default {
  name: "Dashboard-view",
  data: () => {
    return {
      buttonLoad: false,
      form: {
        cor: null,
        marca: null,
        modelo: null,
        placa: null,
      },
      fields: [
        { key: "id", label: "Id", sortable: true },
        { key: "cor", label: "Cor", sortable: true },
        { key: "marca", label: "Marca", sortable: true },
        { key: "modelo", label: "Modelo", sortable: true },
        { key: "placa", label: "Placa", sortable: true },
        { key: "actions", label: "Ação" },
      ],
      filter: null,
      itemToRemove: null,
      pageOptions: [5, 10, 15, { value: 100, text: "Todas as páginas" }],
      perPage: 5,
      cars: [],
      totalRows: 1,
      currentPage: 1,
    };
  },
  computed: {},
  methods: {
    async loadCars() {
      try {
        this.buttonLoad = true;
        const response = await axios.get("/Car/Get/All");
        const { status, data } = await response;
        if (status === 200) {
          this.cars = data.cars;
          this.buttonLoad = false;
        }
        this.buttonLoad = false;
      } catch {
        this.buttonLoad = false;
        this.$toasted.global.defaultError();
        return;
      }
    },

    async save() {
      try {
        this.buttonLoad = true;
        const response = await axios.post("/Car/Post/Create", this.form);
        const { status } = await response;
        if (status === 200) {
          this.$toasted.global.defaultSuccess();
          await this.reset();
          this.buttonLoad = false;
        }
        this.buttonLoad = false;
      } catch {
        this.buttonLoad = false;
        this.$toasted.global.defaultError();
        return;
      }
    },

    async remove(id) {
      try {
        this.buttonLoad = true;
        const response = await axios.delete(`/Car/Delete/${id}`, this.form);
        const { status } = await response;
        if (status === 200) {
          this.$toasted.global.defaultSuccess();
          await this.reset();
          this.buttonLoad = false;
        }
        this.buttonLoad = false;
      } catch {
        this.buttonLoad = false;
        this.$toasted.global.defaultError();
        return;
      }
    },

    async reset() {
      this.form = {
        cor: null,
        marca: null,
        modelo: null,
        placa: null,
      };
      await this.loadCars();
    },
  },
  async mounted() {
    await this.loadCars();
  },
};
</script>

<style scoped>
.main {
  display: flex;
  justify-content: center;
  flex-wrap: wrap;
}
.selectPage {
  background: #fff
    url("data:image/svg+xml,%3csvg xmlns='http://www.w3.org/2000/svg' width='4' height='5' viewBox='0 0 4 5'%3e%3cpath fill='%23fffff' d='M2 0L0 2h4zm0 5L0 3h4z'/%3e%3c/svg%3e")
    right 0.75rem center/8px 10px no-repeat;
}
.search {
  display: flex;
  justify-content: flex-end;
}
.bgd {
  background: #1a202e;
  border-radius: 5px;
}
.bg-dark {
  --bs-bg-opacity: 1;
  background-color: #343a40 !important;
}
.circle {
  position: relative;
  top: 23px;
  cursor: pointer;
}
.circleBlue {
  background-image: linear-gradient(to right, #005486, #009add);
}
.customize {
  border-bottom: #707070 solid 2px !important;
  border-radius: 5px 5px 0 0;
}
.customize::-webkit-input-placeholder {
  /* WebKit browsers */
  color: #fff;
}
.customize:-ms-input-placeholder {
  /* Internet Explorer 10+ */
  color: #fff;
}
.main-input input {
  background-color: #343a40;
}
.plus-button button {
  text-align: center;
  width: 38px;
  height: 38px;
  position: relative;
  border: 0;
  outline: 0;
  border-radius: 30px;
  color: white;
  background-image: linear-gradient(to right, #009add, #005486);
}
.plus-button .fa {
  position: relative;
  display: table-cell;
  width: 60px;
  height: 36px;
  vertical-align: baseline;
  font-size: 20px;
  padding-top: 4px;
}
.plus-button.btn button:hover {
  background-image: linear-gradient(to right, #005486, #009add) !important;
}
.text-white {
  color: #fff !important;
}
.table {
  --bs-table-bg: white !important;
}
@media (min-width: 1440px) {
  #pageSelect {
    width: 154px;
  }
  .lbl-page {
    width: 320px;
  }
}
</style>
