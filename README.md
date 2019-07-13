Save the Pony
===

This is my solution for https://ponychallenge.trustpilot.com/index.html

It consists of a python script, used to explore the API and the problem itself; and a C# console app, used to solve the maze and post the solution to the API.

Usage
---

<h3>Python script</h3>
The script is made in Python3. It uses 'curses' to draw the maze, 'requests' to call the API and 'uuid' to parse maze IDs.

`python3 save-the-pony-interactive.py`

If you get the error:
    
    Traceback (most recent call last):
        File "save-the-pony-interactive.py", line 105, in <module>
            main()
        File "save-the-pony-interactive.py", line 72, in main
            screen.addstr(1, 0, responseMaze.text)
	_curses.error: addwstr() returned ERR

You are probably trying to draw a big maze in a small terminal. Make sure your terminal is filling the screen, or use a smaller map size.

<h3>C# console app</h3>
The console app is made in .NET Core 2.2 using Visual Studio 2019

To run the tests:

	cd SaveThePony
	dotnet test

To run the app:
    
	cd SaveThePony
    dotnet run --project SaveThePony/SaveThePony.csproj

The app will ask for a maze GUID or the information for a new maze. Then it will proceed to calculate a path for the pony using A*, and it will POST the steps of the path to the API, taking Domokun's position into account after each step.

