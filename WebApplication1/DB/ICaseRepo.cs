using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.DB
{
    public interface ICaseRepo
    {
        Case GetCaseById(int id);

        List<Case> GetAllCases();

        HttpStatusCode SaveCase(Case MyCase);

        HttpStatusCode DeleteCase(int id);
        HttpStatusCode updateCase(Case MyCase);
    }
}
