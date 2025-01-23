using Contracts.BindingModel;
using Contracts.SearchModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.InteractorContract
{
	public interface IProgressControlLogic
	{
		public List<ProgressControlBindingModel> GetFullList(ProgressControlSearchModel? SearchModel);
		public ProgressControlBindingModel GetProgressControl(ProgressControlSearchModel SearchModel);
	}
}
