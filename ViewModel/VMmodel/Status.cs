using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.VMmodel
{
    public class Status
    {
        private HttpStatusCode _code;
        private bool _isErrorInService;
        private string _message;
        private string _id;

        public HttpStatusCode code
        {
            get { return _code; }
            set { _code = value; }
        }

        public bool isErrorInService
        {
            get { return _isErrorInService; }
            set { _isErrorInService = value; }
        }

        public string message
        {
            get { return _message; }
            set { _message = value; }
        }

        public string id
        {
            get { return _id; }
            set { _id = value; }
        }
    }
}
