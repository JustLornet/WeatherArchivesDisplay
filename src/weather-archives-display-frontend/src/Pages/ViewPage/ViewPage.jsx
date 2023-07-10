import { connect } from "react-redux";
import "./ViewPage.css";
import { useMemo, useState } from "react";
import { fetchDataFromBack } from "../../store/actions/viewPage";
import { Spinner } from "reactstrap";
import { MaterialReactTable } from "material-react-table";
import tableColumns from "./tableColumns";
import { DateRangePicker } from "rsuite";
import "rsuite/dist/rsuite.min.css";
import moment from "moment/moment";
import PagesMenu from "../../Common/PagesMenu/PagesMenu";

const ViewPage = ({ logEntries, isFetching, fetchData = f => f }) => {
	const [dateTime, setDateTime] = useState([]);

	const columns = useMemo(() => tableColumns, []);

	const dateChanged = date => {
		setDateTime(date ?? []);

		if (date != null && date.length > 0) {
			const parsedStart = moment(date[0]).utc(true).format();
			const parsedEnd = moment(date[1]).utc(true).format();

			const filters = {
				start: parsedStart,
				end: parsedEnd,
			};

			fetchData(filters);
		}
	};

	const isDateSet = dateTime != null && dateTime.length > 0;

	if (isFetching) {
		return <Spinner style={{ width: "4rem", height: "4rem" }}>Запрос данных</Spinner>;
	}

	return (
		<div className={isDateSet ? "view-page" : "view-page view-page--empty"}>
			<div className="view-page__header-container">
				<PagesMenu />
				
			</div>
			<div className="view-page__date-picker-container" style={{ margin: '0 0 2rem 0' }}>
				<DateRangePicker
					value={dateTime}
					size="lg"
					className="view-page__date-picker"
					format="dd.MM.yyyy HH:mm:ss"
					defaultCalendarValue={[
						new Date("01.01.2010 00:00:00"),
						new Date("01.02.2010 23:59:59"),
					]}
					onChange={dateChanged}
				/>
				</div>
			{isDateSet ? (
				<MaterialReactTable
					columns={columns}
					data={logEntries}
				/>
			) : (
				<h2>Введите дату для запроса</h2>
			)}
		</div>
	);
};

const mapStateToProps = state => {
	console.log(state);

	return {
		isFetching: state.viewPage.isFetching,
		logEntries: state.viewPage.logEntries,
	};
};

const mapDispatchToProps = dispatch => {
	return {
		fetchData: filters => dispatch(fetchDataFromBack(filters)),
	};
};

export default connect(mapStateToProps, mapDispatchToProps)(ViewPage);
