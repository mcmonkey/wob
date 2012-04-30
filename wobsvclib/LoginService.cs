using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace wobsvclib
{
    //[ServiceContract(Namespace = "https://Wob.Services")]
    public class LoginService : ILogin
    {
        public bool Login(string username, string password = null)
        {
            return true;
        }
    }
}
