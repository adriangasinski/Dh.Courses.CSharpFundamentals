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


****

# Working with classes and objects

We create classes to deal with complexity and encapsulate some behaviour. 

## Syntax to create a class
``` c#
Class NameOfClass{

}
```
Namespaces allow to separate classes from third-party code and avoid conflicts. 

## One class per file
It is not mandatory but it is good convetnion. 


File with new class should look like this
``` c#
namespace GradeBook
{
    public class Book
    {
        
    }
}
```

## Defining methods and fields
``` c#
namespace GradeBook
{
    public class Book
    {

        public void AddGrade(double grade){
            
        }

        grades = List<dobule>;
        
    }
}
```

We can not use implicit typing (var) to create a field. 

## Constructor

Method that constructs an object. 

Explicit constructor - it appears in a class.

It has got the same name as the class. It has no return type. 

Inside we can initialize fields. 

``` c#
class Book
{
    public Book()
    {
        grades = new List<double>();
    }
}
```

Encapsulation - hiding complexity. Hiding detials that are unimportant on certain level. 


## Access modifiers
keywords like 'public'

public - code outside this class can access this method / field. 

Normally we do not want to give direct access to our fields. We want to control modifying state of objects. For example to check validation logic. 
 
private - available only inside a class


## this keyword
Let's asssume that we haveg got a private field name. We want user to provide this name when he creates an object. We use constructor parameter to do that. In a constructor we assign a value from parametr name to private field name. It looks like this:
``` c#
name = name;
```
It makes no sense in this form. That's the reason we use this keyword. It allows us to assign value in a constructor to object fields. It should look like this:
``` c#
this.name = name;
```

## static keyword 
What does it mean for a class memeber to be static?

Statics are not associated with an object instance. 

We can not invoke it with an object reference. 
We can invoke it only with type referrence.

## commenting

ctrl +k  + k + c -comment 
ctrl + k _ k + u - uncomment 

## Generating method from invokes
If I invoke a method that doesn't exist I can place a cursor on its name and press ctrl + . to let VS Code create a method. 

---

# Unit tests

Benefits
* verify 
* investigate (when things go wrong)
* small units of code
* test runner 
* automation

## xUnit.net
Library to run unit tests. It's not a part of .net

We should write our test in separate project and folder. 

We can create such a project from command line. 
```
mkdir Gradebook.Tests
cd Gradebook.Tests
dotnet new xunit
```

``` c#
[Fact]
public void Test1()
{

}
```
[Fact] is an attribute attached to Test1 method. 

## Running test from CLI
```
dotnet test
```
It should be invoke in test project folder. 


## Simple example 
``` c#
[Fact]
public void Test1()
{
    // arrange 
    var x = 5;
    var y = 2;
    var expected = 7;

    // act 
    var actual = x * y;

    // assert 
    Assert.Equal(expected, actual);
}
```
There are typically 3 sections:
* arrange 
* act
* assert

## Adding reference to actual projest 
To use classes from our main project we need to use a refference. We can do it in VisualStudio or in a CLI. 

```
dotnet add reference  ..\..\src\GradeBook\GradeBook.csproj
```

---
# Reference types and Value types

Reference TYpe 

everytime we use a class we are uisng reference type. 

``` c#
var b = new Book("Grades");
```

variable b is only a reference to address in memory where book object is stored.



Value type 
``` c#
var x = 3
```

integer type is a value type. 
instead of storing reference the exact value is stored. 

same for floats and doubles.


## Solution file 
solution file  keeps track for several projects.

to create solution file use:
``` 
dotnet new sln 
```

to add project to solution 
```
dotnet sln add src\GradeBook\GradeBook.csproj
dotnet sln add test\GradeBook.Tests\GradeBook.Tests.csproj
```
Now when we use dotnet build or dotnet test all projects in solutions are taken.

soultion is created in folder gradebook. It's a place whwere folders src and test exist.


## Passing parameters by values 

When you pass a parameter to a method you pass a value not a reference. (unless there is a special keyword)

## Passing parameters by reference 
When we want to pass parameter by reference (to be able to change or overwrite original object that is passed) we can use ref keyword. We should use ref keyword in method definition however we should also use ref keyword when we invoke this method to be aware thata we are doing this. 

There is also 'out' parameter. It works same as 'ref' but parameter must be initialized inside the method. 


## How to check we are working with reference or value type?

When you are using class - this will be reference. 
When you are using struct - this will be value. 

To check:
* place a cursor on a type 
* press f12 - to enable meta data view 
* check if a type is defined using class / struct 

Special case - string 
* is defined as a classs - is a reference type. 
* it behaves like a value type

## Garbage collector
We do not have to kill/ free object after we finished using it. GC makes it for us. 

---

# Controlling the flow of execution

## branching statements
``` c#
if (bool condition)
{
    // do some actions
}
else 
{
    // do something different 
}

```

Instead of nesting ifs it is better to use logical operators in condition 

boolean operators 
* and - &&
* or - ||
* equal - == - dangerous with floating points!


