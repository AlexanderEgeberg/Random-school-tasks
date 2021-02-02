import Axios, { AxiosError, AxiosResponse } from "../../node_modules/axios/index";

interface IRecord {
    //https://drrestservice2020.azurewebsites.net/api/Record
    Id: Number,
    City: String,
    Household: Number,
    Tested: Number,
    Sick: Number
}

let baseUrl: string = "http://localhost:5000/api/CovidRecords";



new Vue({
    // TypeScript compiler complains about Vue because the CDN link to Vue is in the html file.
    // Before the application runs this TypeScript file will be compiled into bundle.js
    // which is included at the bottom of the html file.


    el: "#app",
    data: {
        ID: undefined,
        Data: [],
        CityData: [],
        HouseholdData: [],
        city: undefined,
        household: undefined,
        deleteResponse: [],
        errorMessage: "",
        postCity: "",
        postHousehold: undefined,
        postTested: undefined,
        postSick: undefined,
        postFormData: {City: "", Household: undefined, Tested: undefined, Sick: undefined},
    },
    methods: {

        //Calls a HTTP get method and returns as HTTP Response
        async getAllAsync() {
            try { return Axios.get<IRecord[]>(baseUrl) }
            catch (error: any) {
                this.errorMessage = error.message;
                alert(error.message)
            }
        },

        //creates response variable and assigns values to data.
        async getAll() {
            let response = await this.getAllAsync();
            this.Data = response.data;
        },

        //Calls a HTTP get method by specific ID 
        getById(id: number) {
            let url: string = baseUrl + "/" + id
            Axios.get<IRecord>(url)
                .then((response: AxiosResponse<IRecord>) => {
                    this.Data = response.data
                })
                .catch((error: AxiosError) => {
                    this.errorMessage = error.message
                    alert(error.message) // https://www.w3schools.com/js/js_popup.asp
                })
        },
        getCity(city: string) {
            let url: string = baseUrl + "/city/" + city
            Axios.get<IRecord>(url)
                .then((response: AxiosResponse<IRecord>) => {
                    this.CityData = response.data
                })
                .catch((error: AxiosError) => {
                    this.errorMessage = error.message
                    alert(error.message) // https://www.w3schools.com/js/js_popup.asp
                })
        },
        getHousehold(household: number) {
            let url: string = baseUrl + "/household/" + household
            Axios.get<IRecord>(url)
                .then((response: AxiosResponse<IRecord>) => {
                    this.HouseholdData = response.data
                })
                .catch((error: AxiosError) => {
                    this.errorMessage = error.message
                    alert(error.message) // https://www.w3schools.com/js/js_popup.asp
                })
        },
        async postAsync() {
            try {
                return Axios.post<IRecord>(baseUrl, this.postFormData)
            }
            catch (error: any) {
                this.errorMessage = error.message
                console.log("message" + error.message);
                alert(error.message)
            }
        },

        async HTTPPost(){
          this.postFormData.City = this.postCity;
          this.postFormData.Household = Number(this.postHousehold);
          this.postFormData.Tested = Number(this.postTested);
          this.postFormData.Sick = Number(this.postSick);
          console.log(this.postFormData);
          let response = await this.postAsync();
          this.addStatus = "Status: " + response.status + ' ' + response.statusText;
          this.addMessage = "Response data: " + JSON.stringify(response.data);  
        },

        HTTPDelete(id: number) {
            let url: string = baseUrl + "/" + id
            Axios.delete<IRecord>(url)
                .then((response: AxiosResponse<IRecord>) => {
                    this.deleteResponse = response.data
                })
                .catch((error: AxiosError) => {
                    this.errorMessage = error.message
                    alert(error.message) // https://www.w3schools.com/js/js_popup.asp
                })
        },
    }
})