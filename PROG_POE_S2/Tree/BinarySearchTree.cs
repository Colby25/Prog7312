namespace PROG_POE_S2.Tree
{
    //Reference:
    //Youtube video, 2019, Binary search tree implemented in C# , kc70 :https://youtu.be/pN1RWeX47tg?si=Hq-iH-wLUAUL5i_p 
    
    public class BinarySearchTree
    {
        private ServiceRequest root;

        // Inserts a new service request into the tree
        public void Insert(int id, string description, string status)
        {
            var newRequest = new ServiceRequest(id, description, status);
            if (root == null)
            {
                root = newRequest;
            }
            else
            {
                InsertRecursive(root, newRequest);
            }
        }

        // Helper for inserting nodes recursively
        private void InsertRecursive(ServiceRequest current, ServiceRequest newRequest)
        {
            if (newRequest.Id < current.Id)
            {
                if (current.Left == null)
                    current.Left = newRequest;
                else
                    InsertRecursive(current.Left, newRequest);
            }
            else
            {
                if (current.Right == null)
                    current.Right = newRequest;
                else
                    InsertRecursive(current.Right, newRequest);
            }
        }

        // Retrieves all service requests using in-order traversal
        public List<ServiceRequest> GetAllServiceRequests()
        {
            var serviceRequests = new List<ServiceRequest>();
            TraverseInOrder(root, serviceRequests);
            return serviceRequests;
        }

        // In-order traversal to collect nodes
        private void TraverseInOrder(ServiceRequest node, List<ServiceRequest> serviceRequests)
        {
            if (node != null)
            {
                TraverseInOrder(node.Left, serviceRequests);
                serviceRequests.Add(node);
                TraverseInOrder(node.Right, serviceRequests);
            }
        }

        // Searches for a service request by ID
        public ServiceRequest Search(int id)
        {
            return SearchRecursive(root, id);
        }

        // Helper for recursive search
        private ServiceRequest SearchRecursive(ServiceRequest node, int id)
        {
            if (node == null || node.Id == id)
                return node;
            return id < node.Id ? SearchRecursive(node.Left, id) : SearchRecursive(node.Right, id);
        }
    }
}