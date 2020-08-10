import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, FormControl, Validators } from '@angular/forms';
import { ConexionDBService } from '../conexion-db.service';
import { Router } from '@angular/router';
import { UsuarioModels } from '../models/UsuarioModels';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  FormularioGuardar:FormGroup;
  public usuarioContraseña: "";
  public usuarioCorreo: "";
  obtner = {};

  constructor(
    private _service:ConexionDBService,
    private formularioB:FormBuilder,
    private router: Router,
  ) {

    this.FormularioGuardar = this.formularioB.group({
      Correo: new FormControl('', Validators.compose([
        Validators.required
      ])),
      Contraseña: new FormControl('', Validators.compose([
        Validators.required
      ]))
    })
  }

  ngOnInit() {
    this._service.SignIngIfUserExist();
  }

  obtenerDatosUsuarioLogin() {
    this._service.obtenerUsuarioLogin(this.FormularioGuardar.get('Correo').value)
    .subscribe((userData: UsuarioModels) => {

      this.usuarioCorreo = userData.usuarioCorreo;
      this.usuarioContraseña = userData.usuarioContraseña;
      if (this.FormularioGuardar.get('Contraseña').value === userData.usuarioContraseña && this.FormularioGuardar.get('Correo').value === userData.usuarioCorreo) {
        localStorage.setItem('user',JSON.stringify(userData));
        this.router.navigate(['dashboard']);
        window.location.reload();
      }
      else {
        console.log("No Existe Usuario");
        //this.growlService.addError({heading:'Oops',message:'Usuario No Existe'});
      }
    }, error => {
      console.log("Usuario Y Contraseña Erroneas");
      //this.growlService.addError({heading:'Oops',message:'Usuario Y Contraseña Erroneas'});
      this.clear();
    });
  }

  clear() {
    console.log("clear clicked")
    this.FormularioGuardar.reset();
  }

  logoutUser() {
    localStorage.removeItem('user');
  }

}
