using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonEnitity.Users;

public class AppUser
{
    public int UserId { get; set; }
    public string? DisplayName { get; set; }
    [Required]
    public string UserName { get; set; }
    [Required]
    public string Password { get; set; }
    public string EmailID { get; set; }
    public DateTime? AddedOn { get; set; }
}

