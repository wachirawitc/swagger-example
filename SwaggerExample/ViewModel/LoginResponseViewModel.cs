using System;

namespace SwaggerExample.ViewModel
{
    public class LoginResponseViewModel
    {
        public string Token { get; set; }

        public DateTime ExpiryDate { get; set; }
    }
}