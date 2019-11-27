using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.DTO
{
    public class LoginDTO
    {

        [Required(ErrorMessage = "Yêu cầu nhập tên tài khoảng !!!")]
        [StringLength(50, MinimumLength = 3)]
        public string Account { get; set; }
        
        [Required(ErrorMessage = "Yêu cầu nhập tên mật khẩu !!!")]
        public string Password { get; set; }
        
        public bool Remember { get; set; }
    }
}
