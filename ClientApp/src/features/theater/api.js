import { apiClient } from "../../client";

async function getSpectacles(params) {
    let url = "spectacles?";
 
    if (params && params.name) {
        url += "&name=" + params.name;
    }

    if (params && params.date) {
        url += "&date=" + params.date;
    }

    try {
        var res = await apiClient.get(url);
        return res.data;
    } catch (error) {
        //todo
    } 
}

async function getSpectacle(id) {
    let url = "spectacles/" + id;
    try {
        var res = await apiClient.get(url);
        return res.data;
    } catch (error) {
        //todo
    } 
}

async function updateSpectacle(data) {
    let url = "spectacles/" + data.id;
    
    try {
        var res = await apiClient.put(url, data);
        return res.data;
    } catch (error) {
        //todo
    } 
}

async function createSpectacle(data) {
    let url = "spectacles/";
    try { 
        var token = JSON.parse(localStorage.getItem('user')).token;
        debugger;
        var res = await apiClient.post(url, data, {
            headers: {
              Authorization: 'Bearer ' + token, 
              'Content-Type': 'application/json'         
            }});
        return res.data;
    } catch (error) {
        //todo
    } 
}

export const Api = {
    updateSpectacle,
    getSpectacle,
    getSpectacles,
    createSpectacle
}