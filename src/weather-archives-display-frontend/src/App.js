import React from "react";
import { BrowserRouter as Router, Routes, Route, Link } from "react-router-dom";
import "./App.css";

export const App = () => {
	return (
		<main>
			<Router>
				<Routes>
					{/* <Route path="/" element={<CoffeeOrderPage />} /> */}
					<Route
						path="*"
						element={<p>Неопознанный маршрут</p>}
					/>
				</Routes>
			</Router>
		</main>
	);
};

export default App;