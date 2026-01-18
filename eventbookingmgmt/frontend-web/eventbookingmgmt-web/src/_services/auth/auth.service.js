import basePath from '../../_helpers/basePath';

export const userService = {
    login,
    register
}

async function login(model) {
    debugger;
    const requestOption = {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
            'ki-client-code': 'event',
        },
        body: JSON.stringify(model)
    };
    const response = await fetch(basePath.BASE_API_PATH + 'mstusers/Login', requestOption);
    debugger;
    const res = await handleResponse(response);
    debugger;
    return res;

}

async function register(model) {

}

 function handleResponse(response) {
    return response.text().then(txt => {
        const data = JSON.stringify(txt);

        if (!response.oK) {
            console.log(`response ${response}`);
            const error = (data && data.message) || response.statusText;
            return Promise.reject(error);
        }
        return data;
    });
}