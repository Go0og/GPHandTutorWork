using Contracts.BindingModel;
using DataModel.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.StorageContract.dbModels
{
	public class Tutor : ITutor
	{
		public int Id { get; set;}
		[Required]
		public string FIO { get; set; } = string.Empty;
		[Required]
		public string Login { get; set; } = string.Empty;
		[Required]
		public string Password { get; set; } = string.Empty;	

		public static Tutor? Create (TutorBindingModel Model)
		{
			if (Model == null)
			{
				return null;
			}
			return new Tutor()
			{
				Id = Model.Id,
				FIO = Model.FIO,
				Login = Model.Login,
				Password = Model.Password
			};
		}
		public void update(TutorBindingModel model)
		{
			if (model == null)
			{
				return;
			}
			FIO = model.FIO;
			Login = model.Login;
			Password = model.Password;
		}
	}
}
