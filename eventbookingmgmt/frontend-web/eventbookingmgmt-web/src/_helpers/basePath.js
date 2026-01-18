export default class Global {
    static BASE_API_PATH = "http://192.168.1.5:55/api/";
    static BASE_IMAGES_PATH = "http://92.168.1.5:55/api/Images/";
    static API_COUNTRY_LIST_PATH = `${this.BASE_API_PATH}mstcountry/Getlist`;
    static API_COUNTRY_INSERT_PATH = `${this.BASE_API_PATH}mstcountry/Insert`;
    static API_COUNTRY_UPDATE_PATH = `${this.BASE_API_PATH}mstcountry/Update`;
    static API_COUNTRY_DELETE_PATH = `${this.BASE_API_PATH}mstcountry/Delete`;
}
