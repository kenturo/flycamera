using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;
using System.Web.Mvc;
using Flycamera.Areas.Administrator.ViewModel;
using FlyEntity;
using FlyEntity.DataAccess;
using FlyEntity.Repositry;

namespace Flycamera.Areas.Administrator.Controllers.Team
{
    public class TeamController : Controller
    {
        private readonly IRepositryBase<Fly_Team> _repository = null;
        readonly TeamVm _vm = null; 

        public TeamController()
        {
            _vm = new TeamVm();
            _repository = new TeamDao();
        }

        //
        // GET: /Administrator/Team/

        public ActionResult Index()
        {
            try
            {
                _vm.ListTeam = _repository.getAllItems().Where(x => x.Published == true).ToList();
                return View(_vm.ListTeam);
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }

        public ActionResult Create()
        {
            try
            {
                return View(_vm);
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(TeamVm obj)
        {
            try
            {
                obj.Team.LanguageId = 1; // language vietnamese
                obj.Team.CreatedOn = DateTime.Now;
                obj.Team.Deleted = false;
                obj.Team.Published = obj.IsPublish;
                obj.Team.Deleted = obj.IsDelete;

                _repository.Add(obj.Team);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }

        public ActionResult Edit(int id)
        {
            try
            {
                _vm.Team = _repository.getItem(id);
                _vm.IsPublish = _vm.Team.Published.GetValueOrDefault();
                _vm.IsDelete = _vm.Team.Deleted.GetValueOrDefault();

                if (_vm.Team.Deleted == true)
                {
                    _vm.Team = null;
                    _vm.IsPublish = true;
                    _vm.IsDelete = false;
                }
                return View(_vm);
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(TeamVm obj)
        {
            try
            {
                obj.Team.Published = obj.IsPublish;
                obj.Team.Deleted = obj.IsDelete;
                _repository.Edit(obj.Team);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }

    }
}
