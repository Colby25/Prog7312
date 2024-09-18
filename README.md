# Municipality services application 

## Overview
The project was built in .NET Core MVC web application, its main goal is to enable users to report issues in a dynamic engagement strategy which will encourage users to actively participate to report issues in their community for the municipality to fix. These issues include, roads, sanitization, utilities and the infrastructure upon startup the application presents the user with a main menu from where they can choose to navigate to three pages: Report issues, service request status and events only the Report page will have functionality and the other two will be implemented in part 2 and part 3.
# Features
1.	### Main menu: On startup the user will be presented with 3 options to choose from 
  •	Report issues (implemented)

  •	Service request status (disabled)

  •	Local events and anouncements (disabled)

 ![image](https://github.com/user-attachments/assets/f102856f-5ea6-43dd-83d7-0daa0ba9bc56)

2.	### Report Issues: Issues can be reported through the following:
  •	Location input: a simble textbox for users to input the location of the issue

  •	Category selection: A dropdown for selecting the following categorys: sanitization, roads, utilities, infrastructure.

  •	Description: A richTextbox where users can provide a in depth explanation of the issue.

  •	Media attachment: a button where users can attach images regarding the issue.

  •	Engagement feature: A progress bar with a motivational message which fills as the user inputs their data this encourages participation and user engagement. 

  •	After submission the user is redirected to a Issue Success page where they can view all previous submitted issues, displayed in a table.

 ![image](https://github.com/user-attachments/assets/78fb6f9a-c598-42d2-9dc0-b66190b10cb9)

3. ### Success Page:
  •	All data stored in a dictionary data structure is displayed in a table here.

  •	Users can return to the issue page by clicking on a back button to submit more issues.

 ![image](https://github.com/user-attachments/assets/23ac9afb-5a75-4c1b-8095-5e29ea8ff5d3)

# Design considerations:
  •Consistency: the pages are color themed for example the Report issue page is red, the main menu page is yellow themed, the events page is blue and the service request status in green 

  •Clarity: all the buttons and layoput feature like the containers, have a hover feature for it to stand out to the user and easily navigate through the application.

# Technical requirements:
  •User reported issues are stored using a dictionary data structure.

  •Feedback mechanisms are provided for example when a user does not input a required field in the report issues page and presses the submit button, the user will be prompted to input that field.

 ![image](https://github.com/user-attachments/assets/ea3ed0d4-0cf6-404c-85d5-2215df5285c4)

# Prerequsites:
  •	Visual Studio 2022 (or later) with .NET Core SDK installed.

  •	A web browser to access the application.

# How to build and run:
1.	Clone the repository
2.	In visual studio, open the solution
3.	 Run the project by selecting the appropriate IIS Express or local server configuration.
4.	 Upon launch, the app will present the user with a main menu with the "Report Issues" feature enabled.

# How to Use
1.	From the main menu, click "Report Issues."
2.	Enter the location and select the category of the issue.
3.	Provide a detailed description of the issue in the RichTextBox.
4.	Optionally, attach media files like images or documents to the report.
5.	Click "Submit" to report the issue.
6.	After submission, you'll be redirected to the success page where you can view your submitted issues.
7.	To submit another report, use the back button to return to the issue reporting form.

# Future Features
  •	Local Events and Announcements (to be implemented).

 ![image](https://github.com/user-attachments/assets/fdf8e878-f0d0-4c20-8dc6-1fb7abd76cde)

  •	Service Request Status (to be implemented).

![image](https://github.com/user-attachments/assets/d5a338b1-f73c-4887-9d9a-34f71d5c4589)
