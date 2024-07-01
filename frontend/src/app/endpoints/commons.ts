import { AccountClient } from "./AccountClient";
import { LoginHelper } from "./loginHelper";

export const environment = {
    production: false,
    baseUrl: 'https://localhost:7082/api/',
    userVariable: new LoginHelper()
};

