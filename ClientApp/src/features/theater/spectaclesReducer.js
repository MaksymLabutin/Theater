import {FETCH_SPECTACLES, UPDATE_SPECTACLES} from "./actions"; 

const initialState = {
    spectacles: [],
    total: 0
}

export default function(state = initialState, action){
    switch (action.type) {
        case FETCH_SPECTACLES: { 
          return {
            ...state
          };
        }
        case UPDATE_SPECTACLES: {
          const { spectacles } = action.payload;
          debugger;
          return {
            ...spectacles
          };
        }
        default:
          return state;
      }
}