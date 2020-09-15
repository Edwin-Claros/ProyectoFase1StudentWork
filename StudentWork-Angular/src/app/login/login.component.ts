import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, FormControl, Validators } from '@angular/forms';
import { ConexionDBService } from '../conexion-db.service';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  FormularioGuardar:FormGroup;
  public usuarioContraseña: "";
  public usuarioCorreo: "";

  constructor(
    private _service:ConexionDBService,
    private formularioB:FormBuilder,
    private router: Router,
    private toastr: ToastrService
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
    //this._service.SignIngIfUserExist();
  }

  loginFormulario(){
    this._service.login(this.FormularioGuardar.get('Correo').value,this.FormularioGuardar.get('Contraseña').value)
  }

  loginGoogle(){
    this._service.loginWithGoogle();
  }

  loginFacebook(){
    this._service.loginWithFacebook();
  }

  /*obtenerDatosUsuarioLogin() {
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
        this.toastr.error('<span class="now-ui-icons ui-1_bell-53"></span> El <b> Usuario </b> No Existe.', '', {
          timeOut: 8000,
          enableHtml: true,
          closeButton: true,
          toastClass: "alert alert-danger alert-with-icon",
          positionClass: 'toast-bottom-right',
        });
      }
    }, error => {
      console.log("Usuario Y Contraseña Erroneas");
      this.toastr.error('<span class="now-ui-icons ui-1_bell-53"></span> El <b> Usuario o Contraseña </b> Erronea.', '', {
        timeOut: 8000,
        enableHtml: true,
        closeButton: true,
        toastClass: "alert alert-danger alert-with-icon",
        positionClass: 'toast-bottom-right',
      });
      this.clear();
    });
  }

  clear() {
    console.log("clear clicked")
    this.FormularioGuardar.reset();
  }*/

}
