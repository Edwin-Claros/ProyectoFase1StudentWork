import { Component, OnInit } from "@angular/core";
import { ConexionDBService } from "../conexion-db.service";
import { error } from "protractor";
import { UsuarioModel } from "../models/UsuarioModel";

@Component({
  selector: "app-user-profile",
  templateUrl: "./user-profile.component.html",
  styleUrls: ["./user-profile.component.css"],
})
export class UserProfileComponent implements OnInit {
  getDatoUser: any = [];
  getCountryUser: any = [];
  getCityUser: any = [];
  getStateUser: any = [];
  getLicencesUser: any = [];

  constructor(private _service: ConexionDBService) {
    this.getProfileUser();
    this.getCountries();
    this.getCities();
    this.getState();
    this.getLicences();
  }

  ngOnInit() {
   /*  this.getProfileUser();
    this.getCountries();
    this.getCities();
    this.getState();
    this.getLicences(); */
  }

  getProfileUser() {
    this._service.getDatoUser().subscribe(
      (result) => {
        this.getDatoUser = result;
      },
      (error) => {
        console.log(JSON.stringify(error));
      }
    );
  }

  getCountries() {
    this._service.getCountries().subscribe(
      (result) => {
        this.getCountryUser = result;
      },
      (error) => {
        console.log(JSON.stringify(error));
      }
    );
  }
  getCities() {
    this._service.getCities().subscribe(
      (result) => {
        this.getCityUser = result;
      },
      (error) => {
        console.log(JSON.stringify(error));
      }
    );
  }
  getState() {
    this._service.getState().subscribe(
      (result) => {
        this.getStateUser = result;
      },
      (error) => {
        console.log(JSON.stringify(error));
      }
    );
  }
  getLicences() {
    this._service.getLicences().subscribe(
      (result) => {
        this.getLicencesUser = result;
      },
      (error) => {
        console.log(JSON.stringify(error));
      }
    );
  }

  goFacebook(){
    window.location.href = this.getDatoUser.usuarioFacebook;
  }
}
