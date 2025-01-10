using Contracts.SearchModel;
using Contracts.StorageContract;
using Contracts.StorageContract.dbModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseImplement.Implements
{
	public class CurriculumStorage : ICurriculumStorage
	{
		public Curriculum? GetCurriculum(CurriculumSearchModel SearchModel)
		{
			using var context = new DataBaseImplement();
			if (SearchModel.Id.HasValue)
			{
				return context.Curriculums
					.Include(x => x.Group)
					.Include(x => x.Subject)
					.Include(x => x.AttestationForm)
					.Include(x => x.PracticalHours)
					.Include(x => x.ConsultationExam)
					.Include(x => x.TheoreticalHours)
					.Include(x => x.Term)
					.Include(x => x.PracticalHours)
					.Include(x => x.Exam)
					.FirstOrDefault(x => x.Id == SearchModel.Id);
			}
			return null;

		}

		public List<Curriculum> GetFillteredList(CurriculumSearchModel SearchModel)
		{
			using var context = new DataBaseImplement();
			if (SearchModel.Id.HasValue)
			{
				return context.Curriculums
					.Where(x => x.Id == SearchModel.Id)
					.Include(x => x.Group)
					.Include(x => x.Subject)
					.Include(x => x.AttestationForm)
					.Include(x => x.PracticalHours)
					.Include(x => x.ConsultationExam)
					.Include(x => x.TheoreticalHours)
					.Include(x => x.Term)
					.Include(x => x.PracticalHours)
					.Include(x => x.Exam)
					.ToList();
			}
			return new();
		}

		public List<Curriculum> GetFullList()
		{
			using var context = new DataBaseImplement();
			return context.Curriculums.ToList();
		}
	}
}
