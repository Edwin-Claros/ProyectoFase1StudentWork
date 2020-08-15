import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class ConexionDBService {

  obtenerUsuario:Observable<any>

  constructor(private http:HttpClient, private router: Router) {

  }

  obtenerUsuarioLogin(usuarioCorreo: string){
    return this.http.get(`https://webapistudentwork.azurewebsites.net/api/Usuario/${usuarioCorreo}`)
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
