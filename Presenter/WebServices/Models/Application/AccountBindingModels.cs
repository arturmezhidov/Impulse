using System.ComponentModel.DataAnnotations;

namespace Impulse.Presenter.WebServices.Models.Application
{
	public class AddExternalLoginBindingModel
	{
		[Required]
		[Display(Name = "Внешний маркер доступа")]
		public string ExternalAccessToken { get; set; }
	}

	public class ChangePasswordBindingModel
	{
		[Required]
		[DataType(DataType.Password)]
		[Display(Name = "Текущий пароль")]
		public string OldPassword { get; set; }

		[Required]
		[StringLength(100, ErrorMessage = "Значение {0} должно содержать не менее {2} символов.", MinimumLength = 6)]
		[DataType(DataType.Password)]
		[Display(Name = "Новый пароль")]
		public string NewPassword { get; set; }

		[DataType(DataType.Password)]
		[Display(Name = "Подтверждение нового пароля")]
		[Compare("NewPassword", ErrorMessage = "Новый пароль и его подтверждение не совпадают.")]
		public string ConfirmPassword { get; set; }
	}

	public class RegisterBindingModel
	{
		[Required(ErrorMessage = "Поле обязательно для заполнения")]
		[MaxLength(128, ErrorMessage = "Длина поля не может превышать 128 символов")]
		public string FirstName { get; set; }

		[Required(ErrorMessage = "Поле обязательно для заполнения")]
		[MaxLength(128, ErrorMessage = "Длина поля не может превышать 128 символов")]
		public string LastName { get; set; }

		[Required(ErrorMessage = "Поле обязательно для заполнения")]
		[MaxLength(128, ErrorMessage = "Длина поля не может превышать 128 символов")]
		public string Email { get; set; }

		[Required(ErrorMessage = "Поле обязательно для заполнения")]
		[MinLength(7, ErrorMessage = "Длина поля не может быть меньше 7 символов")]
		[MaxLength(15, ErrorMessage = "Длина поля не может превышать 15 символов")]
		public string Phone { get; set; }

		[Required]
		[StringLength(100, ErrorMessage = "Значение {0} должно содержать не менее {2} символов.", MinimumLength = 6)]
		[DataType(DataType.Password)]
		[Display(Name = "Пароль")]
		public string Password { get; set; }

		[DataType(DataType.Password)]
		[Display(Name = "Подтверждение пароля")]
		[Compare("Password", ErrorMessage = "Пароль и его подтверждение не совпадают.")]
		public string ConfirmPassword { get; set; }

		public int GroupId { get; set; }
	}

	public class RegisterExternalBindingModel
	{
		[Required]
		[Display(Name = "Адрес электронной почты")]
		public string Email { get; set; }
	}

	public class RemoveLoginBindingModel
	{
		[Required]
		[Display(Name = "Поставщик входа")]
		public string LoginProvider { get; set; }

		[Required]
		[Display(Name = "Ключ поставщика")]
		public string ProviderKey { get; set; }
	}

	public class SetPasswordBindingModel
	{
		[Required]
		[StringLength(100, ErrorMessage = "Значение {0} должно содержать не менее {2} символов.", MinimumLength = 6)]
		[DataType(DataType.Password)]
		[Display(Name = "Новый пароль")]
		public string NewPassword { get; set; }

		[DataType(DataType.Password)]
		[Display(Name = "Подтверждение нового пароля")]
		[Compare("NewPassword", ErrorMessage = "Новый пароль и его подтверждение не совпадают.")]
		public string ConfirmPassword { get; set; }
	}
}
