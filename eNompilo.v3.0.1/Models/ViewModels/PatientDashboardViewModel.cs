﻿using eNompilo.v3._0._1.Models.Counselling;
using eNompilo.v3._0._1.Models.Vaccination;
using eNompilo.v3._0._1.Models.SystemUsers;

namespace eNompilo.v3._0._1.Models.ViewModels
{
    public class PatientDashboardViewModel
    {
        public PatientFile PatientFiles { get; set; }
        public List<GeneralAppointment> GeneralAppointments { get; set; }
        public List<Session> Medication { get; set; }
        public List<SessionNotes> Session { get; set; }
    }
}
