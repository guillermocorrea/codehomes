using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Mvc;
using CodedHomes.Data;
using CodedHomes.Web.ViewModels;

namespace CodedHomes.Web.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [System.Web.Mvc.Authorize]
    public class HomesController : Controller
    {
        /// <summary>
        /// The _unit
        /// </summary>
        private ApplicationUnit _unit = new ApplicationUnit();

        /// <summary>
        /// Indexes this instance.
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        public ActionResult Index()
        {
            HomesListViewModel viewModel = new HomesListViewModel();
            var query = this._unit.Homes.GetAll().OrderByDescending(h => h.Price);
            viewModel.Homes = query.ToList();
            return View("Index", viewModel);
        }

        /// <summary>
        /// Releases unmanaged resources and optionally releases managed resources.
        /// </summary>
        /// <param name="disposing">true to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
        protected override void Dispose(bool disposing)
        {
            if (this._unit != null)
            {
                this._unit.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}