## Looping statements

foreach 
``` c#
foreach(var grade in grades)
{
    // some actions 
}
```

do while 
``` c#
do 
{

} while (condition); 
```


while 
``` c#
while (condition)
{

}
```


for loop 
```c#
for(var index = 0; index < grades.Count; index += 1)
{
    
}

```

### Jumping with break and continue

break
```c#
for(var index = 0; index < grades.Count; index += 1)
{
    if (grades[index] == 42.1)
    {
        break;
    }
    result.Sum += grades[index];
}
```
for loop will be broken. Next iterations will not execute. 
sum will not be incremented

continue 
```c#
for(var index = 0; index < grades.Count; index += 1)
{
    if (grades[index] == 42.1)
    {
        continue;
    }
    result.Sum += grades[index];
}
```
This iteration will be skipped and then next itereations will be executed.
sum will not be incremented.


go to 
```c#
for(var index = 0; index < grades.Count; index += 1)
{
    if (grades[index] == 42.1)
    {
        go to done;
    }
    result.Sum += grades[index];
}

done:
```
Go to is not commonly used theese days. We should not use that. 


### switch statement
```c#
switch(letter)
{
    case 'A':
        AddGrade(90);
        break;

    case 'B':
        AddGrade(80);
        break;

    case 'C':
        AddGrade(70);
        break;

    case 'D':
        AddGrade(60);
        break;

    default:
        AddGrade(0);
        break;
}
```


### pattern matching with switch statement
From C# v.7.0 switch statement became much more powerful because of pattern matching. 

```c#
switch(result.Average)
{
    case var d when d >= 90.0:
        result.Letter = 'A';
        break;
    
    case var d when d >= 80.0:
        result.Letter = 'B';
        break;
    
    default:
        result.Letter = 'F';
        break;
}
```

## Throwing exceptions
We can throw predefined exceptions. There is also a way to create our own exceptions but this is not covered in the course. 

To throw an exception we use code:
```c#
throw new ArgumentException($"Ivalid {nameof(grade)}");
```
nameof function gives the string representation of argument name. It is better to use nameof instead of hardcoding the name of argument because if I change it in the future I will have to change this message too. 


## Catching exceptions
We can catch exceptions using try catch blocks
```c#
try 
{
    var grade = double.Parse(input);
}
catch(Exception ex)
{
    Console.WriteLine(ex.Message);
    // if we want to rethrow to catch it in other place or to terminate the program 
    //  we can use throw statement
    // throw;
}
```

We can alse define the type of exceptions we want to catch. 
```c#
try
{

}
catch(ArgumentException ex)
{
    //this code will run only if the type of exception is argument exception
}
catch(FormatException ex)
{
    // handling format exception
}
```
This way we can handle exceptions we are aware of and let others to terminate the progam. 


Finally block
```c#
finally {
    //this code will execute regardless the exceptions occured or not
}
```



# Building types 

## Overloading methods
Method signature consists of method name and prameters' types. So that we can define two methods with the same name but different parameters types. Compiler will choose the correct one based on method signature. 

Return type is not a part of method signature. We can not have two methods with the same name and parameters types but different return type. 

overloading - depending on a parameters types different method is called.

## Properties
Another type of a member we can add to the class is a property. 

It is very similar to a field in a sense that it can encapsulate state and store data of an object. 
But property has got a different syntax and some powerful features. 

There are several approaches that you can declare a property for a C# class. 

Long hand sytnax
``` c#
public string Name 
{
    get
    {
        return name;
    }
    set
    {
        if (!String.IsNullOrEmpty(value))
        {
            name = value;
        }
    }
}

private string name;
```

So a propperty is a way to encapsulate the state of an object but it gives us opportunity to control what is going on when we set or get value of it.


Another way to declare a property
``` c#
public string Name 
{
    get; set;
}
```
It is known as an auto-property in C#.

What is the difference between an auto-property and having just a public field?

There are some differences in C# when it comes to reflection and serialization. 

Another difference - we can apply another access modifiers to get and set. 


For example
``` c#
public string Name 
{
    get; 
    private set;
}
```

We can get the value but we can't set it from the oustide of a class. 



## Defining readonly members

### readonly keyword
It causes that only two places where we can set the value of a memeber is an initialization and constructor. 


Example of a readolny field 
``` c#
readonly string category = "Science";
```


### const keyword

Value of a constant field can be set only in the initialization.


Example of a const field
``` c#
const string category = "Science";
```

It can also be public
``` c#
public const string CATEGORY = "Science";
```

It is a publicly exposed but the only thing that can be done with it is to read it. 

You can access constant method only as a static member of a class. 
So you cant reference object. You need to reference a class. 



## Events 
They are not completely covered in this course for 2 reasons:
1. Events not in style with server framewoks
2. Events are hard to understand

However there are described beacuse:
1. Events are popular in forms and desktop programming. 
2. Events build on top of delegates.



## Deleagtes
Delagete describes what a method will look like. 

