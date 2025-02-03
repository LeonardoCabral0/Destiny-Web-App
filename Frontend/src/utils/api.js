import axios from "axios"

const apiUrl = "https://localhost:5000/"

const api = axios.create({
    baseURL: apiUrl
})

export default api;