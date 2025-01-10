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
	public class UniversityEmployee : IUniversityEmployee
	{
		public int Id {get; set;}
		public string FIO { get; set; } = string.Empty;
		public string Login { get; set; } = string.Empty;
		public string Password { get; set; } = string.Empty;
		public static UniversityEmployee? Create(UniversityEmployeeBindingModel Model)
		{
			if (Model == null)
			{
				return null;
			}
			return new UniversityEmployee()
			{
				Id = Model.Id,
				FIO = Model.FIO,
				Login = Model.Login,
				Password = Model.Password
			};
		}
		public void update(UniversityEmployeeBindingModel model)
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
