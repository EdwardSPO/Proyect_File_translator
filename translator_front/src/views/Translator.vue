<template>
  <div>
    <h1>Traductor</h1>
    <div class="header"></div>

    <div class="container">
      <div class="mb-3">
        <input
          class="form-control"
          type="file"
          id="formFile"
          v-on:change="getFile($event)"
        />
      </div>

      <div class="input-group mb-3">
        <label class="input-group-text" for="inputGroupSelect01">Idioma</label>
        <select class="form-select" id="inputGroupSelect01">
          <option selected>Seleccione el idioma</option>
          <option value="1"></option>
          <option value="2"></option>
          <option value="3"></option>
        </select>
      </div>
      -->
      <br />
      <div class="progress">
        <p>
          Progress:
          <!-- <progress :value="uploadValue" max='100'></progress> -->
        </p>
      </div>

      <div
        class="btn-group"
        role="group"
        aria-label="Basic mixed styles example"
      >
        <button
          id="traduccion"
          type="button"
          class="btn btn-success"
          @click="submitForm($event)"
        >
          Traducir
        </button>
      </div>
    </div>
  </div>
</template>
<script>
export default {
  data() {
    return {
      uploadURL: " http://localhost:5000/",
      file: "",
    };
  },
  methods: {
    getFile(event) {
      this.file = event.target.files[0];
      console.log(this.file);
    },
    submitForm(event) {
      event.preventDefault();
      let formData = new FormData();
      formData.append("file", this.file);

      let config = {
        headers: {
          "Content-Type": "multipart/form-data",
        },
      };

      this.$http
        .post(this.uploadURL, formData, config)
        .then(function (response) {
          if (response.status === 200) {
            console.log(response.data);
          }
        });
    },
  },
};
</script>
<style scoped>
.header {
  position: absolute;
  background-color: rgb(13, 70, 51);
  width: 2365px;
  height: 65px;
  top: -15px;
}

h1 {
  position: absolute;
  color: darkgreen;
  top: 80px;
  left: 800px;
}

.form-control {
  position: absolute;
  top: 250px;
  left: 320px;
  width: 1365px;
  height: 40px;
}

.form-select {
  position: absolute;
  top: 300px;
  left: 80px;
  width: 100px;
  height: 40px;
}

.input-group-text {
  position: absolute;
  top: 300px;
  left: 10px;
  height: 40px;
}

.btn {
  position: absolute;
  top: 350px;
  left: 650px;
}
.progress {
  position: absolute;
  top: 460px;
  left: 1300px;
}
</style>