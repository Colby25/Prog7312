# Municipality services application 

## Overview
The project was built in .NET Core MVC web application, its main goal is to enable users to report issues in a dynamic engagement strategy which will encourage users to actively participate to report issues in their community for the municipality to fix. These issues include, roads, sanitization, utilities and the infrastructure upon startup the application presents the user with a main menu from where they can choose to navigate to three pages: Report issues, service request status and events. The final part focuses on displaying service request, and their statuses these information is displayed and organized through data structures like a binary search tree, and a Graph traversal.

# Prerequsites:
  -	Visual Studio 2022 (or later) with .NET Core SDK installed.
  -	A web browser to access the application.

# How to Compile:
1. Clone the repo using the web URL in the GitHub repository
2. Open Visual Studio.
3. Click on File → Clone Repository.
4. Enter the repository URL: https://github.com/Colby25/Prog7312.git
5. Click Clone. 
6. After cloning, Visual Studio should automatically open the project.
7. If not, go to File → Open → Project/Solution, and then navigate to the .sln file in the cloned project folder.
8. If you encounter build errors, ensure all packages are restored by right-clicking on the solution in the Solution Explorer and selecting "Restore NuGet Packages".

# How to Run the Program:
1. Launch the application by pressing F5 or by navigating to Debug > Start Debugging.
2. Access the main application page via the provided local URL.
3. Visual Studio will build the project and launch it.
4. By default, the application will open in your default web browser

# How to Use
1.	### Main menu: On startup the user will be presented with 3 options to choose from 
    1.1 Report issues (implemented)
    1.2	Service request status (implemented)
    1.3 Local events and anouncements (implemented)
![Screenshot (534)](https://github.com/user-attachments/assets/bf15f0e7-50c1-479a-9cef-c7be2ef3c807)

2. ### Report Issues: Issues can be reported through the following:
   - Location input: a simble textbox for users to input the location of the issue
   - Category selection: A dropdown for selecting the following categorys: sanitization, roads, utilities, infrastructure.
   - Description: A richTextbox where users can provide a in depth explanation of the issue.
   - Media attachment: a button where users can attach images regarding the issue.
   - Engagement feature: A progress bar with a motivational message which fills as the user inputs their data this encourages participation and user engagement. 
   -	After submission the user is redirected to a Issue Success page where they can view all previous submitted issues, displayed in a table.
   -	To submit another report, use the back button to return to the issue reporting form.
 ![image](https://github.com/user-attachments/assets/78fb6f9a-c598-42d2-9dc0-b66190b10cb9)
 ![image](https://github.com/user-attachments/assets/23ac9afb-5a75-4c1b-8095-5e29ea8ff5d3)

3. ### Local events page:
   - Users can now navigate to the events page from the main menu page by clicking the blue button.
   - users can view all the upcoming events, and see the dates on the calender
   -	Users can filter the events by selecting date and category, this will display the events in that category
   -	If a user selects a specific date for the category that event will show up and all the other events on th ediffernt dates for that same category will be displayed as recommended events.
   -	The events are displayed in a aestetically pleasing manner , with cool hover effects that make them more visible.

  ![Screenshot (527)](https://github.com/user-attachments/assets/a7f771af-23a2-45a4-b318-77bead54e5ae)

  ![Screenshot (532)](https://github.com/user-attachments/assets/1f5073ba-073f-4689-a878-0d5d20c85262)

  ![Screenshot (533)](https://github.com/user-attachments/assets/42c956fc-03c4-44a7-9bca-6cdb14484824)
   
4. ### Service request page:
   - Navigate to the "Service Request Status" page from the main menu which will be displayed to the user upon startup to see a list of all requests by tracking a service using the ID as a unique identifier.
   - Enter the service request ID in the provided form and click the "Track" button.
   - Results, including related service requests, are displayed if applicable.
   - Specify a start ID for graph traversal, and the BFS traversal results will be shown.
  
   # In-depth Explanation of Data Structures: 
1.	Binary Search Tree (BST) Explanation:
-	Role:	Service requests are efficiently managed and stored through the use of a binary search tree. Every node represents a unique identifier which is the service request ID and the data associated with it, for example, the description & status. 
-	Contribution to Efficiency:	The binary search tree is efficient for operations like inserting, deleting, and tracking with a time complexity of O(log ). Thus for the scenario of tracking a service request status, this efficiency makes it possible to quickly track service requests using the ID / the unique identifier.
-	Example:	A node can quickly be tracked through a binary search, for example when a user wants to track a service request with ID 2, it can quickly be located, and it is then not needed to traverse the whole list of requests. Especially in large datasets, the BST is a lot faster in comparison to linear search. Example:	You search for ID 4 in the BST, which returns:
“Service Request Found: Park Cleanup - Status: Scheduled”
“Related Service Requests:”
“Service Request ID: 1”
“Service Request ID: 5”
-	This is because the Search method in the BST found 4 and then fetched related requests from the graph via GetConnections(4) (which returns 1 and 5 due to the edges defined in the graph).

2.	Graph Traversal using Breadth-First Search (BFS) Explanation:
-	Role:	Relationships between the service request are represented through the use of a graph data structure, in this case where nodes are service requests and edges represent connections, like related tasks for example. These connections are explored layer by layer using Breadth first search, and the start point is from the node that’s specified / or known as the service request in this scenario.
-	Contribution to Efficiency:	BFS finds the shortest path, related service request, by making sure all the nodes at the current level are visited before going to the next level.
-	For example: The BFS traversal will start at the node which a user selects let's say a user selects a service request with an ID of 2, it will then explore all directly related requests before going to the next level of related nodes. This will help users to identify and view all linked service requests related to one another. Example: You performed a graph traversal starting at ID 4, which used BFS to explore all connected nodes. The traversal returned:
"Service Request ID: 4" (The start node)
"Service Request ID: 1"
"Service Request ID: 5"
"Service Request ID: 2"
"Service Request ID: 3"
- The BFS started at 4, then moved to its connected nodes 1 and 5, then explored their connections: ( 2 from 1, and 3 from 2), resulting in the output above.



