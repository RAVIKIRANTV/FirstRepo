using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using WebAPICrudOperation.Models;


namespace WebAPICrudOperation.Controllers
{
    public class ValuesController : ApiController
    {
        //[System.Web.Http.HttpPost]
        //public string Post([FromBody]int id)
        //{
        //    return "Welcome";
        //}

        PatientModelManager patientModelManager = new PatientModelManager();
        //GET api/values
       [System.Web.Http.HttpGet]
        public List<PateintModel> Get()
        {
            List<PateintModel> listOfPatientDetails = patientModelManager.GetPatientDetails();
            return listOfPatientDetails;
        }
        // GET api/values/5
        [System.Web.Http.HttpGet]
        public PateintModel Get(int id)
        {
            PateintModel pateintDetails = patientModelManager.GetPatientDetailsBasedOnPId(id);
            return pateintDetails;
        }
        [System.Web.Http.HttpGet]
        public void Delete(int id)
        {
            int count = patientModelManager.DeletePatient(id);
        }
        //// POST api/values
        [System.Web.Http.HttpPost]
        public void Post([FromBody]PateintModel patient)
        {
            int count = patientModelManager.RegisterPatient(patient);
        }

        // PUT api/values/5
        [System.Web.Http.HttpPost]
        public void Put(int id,[FromBody]PateintModel patient)
        {
            int count = patientModelManager.UpdatePatient(id, patient);
        }
    }
}
