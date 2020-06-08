import axios from "axios";

const baseUrl = window.env.API_URL;

const apiClient = axios.create({
    baseURL: baseUrl
});

apiClient.interceptors.request.use(
    request => {
      request.headers = {
        'Content-Type': 'application/json',
      };
      return request;
    },
    error => {
      return Promise.reject(error);
    }
  );
  

export {apiClient};