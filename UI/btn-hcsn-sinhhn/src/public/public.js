import axios from "axios";
import moment from 'moment';
var commonJS = {
    /**
     * Sinh mã tự động cho mã nhân viên khi ấn vào Add
     * Author:Lợn Cọc
     * Date: 5.40pm 7/8/2022
     */
    AutoId: async function (ID) {
        try {
            axios
                .get("https://cukcuk.manhnv.net/api/v1/Employees/NewEmployeeCode")
                .then((response) => {
                    ID += response.data;
                });
            return ID;
        } catch (error) {
            console.log(error);
        }
    },
    /**
     * Format lại Ngày tháng năm để import vào dialog
     * Author:Lợn Cọc
     * Date: 5.10pm 7/8/2022
     */
     format_date(value) {
        try {
          if (value) {
            return moment(String(value)).format("YYYY-DD-MM");
          }
        } catch (error) {
          console.log(error);
        }
      },
}



export default commonJS;