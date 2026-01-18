import axios from "axios";
import basePath from '../../_helpers/basePath';

const config = { headers: { 'Content-type': 'application/json; charset=UTF-8' }, }

const api_No_Auth = axios.create({
    baseURL: basePath.BASE_API_PATH
})
const api_Auth = axios.create({
    baseURL: basePath.BASE_API_PATH
})

//api_No_Auth.defaults.headers.common['ki-client-code'] = 'event';
//api_Auth.defaults.headers.common['ki-client-code'] = 'event';

export const Login_Process = (objmodel) => {
    debugger;
    api_No_Auth.defaults.headers.common['ki-client-code'] = objmodel.clientcode;
    const obj = { 'username': objmodel.username, 'password': objmodel.password }
    return api_No_Auth.post('mstusers/Login',
        JSON.stringify(obj),
        config
    );
};
