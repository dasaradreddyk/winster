import { Component, OnInit, Input, SimpleChanges, Output, EventEmitter} from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { Router, ActivatedRoute, Params, ParamMap, RouterStateSnapshot, NavigationEnd  } from '@angular/router';
import { AdventureTimeService } from '../services/adventure-time.service';

@Component({
  selector: 'app-table',
  templateUrl: './table.component.html',
  styleUrls: ['./table.component.css']
})
export class TableComponent implements OnInit {
    public id: string;
    param1: string;
    param2: string;
    @Input() searchword: string;
    @Input() type: string;
    @Input() url: string;
    @Input() searchword1: string;
    @Output() urlEmit = new EventEmitter<{ url: string, type: string }>();
  characters: Observable<any[]>;
  columns: string[];
  public activatedRoute: ActivatedRoute;
    constructor(private atService: AdventureTimeService, route: ActivatedRoute, router: Router) {
       // const snapshot: RouterStateSnapshot = route.routerState.snapshot;
        console.log(route.queryParams); 
        route.queryParams.subscribe(params => {
            let date = params['id'];
            console.log(date); // Print the parameter to the console.

        });
 router.events.subscribe((val) => {
        // see also
        console.log(val instanceof NavigationEnd)
    });
    }
    childEventClicked(event: string) {

      
        this.url = event["url"];
        this.urlEmit.emit({ url: this.url, type: "" });
        console.log("url in parent  :" + this.url);
    }
    ngOnChanges(changes: SimpleChanges) {
        this.columns = this.atService.getColumns();
        this.characters = this.atService.getCharacters(this.searchword);
        console.log(this.type);
        console.log(this.searchword);

    }

    ngOnInit() {
        this.columns = this.atService.getColumns();
        this.characters = this.atService.getCharacters("live");
        
       
  }

}
