using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.DB
{
    public class CaseRepoImpl : ICaseRepo
    {
        public HttpStatusCode DeleteCase(int id)
        {
            using (var context = new CaseContext())
            {
                try
                {
                    var cs = context.Cases.Find(id);
                    context.Cases.Remove(cs);
                    context.SaveChanges();
                    return HttpStatusCode.OK;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return HttpStatusCode.NotFound;

                }
            }
        }

        public List<Case> GetAllCases()
        {
            using (var context = new CaseContext())
            {
                List<Case> cases = context.Cases.ToList();
                return cases;
            }

        }

        public Case GetCaseById(int id)
        {

            using (var context = new CaseContext())
            {
                var cs = context.Cases.Find(id);
                if (cs == null)
                {
                    throw new KeyNotFoundException();
                }
                return cs;
            }
        }

        public HttpStatusCode SaveCase(Case MyCase)
        {
            using (var context = new CaseContext())
            {
                try
                {
                    context.Cases.Add(MyCase);
                    context.SaveChanges();
                    return HttpStatusCode.Created;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return HttpStatusCode.BadRequest;

                }


            }
        }

        public HttpStatusCode updateCase(Case MyCase)
        {
            using (var context = new CaseContext())
            {
                try
                {
                    var originalCase = context.Cases.Find(MyCase.ID);

                    if (originalCase != null)
                    {
                        originalCase.caseNumber = MyCase.caseNumber;
                        originalCase.customerNumber = MyCase.customerNumber;
                        originalCase.kind = MyCase.kind;
                        context.SaveChanges();


                    }
                    return HttpStatusCode.Accepted;

                }
                catch (Exception ex)
                {
                    return HttpStatusCode.BadRequest;

                }
            }


        }
    
}
}