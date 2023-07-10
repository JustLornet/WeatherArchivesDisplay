import * as api from "../api";

export const REQUEST_DATA = 'REQUEST_DATA'
const requestData = () => {
    return {
        type: REQUEST_DATA,
    }
}

export const SET_REDUX_DATA = 'SET_REDUX_DATA'
const setReduxData = (propertyName, value) => {
    return {
        type: SET_REDUX_DATA,
        propertyName: propertyName,
        value: value
    }
}

export const fetchDataFromBack = (filters) => {
    return dispatch => {
        dispatch(requestData());
		api.post(`/ViewPage/GetLogEntries`, filters)
			.then(response => {
				if (response.status != 200) {
					console.log("Error", response);
					return [];
				}

				return response.data;
			})
			.then(json => dispatch(setReduxData('logEntries', json)));
    }
}