﻿//===========================
// Copyright (c) Tarteeb LLC
// Powering True Leadership
//===========================

using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Excel.Importer.Models.Foundations.ExternalApplicants;

namespace Excel.Importer.Services.Proccessings.Spreadsheets
{
    public interface ISpreadsheetProccessingService
    {
        ValueTask<List<ExternalApplicant>> GetExternalApplicantsAsync(MemoryStream spreadsheet);
    }
}
