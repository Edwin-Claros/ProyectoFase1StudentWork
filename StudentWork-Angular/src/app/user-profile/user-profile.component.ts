import { Component, OnInit } from "@angular/core";
import { ConexionDBService } from "../conexion-db.service";
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { UsuarioModel } from "../models/UsuarioModel";
import { ExperienciaModel } from "../models/ExperienciaModel";
import { FormacionModel } from "../models/FormacionModel";
import { UserIdiomaModel } from "../models/UserIdiomaModel";
import { ConocimientoModel } from "../models/ConocimientoModel";
import { PreferenciasDeTrabajoModel } from "../models/PreferenciasDeTrabajoModel";
import { UsuarioImagenModel } from "../models/UsuarioImagenModel";
import { ImageCroppedEvent } from 'ngx-image-cropper';

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
  getIdiomaUser: any = [];

  FormularioUser: FormGroup;
  FormularioExperiencia: FormGroup;
  FormularioExperienciaModal: FormGroup;
  FormularioFormacion: FormGroup;
  FormularioFormacionModal: FormGroup;
  FormularioUserIdioma: FormGroup;
  FormularioConocimiento: FormGroup;
  FormularioPreferenciasDeTrabajo: FormGroup;

  showFormExperiencia: boolean = false;
  showFormFormacion: boolean = false;
  showFormIdioma: boolean = false;
  showFormConocimiento: boolean = false;

  getExperiencia: any = [];
  getEmpresaSectorUser: any = [];
  getNivelEstudioUser: any = [];
  getExperienciaedit: any = [];
  getFormacionedit: any = [];
  getFormacion: any = [];
  getDatoIdioma: any = [];
  getDatoConocimiento: any = [];
  getDatoPreferenciasDeTrabajo: any = [];
  getSituacionActualUser: any = [];

  constructor(
    private _service: ConexionDBService,
    private formularioB: FormBuilder
  ) {
    this.tiempo();
  }

  ngOnInit() {
    console.log("creo ser cuarto");
    this.getCountries();
    this.getSituacionActual();
    this.getCities();
    this.getState();
    this.getIdioma();
    this.getLicences();
    this.getEmpresaSector();
    this.getNivelEstudio();
    this.obtenerEmailUser = JSON.parse(sessionStorage.getItem("user"));
    this.formularioUsuario();
    this.formularioExperiencia();
    this.formularioExperienciaModal();
    this.formularioFormacion();
    this.formularioFormacionModal();
    this.formularioUserIdioma();
    this.formularioConocimiento();
    this.formularioPreferenciasDeTrabajo();
  }

  imageChangedEvent: any = '';
    croppedImage: any = '';

    fileChangeEvent(event: any): void {
        this.imageChangedEvent = event;
        console.log(this.imageChangedEvent);
    }
    imageCropped(event: ImageCroppedEvent) {
        this.croppedImage = event.base64;
        console.log(this.croppedImage);
    }
    imageLoaded() {
        // show cropper
    }
    cropperReady() {
        // cropper ready
    }
    loadImageFailed() {
        // show message
    }







  onSubmitUser(ModeloClase: any) {
    const agregar = new UsuarioModel();
    this.modelUser(agregar, ModeloClase);
    if (this.getDatoUser.usuarioId == null || undefined) {
      this.addUser(agregar);
    } else {
      agregar.usuarioId = this.getDatoUser.usuarioId;
      agregar.usuarioTimestamp = this.getDatoUser.usuarioTimestamp;
      console.log(agregar);
      this.updateUser(agregar, this.getDatoUser.usuarioId);
    }
  }

  onSubmitExperiencia(ModeloClase: any) {
    const agregar = new ExperienciaModel();
    this.modelExperiencia(agregar, ModeloClase);
    agregar.usuario_Id = this.getDatoUser.usuarioId;
    console.log(agregar);
    this.addExperiencia(agregar);
  }

  onSubmitUserIdioma(ModeloClase: any) {
    const agregar = new UserIdiomaModel();
    this.modelUserIdioma(agregar, ModeloClase);
    agregar.usuario_Id = this.getDatoUser.usuarioId;
    console.log(agregar);
    this.addUserIdioma(agregar);
  }

  onSubmitExperienciaUpdate(ModeloClase: any) {
    const agregar = new ExperienciaModel();
    this.modelExperienciaUpdate(agregar, ModeloClase);
    agregar.usuario_Id = this.getDatoUser.usuarioId;
    agregar.experienciaId = this.getExperienciaedit.experienciaId;
    console.log(agregar);
    this.updateExperiencia(agregar, this.getExperienciaedit.experienciaId);
  }

  onSubmitFormacion(ModeloClase: any) {
    const agregar = new FormacionModel();
    this.modelFormacion(agregar, ModeloClase);
    agregar.usuario_Id = this.getDatoUser.usuarioId;
    console.log(agregar);
    this.addFormacion(agregar);
  }

  onSubmitFormacionUpdate(ModeloClase: any) {
    const agregar = new FormacionModel();
    this.modelFormacionUpdate(agregar, ModeloClase);
    agregar.usuario_Id = this.getDatoUser.usuarioId;
    agregar.formacionId = this.getFormacionedit.formacionId;
    console.log(agregar);
    this.updateFormacion(agregar, this.getFormacionedit.formacionId);
  }

  onSubmitConocimiento(ModeloClase: any) {
    const agregar = new ConocimientoModel();
    this.modelConocimiento(agregar, ModeloClase);
    agregar.usuario_Id = this.getDatoUser.usuarioId;
    console.log(agregar);
    this.addConocimiento(agregar);
  }

  onSubmitPreferenciasDeTrabajo(ModeloClase: any) {
    const agregar = new PreferenciasDeTrabajoModel();
    this.modelPreferenciasDeTrabajo(agregar, ModeloClase);
    if (
      this.getDatoPreferenciasDeTrabajo.preferenciasDeTrabajoId == null ||
      undefined
    ) {
      agregar.usuario_Id = this.getDatoUser.usuarioId;
      console.log(agregar);
      this.addPreferenciasDeTrabajo(agregar);
    } else {
      agregar.usuario_Id = this.getDatoUser.usuarioId;
      agregar.preferenciasDeTrabajoId = this.getDatoPreferenciasDeTrabajo.preferenciasDeTrabajoId;
      console.log(agregar);
      this.updatePreferenciasDeTrabajo(
        agregar,
        this.getDatoPreferenciasDeTrabajo.preferenciasDeTrabajoId
      );
    }
  }

  tiempo() {
    setTimeout(() => {
      this.getProfileUser();
      this.getExperienciaUser();
      this.getFormacionUser();
      this.getDatoIdiomaUser();
      this.getConocimiento();
      this.getPreferenciasDeTrabajo();
      console.log("ya");
    }, 2000);
  }

  addPreferenciasDeTrabajo(agregar) {
    this._service.addPreferenciasDeTrabajo(agregar).subscribe(
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
        console.log(JSON.stringify(error));
      }
    );
  }

  updatePreferenciasDeTrabajo(agregar, id) {
    this._service.updatePreferenciasDeTrabajo(agregar, id).subscribe(
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
        console.log(JSON.stringify(error));
      }
    );
  }

  getPreferenciasDeTrabajo() {
    var getPreferenciasDeTrabajo = JSON.parse(
      sessionStorage.getItem("userPreferenciasApi")
    );
    if (getPreferenciasDeTrabajo == null) {
      this.getDatoPreferenciasDeTrabajo.preferenciasDeTrabajoPuesto = [];
    } else {
      this.getDatoPreferenciasDeTrabajo = getPreferenciasDeTrabajo;
    }
  }

  getSituacionActual() {
    this._service.getSituacionActual().subscribe(
      (result) => {
        this.getSituacionActualUser = result;
      },
      (error) => {
        this._service.funcionError("No se pudieron obtener los Paises");
        console.log(JSON.stringify(error));
      }
    );
  }

  addConocimiento(agregar) {
    this._service.addConocimiento(agregar).subscribe(
      (result) => {
        this._service.funcionExitosa(
          "Felicidades, los datos fueron guardados con exito!"
        );
        this._service.addDatoConocimientoStorage();
        this.tiempo();
      },
      (error) => {
        this._service.funcionError(
          "ERROR, Los datos no pudieron ser almacenados"
        );
      }
    );
  }

  deleteConocimiento(id) {
    this._service.deleteConocimiento(id).subscribe(
      (result) => {
        this._service.funcionExitosa(
          "Felicidades, los datos fueron eliminados con exito!"
        );
        this._service.addDatoConocimientoStorage();
        this.tiempo();
      },
      (error) => {
        this._service.funcionError(
          "ERROR, Los datos no pudieron ser eliminados"
        );
        console.log(JSON.stringify(error));
      }
    );
  }

  getConocimiento() {
    var getConocimiento = JSON.parse(sessionStorage.getItem("conocimientoApi"));
    if (getConocimiento == null) {
      this.getDatoConocimiento.conocimientoNombre = [];
    } else {
      this.getDatoConocimiento = getConocimiento;
    }
  }

  addUser(agregar) {
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

  addUserIdioma(agregar) {
    this._service.addUserIdioma(agregar).subscribe(
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

  addExperiencia(agregar) {
    this._service.addExperiencia(agregar).subscribe(
      (result) => {
        this._service.funcionExitosa(
          "Felicidades, los datos fueron guardados con exito!"
        );
        setTimeout(() => {
          this.refresh();
        }, 400);
      },
      (error) => {
        this._service.funcionError(
          "ERROR, Los datos no pudieron ser almacenados"
        );
        console.log(JSON.stringify(error));
      }
    );
  }

  addFormacion(agregar) {
    this._service.addFormacion(agregar).subscribe(
      (result) => {
        this._service.funcionExitosa(
          "Felicidades, los datos fueron guardados con exito!"
        );
        setTimeout(() => {
          this.refresh();
        }, 400);
      },
      (error) => {
        this._service.funcionError(
          "ERROR, Los datos no pudieron ser almacenados"
        );
        console.log(JSON.stringify(error));
      }
    );
  }

  deleteExperiencia(id) {
    this._service.deleteExperiencia(id).subscribe(
      (result) => {
        this._service.funcionExitosa(
          "Felicidades, los datos fueron eliminados con exito!"
        );
        setTimeout(() => {
          this.refresh();
        }, 400);
      },
      (error) => {
        this._service.funcionError(
          "ERROR, Los datos no pudieron ser eliminados"
        );
        console.log(JSON.stringify(error));
      }
    );
  }

  deleteFormacion(id) {
    this._service.deleteFormacion(id).subscribe(
      (result) => {
        this._service.funcionExitosa(
          "Felicidades, los datos fueron eliminados con exito!"
        );
        setTimeout(() => {
          this.refresh();
        }, 400);
      },
      (error) => {
        this._service.funcionError(
          "ERROR, Los datos no pudieron ser eliminados"
        );
        console.log(JSON.stringify(error));
      }
    );
  }

  deleteIdioma(id) {
    this._service.deleteIdioma(id).subscribe(
      (result) => {
        this._service.funcionExitosa(
          "Felicidades, los datos fueron eliminados con exito!"
        );
        setTimeout(() => {
          this.refresh();
        }, 400);
      },
      (error) => {
        this._service.funcionError(
          "ERROR, Los datos no pudieron ser eliminados"
        );
        console.log(JSON.stringify(error));
      }
    );
  }

  updateExperiencia(agregar, id) {
    this._service.updateExperiencia(agregar, id).subscribe(
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

  updateUser(agregar, id) {
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

  updateFormacion(agregar, id) {
    this._service.updateFormacion(agregar, id).subscribe(
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
        console.log(this.getNivelEstudioUser);
      }
    );
  }

  getProfileUser() {
    var getUser = JSON.parse(sessionStorage.getItem("userApi"));
    if (getUser == null) {
      this.getDatoUser.usuarioNombre = [];
    } else {
      this.getDatoUser = getUser;
    }
  }

  getExperienciaUser() {
    var getExperiencia = JSON.parse(sessionStorage.getItem("expApi"));
    if (getExperiencia == null) {
      this.getExperiencia = [];
    } else {
      this.getExperiencia = getExperiencia;
    }
  }

  getFormacionUser() {
    var getFormacion = JSON.parse(sessionStorage.getItem("formacionApi"));
    if (getFormacion == null) {
      this.getFormacion = [];
    } else {
      this.getFormacion = getFormacion;
    }
  }

  getDatoIdiomaUser() {
    var getDatoIdioma = JSON.parse(sessionStorage.getItem("userIdiomaApi"));
    if (getDatoIdioma == null) {
      this.getDatoIdioma = [];
    } else {
      this.getDatoIdioma = getDatoIdioma;
    }
  }

  getIdioma() {
    this._service.getIdioma().subscribe(
      (result) => {
        this.getIdiomaUser = result;
      },
      (error) => {
        this._service.funcionError("No se pudieron obtener los Idiomas");
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

  getEmpresaSector() {
    this._service.getEmpresaSector().subscribe(
      (result) => {
        this.getEmpresaSectorUser = result;
      },
      (error) => {
        console.log(JSON.stringify(error));
        this._service.funcionError("No se pudieron obtener las sectores de empresas");
      }
    );
  }

  getNivelEstudio() {
    this._service.getNivelEstudio().subscribe(
      (result) => {
        this.getNivelEstudioUser = result;
      },
      (error) => {
        console.log(JSON.stringify(error));
        this._service.funcionError("No se pudieron obtener los listados de nivel de estudio");
      }
    );
  }

  refresh() {
    window.location.reload();
  }

  editExperiencia(item) {
    this.getExperienciaedit = item;
    console.log(item);
  }

  editFormacion(item) {
    this.getFormacionedit = item;
    console.log(item);
  }

  formularioExperiencia() {
    this.FormularioExperiencia = this.formularioB.group({
      experienciaEmpresa: ["", Validators.required],
      experienciaDestacar: [""],
      experienciaMejorar: [""],
      experienciaCargo: ["", Validators.required],
      experienciaArea: ["", Validators.required],
      experienciaFuncionesYLogros: [""],
      experienciaFechaInicio: ["", Validators.required],
      experienciaFechaFinal: ["", Validators.required],
      experienciaRecomendacion: ["", Validators.required],
      empresaSector_Id: ["", Validators.required],
    });
  }

  formularioUserIdioma() {
    this.FormularioUserIdioma = this.formularioB.group({
      usuarioIdiomaNivel: ["", Validators.required],
      idioma_Id: ["", Validators.required],
    });
  }

  formularioConocimiento() {
    this.FormularioConocimiento = this.formularioB.group({
      conocimientoNombre: ["", Validators.required],
    });
  }

  formularioExperienciaModal() {
    this.FormularioExperienciaModal = this.formularioB.group({
      experienciaEmpresaModal: ["", Validators.required],
      experienciaDestacarModal: [""],
      experienciaMejorarModal: [""],
      experienciaCargoModal: ["", Validators.required],
      experienciaAreaModal: ["", Validators.required],
      experienciaFuncionesYLogrosModal: [""],
      experienciaFechaInicioModal: ["", Validators.required],
      experienciaFechaFinalModal: ["", Validators.required],
      experienciaRecomendacionModal: ["", Validators.required],
      empresaSector_IdModal: ["", Validators.required],
    });
  }

  formularioFormacion() {
    this.FormularioFormacion = this.formularioB.group({
      formacionCentroEducativo: ["", Validators.required],
      formacionAreaDeEstudio: ["", Validators.required],
      formacionNivelProfesorado: [""],
      formacionSatisfaccionprendizaje: [""],
      formacionAccesoAEmpleo: [""],
      formacionRecomendacion: ["", Validators.required],
      formacionEstado: ["", Validators.required],
      formacionFechaInicio: ["", Validators.required],
      formacionFechaFinal: ["", Validators.required],
      nivelEstudio_Id: ["", Validators.required],
    });
  }

  formularioFormacionModal() {
    this.FormularioFormacionModal = this.formularioB.group({
      formacionCentroEducativoModal: ["", Validators.required],
      formacionAreaDeEstudioModal: ["", Validators.required],
      formacionNivelProfesoradoModal: [""],
      formacionSatisfaccionprendizajeModal: [""],
      formacionAccesoAEmpleoModal: [""],
      formacionRecomendacionModal: ["", Validators.required],
      formacionEstadoModal: ["", Validators.required],
      formacionFechaInicioModal: ["", Validators.required],
      formacionFechaFinalModal: ["", Validators.required],
      nivelEstudio_IdModal: ["", Validators.required],
    });
  }

  formularioPreferenciasDeTrabajo() {
    this.FormularioPreferenciasDeTrabajo = this.formularioB.group({
      preferenciasDeTrabajoPuesto: ["", Validators.required],
      preferenciasDeTrabajoSalario: ["", Validators.required],
      preferenciasDeTrabajoArea: ["", Validators.required],
      preferenciasDeTrabajoViajar: ["", Validators.required],
      preferenciasDeTrabajoResidencia: ["", Validators.required],
      paisDepartamento_Id: ["", Validators.required],
      situacionActual_Id: ["", Validators.required],
    });
  }

  formularioUsuario() {
    this.FormularioUser = this.formularioB.group({
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

  modelUserIdioma(agregar, ModeloClase) {
    agregar.usuarioIdiomaNivel = ModeloClase.usuarioIdiomaNivel;
    agregar.idioma_Id = ModeloClase.idioma_Id;
  }

  modelConocimiento(agregar, ModeloClase) {
    agregar.conocimientoNombre = ModeloClase.conocimientoNombre;
  }

  modelUserImagen(agregar, ModeloClase) {
    agregar.userImagenImagem = ModeloClase.userImagenImagem;
  }

  modelUser(agregar, ModeloClase) {
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

  modelExperiencia(agregar, ModeloClase) {
    agregar.experienciaEmpresa = ModeloClase.experienciaEmpresa;
    agregar.experienciaDestacar = ModeloClase.experienciaDestacar;
    agregar.experienciaMejorar = ModeloClase.experienciaMejorar;
    agregar.experienciaCargo = ModeloClase.experienciaCargo;
    agregar.experienciaArea = ModeloClase.experienciaArea;
    agregar.experienciaFuncionesYLogros =
      ModeloClase.experienciaFuncionesYLogros;
    agregar.experienciaFechaInicio = ModeloClase.experienciaFechaInicio;
    agregar.experienciaFechaFinal = ModeloClase.experienciaFechaFinal;
    agregar.experienciaRecomendacion = ModeloClase.experienciaRecomendacion;
    agregar.empresaSector_Id = ModeloClase.empresaSector_Id;
  }

  modelPreferenciasDeTrabajo(agregar, ModeloClase) {
    agregar.preferenciasDeTrabajoPuesto =
      ModeloClase.preferenciasDeTrabajoPuesto;
    agregar.preferenciasDeTrabajoSalario =
      ModeloClase.preferenciasDeTrabajoSalario;
    agregar.preferenciasDeTrabajoArea = ModeloClase.preferenciasDeTrabajoArea;
    agregar.preferenciasDeTrabajoViajar =
      ModeloClase.preferenciasDeTrabajoViajar;
    agregar.preferenciasDeTrabajoResidencia =
      ModeloClase.preferenciasDeTrabajoResidencia;
    agregar.paisDepartamento_Id = ModeloClase.paisDepartamento_Id;
    agregar.situacionActual_Id = ModeloClase.situacionActual_Id;
  }

  modelExperienciaUpdate(agregar, ModeloClase) {
    agregar.experienciaEmpresa = ModeloClase.experienciaEmpresaModal;
    agregar.experienciaDestacar = ModeloClase.experienciaDestacarModal;
    agregar.experienciaMejorar = ModeloClase.experienciaMejorarModal;
    agregar.experienciaCargo = ModeloClase.experienciaCargoModal;
    agregar.experienciaArea = ModeloClase.experienciaAreaModal;
    agregar.experienciaFuncionesYLogros =
      ModeloClase.experienciaFuncionesYLogrosModal;
    agregar.experienciaFechaInicio = ModeloClase.experienciaFechaInicioModal;
    agregar.experienciaFechaFinal = ModeloClase.experienciaFechaFinalModal;
    agregar.experienciaRecomendacion =
      ModeloClase.experienciaRecomendacionModal;
    agregar.empresaSector_Id = ModeloClase.empresaSector_IdModal;
  }

  modelFormacion(agregar, ModeloClase) {
    agregar.formacionCentroEducativo = ModeloClase.formacionCentroEducativo;
    agregar.formacionAreaDeEstudio = ModeloClase.formacionAreaDeEstudio;
    agregar.formacionNivelProfesorado = ModeloClase.formacionNivelProfesorado;
    agregar.formacionSatisfaccionprendizaje =
      ModeloClase.formacionSatisfaccionprendizaje;
    agregar.formacionAccesoAEmpleo = ModeloClase.formacionAccesoAEmpleo;
    agregar.formacionRecomendacion = ModeloClase.formacionRecomendacion;
    agregar.formacionEstado = ModeloClase.formacionEstado;
    agregar.formacionFechaInicio = ModeloClase.formacionFechaInicio;
    agregar.formacionFechaFinal = ModeloClase.formacionFechaFinal;
    agregar.nivelEstudio_Id = ModeloClase.nivelEstudio_Id;
  }

  modelFormacionUpdate(agregar, ModeloClase) {
    agregar.formacionCentroEducativo =
      ModeloClase.formacionCentroEducativoModal;
    agregar.formacionAreaDeEstudio = ModeloClase.formacionAreaDeEstudioModal;
    agregar.formacionNivelProfesorado =
      ModeloClase.formacionNivelProfesoradoModal;
    agregar.formacionSatisfaccionprendizaje =
      ModeloClase.formacionSatisfaccionprendizajeModal;
    agregar.formacionAccesoAEmpleo = ModeloClase.formacionAccesoAEmpleoModal;
    agregar.formacionRecomendacion = ModeloClase.formacionRecomendacionModal;
    agregar.formacionEstado = ModeloClase.formacionEstadoModal;
    agregar.formacionFechaInicio = ModeloClase.formacionFechaInicioModal;
    agregar.formacionFechaFinal = ModeloClase.formacionFechaFinalModal;
    agregar.nivelEstudio_Id = ModeloClase.nivelEstudio_IdModal;
  }

  goFacebook() {
    window.location.href = this.getDatoUser.usuarioFacebook;
  }

  goTwitter() {
    window.location.href = this.getDatoUser.usuarioTwitter;
  }

  goInstagram() {
    window.location.href = this.getDatoUser.usuarioInstagram;
    var c = document.getElementById
  }
}
