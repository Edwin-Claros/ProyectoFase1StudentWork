import { Component, OnInit } from "@angular/core";
import { ConexionDBService } from "../conexion-db.service";
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { UsuarioModel } from "../models/UsuarioModel";
import { Router } from "@angular/router";

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
  obtenerEmailUser: any = [];
  FormularioGuardar: FormGroup;
  getUser: any = [];

  constructor(
    private _service: ConexionDBService,
    private formularioB: FormBuilder
  ) {
    console.log("creo ser tercero");
    this.tiempo();
  }

  ngOnInit() {
    console.log("creo ser cuarto");
    this.getCountries();
    this.getCities();
    this.getState();
    this.getLicences();
    this.obtenerEmailUser = JSON.parse(sessionStorage.getItem("user"));

    this.FormularioGuardar = this.formularioB.group({
      usuarioNombre: ["", Validators.required],
      usuarioCorreo: ["", Validators.required],
      usuarioDNI: [""],
      usuarioTelefono: [""],
      usuarioSkype: [""],
      usuarioDireccion: [""],
      usuarioCodigoPostal: [""],
      usuarioEstadoCivil: ["", Validators.required],
      usuarioVehiculoPropio: ["", Validators.required],
      usuarioGenero: ["", Validators.required],
      usuarioFechaNacimiento: ["", Validators.required],
      pais_Id: ["", Validators.required],
      paisDepartamento_Id: [""],
      paisCiudad_Id: [""],
      licenciaConducir_Id: ["", Validators.required],
      usuarioDescripcion: [""],
      usuarioFacebook: [""],
      usuarioInstagram: [""],
      usuarioTwitter: [""],
      usuarioApellido: ["", Validators.required],
    });
  }

  onSubmit(ModeloClase: any) {
    const agregar = new UsuarioModel();

    this.saveModel(agregar, ModeloClase);

    if (this.getDatoUser == null) {
      this.addUser(agregar);
    } else {
      agregar.usuarioId = this.getDatoUser.usuarioId;
      agregar.usuarioTimestamp = this.getDatoUser.usuarioTimestamp;
      this.updateUser(agregar, this.getDatoUser.usuarioId);
    }
  }

  getProfileUser() {
    this.getUser = JSON.parse(sessionStorage.getItem("userApi"));
    if (this.getUser == null) {
      this.getDatoUser.usuarioNombre = "";
    } else {
      this.getDatoUser = this.getUser;
    }
  }

  tiempo() {
    setTimeout(() => {
      this.getProfileUser();
      console.log("ya");
    }, 100);
  }

  getCountries() {
    this._service.getCountries().subscribe(
      (result) => {
        this.getCountryUser = result;
      },
      (error) => {
        this._service.funcionError("No se pudieron obtener los Paises");
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
        this._service.funcionError("No se pudieron obtener las Ciudades");
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
        this._service.funcionError("No se pudieron obtener los Departamentos");
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
        this._service.funcionError("No se pudieron obtener las Licencias");
      }
    );
  }

  goFacebook() {
    window.location.href = this.getDatoUser.usuarioFacebook;
  }

  goTwitter() {
    window.location.href = this.getDatoUser.usuarioTwitter;
  }

  goInstagram() {
    window.location.href = this.getDatoUser.usuarioInstagram;
  }

  saveModel(agregar: any, ModeloClase: any) {
    agregar.usuarioNombre = ModeloClase.usuarioNombre;
    agregar.usuarioCorreo = ModeloClase.usuarioCorreo;
    agregar.usuarioDNI = ModeloClase.usuarioDNI;
    agregar.usuarioTelefono = ModeloClase.usuarioTelefono;
    agregar.usuarioSkype = ModeloClase.usuarioSkype;
    agregar.usuarioDireccion = ModeloClase.usuarioDireccion;
    agregar.usuarioCodigoPostal = ModeloClase.usuarioCodigoPostal;
    agregar.usuarioEstadoCivil = ModeloClase.usuarioEstadoCivil;
    agregar.usuarioVehiculoPropio = ModeloClase.usuarioVehiculoPropio;
    agregar.usuarioGenero = ModeloClase.usuarioGenero;
    agregar.usuarioFechaNacimiento = ModeloClase.usuarioFechaNacimiento;
    agregar.pais_Id = ModeloClase.pais_Id;
    agregar.paisDepartamento_Id = ModeloClase.paisDepartamento_Id;
    agregar.paisCiudad_Id = ModeloClase.paisCiudad_Id;
    agregar.licenciaConducir_Id = ModeloClase.licenciaConducir_Id;
    agregar.usuarioDescripcion = ModeloClase.usuarioDescripcion;
    agregar.usuarioFacebook = ModeloClase.usuarioFacebook;
    agregar.usuarioInstagram = ModeloClase.usuarioInstagram;
    agregar.usuarioTwitter = ModeloClase.usuarioTwitter;
    agregar.usuarioApellido = ModeloClase.usuarioApellido;
  }

  addUser(agregar: any) {
    this._service.addUser(agregar).subscribe(
      (result) => {
        this._service.funcionExitosa(
          "Felicidades, los datos fueron guardados con exito!"
        );
        this.refresh();
      },
      (error) => {
        this._service.funcionError(
          "ERROR, Los datos no pudieron ser almacenados"
        );
      }
    );
  }

  updateUser(agregar: any, id: string) {
    this._service.updateUser(agregar, id).subscribe(
      (result) => {
        this._service.funcionExitosa(
          "Felicidades, los datos fueron actualizados con exito!"
        );
        setTimeout(() => {
          this.refresh();
        }, 400);
      },
      (error) => {
        this._service.funcionError(
          "ERROR, Los datos no pudieron ser actualizados"
        );
      }
    );
  }

  refresh() {
    window.location.reload();
  }
}
