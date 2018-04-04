using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication1.DB;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class CaseController : ApiController
    {
        private ICaseRepo _caseRepo;

        public CaseController()
        {
            _caseRepo = new CaseRepoImpl();
        }

        public CaseController(ICaseRepo s)
        {
            _caseRepo = s;
        }

        public List<Case> Get()
        {
            return _caseRepo.GetAllCases();

        }

        
        public Case Get(int id)
        {
            return _caseRepo.GetCaseById(id);
        }

        public void Post(Case MyCase)
        {
            _caseRepo.SaveCase(MyCase);
        }

        public void delete(int id)
        {
            _caseRepo.DeleteCase(id);
        }

        public void put(int id, [FromBody]Case myCase)
        {
            myCase.ID = id;
            _caseRepo.updateCase(myCase);
        }
    }
}
