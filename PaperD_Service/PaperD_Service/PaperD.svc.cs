using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace PaperD_Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "PaperD" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select PaperD.svc or PaperD.svc.cs at the Solution Explorer and start debugging.
    public class PaperD : IPaperD
    {
        PaperDDataContext db = new PaperDDataContext();
        public SysUser Login(string Email, string Password)
        {
            var user = (from u in db.SysUsers
                        where u.Email.Equals(Email) &&
                        u.Password.Equals(Password)
                        select u).FirstOrDefault();

            var LoginUser = new SysUser
            {
                Id = user.Id,
                Name = user.Name,
                UserType = user.UserType
            };

            return LoginUser;
        }
    }
}