**Example output:**
```
Enter a maze GUID or press enter for a new maze:

Creating new maze
Enter width:
15
Enter height:
15
Enter difficulty:
0
Enter pony name:
Spike
Maze ID 3d846406-c74c-4eef-83ca-cde8c190c719 created.
+---+---+---+---+---+---+---+---+---+---+---+---+---+---+---+
|   |       |       |                                       |
+   +   +   +   +   +---+   +---+   +---+---+---+---+---+   +
|   |   |       |       |       |       |           |       |
+   +   +---+---+---+   +---+   +---+   +---+   +   +   +---+
|   |       |           |           |       |   |   |       |
+   +---+   +   +---+---+---+---+---+---+   +   +   +---+   +
|       |   |   |       |       |           |   |       |   |
+---+   +   +   +   +   +   +   +   +---+---+---+   +---+   +
|   |   | E |       |   |   |       |               |       |
+   +   +   +---+---+   +   +---+---+   +---+   +---+   +---+
|   |   |   |       |       |   |       |       |       |   |
+   +   +   +   +---+---+---+   +   +---+   +---+   +---+   +
|       |   |           |           |   |       |   |       |
+   +---+   +   +---+   +   +---+---+   +---+   +   +---+   +
|   |       |   |       |   |       |       |   |       |   |
+   +---+   +   +   +---+   +   +---+   +   +   +---+   +   +
|     P     |   |           |       |   |   |           |   |
+---+---+---+   +---+---+---+---+   +   +   +---+---+---+   +
|           |           |       |   |   |               |   |
+   +---+   +---+---+   +   +   +   +   +   +---+---+   +   +
|   |               |       |   |       |   |       |       |
+   +   +---+---+---+---+---+   +---+---+   +   +   +---+   +
|   |           |           |   |       |   |   |           |
+   +---+---+   +   +   +---+   +   +   +   +---+   +---+---+
|   |       |       |           |   |   |       |           |
+   +   +   +---+---+---+---+---+   +   +---+   +---+---+   +
|       |   |           |           |       |   |           |
+---+---+   +---+   +   +---+   +---+---+   +   +   +---+---+
|                   |           | D             |           |
+---+---+---+---+---+---+---+---+---+---+---+---+---+---+---+
Here's the ideal path of the pony, let's see it in action:
[Path: (1,8)->(2,8),(2,7),(2,6),(2,5),(2,4)]
Run pony! Run east!
+---+---+---+---+---+---+---+---+---+---+---+---+---+---+---+
|   |       |       |                                       |
+   +   +   +   +   +---+   +---+   +---+---+---+---+---+   +
|   |   |       |       |       |       |           |       |
+   +   +---+---+---+   +---+   +---+   +---+   +   +   +---+
|   |       |           |           |       |   |   |       |
+   +---+   +   +---+---+---+---+---+---+   +   +   +---+   +
|       |   |   |       |       |           |   |       |   |
+---+   +   +   +   +   +   +   +   +---+---+---+   +---+   +
|   |   | E |       |   |   |       |               |       |
+   +   +   +---+---+   +   +---+---+   +---+   +---+   +---+
|   |   |   |       |       |   |       |       |       |   |
+   +   +   +   +---+---+---+   +   +---+   +---+   +---+   +
|       |   |           |           |   |       |   |       |
+   +---+   +   +---+   +   +---+---+   +---+   +   +---+   +
|   |       |   |       |   |       |       |   |       |   |
+   +---+   +   +   +---+   +   +---+   +   +   +---+   +   +
|         P |   |           |       |   |   |           |   |
+---+---+---+   +---+---+---+---+   +   +   +---+---+---+   +
|           |           |       |   |   |               |   |
+   +---+   +---+---+   +   +   +   +   +   +---+---+   +   +
|   |               |       |   |       |   |       |       |
+   +   +---+---+---+---+---+   +---+---+   +   +   +---+   +
|   |           |           |   |       |   |   |           |
+   +---+---+   +   +   +---+   +   +   +   +---+   +---+---+
|   |       |       |           |   |   |       |           |
+   +   +   +---+---+---+---+---+   +   +---+   +---+---+   +
|       |   |           |           |       |   |           |
+---+---+   +---+   +   +---+   +---+---+   +   +   +---+---+
|                   |           |     D         |           |
+---+---+---+---+---+---+---+---+---+---+---+---+---+---+---+
Run pony! Run north!
+---+---+---+---+---+---+---+---+---+---+---+---+---+---+---+
|   |       |       |                                       |
+   +   +   +   +   +---+   +---+   +---+---+---+---+---+   +
|   |   |       |       |       |       |           |       |
+   +   +---+---+---+   +---+   +---+   +---+   +   +   +---+
|   |       |           |           |       |   |   |       |
+   +---+   +   +---+---+---+---+---+---+   +   +   +---+   +
|       |   |   |       |       |           |   |       |   |
+---+   +   +   +   +   +   +   +   +---+---+---+   +---+   +
|   |   | E |       |   |   |       |               |       |
+   +   +   +---+---+   +   +---+---+   +---+   +---+   +---+
|   |   |   |       |       |   |       |       |       |   |
+   +   +   +   +---+---+---+   +   +---+   +---+   +---+   +
|       |   |           |           |   |       |   |       |
+   +---+   +   +---+   +   +---+---+   +---+   +   +---+   +
|   |     P |   |       |   |       |       |   |       |   |
+   +---+   +   +   +---+   +   +---+   +   +   +---+   +   +
|           |   |           |       |   |   |           |   |
+---+---+---+   +---+---+---+---+   +   +   +---+---+---+   +
|           |           |       |   |   |               |   |
+   +---+   +---+---+   +   +   +   +   +   +---+---+   +   +
|   |               |       |   |       |   |       |       |
+   +   +---+---+---+---+---+   +---+---+   +   +   +---+   +
|   |           |           |   |       |   |   |           |
+   +---+---+   +   +   +---+   +   +   +   +---+   +---+---+
|   |       |       |           |   |   |       |           |
+   +   +   +---+---+---+---+---+   +   +---+   +---+---+   +
|       |   |           |           |       |   |           |
+---+---+   +---+   +   +---+   +---+---+   +   +   +---+---+
|                   |           | D             |           |
+---+---+---+---+---+---+---+---+---+---+---+---+---+---+---+
Run pony! Run north!
+---+---+---+---+---+---+---+---+---+---+---+---+---+---+---+
|   |       |       |                                       |
+   +   +   +   +   +---+   +---+   +---+---+---+---+---+   +
|   |   |       |       |       |       |           |       |
+   +   +---+---+---+   +---+   +---+   +---+   +   +   +---+
|   |       |           |           |       |   |   |       |
+   +---+   +   +---+---+---+---+---+---+   +   +   +---+   +
|       |   |   |       |       |           |   |       |   |
+---+   +   +   +   +   +   +   +   +---+---+---+   +---+   +
|   |   | E |       |   |   |       |               |       |
+   +   +   +---+---+   +   +---+---+   +---+   +---+   +---+
|   |   |   |       |       |   |       |       |       |   |
+   +   +   +   +---+---+---+   +   +---+   +---+   +---+   +
|       | P |           |           |   |       |   |       |
+   +---+   +   +---+   +   +---+---+   +---+   +   +---+   +
|   |       |   |       |   |       |       |   |       |   |
+   +---+   +   +   +---+   +   +---+   +   +   +---+   +   +
|           |   |           |       |   |   |           |   |
+---+---+---+   +---+---+---+---+   +   +   +---+---+---+   +
|           |           |       |   |   |               |   |
+   +---+   +---+---+   +   +   +   +   +   +---+---+   +   +
|   |               |       |   |       |   |       |       |
+   +   +---+---+---+---+---+   +---+---+   +   +   +---+   +
|   |           |           |   |       |   |   |           |
+   +---+---+   +   +   +---+   +   +   +   +---+   +---+---+
|   |       |       |           |   |   |       |           |
+   +   +   +---+---+---+---+---+   +   +---+   +---+---+   +
|       |   |           |           |       |   |           |
+---+---+   +---+   +   +---+   +---+---+   +   +   +---+---+
|                   |           |     D         |           |
+---+---+---+---+---+---+---+---+---+---+---+---+---+---+---+
Run pony! Run north!
+---+---+---+---+---+---+---+---+---+---+---+---+---+---+---+
|   |       |       |                                       |
+   +   +   +   +   +---+   +---+   +---+---+---+---+---+   +
|   |   |       |       |       |       |           |       |
+   +   +---+---+---+   +---+   +---+   +---+   +   +   +---+
|   |       |           |           |       |   |   |       |
+   +---+   +   +---+---+---+---+---+---+   +   +   +---+   +
|       |   |   |       |       |           |   |       |   |
+---+   +   +   +   +   +   +   +   +---+---+---+   +---+   +
|   |   | E |       |   |   |       |               |       |
+   +   +   +---+---+   +   +---+---+   +---+   +---+   +---+
|   |   | P |       |       |   |       |       |       |   |
+   +   +   +   +---+---+---+   +   +---+   +---+   +---+   +
|       |   |           |           |   |       |   |       |
+   +---+   +   +---+   +   +---+---+   +---+   +   +---+   +
|   |       |   |       |   |       |       |   |       |   |
+   +---+   +   +   +---+   +   +---+   +   +   +---+   +   +
|           |   |           |       |   |   |           |   |
+---+---+---+   +---+---+---+---+   +   +   +---+---+---+   +
|           |           |       |   |   |               |   |
+   +---+   +---+---+   +   +   +   +   +   +---+---+   +   +
|   |               |       |   |       |   |       |       |
+   +   +---+---+---+---+---+   +---+---+   +   +   +---+   +
|   |           |           |   |       |   |   |           |
+   +---+---+   +   +   +---+   +   +   +   +---+   +---+---+
|   |       |       |           |   |   |       |           |
+   +   +   +---+---+---+---+---+   +   +---+   +---+---+   +
|       |   |           |           |       |   |           |
+---+---+   +---+   +   +---+   +---+---+   +   +   +---+---+
|                   |           |         D     |           |
+---+---+---+---+---+---+---+---+---+---+---+---+---+---+---+
Run pony! Run north!
+---+---+---+---+---+---+---+---+---+---+---+---+---+---+---+
|   |       |       |                                       |
+   +   +   +   +   +---+   +---+   +---+---+---+---+---+   +
|   |   |       |       |       |       |           |       |
+   +   +---+---+---+   +---+   +---+   +---+   +   +   +---+
|   |       |           |           |       |   |   |       |
+   +---+   +   +---+---+---+---+---+---+   +   +   +---+   +
|       |   |   |       |       |           |   |       |   |
+---+   +   +   +   +   +   +   +   +---+---+---+   +---+   +
|   |   | P |       |   |   |       |               |       |
+   +   +   +---+---+   +   +---+---+   +---+   +---+   +---+
|   |   |   |       |       |   |       |       |       |   |
+   +   +   +   +---+---+---+   +   +---+   +---+   +---+   +
|       |   |           |           |   |       |   |       |
+   +---+   +   +---+   +   +---+---+   +---+   +   +---+   +
|   |       |   |       |   |       |       |   |       |   |
+   +---+   +   +   +---+   +   +---+   +   +   +---+   +   +
|           |   |           |       |   |   |           |   |
+---+---+---+   +---+---+---+---+   +   +   +---+---+---+   +
|           |           |       |   |   |               |   |
+   +---+   +---+---+   +   +   +   +   +   +---+---+   +   +
|   |               |       |   |       |   |       |       |
+   +   +---+---+---+---+---+   +---+---+   +   +   +---+   +
|   |           |           |   |       |   |   |           |
+   +---+---+   +   +   +---+   +   +   +   +---+   +---+---+
|   |       |       |           |   |   |       |           |
+   +   +   +---+---+---+---+---+   +   +---+   +---+---+   +
|       |   |           |           |       |   |           |
+---+---+   +---+   +   +---+   +---+---+   +   +   +---+---+
|                   |           |     D         |           |
+---+---+---+---+---+---+---+---+---+---+---+---+---+---+---+
```