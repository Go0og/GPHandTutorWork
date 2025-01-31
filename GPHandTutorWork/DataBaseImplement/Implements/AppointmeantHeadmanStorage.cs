using Contracts.BindingModel;
using Contracts.SearchModel;
using Contracts.StorageContract;
using Contracts.StorageContract.dbModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseImplement.Implements
{
	public class AppointmentHeadmanStorage : IAppointmentHeadmanStorage
	{

		public bool CreateAppointmentHeadman(AppointmentHeadmanBindingModel Model)
		{
			using var context = new DataBaseImplement();

			if (UpdateAppointmentHeadman(SearchAppointmeanHeadman_InGroup(context.Students.FirstOrDefault(x => x.Id == Model.StudentId))))
			{
				return true;
			}

			var NewAppoinmeant = AppointmentHeadman.Create(Model);
			if (NewAppoinmeant == null)
			{
				return false;
			}
			context.Appointments.Add(NewAppoinmeant);

			context.SaveChanges();
			return true;
		}
		public bool UpdateAppointmentHeadman(AppointmentHeadmanBindingModel Model)
		{
			using var context = new DataBaseImplement();
			var UpdateAppointment = context.Appointments.FirstOrDefault(x => x.Id == Model.Id );
			if(UpdateAppointment == null)
			{
				return false;
			}
			UpdateAppointment.update(Model);
			context.SaveChanges();
			return true;
		}
		public bool DeleteAppointmentHeadman(AppointmentHeadmanBindingModel Model)
		{
			using var context = new DataBaseImplement();
			var DelAppointment = context.Appointments.FirstOrDefault(x=>x.Id == Model.Id);
			if (DelAppointment == null)
			{
				return false;
			}
			context.Appointments.Remove(DelAppointment);
			context.SaveChanges();
			return true;
		}


		public AppointmentHeadman? GetAppointmentHeadman(AppointmentHeadmanSearchModel SearchModel)
		{
			using var context = new DataBaseImplement();
			if (SearchModel.Id.HasValue)
			{
				return context.Appointments
					.Include(x=>x.Tutor)
					.Include(x=>x.Student)
					.FirstOrDefault(x=>x.Id == SearchModel.Id);
			}
			if (SearchModel.StudentId.HasValue)
			{
				return context.Appointments
					.Include(x => x.Tutor)
					.Include(x => x.Student)
					.FirstOrDefault(x => x.StudentId == SearchModel.StudentId);
			}
			return null;
		}
		
		public List<AppointmentHeadman> GetFillteredList(AppointmentHeadmanSearchModel SearchModel)
		{
			using var context = new DataBaseImplement();
			if (SearchModel.TutorId.HasValue)
			{
				return context.Appointments
					.Where(x => x.TutorId == SearchModel.TutorId)
					.Include(x => x.Tutor)
					.Include(x => x.Student)
					.ToList();
			}
			return new();
		}

	
		public List<AppointmentHeadman> GetFullList()
		{
			using var context = new DataBaseImplement();
			return context.Appointments.ToList();
		}

		//----------------------------признак единственной ответственности (SPR)------------------------------------

		private AppointmentHeadmanBindingModel? SearchAppointmeanHeadman_InGroup(Student student)
		{
			using var context = new DataBaseImplement();

			var StudentsInGroups = context.Students.Where(x => x.GroupId == student.GroupId).ToList();

			foreach (var stud in StudentsInGroups)
			{
				var StudentHeadman = GetAppointmentHeadman(new AppointmentHeadmanSearchModel
				{
					StudentId = stud.Id,
				});
				if (StudentHeadman != null) 
				{
					return new AppointmentHeadmanBindingModel
					{
						Id = StudentHeadman.Id,
						StudentId = student.Id,
						TutorId = StudentHeadman.TutorId
					};
				}
			}
			return null;
		}

	}
}
