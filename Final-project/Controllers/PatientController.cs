﻿using BLL.DTOs;
using BLL.DTOs.Patient_DTO;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Final_project.Controllers
{
    [EnableCors("*", "*", "*")]
    public class PatientController : ApiController
    {
        [HttpGet]
        [Route("api/Patients")]
        public HttpResponseMessage AllPatient()
        {
            try
            {
                var data = PatientService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        [HttpGet]
        [Route("api/Patients/{email}")]
        public HttpResponseMessage FindPatient(string email)
        {
            try
            {
                var data = PatientService.Get(email);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        [HttpPost]
        [Route("api/Patients/delete/{email}")]
        public HttpResponseMessage DeletePatient(string email)
        {
            try
            {
                var data = PatientService.Delete(email);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        [HttpPost]
        [Route("api/Patients/insert")]
        public HttpResponseMessage InsertPatient(PatientDTO patient)
        {
            try
            {
                var data = PatientService.Create(patient);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        [HttpPost]
        [Route("api/Patients/update")]
        public HttpResponseMessage UpdatePatient(PatientDTO patient)
        {
            try
            {
                var data = PatientService.Update(patient);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
