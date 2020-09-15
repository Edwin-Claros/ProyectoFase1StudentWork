import { Component, OnInit} from '@angular/core';
import { ConexionDBService } from './conexion-db.service';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit{


  constructor(private _service:ConexionDBService) { }

  ngOnInit() {
  }

  logIn = this._service.isLoggedIn;
}
