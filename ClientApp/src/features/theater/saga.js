import { takeEvery, put, call } from 'redux-saga/effects'; 
import { FETCH_SPECTACLES, updateSpectacles } from "./actions";
import {getSpectacles} from "./api";

export default function* spectacles() {
    // yield takeEvery(FETCH_SPECTACLES, fetchSpectacles);
}

export function* fetchSpectacles() {
//    try{
//     var res = yield call(getSpectacles); 
//     yield put(updateSpectacles(res.data));
//    }catch(error){
//        //todo
//    }
}



