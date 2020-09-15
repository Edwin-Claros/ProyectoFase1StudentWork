import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Router } from "@angular/router";
import { auth } from "firebase/app";
import { AngularFireAuth } from "@angular/fire/auth";
import { User } from "firebase";
import { UsuarioModel } from "./models/UsuarioModel";
import { Observable } from "rxjs";

@Injectable({
  providedIn: "root",
})
export class ConexionDBService {
  obtenerDatosUsuarioLocal: any;
  userLoginFirebase: User;

  constructor(
    private http: HttpClient,
    private router: Router,
    private firebaseAuth: AngularFireAuth
  ) {
    this.firebaseAuth.authState.subscribe((user) => {
      if (user) {
        this.userLoginFirebase = user;
        localStorage.setItem("user", JSON.stringify(this.userLoginFirebase));
        localStorage.setItem("userCorreo", this.userLoginFirebase.email);
      } else {
        localStorage.setItem("user", null);
        localStorage.setItem("userCorreo", null);
        this.router.navigate(["login"]);
      }
    });
  }

  async login(email: string, password: string) {
    return await this.firebaseAuth
      .signInWithEmailAndPassword(email, password)
      .then((result) => {
        this.router.navigate(["dashboard"]);
        window.location.reload();
      })
      .catch((error) => {
        window.alert(error.message);
      });
  }

  async register(email, password) {
    return await this.firebaseAuth
      .createUserWithEmailAndPassword(email, password)
      .then((result) => {
        window.alert("Tu registro se ha realizado exitosamente!");
        this.sendEmailVerification();
      })
      .catch((error) => {
        window.alert(error.message);
      });
  }

  async sendEmailVerification() {
    (await this.firebaseAuth.currentUser).sendEmailVerification();
    this.router.navigate(["login"]);
  }

  async sendPasswordResetEmail(passwordResetEmail: string) {
    return await this.firebaseAuth.sendPasswordResetEmail(passwordResetEmail);
  }

  async logout() {
    await this.firebaseAuth.signOut();
    localStorage.removeItem("user");
    window.location.reload();
    this.router.navigate(["login"]);
  }

  get isLoggedIn(): boolean {
    const user = JSON.parse(localStorage.getItem("user"));
    return user !== null;
  }

  async loginWithGoogle() {
    await this.firebaseAuth.signInWithPopup(new auth.GoogleAuthProvider());
    window.location.reload();
    this.router.navigate(["dashboard"]);
  }

  async loginWithFacebook() {
    await this.firebaseAuth.signInWithPopup(new auth.FacebookAuthProvider());
    window.location.reload();
    this.router.navigate(["dashboard"]);
  }

  getDatoUser() {
    return this.http.get(
      `https://studentwork.azurewebsites.net/api/Usuario/${localStorage.getItem(
        "userCorreo"
      )}`
    );
  }
  getCountries(): Observable<any> {
    return this.http.get("https://studentwork.azurewebsites.net/api/Pais");
  }
  getCities(): Observable<any> {
    return this.http.get("https://studentwork.azurewebsites.net/api/PaisCiudad");
  }
  getState(): Observable<any> {
    return this.http.get("https://studentwork.azurewebsites.net/api/PaisDepartamento");
  }
  getLicences(): Observable<any> {
    return this.http.get("https://studentwork.azurewebsites.net/api/LicenciaConducir");
  }
}
