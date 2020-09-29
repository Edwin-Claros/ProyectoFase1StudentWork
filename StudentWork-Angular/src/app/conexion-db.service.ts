import { Injectable } from "@angular/core";
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Router } from "@angular/router";
import { auth } from "firebase/app";
import { AngularFireAuth } from "@angular/fire/auth";
import { User } from "firebase";
import { Observable } from "rxjs";
import { ToastrService } from "ngx-toastr";
import { environment } from "../environments/environment";

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
      this.addDatoExperienciaStorage();
      this.addDatoFormacionStorage();
      if (user) {
        sessionStorage.setItem("user", JSON.stringify(user));
        console.log("creo ser primero");
      } else {
        this.router.navigate(["login"]);
      }
    });
    this.addDatoUserStorage();
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

    return this.http.get(`${environment.servidor}/api/Usuario/${user.email}`);
  }

  getDatoExperiencia(): Observable<any> {
    var userApi = JSON.parse(sessionStorage.getItem("userApi"));

    if (userApi == null) {
      return null;
    }

    return this.http.get(
      `${environment.servidor}/api/Experiencia/${userApi.usuarioId}`
    );
  }

  getDatoFormacion(): Observable<any> {
    var userApi = JSON.parse(sessionStorage.getItem("userApi"));

    if (userApi == null) {
      return null;
    }

    return this.http.get(
      `${environment.servidor}/api/Formacion/${userApi.usuarioId}`
    );
  }

  deleteExperiencia(id): Observable<any> {
    return this.http.delete(`${environment.servidor}/api/Experiencia/${id}`);
  }
  deleteFormacion(id): Observable<any> {
    return this.http.delete(`${environment.servidor}/api/Formacion/${id}`);
  }

  getCountries(): Observable<any> {
    return this.http.get(`${environment.servidor}/api/Pais`);
  }

  getCities(): Observable<any> {
    return this.http.get(`${environment.servidor}/api/PaisCiudad`);
  }

  getState(): Observable<any> {
    return this.http.get(`${environment.servidor}/api/PaisDepartamento`);
  }

  getLicences(): Observable<any> {
    return this.http.get(`${environment.servidor}/api/LicenciaConducir`);
  }

  getEmpresaSector(): Observable<any> {
    return this.http.get(`${environment.servidor}/api/EmpresaSector`);
  }

  getNivelEstudio(): Observable<any> {
    return this.http.get(`${environment.servidor}/api/NivelEstudio`);
  }

  addDatoUserStorage() {
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

  addDatoExperienciaStorage() {
    if (this.getDatoExperiencia() == null) {
      sessionStorage.setItem("expApi", null);
    } else {
      this.getDatoExperiencia().subscribe(
        (result) => {
          sessionStorage.setItem("expApi", JSON.stringify(result));
        },
        (error) => {
          sessionStorage.setItem("expApi", null);
          console.log(JSON.stringify(error));
        }
      );
    }
  }

  addDatoFormacionStorage() {
    if (this.getDatoFormacion() == null) {
      sessionStorage.setItem("formacionApi", null);
    } else {
      this.getDatoFormacion().subscribe(
        (result) => {
          sessionStorage.setItem("formacionApi", JSON.stringify(result));
        },
        (error) => {
          sessionStorage.setItem("formacionApi", null);
          console.log(JSON.stringify(error));
        }
      );
    }
  }

  addUser(user) {
    let json = JSON.stringify(user);
    let headers = new HttpHeaders().set("content-Type", "application/json");
    return this.http.post(`${environment.servidor}/api/Usuario`, json, {
      headers: headers,
    });
  }

  addExperiencia(experiencia) {
    let json = JSON.stringify(experiencia);
    let headers = new HttpHeaders().set("content-Type", "application/json");
    return this.http.post(`${environment.servidor}/api/Experiencia`, json, {
      headers: headers,
    });
  }

  addFormacion(formacion) {
    let json = JSON.stringify(formacion);
    let headers = new HttpHeaders().set("content-Type", "application/json");
    return this.http.post(`${environment.servidor}/api/Formacion`, json, {
      headers: headers,
    });
  }

  updateUser(user, id): Observable<any> {
    return this.http.put(`${environment.servidor}/api/Usuario/${id}`, user);
  }

  updateExperiencia(experiencia, id): Observable<any> {
    return this.http.put(
      `${environment.servidor}/api/Experiencia/${id}`,
      experiencia
    );
  }

  updateFormacion(Formacion, id): Observable<any> {
    return this.http.put(
      `${environment.servidor}/api/Formacion/${id}`,
      Formacion
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
