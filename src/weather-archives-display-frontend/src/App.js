import React from "react";
import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import "./App.css";
import ArchivesImportPage from "./Pages/ArchivesImportPage/ArchivesImportPage"
import MainMenuPage from "./Pages/MainMenu/MainMenuPage";

export const App = () => {
	return (
		<main>
			<Router>
				<Routes>
					<Route path="/" element={<MainMenuPage />} />
					<Route path="/import" element={<ArchivesImportPage />} />
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