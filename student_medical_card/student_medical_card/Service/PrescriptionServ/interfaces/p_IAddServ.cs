﻿using Microsoft.Data.SqlClient;
using student_medical_card.Models;
using student_medical_card.Models.Responses;

namespace student_medical_card.Service.PrescriptionRepo.interfaces
{
    public interface p_IAddServ
    {
        p2_Response p_Add(Prescription2 prescription);
    }
}
