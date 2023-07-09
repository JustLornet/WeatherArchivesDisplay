import React, { useEffect } from "react";
import { connect } from "react-redux"
import { useNavigate } from "react-router-dom";

const MainMenuPage = ({ state }) => {
    const navigate = useNavigate()

    return (
        <div style={{ display: 'flex', flexDirection: 'column', width: '20rem' }} >
            <button style={{ fontSize: '1.6rem', padding: '1rem' }} onClick={() => navigate('/import')}>
                Страница импорта
            </button>
            <button style={{ fontSize: '1.6rem', padding: '1rem' }} onClick={() => navigate('/view')}>
                Страница просмотра
            </button>
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

export default connect(mapStateToProps, mapDispatchToProps)(MainMenuPage)