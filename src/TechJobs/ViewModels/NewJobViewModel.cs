using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TechJobs.Data;
using TechJobs.Models;

namespace TechJobs.ViewModels
{
    public class NewJobViewModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Employer")]
        public int EmployerID { get; set; }

        // TODO #3 - Included other fields needed to create a job,
        // with correct validation attributes and display names.

        public List<SelectListItem> Employers { get; set; } = new List<SelectListItem>();

        [Required]
        [Display(Name = "Location")]
        public int LocationID { get; set; }//This corresponds with Locationid that found in the view New.cshtml

        public List<SelectListItem> Locations { get; set; } = new List<SelectListItem>();//this initalize the list that is filled below see line 56 to 63
        // both property LocationID and List<SelectListItem> Locations are link to one another via form in Newcshtml

        [Required]
        [Display(Name = "Skills")]
        public int CoreCompetencyID { get; set; }

        public List<SelectListItem> CoreCompetencies { get; set; } = new List<SelectListItem>();

        [Required]
        [Display(Name = "PositionTypes")]
        public int PositionTypeID { get; set; }

        public List<SelectListItem> PositionTypes { get; set; } = new List<SelectListItem>();

        public NewJobViewModel()
        {

            JobData jobData = JobData.GetInstance();

            foreach (Employer field in jobData.Employers.ToList())
            {
                Employers.Add(new SelectListItem {
                    Value = field.ID.ToString(),
                    Text = field.Value
                });
            }

            // TODO #4 - populate the other List<SelectListItem> 
            // collections needed in the view
            foreach (Location field in jobData.Locations.ToList())//type is a list property in JobData.cs
            {
                Locations.Add(new SelectListItem
                {
                    Value = field.ID.ToString(),
                    Text = field.Value
                });
            }

            foreach (PositionType field in jobData.PositionTypes.ToList())//jobData.PositionTypes.ToList() from the fields found in this NewJobViewModel.cs
            {
                PositionTypes.Add(new SelectListItem
                {
                    Value = field.ID.ToString(),
                    Text = field.Value
                });
            }

            foreach (CoreCompetency field in jobData.CoreCompetencies.ToList())
            {
                CoreCompetencies.Add(new SelectListItem
                {
                    Value = field.ID.ToString(),
                    Text = field.Value
                });
            }

        }
    }
}
