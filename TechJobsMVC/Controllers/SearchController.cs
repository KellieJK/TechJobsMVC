using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TechJobsMVC.Data;
using TechJobsMVC.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TechJobsMVC.Controllers
{
    public class SearchController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            ViewBag.columns = ListController.ColumnChoices;
            return View();
        }

        // TODO #3: Create an action method to process a search request and render the updated search view. 

        [HttpPost]
        //[Route("/Events/Add")]
        public IActionResult Jobs(string searchType, string searchTerm)
        {
            List<Job> jobs = new List<Job>();
            jobs = JobData.FindByValue(searchTerm);
            List<Job> results = new List<Job>();

            if (searchType.ToLower() == "employer")
            {
                foreach (Job job in jobs)
                {
                    if (job.Employer.ToString().ToLower().Contains(searchTerm.ToLower()))
                    {
                        results.Add(job);
                    }
                }
            }
            else if (searchType.ToLower() == "location")
            {
                foreach (Job job in jobs)
                {
                    if (job.Location.ToString().ToLower().Contains(searchTerm.ToLower()))
                    {
                        results.Add(job);
                    }
                }
            }
            else if (searchType.ToLower() == "positionType")
            {
                foreach (Job job in jobs)
                {
                    if (job.PositionType.ToString().ToLower().Contains(searchTerm.ToLower()))
                    {
                        results.Add(job);
                    }
                }
            }
            else if (searchType.ToLower() == "coreCompetency")
            {
                foreach (Job job in jobs)
                {
                    if (job.CoreCompetency.ToString().ToLower().Contains(searchTerm.ToLower()))
                    {
                        results.Add(job);
                    }
                }
            }
       
            else
            {
                results = jobs;
            }

            ViewBag.jobs = results;
            return View();
        }
    }

}