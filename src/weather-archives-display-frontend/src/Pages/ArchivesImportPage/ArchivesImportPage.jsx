import React, { useEffect } from "react";
import "./ArchivesImportPage.css";
import { connect } from "react-redux";
import FilesInput from "../../Common/FilesInput/FilesInput";
import PagesMenu from "../../Common/PagesMenu/PagesMenu";

const ArchivesImportPage = ({ state }) => {
	return (
		<div style={{ display: "flex", flexDirection: "column" }}>
			<PagesMenu />
			<div style={{ margin: "4rem" }}>
				<FilesInput />
			</div>
		</div>
	);
};

const mapStateToProps = state => {
	console.log(state);

	return {
		state: state,
	};
};

const mapDispatchToProps = dispatch => {
	return {};
};

export default connect(mapStateToProps, mapDispatchToProps)(ArchivesImportPage);
