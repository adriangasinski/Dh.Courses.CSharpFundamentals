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

Instead we can use 
``` c#
$" text {variableName} the rest of text"
```

## Passing argument to application from command line.

dotnet run Arg - passes Arg to CLI not to application

to pass argument to application we have to use --
dotnet run -- Arg

## Debugging

Make a breakpoint in VS. Chosse Statr with Debugging (F5)

To pass arguments to application we can edit launch.json file in .vscode folder. There is args field that can be set.

***

# Learning the C# Syntax
## block of code 
``` c#
{
    statement;
}
```
semicolon at the end of the statement

## variable declaration
``` c#
double x;
```

initialization expression immediately after declaring variable 
``` c#
double x = 34.1;
```

## Implicit typing 
When we initialize and declare variable in the same place. 

``` c#
var x = 34.1
```

Compiler should figure out the type from context. 
To check if it has got it right we can hoover over variable. 


## Code snpipets
There are code snippets in VS Code. Instead of typing in Console.Writeline() we can type in cw and press tab button. 

## Arrays 
``` c#
double[] numbers
```

Variable numbers is declared but not initialized so we can not use it.
``` c#
numbers[0] = 12.7; //would be illegal
```

We need to initialize array with the new instance of array.

``` c#
double[] numbers = new double[3];
```
the same with implicit typing
``` c#
var numbers  = new double[3];
```

## Array initialization with values 

``` c#
var numbers = new[] {12.7, 10.3, 6.11};

```

## for each statement

``` c#
var result = 0.0;
foreach(double number in numbers)
{
    result += number;
}
```

## List

When we use an array we need to know its length in advance. In case we do not know it we can use list. 

``` c#
using System.Collections.Generic;
List<double> grades = new List<double>();
grades.Add(56.1);
grades.Add()
```
ctrl + . - suggests fixes.


same with var
``` c#
var grades = new List<double?() { 12.7, 10.3, 6.11, 4.1};
```

formatting floating point number
``` c#
$"The total sum of grades is {result:N1}");
```
```:N1``` means that result shoud be rounded to 1 decimal place. 


