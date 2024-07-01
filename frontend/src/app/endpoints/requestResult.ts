export class requestResult {

    public success: boolean = false;
    public message:string = "";
    public result:any;
    public errors:object;

    constructor() {
        this.success = false;
        this.message = "Not data available";
        this.result = {};
        this.errors = {};
    }
    
}