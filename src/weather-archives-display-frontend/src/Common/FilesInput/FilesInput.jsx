import React, { useRef } from "react";
import { connect } from "react-redux";
import { sendFilesToBack } from "../../store/actions/archivesImportPage";
import { UploadFile } from "@mui/icons-material";
import { Label } from "reactstrap";
import './FilesInput.css'

const FilesInput = ({ sendData = f => f }) => {
	const inputFile = useRef(null);

	const inputChanged = ev => {
		const data = ev.target.files;

		let formData = new FormData();
		const keys = Object.keys(data);
		keys.forEach(key => {
			const file = data[key];
			formData.append("data", file);
		});

		sendData(1, formData);
	};

	return (
		<div style={{ display: 'flex', flexDirection: 'column', alignItems: 'center' }}>
			<Label style={{ fontSize: '3rem', margin: '0 0 2rem 0' }}>
				Нажмите, чтобы загрузить файлы
			</Label>
			<label htmlFor="formId" className="file-button">
				<input
					name=""
					type="file"
					id="formId"
					hidden
					style={{ fontSize: "1.2rem", padding: "1rem" }}
					ref={inputFile}
					onChange={inputChanged}
					multiple
				/>
				<UploadFile style={{ width: "12rem", height: "12rem" }} />
			</label>
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
