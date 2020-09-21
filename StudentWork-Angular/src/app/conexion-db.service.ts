import { Injectable } from "@angular/core";
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Router } from "@angular/router";
import { auth } from "firebase/app";
import { AngularFireAuth } from "@angular/fire/auth";
import { User } from "firebase";
import { Observable } from "rxjs";
import { ToastrService } from "ngx-toastr";

@Injectable({
  providedIn: "root",
})
export class ConexionDBService {
  userLoginFirebase: User;
  getDatoUserApi: any;
  obtenerDatosUser: any;

  constructor(
    private http: HttpClient,
    private router: Router,
    private firebaseAuth: AngularFireAuth,
    private toastr: ToastrService
  ) {
    this.firebaseAuth.authState.subscribe((user) => {
      if (user) {
        sessionStorage.setItem("user", JSON.stringify(user));
        console.log("creo ser primero");
      } else {
        this.router.navigate(["login"]);
      }
    });
    this.getProfileUser();
    console.log("creo ser segundo");
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
    sessionStorage.removeItem("user");
    sessionStorage.removeItem("userApi");
    window.location.reload();
    this.router.navigate(["login"]);
  }

  get isLoggedIn(): boolean {
    const user = JSON.parse(sessionStorage.getItem("user"));
    if (user == null) {
      this.firebaseAuth.signOut();
      return false;
    }
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

  getDatoUser(): Observable<any> {
    var user = JSON.parse(sessionStorage.getItem("user"));

    if (user == null) {
      return null;
    }

    return this.http.get(
      `https://studentwork.azurewebsites.net/api/Usuario/${user.email}`
    );
  }

  getCountries(): Observable<any> {
    return this.http.get("https://studentwork.azurewebsites.net/api/Pais");
  }

  getCities(): Observable<any> {
    return this.http.get(
      "https://studentwork.azurewebsites.net/api/PaisCiudad"
    );
  }

  getState(): Observable<any> {
    return this.http.get(
      "https://studentwork.azurewebsites.net/api/PaisDepartamento"
    );
  }

  getLicences(): Observable<any> {
    return this.http.get(
      "https://studentwork.azurewebsites.net/api/LicenciaConducir"
    );
  }

  getProfileUser() {
    console.log(this.getDatoUser());
    if (this.getDatoUser() == null) {
      sessionStorage.setItem("userApi", null);
    } else {
      this.getDatoUser().subscribe(
        (result) => {
          sessionStorage.setItem("userApi", JSON.stringify(result));
        },
        (error) => {
          sessionStorage.setItem("userApi", null);
          console.log(JSON.stringify(error));
        }
      );
    }
  }

  addUser(user) {
    let json = JSON.stringify(user);
    let headers = new HttpHeaders().set("content-Type", "application/json");
    return this.http.post(
      "https://studentwork.azurewebsites.net/api/Usuario",
      json,
      { headers: headers }
    );
  }

  updateUser(user, id): Observable<any> {
    return this.http.put(
      `https://studentwork.azurewebsites.net/api/Usuario/${id}`,
      user
    );
  }

  funcionError(mensaje) {
    this.toastr.error(
      '<span class="now-ui-icons ui-1_bell-53"></span> <b>' + mensaje + "</b>",
      "",
      {
        timeOut: 5000,
        enableHtml: true,
        closeButton: true,
        toastClass: "alert alert-danger alert-with-icon",
        positionClass: "toast-bottom-right",
      }
    );
  }

  funcionExitosa(mensaje) {
    this.toastr.success(
      '<span class="now-ui-icons ui-1_bell-53"></span> <b>' + mensaje + "</b>",
      "",
      {
        timeOut: 5000,
        closeButton: true,
        enableHtml: true,
        toastClass: "alert alert-success alert-with-icon",
        positionClass: "toast-bottom-right",
      }
    );
  }
}
