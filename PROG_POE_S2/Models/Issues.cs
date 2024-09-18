namespace PROG_POE_S2.Models
{
    public class Issue
    {
        public int Id { get; set; } // Unique identifier for the issue
        public string Location { get; set; } // Location of the reported issue
        public string Category { get; set; } // Category of the issue like sanitation, roads etc...
        public string Description { get; set; } // Detailed description of the issue
        public string MediaPath { get; set; } // Path to the media file 
    }
}
