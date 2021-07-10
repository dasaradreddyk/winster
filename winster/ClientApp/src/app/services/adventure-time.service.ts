import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/observable/of';
import 'rxjs/add/operator/delay';
import { HttpClient } from '@angular/common/http'
import { CHARACTERS } from './mock-data';
import { CHARACTERS1 } from './mock-data';
import { concat } from 'rxjs';

@Injectable()
export class AdventureTimeService {

  public http: HttpClient;
  public data: ProfieData[];
    public videoids: any[];
    public videoids3: Observable<any[]>;

    public videoids1: string[]=[];
    public CHARACTERS: any[];
    public CHARACTERS1: any[];
    constructor(http: HttpClient) {
      this.http = http;
      http.get<ProfieData[]>('/data/Getprofies?input=NEWETOWN').subscribe
            (
            result => {
                this.data = result; 
                console.log(this.data);
                this.data.forEach(function (element) {
                    CHARACTERS.push(element);
                });
                
                CHARACTERS.push(this.data[0]);
            }, error => console.error(error));
    
    }

    getCharacters(val): Observable<WeatherForecast[]>{
      var url = "/data/Getprofies?input=" +val;

      this.http.get<ProfieData[]>(url).subscribe
            (
            result => {
                this.data = result;
                console.log(this.data);
                this.data.forEach(function (element) {
                    CHARACTERS.push(element);
                });

                CHARACTERS.push(this.data[0]);
            }, error => console.error(error));
        return Observable.of(CHARACTERS).delay(100);
  }

  getColumns(): string[]{
    return ["name", "url"]
  }
   //delete content 

   Updateclicks(str)
   {
     
   }
    

  //video data ..
     
   
}

interface WeatherForecast {
    name: string;
    age: string ;
    species: number;
    occupation: string;
}
interface ProfieData {
  name: string;
  url: string;
   
}
