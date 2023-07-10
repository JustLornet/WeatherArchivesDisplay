import { REQUEST_DATA, SET_REDUX_DATA } from "../actions/viewPage";

const initState = {
    isFetching: false,
    logEntries: []
}

const viewPage = (state = initState, action) => {
	switch (action.type) {
		case REQUEST_DATA:
			return {
				...state,
				isFetching: true,
			};

		case SET_REDUX_DATA:
			return {
				...state,
				isFetching: false,
				[action.propertyName]: action.value,
			};

		default:
			return state;
	}
};

export default viewPage;
