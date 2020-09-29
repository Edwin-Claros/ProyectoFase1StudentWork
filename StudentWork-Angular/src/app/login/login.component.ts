import { Component, OnInit } from "@angular/core";
import {
  FormGroup,
  FormBuilder,
  FormControl,
  Validators,
} from "@angular/forms";
import { ConexionDBService } from "../conexion-db.service";
import { Router } from "@angular/router";
import { ToastrService } from "ngx-toastr";

@Component({
  selector: "app-login",
  templateUrl: "./login.component.html",
  styleUrls: ["./login.component.css"],
})
export class LoginComponent implements OnInit {
  FormularioGuardar: FormGroup;
  public usuarioContraseña: "";
  public usuarioCorreo: "";

  constructor(
    private _service: ConexionDBService,
    private formularioB: FormBuilder,
    private router: Router,
    private toastr: ToastrService
  ) {
    this.FormularioGuardar = this.formularioB.group({
      Correo: new FormControl("", Validators.compose([Validators.required])),
      Contraseña: new FormControl(
        "",
        Validators.compose([Validators.required])
      ),
    });
  }

  ngOnInit() {
  }

  loginFormulario() {
    this._service.login(
      this.FormularioGuardar.get("Correo").value,
      this.FormularioGuardar.get("Contraseña").value
    );
  }

  loginGoogle() {
    this._service.loginWithGoogle();
  }

  loginFacebook() {
    this._service.loginWithFacebook();
  }
}
