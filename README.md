# Task-Manager
This WPF Task Manager application is a software that helps a person manage their personal tasks by providing features to create and manipulate To Do Lists and Tasks. The application is built using C# and WPF design pattern MVVM. It has a main window that displays the content of the To Do Lists and allows the user to perform various operations on it.

The application contains two types of entities: To Do List (TDL) and Task. A TDL can contain other TDLs and/or Tasks. The user can create multiple files with TDLs and Tasks, and each group can be archived in a convenient way. The main menu of the application includes options to create, open, archive, and exit databases.

The main window of the application displays the TDLs in a tree-like structure, and the Tasks are displayed in a table-like structure. The user can add, edit, and delete TDLs and Tasks, and move them up and down in the list. The user can also manage categories, find tasks, sort and filter the view, and get statistics.

The TDL has a name, an image, and a content that can be a list of TDLs and/or Tasks. The Task has a name, a description, a status (created, in progress, done), a priority (High, Medium, Low), a deadline (of type DateTime), a completion date (of type DateTime), and a category (a predefined list of categories).

The user can add a TDL by specifying its name and selecting an icon from a predefined list of images. If a TDL is selected, then the created TDL will be a sub-TDL for the selected one. The application does not allow adding TDLs with duplicate names. When a TDL is deleted, its content is also deleted. The user can change the parent of a TDL, move it up and down in the list, and set its path.

The user can add a Task to a TDL, and the application displays it in the table-like structure with all the relevant information. The user can also edit and delete the Task, set it as done, and move it up and down in the list. The user can manage categories, including adding, modifying, and deleting them.

The user can find a Task by searching for its name or deadline. The application provides a search window with options to filter the results by name or deadline.
