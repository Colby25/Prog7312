namespace PROG_POE_S2.Graph
{
    using System;
    using System.Collections.Generic;

    //reference:
    //Youtube video, 2021, Graph Data Structure | Traversal | Depth | Breadth First Search | C# , TechWebDots :https://youtu.be/-xdKCoYrfZE?si=1_yic8YhyozaLOb7
    //understood how the differnt nodes connect to one another 
    public class ServiceGraph
    {
        // Represents connections in the graph where each node maps to connected nodes
        private Dictionary<int, List<int>> adjacencyList = new Dictionary<int, List<int>>();

        // Adds a node (service request) to the graph
        public void AddNode(int id)
        {
            if (!adjacencyList.ContainsKey(id))
            {
                adjacencyList[id] = new List<int>();
            }
        }

        // Creates an edge between two nodes (representing a dependency)
        public void AddEdge(int fromId, int toId)
        {
            if (adjacencyList.ContainsKey(fromId) && adjacencyList.ContainsKey(toId))
            {
                adjacencyList[fromId].Add(toId);
            }
            else
            {
                Console.WriteLine("One or both nodes not found in the graph.");
            }
        }

        // Returns a list of connections for a given node
        public List<int> GetConnections(int id)
        {
            return adjacencyList.ContainsKey(id) ? adjacencyList[id] : new List<int>();
        }

        // BFS traversal from a start node
        public List<int> BFS(int startId)
        {
            var visited = new HashSet<int>();
            var queue = new Queue<int>();
            var result = new List<int>();

            if (!adjacencyList.ContainsKey(startId))
            {
                return result;
            }

            queue.Enqueue(startId);
            visited.Add(startId);

            while (queue.Count > 0)
            {
                int current = queue.Dequeue();
                result.Add(current);

                foreach (var neighbor in adjacencyList[current])
                {
                    if (!visited.Contains(neighbor))
                    {
                        visited.Add(neighbor);
                        queue.Enqueue(neighbor);
                    }
                }
            }

            return result;
        }
    }
}