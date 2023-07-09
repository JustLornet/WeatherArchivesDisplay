import * as api from "../api";

const sendingResult = {
    SUCCESSFUL: 'successful',
    ERROR: 'error',
}

const sendingStatus = {
    SENDING: 'sending',
    NOT_SENDING: 'not_sending'
}

export const SET_DATA_SENDING_STATUS = 'SET_DATA_SENDING_STATUS'
const setDataSendingStatus = (status = null) => {
    return {
        type: SET_DATA_SENDING_STATUS,
        value: status
    }
}

export const SET_DATA_SENT_RESULT = 'SET_DATA_SENT_RESULT'
const setDataSentResult = (result, error = null) => {
    return {
        type: SET_DATA_SENT_RESULT,
        value: result
    }
}

export const sendFilesToBack = (dataSourceId, data) => {
    return dispatch => {
        dispatch(setDataSendingStatus(sendingStatus.SENDING))

        console.log('!sending', data)

        api.postSingleFile(`/ArchivesImportPage/UploadFiles?id=${dataSourceId}`, data)
        .then(response => {
            if (response.status != 201) {
                dispatch(setDataSentResult(response))
                console.log("Error", response);

                return null;
            }
            dispatch(setDataSendingStatus(sendingStatus.NOT_SENDING))

            return response.data;
        })
    }
}