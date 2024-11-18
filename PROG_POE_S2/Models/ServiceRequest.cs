public class ServiceRequest
{
    // Unique identifier for the service request
    public int Id { get; set; }

    public string Description { get; set; }

    public string Status { get; set; }

    // Reference to the left child node in a binary search tree
    public ServiceRequest Left { get; set; }

    // Reference to the right child node in a binary search tree
    public ServiceRequest Right { get; set; }

    // Constructor to initialize a new instance of the ServiceRequest class
    public ServiceRequest(int id, string description, string status)
    {
        Id = id; 
        Description = description; 
        Status = status; 
        Left = null; // Set the left child node reference to null (no child initially)
        Right = null; // Set the right child node reference to null (no child initially)
    }
}
