import React, { useEffect } from "react";
import "./ArchivesImportPage.css"
import { connect } from "react-redux"
import FilesInput from "../../Common/FilesInput/FilesInput";

const ArchivesImportPage = ({ state }) => {
    return (
        <div>
            <FilesInput />
        </div>
    )
}

const mapStateToProps = (state) => {
    console.log(state)

    return {
        state: state
    }
}

const mapDispatchToProps = (dispatch) => {
    return {
    }
}

export default connect(mapStateToProps, mapDispatchToProps)(ArchivesImportPage)