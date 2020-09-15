import { Component, OnInit } from '@angular/core';
import { ConexionDBService } from '../../conexion-db.service';

@Component({
  selector: 'app-footer',
  templateUrl: './footer.component.html',
  styleUrls: ['./footer.component.css']
})
export class FooterComponent implements OnInit {
  Date : Date = new Date();

  constructor(private _service:ConexionDBService,) { }

  ngOnInit() {
   // this._service.SignIngIfUserExist();
  }

}
