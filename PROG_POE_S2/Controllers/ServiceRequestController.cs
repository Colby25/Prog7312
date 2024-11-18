using Microsoft.AspNetCore.Mvc;
using PROG_POE_S2.Graph;
using PROG_POE_S2.Tree;
using System.Collections.Generic;

namespace PROG_POE_S2.Controllers
{
    public class ServiceRequestController : Controller
    {
        // Static instances of Binary Search Tree (BST) and Graph for managing service requests
        private static BinarySearchTree bst = new BinarySearchTree();
        private static ServiceGraph graph = new ServiceGraph();

        static ServiceRequestController()
        {
            // Adds service requests to the binary search tree (BST)
            bst.Insert(1, "Fix Water Leakage", "In Progress");
            bst.Insert(2, "Street Light Repair", "Pending");
            bst.Insert(3, "Pothole Repair", "Completed");
            bst.Insert(4, "Park Cleanup", "Scheduled");
            bst.Insert(5, "Building Inspection", "Completed");
            bst.Insert(6, "Road Resurfacing", "In Progress");
            bst.Insert(7, "Tree Trimming", "Pending");
            bst.Insert(8, "Drainage Maintenance", "In Progress");
            bst.Insert(9, "Playground Repair", "Scheduled");

            // Populates the graph with nodes representing service requests
            graph.AddNode(1);
            graph.AddNode(2);
            graph.AddNode(3);
            graph.AddNode(4);
            graph.AddNode(5);
            graph.AddNode(6);
            graph.AddNode(7);
            graph.AddNode(8);
            graph.AddNode(9);

            // Establish connections (edges) to represent dependencies or relationships between service requests
            graph.AddEdge(1, 2); // Service Request 1 depends on 2
            graph.AddEdge(2, 3); // Service Request 2 depends on 3
            graph.AddEdge(4, 1); // Service Request 4 depends on 1
            graph.AddEdge(4, 5); // Service Request 4 depends on 5
            graph.AddEdge(6, 3); // Service Request 6 depends on 3
            graph.AddEdge(6, 8); // Service Request 6 depends on 8
            graph.AddEdge(7, 5); // Service Request 7 depends on 5
            graph.AddEdge(8, 7); // Service Request 8 depends on 7
            graph.AddEdge(9, 4); // Service Request 9 depends on 4
        }

        //  fetch and display all service requests
        public IActionResult Index()
        {
            List<ServiceRequest> serviceRequests = bst.GetAllServiceRequests() ?? new List<ServiceRequest>();
            return View("~/Views/Home/ServiceRequestStatus.cshtml", serviceRequests); // Pass the list of service requests to the view
        }

        [HttpPost]
        public IActionResult TrackRequest(int id)
        {
            if (id <= 0)
            {
                ViewBag.Message = "Invalid Service Request ID.";
                ViewBag.RelatedRequests = new List<ServiceRequest>();
                return View("~/Views/Home/ServiceRequestStatus.cshtml", bst.GetAllServiceRequests());
            }

            // Search for the service request by ID in the BST
            ServiceRequest request = bst.Search(id);
            if (request != null)
            {
                ViewBag.Message = $"Service Request Found: {request.Description} - Status: {request.Status}";

                // Find related requests based on graph connections
                var relatedRequests = new List<ServiceRequest>();
                foreach (var relatedId in graph.GetConnections(id))
                {
                    var relatedRequest = bst.Search(relatedId);
                    if (relatedRequest != null)
                    {
                        relatedRequests.Add(relatedRequest);
                    }
                }

                ViewBag.RelatedRequests = relatedRequests;
                return View("~/Views/Home/ServiceRequestStatus.cshtml", bst.GetAllServiceRequests());
            }
            else
            {
                ViewBag.Message = "Service Request Not Found.";
                ViewBag.RelatedRequests = new List<ServiceRequest>();
                return View("~/Views/Home/ServiceRequestStatus.cshtml", bst.GetAllServiceRequests());
            }
        }

        // Action for performing a graph traversal starting from a specified node ID
        public IActionResult GraphTraversal(int startId)
        {
            if (startId <= 0)
            {
                ViewBag.Message = "Invalid Start ID for Graph Traversal.";
                return View("~/Views/Home/ServiceRequestStatus.cshtml", bst.GetAllServiceRequests());
            }

            // Perform a BFS traversal and collect results
            List<int> traversalResult = graph.BFS(startId);
            var detailedTraversal = new List<ServiceRequest>();

            foreach (var nodeId in traversalResult)
            {
                var request = bst.Search(nodeId);
                if (request != null)
                {
                    detailedTraversal.Add(request);
                }
            }

            ViewBag.TraversalResult = detailedTraversal; // Pass the traversal result to the view
            return View("~/Views/Home/ServiceRequestStatus.cshtml", bst.GetAllServiceRequests());
        }
    }
}