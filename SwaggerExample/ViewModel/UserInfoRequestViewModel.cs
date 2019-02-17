using System.ComponentModel.DataAnnotations;

namespace SwaggerExample.ViewModel
{
    public class UserInfoRequestViewModel
    {
        [Required]
        [MaxLength(50)]
        public string UserName { get; set; }
    }
}