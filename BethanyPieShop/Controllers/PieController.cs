using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BethanyPieShop.Models;
using Microsoft.AspNetCore.Mvc;
using BethanyPieShop.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BethanyPieShop.Controllers
{
    public class PieController : Controller
    {
        private readonly IPieRepository pieRepository;
        private readonly ICategoryRepository categoryRepository;

        public PieController(IPieRepository pieRepository, 
            ICategoryRepository categoryRepository)
        {
            this.pieRepository = pieRepository;
            this.categoryRepository = categoryRepository;
        }

        public ViewResult List()
        {
            //ViewBag.tototo = "qs";

            var piesListViewModel = new PiesListViewModel();
            piesListViewModel.Pies = this.pieRepository.Pies;
            piesListViewModel.CurrentCategory = "toto cake";


            return this.View(piesListViewModel);
        }
    }
}
