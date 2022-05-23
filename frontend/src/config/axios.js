import axios from "axios";

const success = (res) => res;
const error = (err) => {
  if (401 === err.response.status || 403 === err.response.status) {
    window.location = "/";
  } else {
    return Promise.reject(err);
  }
};

axios.create({});
axios.defaults.baseURL = "https://crud-eng-soft2.herokuapp.com/api";
axios.interceptors.response.use(success, error);

export default axios;
