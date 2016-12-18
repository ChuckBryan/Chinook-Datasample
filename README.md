# About This Project #
If you stumbled across this project, it is basically an application that I am using to build up my understanding of **ASP.NET Core.**
For the backend, I am using the **Chinook** data model as an example.

This is project is using ASP.NET Core 1.1 and E.F. Core 1.1. I've used MVC since it first came out, but, I purposefully didn't follow
the Core upgrades until it moved past 1.0 (so, 1.1 it is!!).

# Failure to Launch #
Initially, I had several failures trying to get this project template working. I *still* think that I am doing something wrong. Here
is what I *thought* that I needed to do.

1. Make sure that the ASP.NET Core Framework was installed (check)
2. Create an ASP.NET Core Web Application (check)
3. The result should be targeting 1.1 (no)

With a little google foo, I found that I needed to make the following changes to the project.json:
```javascript
  "frameworks": {
    "netcoreapp1.0": {
      "imports": [
        "dotnet5.6",
        "portable-net45+win8"
      ]
    }
  }
```
needed to modified to
```javascript
  "frameworks": {
    "netcoreapp1.1": {
      "imports": [
        "dotnet5.6",
        "portable-net45+win8"
      ]
    }
  }
```
and 
```javascript
  "dependencies": {
    "Microsoft.NETCore.App": {
      "version": "1.0.1",
      "type": "platform"
    },
```
needed to modified to
```javascript
  "dependencies": {
    "Microsoft.NETCore.App": {
      "version": "1.1.0",
      "type": "platform"
    },
```

At some point, I noticed that I was getting an error that was stating that the Secrets Manager Schema was not compatible
with the version of NuGet that I had installed. VS2015 wasn't indicating that I needed to update. However, I did
go to NuGet and installed the latest version.

Finally, I updated the remainder of the NuGet Packages that were targeting 1.0.0 to 1.1.0. I thought I was good to
go, However, Power Tools started to put "Squiggles" in my solution explorer. Something else was wrong. Looking at the 
errors, it was obvious that during the package updates, MVC had gotten lost. I used `Ctrl-.` to fix the missing reference
and VS2015 added the package back into my dependencies.

I was finally able to run my Web Application.

# Getting Started #

Getting started with ASP.NET Core 1.1
ASP.NET Core Templates = Web Application “No Authentication”
What does this give us?
1.	Even after installing the ASP.NET Core 1.1 Framework, creating a new Project still references ASP.NET Core 1.0.
2.	I had to manually install an upgrade to NuGet because my tooling didn’t recognize the Schema for the Secrets Manager, and prompted me to upgrade.
a.	Make sure the output window is open so that you can see the log. If there are errors , they will direct you to the out put anyways.
3.	I am starting with the No Authentication
a.	No Entity Framework in this item.
b.	I need to change the dependencies:Microsoft.NETCore.App to version 1.1.0
c.	I need to change frameworks to netcoreapp1.1
d.	Save…A package gets restored.
e.	Update Nuget References
i.	This upgrades the 1.0.0 to 1.1.0
ii.	Razor toolings go grom v1.0.0-preview2-final to v1.1.0-preview4-final
iii.	SELECT ALL – Update…Accept Licenses.
iv.	It still leaves the Microsoft.AspNetCore.Razor.Tools v1.1.0-preview4-final (?)
v.	Check package – update…acceot licenses
4.	My Solution now has a bunch of red squiggles
a.	I did a “Clean Build” and then a Build.
b.	I got about 8 hours, including a lot about not having “UseMvc” and IActionResult being a missing. This makes me think that there is no MVC
c.	I used the “Ctrl-period” to show potential fixes. It suggested to add Microsoft.AspNetCore.Mvc.1.1
i.	Took the suggestion. It added it, but, I still had Red Squiggles.
ii.	Apparently, this was just a caching issue. I think these red squiggels are from power tools
iii.	Yes, these are Soltuion Explorer Errors surfaced by PT.
d.	Ctrl f5 to run. Now, I have the app running.
5.	Now I want to add EF Core to my example.
a.	Install-package Microsoft.EntityFrameworkCore.SqlServer
b.	Create an Album Model
c.	Create a DbContext (e.g. ChinookContext)
i.	Override OnConfiguring to pass in connection string.
ii.	The Chinook has a Table Called Album.
iii.	If you use a Plural name, you will need to map it back to the Chinook Album Table via an attribute.
6.	Use the DbContext with DI Container.
a.	This means that we don’t have to always new up the context, we can pass it in as a constructor variable
b.	In Startup > Configure Services, add services.AddDbContext<ChinookContext>
7.	Using a connection string in external file.
a.	appsettings.json
b.	in the Startup, add the Read the connection during the configure services.
i.	I got a No database provider has been configured for this db context.
ii.	This was because I did not have a constructor on my dbcontext for taking in the DbcontextOptions
8.	




