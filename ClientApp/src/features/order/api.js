import { apiClient } from "../../client";

async function createOrder(data) {
    let url = "orders"; 
    try {
        var res = await apiClient.post(url, data);
        return res.data;
    } catch (error) {
        //todo
    } 
} 

export const OrderApi = {
    createOrder
}