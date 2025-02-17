using Contracts.InteractorContract;
using Contracts.PresenterContract;
using Contracts.StorageContract;
using DataBaseImplement.Implements;
using Interactors;
using Interactors.OfficePackage;
using Interactors.OfficePackage.Implements;
using Microsoft.OpenApi.Models;
using Presenter;
using Presenters;

namespace WebApplicationRestAPI {
    public class Program {
        public static void Main(string[] args) {
            var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.

			// ------STORAGE------
			builder.Services.AddTransient<IAppointmentHeadmanStorage, AppointmentHeadmanStorage>();
			builder.Services.AddTransient<ICurriculumStorage, CurriculumStorage>();
			builder.Services.AddTransient<IGPHAgreementStorage, GPHAgreementStorage>();
			builder.Services.AddTransient<IGroupStorage, GroupStorage>();
			builder.Services.AddTransient<IOfficialNoteStorage, OfficialNoteStorage>();
			builder.Services.AddTransient<IProgressControlStorage, ProgressControlStorage>();
			builder.Services.AddTransient<IStudentStorage, StudentStorage>();
			builder.Services.AddTransient<ITeacherStorage, TeacherStorage>();
			builder.Services.AddTransient<ITutorStorage, TutorStorage>();
			builder.Services.AddTransient<IUniversityEmployeeStorage, UniversityEmployeeStorage>();
			builder.Services.AddTransient<IWorkTutorStorage, WorkTutorStorage>();

			// ------INTERACTORS------
			builder.Services.AddTransient<IAppointmeanHeadmanLogic, AppointmeanHeadmanLogic>();
            builder.Services.AddTransient<ICurriculumLogic, CurriculumLogic>();
            builder.Services.AddTransient<IGPHAgreementLogic, GPHAgreementLogic>();
            builder.Services.AddTransient<IGroupLogic, GroupLogic>();
            builder.Services.AddTransient<IOfficialNoteLogic, OfficialNoteLogic>();
            builder.Services.AddTransient<IProgressControlLogic, ProgressControlLogic>();
            builder.Services.AddTransient<IStudentLogic, StudentLogic>();
            builder.Services.AddTransient<ITeacherLogic, TeacherLogic>();
            builder.Services.AddTransient<ITutorLogic, TutorLogic>();
            builder.Services.AddTransient<IUniversityEmployeeLogic, UniversiteEmployeeLogic>();
            builder.Services.AddTransient<IWorkTutorLogic, WorkTutorLogic>();
            builder.Services.AddTransient<IReportTutorLogic, ReportTutorLogic>();
			builder.Services.AddTransient<IReportEmployeeLogic, ReportEmployeeLogic>();

			// ------ABSTRACT------
			builder.Services.AddSingleton<AbstractOfficialNoteWord, SaveToWordNote>();
			builder.Services.AddSingleton<AbstractWorkTutorWord, SaveToWordWork>();
			builder.Services.AddSingleton<AbstractWordTeacherGPH, SaveToWordTeacherGPH>();


			// ------PRESENTER------
			builder.Services.AddTransient<IAppointmeanHeadmanPresenter, AppointmeanHeadmanPresenter>();
			builder.Services.AddTransient<ICurriculumPresenter, CurriculumPresenter>();
			builder.Services.AddTransient<IGPHAgreementPresenter, GPHAgreementHeadmanPresent>();
			builder.Services.AddTransient<IGroupPresenter, GroupPresenter>();
			builder.Services.AddTransient<IOfficialNotePresenter, OfficialNotePresenter>();
			builder.Services.AddTransient<IProgressControlPrestnter, ProgressControlPresenter>();
			builder.Services.AddTransient<IStudentPrestnter, StudentPresenter>();
			builder.Services.AddTransient<ITeacherPresenter, TeacherPresenter>();
			builder.Services.AddTransient<ITutorPresenter, TutorPresenter>();
			builder.Services.AddTransient<IUniversityEmployeePresenter, UniversityEmployeePresenter>();
			builder.Services.AddTransient<IWorkTutorPresenter, WorkTutorPresenter>(); 

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(s => s.SwaggerDoc("v1", new OpenApiInfo {
                Title = "GPHandTutorWorkApp",
                Version = "V1"
            }));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment()) {
                app.UseSwagger();
                app.UseSwaggerUI(s => s.SwaggerEndpoint("/swagger/v1/swagger.json",
								"GPHandTutorWorkApp v1"));
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
