import axios from "axios";

export const BASE_BACK_PATH = "http://localhost:5050";

export const get = path => {
	const config = {
	method: "GET",
		credentials: "include",
		mode: "cors",
		headers: new Headers({
			Accept: "application/json",
			"Content-Type": "application/json",
			"Access-Control-Allow-Origin": "*",
		}),
	};

	return axios.get(`${BASE_BACK_PATH}${path}`, config);
};

export const post = (path, json) => {
	const config = {
		method: "POST",
		credentials: "include",
		mode: "cors",
		headers: new Headers({
			Accept: "application/json",
			"Content-Type": "application/json",
			"Access-Control-Allow-Origin": "*",
		}),
	};

	return axios.post(`${BASE_BACK_PATH}${path}`, json, config);
};

export const postSingleFile = (path, file) => {
	const config = {
		method: "POST",
		credentials: "include",
		mode: "cors",
		headers: new Headers({
			Accept: "application/json",
			"Content-Type": "multipart/form-data",
			"Content-Length": file.size,
			"Access-Control-Allow-Origin": "*",
		}),
	};

	return axios.post(`${BASE_BACK_PATH}${path}`, file, config);
};
