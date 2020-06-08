export const FETCH_SPECTACLES = "FETCH_SPECTACLES"; 
export const UPDATE_SPECTACLES = "UPDATE_SPECTACLES"; 


export const fetchSpectacles = () => ({
    type: FETCH_SPECTACLES
});

export const updateSpectacles = spectacles => ({
    type: UPDATE_SPECTACLES,
    payload:{
        spectacles
    }
});