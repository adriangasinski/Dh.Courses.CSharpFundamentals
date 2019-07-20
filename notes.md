---
title: 'C# Fundamentals Course - notes'
author: "Adrian Gasiński"
date: "2019-07-20"
---


# Introducing C# and .NET


## .NET
C# - languge 

.NET - framework that takes c# code and translate it to computer. (runtime?)

.NET Framework  - windows only 
.NET Core - multiplatform, open source.

.NET consists of two pieces: 
* CLR - Common Language Runtime - it can run not only C# programs but also F#, VB.
* FCL - Framework Class Library - shared code for common activities already written for you.


## SDK
SDK - Software Development Kit
CLI - common line interface. 

You can start dotnet from cmd just typing dotnet.

dotnet --info - to check what version of .net has been installed.

cls - clears command prompt

dotnet -h
dotnet --help 

lists commands and help


## Project 
Before you create application you have to create project first. 

dotnet new - creates a project
without any arguments it lists template that you can choose from 

catalaog structure:
GradeBook
GradeBook/src - source code. it may consists of many folders with many applications or components in them.
GradeBook/test - unit tests

GradeBook/src/GradeBook - place for our app

dotnet run - runs a project from a directory you are currently in 


## Editing code 

to run editor (VS Code) from commmand line go to project folder (gradebook/) and type "code ."


## Running and building project

Things that .net does behind the scenes when we use dotnet run
* dotnet restore - nuget (package system for .net)- it checks if all requirements for nuget packages are satisfied.
* dotnet build - it compiles source code. It transfomrs C# soruce code to binary representation (stored in dll file). It creates an assembly Gradebook.dll.
* dotnet bin\Debug\netcoreapp2.1\Gradebook.dll

## String concatenation
\+ operator works but is not efficient.

Instead we can use $" text {variableName} the rest of text"

## Passing argument to application from command line.

dotnet run Arg - passes Arg to CLI not to application

to pass argument to application we have to use --
dotnet run -- Arg

## Debugging

Make a breakpoint in VS. Chosse Statr with Debugging (F5)

To pass arguments to application we can edit launch.json file in .vscode folder. There is args field that can be set.

