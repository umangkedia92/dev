using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnowyAlexa.Data
{
    public class Requests
    {
            public Request Create(Request request)
            {
           // try
           // {
                using (var db = new snowyAlexa_Entities())
                {
                    var member = db.Members.FirstOrDefault(m => m.AlexaUserId == request.UserId);

                    if (member == null)
                    {
                        request.Member = new Member() { AlexaUserId = request.UserId, CreatedDate = DateTime.UtcNow, LastRequestDate = DateTime.UtcNow, RequestCount = 1 };

                        db.Requests.Add(request);
                    }
                    else
                    {
                         member.Requests.Add(request);
                    }

                    db.SaveChanges();
                }
            //}
            //catch (DbEntityValidationException e)
            //{
            //    foreach (var eve in e.EntityValidationErrors)
            //    {
            //        Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
            //            eve.Entry.Entity.GetType().Name, eve.Entry.State);
            //        foreach (var ve in eve.ValidationErrors)
            //        {
            //            Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
            //                ve.PropertyName, ve.ErrorMessage);
            //        }
            //    }
            //    throw;
            //}

                return request;
            }
       
    }
}
