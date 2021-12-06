using System.Collections.Generic;

namespace Gouro.WebApp.MVC.Models
{
    public class ErrorViewModel
    {
        public int ErroCode { get; set; }
        public string Titulo { get; set; }
        public string Mensagem { get; set; }
    }

    public class ResponseResult
    {
        public string Title { get; set; }
        public int Status { get; set; }
        public ResponseErrorMessages Errors { get; set; }

        public ResponseResult()
        {
            Errors = new ResponseErrorMessages();
        }
    }

    public class ResponseErrorMessages
    {
        public List<string> Mensagens { get; set; }

        public ResponseErrorMessages()
        {
            Mensagens = new List<string>();
        }
    }
}
