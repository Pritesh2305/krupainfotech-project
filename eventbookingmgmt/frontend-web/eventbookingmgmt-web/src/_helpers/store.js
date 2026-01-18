import { createStore,applyMiddleware, compose, combineReducers } from 'redux';
import reducer from '../_reducers/user.reducer';

const mainReducer = combineReducers({
    user: reducer
});

const composeEnhancers = window.__REDUX_DEVTOOLS_EXTENSION_COMPOSE__ || compose;
//const store = createStore(mainReducer, composeEnhancers(applyMiddleware(thunk)));
const store = createStore(mainReducer);
//const store = configureStore(mainReducer,composeEnhancers(applyMiddleware(thunk)));

export default store;