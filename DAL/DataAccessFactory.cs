﻿using DAL.Interfaces;
using DAL.Models;
using DAL.Models.Patient_Models;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DataAccessFactory
    {
        public static IRepo<Doctor, string, bool> DoctorData()
        {
            return new DoctorRepo();
        }
        public static IRepo<Token, string, Token> TokenData()
        {
            return new TokenRepo();
        }
        public static IAuth<bool> AuthData()
        {
            return new DoctorRepo();
        }
        public static IRepo<Patient, string, Patient> PatientData() 
        { 
            return new PatientRepo(); 
        }
    }
}
