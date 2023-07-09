import React, { useRef } from "react";
import { connect } from "react-redux";
import { sendFilesToBack } from "../../store/actions/archivesImportPage";

const FilesInput = ({ sendData = f => f }) => {
	const inputFile = useRef(null);

	const inputChanged = ev => {
		const data = ev.target.files;

		let formData = new FormData();
		const keys = Object.keys(data);
		keys.forEach(key => {
			const file = data[key];
			formData.append('data', file);
		});

		sendData(1, formData);
	};

	return (
		<div>
			<input
                style={{ fontSize: '1.2rem', padding: '1rem' }}
				type="file"
				ref={inputFile}
				onChange={inputChanged}
				multiple
			/>
		</div>
	);
};

const mapStateToProps = state => {
	return {};
};

const mapDispatchToProps = dispatch => {
	return {
		sendData: (id, data) => dispatch(sendFilesToBack(id, data)),
	};
};

export default connect(mapStateToProps, mapDispatchToProps)(FilesInput);
