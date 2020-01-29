import { connect } from "react-redux";
import { Dispatch } from "react";
import { AnyAction } from "redux";
import { selectSickAnimals } from "../Animals/store/selectors";
import { ICustomAppState } from "../../../store/state";
import { actionClearEntireAnimalsState } from "../Animals/store/actions";
import { HowToHelp } from "./Component";
import { actionClearInfoCard } from "../Home/store/actions";
import { selectSavedInfoCard } from "../Home/store/selectors";

const mapStateToProps = (state: ICustomAppState) => ({
  sickAnimalsList: selectSickAnimals(state),
  infoCard: selectSavedInfoCard(state),
});
const mapDispatchToProps = (dispatch: Dispatch<AnyAction>) => ({
  clearAnimalsState: () => dispatch(actionClearEntireAnimalsState()),
  clearInfoCard: () => dispatch(actionClearInfoCard()),
});

export const HowToHelpPage = connect(mapStateToProps, mapDispatchToProps)(HowToHelp);
export const HOW_TO_HELP_PAGE_LINK: string = '/how-to-help'