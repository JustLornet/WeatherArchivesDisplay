import { Button } from "reactstrap";
import { ChevronLeftRounded } from "@mui/icons-material";
import { useNavigate } from "react-router";

const PagesMenu = ({}) => {
	const navigate = useNavigate();

	const onClick = ev => {
		navigate("/");
	};

	return (
		<div>
			<Button onClick={onClick}>
				<ChevronLeftRounded style={{ width: "4rem", height: "4rem" }} />
			</Button>
		</div>
	);
};

export default PagesMenu;
