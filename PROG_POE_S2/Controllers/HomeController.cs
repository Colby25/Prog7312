using Microsoft.AspNetCore.Mvc;
using PROG_POE_S2.Models;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using System.Linq; 

namespace PROG_POE_S2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        //references: (https://khalidabuhakmeh.com/submitting-a-dictionary-to-an-asp-net-mvc-action , 2015)
        // Dictionary to store reported issues, with issue ID as the key
        public static Dictionary<int, Issue> IssuesDictionary = new Dictionary<int, Issue>();
        private static int _nextId = 1; // generates unique IDs for issues

        // Method to load the Report Issues view
        public IActionResult ReportIssues()
        {
            return View();
        }

        // Method to handle form submissions
        [HttpPost]
        public async Task<IActionResult> SubmitIssue(string location, string category, string description, IFormFile mediaAttachment)
        {
            // Generates a new unique ID for the issue
            int issueId = _nextId++;

            // Process the media attachment if provided
            string mediaPath = null;
            if (mediaAttachment != null && mediaAttachment.Length > 0)
            {
                mediaPath = await SaveFileAsync(mediaAttachment); 
            }

            // Create a new issue object
            var newIssue = new Issue
            {
                Id = issueId,
                Location = location,
                Category = category,
                Description = description,
                MediaPath = mediaPath
            };

            // Adds the issue to the dictionary
            IssuesDictionary.Add(issueId, newIssue);

            //reference https://medium.com/@andrezadossantosabrantes/viewbag-viewdata-and-tempdata-366951ce8798 , 2024)
            // Provide feedback to the user
            TempData["SuccessMessage"] = "Your issue has been reported successfully!";

            // Pass the updated list of issues to the success page
            return RedirectToAction("IssueSuccess");
        }



        // Method to display success page with reported issues
        public IActionResult IssueSuccess()
        {
            //reference https://medium.com/@andrezadossantosabrantes/viewbag-viewdata-and-tempdata-366951ce8798 , 2024)
            // Display the success message
            ViewBag.SuccessMessage = TempData["SuccessMessage"];

            // Pass the issues to the view
            return View(IssuesDictionary.Values.ToList());
        }


        //  file-saving logic is implemented here
        private async Task<string> SaveFileAsync(IFormFile file)
        {
            // Defines the path to save the file
            var uploads = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads");
            var filePath = Path.Combine(uploads, file.FileName);

            // Ensure the directory exists
            Directory.CreateDirectory(uploads);

            // Save the file 
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }

            return $"/uploads/{file.FileName}";
        }

        public IActionResult LocalEvents()
        {
            return View();
        }

        // Action to display the Service Request Status form
        public IActionResult ServiceRequestStatus()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}


