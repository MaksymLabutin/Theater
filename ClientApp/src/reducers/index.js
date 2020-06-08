import { combineReducers } from 'redux';
import spectaclesReducer from "../features/theater/spectaclesReducer";

export const createRootReducer = () =>
    combineReducers({
        spectaclesReducer
    });
