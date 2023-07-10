import { combineReducers } from "redux";
import archivesImportPage from "./archivesImportPage";
import viewPage from "./viewPage";

const rootReducer = combineReducers({
	archivesImportPage,
	viewPage
});

export default rootReducer;
