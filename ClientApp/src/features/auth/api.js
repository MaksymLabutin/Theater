import { apiClient } from "../../client";

async function login(data) {
    let url = "account"; 
    try {
        var res = await apiClient.post(url, data);
        return res.data;
    } catch (error) {
        //todo
    } 
} 

export const AuthApi = {
    login
}