It is an abstract representation for methods. 
It describes types of parameters and type of a return. 

Example 
``` c#
public delegate string WriteLogDelegate(string logMessage);
```

How do we write a method that will match with a delgate type. 

``` c#

string ReturnMessage(string message)
{
    return message;
}

```

Paramters names dont have to match. Their types have to match.

``` c#
{
    WriteLogDelegate log;

    log = new WriteLogDelegate(ReturnMessage);
    // another way to do the same that above line
    log = ReturnMessage;

    var result = log("Hello!");
}
```


## Multi-cast delegates
``` c#
{
    WriteLogDelegate log = ReturnMesage;

    log += ReturnMessage;

    var result = log("Hello!");
}
```



## Events

It is something that happens when other thing happens. :)
Example - button click. 


We need to trigger an event. To do this we can use delegate. We do not know what it will be used for. However we want to inform that something has happened. 

Example - we need to make an event everytime grade is addes to our book. 

Generally we define delgate in a separate file. The rule is one file per type. 

Delegate for an event has typically two parameters
1. object sender
2. EventArgs args

Example of a delgate for an event:
``` c#
    public delegate void GradeAddedDelegate(object sender, EventArgs args);
```


Event is a member of a class.
``` c#
public event GradeAddedDelegate GradeAdded;
```

And when we want to raise the event we use 
``` c#
if(GradeAdded != null)
{
    GradeAdded(this, new EventArgs());
}
```

## Subscribing to an Event

Handling events

wherever I have got an access to object. 

Static memeber can reach only another static members of the class. So that in static class Main we can reach staic method that will match requirements of event delegate. 

``` c#
static void OnGradeAdded(object sender, EventArgs e)
{
            
}
```

Now we can add a method OnGradeAdded to GradeAdded event of an object. 

``` c#
book.GradeAdded += OnGradeAdded;
```

we can add as many methods as we want. 

we can also susbstract methods from an event in this way:
``` c#
book.GradeAdded -= OnGradeAddded;
```


## Object Oriented Progamming in C#
There are threee pilars of OOP
1. Encapsulation
2. Inheritance 
3. Polimorphism 


Encapsulation - hideing implemantation details.
Inheritance  - reusing code between similar classes. 
Polimorphism - allows us to have objects of the same type that behave differently.


### Inheritance 

DRY - Don't Repeat Yourself

Example of inheritance 
``` c#
public class Book : NamedObject
{

}

```
Class book inherits from base class NamedObject

### Chaining contructors
If base class has got a constructor that requires a parameter we need to get this parameter from derived class. So that we need to inherit it from base class cnostructor in a derrived class constructor. 

Example
``` c#
// base class 
    public class NamedObject 
    {
        public NamedObject(string name)
        {
            Name = name;
        }

        public string Name{
            get;
            set;
        }
    }

// derrived class
    public class Book : NamedObject
    {
        public Book(string name) : base(name)
        {
            Name = name;
            grades = new List<double>();
        }
    ...

```


### Deriving from System.Object

In a C# every class has got a base class. Even if it is not specified, everything derrives from System.Object.

keyword object is the same as System.Object


### Abstract class

We can use abstract class with an abstract method when we want to have a base class but we dont know implementation of a method on this level. Everything that derives from this abstract base class has to include an implementation of this abstract class. 

To indicate that method is an implementation of inherited abstract class we need to use an "override" keyword.

``` c#
public override void AddGrade(double grade)
```


### Interface

Another way to ensure encapsulation and polymorphism in C# is to define an Interface. 

Interface doesn't include any implementation details. Abstract class can include some interpretation details. Interface only describes list of members that should be available in a specific type. 

Example of an interface
``` c#
    public interface InMemoryBook
    {
        void AddGrade(double grade);
        Statistics GetStatistics();
        string Name {get;}
        event GradeAddedDelegate GradeAdded;
        
    }
```

Example of interface implementation
``` c#
public class Example : BaseClass, Interf1, Interf2
{
    //
}
```

Class can implement 0 or many interface. There is no limit like in inheritance. 

### Virtual keyword
we need to use virtual keyword with a member of a base class when we want to allowed derrived class to override the implementation from a base class. 

abstract member is implicitly virtual. 


### Using IDisposable
Generally in C# we don't have to care about memory. GC will free resources but we do not have any impact on when it will do that. In some cases we want to free resource immediatley. Classes that allow for this behaviour implement interface IDisposable. 

It is important when we use FileWriter class. We cannot wirte in other stream unless we dispose the first stream. 

We can do this for example in this way:
``` c#
var writer = File.AppendText($"{Name}.txt");
try
{
    writer.WriteLine(grade);
}
finally{
    writer.Dispose();
}

```

but there is a common practice in C# to do this like that:
we create disposble object in using clause and then it will be automatically dispose after execution of following blokc of code.

``` c#
using(var writer = File.AppendText($"{Name}.txt"))
{
    writer.WriteLine(grade);
}

```
After the end of the using block of code C# will automatically dispose writer.



