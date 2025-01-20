using Contracts.PresenterContract;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace WebApplicationRestAPI.Controllers {

    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MainController {
        private readonly IAppointmeanHeadmanPresenter _AppointmeanPresent;
        private readonly ICurriculumPresenter _CurriculumPresent;
        private readonly IGPHAgreementPresenter _GPHAgreementPresenter;
        private readonly IGroupPresenter _GroupPresenter;
        private readonly IOfficialNotePresenter _OfficialNotePresenter;
        private readonly IProgressControlPrestnter _ProgressControlPresenter;
        private readonly IStudentPrestnter _StudentPresenter;
        private readonly ITeacherPresenter _TeacherPresenter;
		private readonly ITutorPresenter _TutorPresenter;
		private readonly IUniversityEmployeePresenter _UniversityEmployeePresenter;
		private readonly IWorkTutorPresenter _WorkTutorPresenter;

		public MainController(IAppointmeanHeadmanPresenter appointmeanHeadmanPresenter, ICurriculumPresenter curriculumPresenter,
            IGPHAgreementPresenter GPHAgreementPresenter, IGroupPresenter groupPresenter, IOfficialNotePresenter officialNotePresenter, IProgressControlPrestnter progressControlPrestnter, 
            IStudentPrestnter studentPrestnter, ITeacherPresenter teacherPresenter, ITutorPresenter tutorPresenter, IUniversityEmployeePresenter universityEmployeePresenter, IWorkTutorPresenter workTutorPresenter)
        { 
            _AppointmeanPresent = appointmeanHeadmanPresenter;
            _CurriculumPresent = curriculumPresenter;
            _GPHAgreementPresenter = GPHAgreementPresenter;
            _GroupPresenter= groupPresenter;
            _TeacherPresenter = teacherPresenter;
            _OfficialNotePresenter = officialNotePresenter;
            _ProgressControlPresenter = progressControlPrestnter;
            _StudentPresenter = studentPrestnter;
            _TeacherPresenter = teacherPresenter ;
            _TutorPresenter = tutorPresenter ;
            _UniversityEmployeePresenter = universityEmployeePresenter;
            _WorkTutorPresenter = workTutorPresenter;
        }

       
    }
}
