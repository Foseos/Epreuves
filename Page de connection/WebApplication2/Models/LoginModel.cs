using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Controllers
{
	public class LoginModel
	{
		[Required]
		[StringLength(10)]
		public string Utilisateur { get; set; }

		[Required]
		public string Motdepasse { get; set; }
	}
}