using Contracts.BindingModel;
using DataModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Contracts.StorageContract.dbModels
{
	public class GPHAgreement : IGPHAgreement
	{
		public int Id {get; set;}
		public DateTime DateOfConclusion {get; set;}

		public DateTime DataEnd {get; set;}

		public int UniversityEmployeeId {get; set;}
		public UniversityEmployee? UniversityEmployee {get; set;}

		public int TeacherId {get; set;}
		public Teacher? Teacher {get; set;}

		public List<int> CurriculumList {get; set;}
		public Curriculum? Curriculum {get; set;} 

		public double Bet {get; set;}

		public static GPHAgreement? Create(GPHAgreementBindingModel Model)
		{
			if (Model == null)
			{
				return null;
			}
			return new GPHAgreement()
			{
				Id = Model.Id,
				DataEnd = Model.DataEnd,
				DateOfConclusion = Model.DateOfConclusion,
				UniversityEmployeeId = Model.UniversityEmployeeId,
				TeacherId = Model.TeacherId,
				CurriculumList = Model.CurriculumList,
				Bet = Model.Bet,

			};
		}
		public void Update(GPHAgreementBindingModel Model)
		{
			if (Model == null)
			{
				return;
			}
			Id = Model.Id;
			DateOfConclusion = Model.DateOfConclusion;
			DataEnd = Model.DataEnd;
			UniversityEmployeeId = Model.UniversityEmployeeId;
			TeacherId = Model.TeacherId;
			CurriculumList = Model.CurriculumList;
			Bet = Model.Bet;
		}
	}
}
