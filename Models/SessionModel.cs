using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using coreTutorials.DAL;
using Microsoft.AspNetCore.Http;

namespace coreTutorials.Models
{
    public class SessionModel
    {
        public string SessionKeyName = "_Name";
        public string SessionKeyUsername = "_Username";
        public string SessionKeyStatus = "_IsActive";
        public string SessionKeyLoginCount = "_Count";
        public string SessionName { get; private set; }
        public string SessionUsername { get; private set; }
        public string SessionStatus { get; private set; }
        public string SessionLoginCount { get; private set; }
    }
}
