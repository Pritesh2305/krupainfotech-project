import { userActionTypes } from '../_actions/user.action.types';
export const changeLoggedIn = (isLoggedIn, user) => {
    return (dispatch) => {
        dispatch({
            type: userActionTypes.LOGIN_SUCCESS,
            payload: { isLoggedIn: isLoggedIn, userData: user }
        })
    }
}