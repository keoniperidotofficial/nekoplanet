# NekoPlanet Source

This is the source code for a joke LittleBigPlanet revival, NekoPlanet. I recently made this revival because I felt like it and I wanted to make it as a joke but I actually put some work into this silly Project Lighthouse fork.

# Requirements
MySQL / MariaDB
Apache (to launch MySQL/MariaDB)
A brain
Terminal
DotNet 8.0

# How To Launch Website.

go to the ProjectLighthouse.Website folder. Open a terminal inside that folder or redirect Command Prompt to that folder. Once you're in, run "dotnet build" and then run "dotnet run" and once it boots up for the first time, you should see a .configme file.


Go back to the ProjectLighthouse.Website folder, you should see a lighthouse.yml.configme file in the directory, edit it with your notepad, you can configure it however you want, it's your source now.


Once you're done configuring the configme, if you can see the file extension, remove the .configme and keep .yml so it'll be lighthouse.yml!


If you have all migrations correct, and if you have MySQL and Apache on, make the database in url "localhost/phpmyadmin" and make the database's name "lighthouse" or whatever name you chose for the database name in the lighthouse.yml file.


Run the terminal again and run "dotnet run", if all is successful, the website will run with no errors! the username and password should be "admin" and "lighthouse". it will ask you to setup 2FA and to change your password, that's normal, just do what it asks you to do. and change the "admin" username to what your RPCSN or PSN username is to connect to the servers you are running.


and that's it! to add CSS to the website, go back to the ProjectLighthouse.Website folder and there should be a folder name "StaticFiles". go on it, make a new folder inside that folder and name the new folder "css" all lowercase, and then you can start making your cool new "styles.css" that'll be the talk to the LittleBigPlanet community! either that or a laughing stock.



# How to launch GameServer.


Go back to your main directory on where you have all of the ProjectLighthouse folders, go on ProjectLighthouse.GameServer folder. that's where the gameserver lives in.


Open a new terminal, run "dotnet build" and after it builds, run "dotnet run", it should make a new file named "lighthouse.yml.configme", same as how you did with the website, config all you want to make your Lighthouse / NekoPlanet instance unique. and like the website tutorial, make the file connect to the database. and once you finish configging the yml. change the file extension from "yml.configme" to just "yml".


it will run all of the migrations again for some reason, but don't worry, if all goes right, it will start up and run on localhost:10060/LITTLEBIGPLANET_XML!



# and that's how you start your very own Lighthouse or NekoPlanet instance! have fun and remember. Play, Create and Share! :3