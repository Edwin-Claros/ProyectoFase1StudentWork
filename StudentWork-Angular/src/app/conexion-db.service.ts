import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class ConexionDBService {

  obtenerDatosUsuarioLocal: any;

  constructor(private http:HttpClient, private router: Router) {

  }

  obtenerUsuarioLogin(usuarioCorreo: string){
    return this.http.get(`https://webapistudentwork.azurewebsites.net/api/Usuario/${usuarioCorreo}`)
  }

  obtenerDatosLogin() {
    this.obtenerDatosUsuarioLocal = JSON.parse(localStorage.getItem('user'));
    return this.http.get(`https://webapistudentwork.azurewebsites.net/api/Usuario/${this.obtenerDatosUsuarioLocal.usuarioCorreo}`);
  }

  SignIngIfUserExist(){
    if (localStorage.getItem('user')) {/*
      this.router.navigate(['dashboard']); */
      this.router.navigate;
      return true;
    } else {
      this.router.navigate(['login'])
      return false;
    }
  }



}
