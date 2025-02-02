import axios from "axios"

const apiUrl = "https://localhost:7218/"

const api = axios.create({
    baseURL: apiUrl
})

export default api;