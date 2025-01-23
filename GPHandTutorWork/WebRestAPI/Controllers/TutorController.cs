using Contracts.BindingModel;
using Contracts.InteractorContract;
using Contracts.PresenterContract;
using Contracts.SearchModel;
using Contracts.ViewContract;
using Microsoft.AspNetCore.Mvc;

namespace WebApplicationRestAPI.Controllers {

    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TutorController : Controller {

        private readonly ITutorLogic _TutorLogic;
        private readonly ITutorPresenter _TutorPresenter; 

        public TutorController(ITutorLogic TutoLogic, ITutorPresenter TutorPresenter) {
            _TutorPresenter = TutorPresenter;
            _TutorLogic = TutoLogic;
        }

        [HttpPost]
        public void register(TutorBindingModel model) {
            try {
                _TutorLogic.CreateTutor(model);
            }
            catch (Exception ex) {
                throw;
            }
        }

        [HttpGet]
        public TutorViewModel? login(string Login, string password) {
            try {
                return _TutorPresenter.MakeTutorPresenter(new TutorSearchModel {
                    Login = Login,
                    Password = password
                });
            }
            catch (Exception ex) {
                throw;
            }
        }

        [HttpPost]
        public void edit(TutorBindingModel model) {
            try {
                _TutorLogic.UpdateTutor(model);
            }
            catch (Exception ex) {
                throw;
            }
        }
        /*          //потом разобрать зачем это было тут
        [HttpGet]
        public List<template_view_model>? get_user_template_list(int userId) {
            try {
                return _userPresenter.make_user_presenter(new user_search_model { id = userId }).templates;
            }
            catch (Exception ex) {
                throw;
            }
        }
        */
    }
}
