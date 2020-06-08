import { all } from 'redux-saga/effects';
import spectacles from "../features/theater/saga"


export default function* rootSaga() {
    yield all([
        spectacles()
    ]);
}
