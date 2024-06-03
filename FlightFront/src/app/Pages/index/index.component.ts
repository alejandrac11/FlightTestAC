import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component } from '@angular/core';
import { Constants } from '../../Class/constants';
import { firstValueFrom } from 'rxjs';
import { FormControl, FormGroup, Validators } from '@angular/forms';

interface responseFligth {
  id: number;
  origin: string;
  destination: string;
  code: string;
  price: number;
  transportId: number;
  transport: string;
}

interface responseCurrency {
  code: string;
  name: string;
  rate: number;
}

interface Flight {
  id: number;
  origin: string;
  destination: string;
  price: number;
  priceCurrencyCode: number;
  currencyCode: number;
  transportId: number;
  transport: string;
}

interface FlightGroup {
  flights: Flight[];
  origin: string;
  destination: string;
  costo: number;
}

@Component({
  selector: 'app-index',
  templateUrl: './index.component.html',
  styleUrls: ['./index.component.scss']
})
export class IndexComponent {

  public arrayLocations: Array<string> = [];
  public arrayCurrencies: Array<string> = [];
  public formLocations: FormGroup;
  public showToast = false;
  public toastTime = 3000;
  public toastMessage = '';
  public flightsData: FlightGroup[] = [];
  public flightsReturnData: FlightGroup[] = [];

  constructor(private http: HttpClient) {
    this.loadInfo();

    this.formLocations = new FormGroup({
      sloOrigin: new FormControl(0, Validators.required),
      sloDestination: new FormControl(0, Validators.required),
      flightType: new FormControl(0, Validators.required),
      sloCurrency: new FormControl(0, Validators.required),
    });
  }

  public async loadInfo() {
    const response: any = await firstValueFrom(this.http.get(Constants.urlApi + 'Flight/GetAll'));

    response.forEach((flight: responseFligth) => {
      const found = this.arrayLocations.find(location => location == flight.origin);
      if (!found) {
        this.arrayLocations.push(flight.origin);
      }
    });

    console.log(this.arrayLocations);

    const responseCurrencies: any = await firstValueFrom(this.http.get(Constants.urlApi + 'Currencies/Get'));
    
    responseCurrencies.forEach((currency: responseCurrency) => {
        this.arrayCurrencies.push(currency.code);
    });

    console.log(this.arrayLocations);
  }

  public async findFlith() {
    const values = this.formLocations.value;
    console.log(values);

    if (values.sloOrigin == 0 || values.sloDestination == 0) {
      this.toastMessage = "Sorry, you must select origin and destination";
      this.showToast = true;
      setTimeout(() => {
        this.showToast = false;
      }, this.toastTime);
      return;
    }

    if (values.flightType == 0) {
      this.toastMessage = "Sorry, you must select a flight type";
      this.showToast = true;
      setTimeout(() => {
        this.showToast = false;
      }, this.toastTime);
      return;
    }

    if (values.sloCurrency == 0) {
      this.toastMessage = "Sorry, you must select a currency";
      this.showToast = true;
      setTimeout(() => {
        this.showToast = false;
      }, this.toastTime);
      return;
    }

    try {
      const response: any = await firstValueFrom(this.http.get(Constants.urlApi + 'Flight/GetJourney/' + values.sloOrigin + '/' + values.sloDestination + '/' + values.sloCurrency));

      if (Array.isArray(response)) {
        this.flightsData = response;
      } else {
        this.toastMessage = "Unexpected response format";
        this.showToast = true;
        setTimeout(() => {
          this.showToast = false;
        }, this.toastTime);
      }

      console.log(response);
    } catch (error) {
      this.toastMessage = "Error fetching flight data";
      this.showToast = true;
      setTimeout(() => {
        this.showToast = false;
      }, this.toastTime);
      console.error('Error:', error);
    }
  
    this.flightsReturnData = [];
    
    if (values.flightType == 'roundtrip') { 
      try {
        const responseReturn: any = await firstValueFrom(this.http.get(Constants.urlApi + 'Flight/GetJourney/' + values.sloDestination + '/' + values.sloOrigin + '/' + values.sloCurrency));
  
        if (Array.isArray(responseReturn)) {
          this.flightsReturnData = responseReturn;
        } else {
          this.toastMessage = "Unexpected response format";
          this.showToast = true;
          setTimeout(() => {
            this.showToast = false;
          }, this.toastTime);
        }
  
        console.log(responseReturn);
      } catch (error) {
        this.toastMessage = "Error fetching flight return data";
        this.showToast = true;
        setTimeout(() => {
          this.showToast = false;
        }, this.toastTime);
        console.error('Error:', error);
      }
    }
    
  }
}
