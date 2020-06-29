# GuardedActions

This repository contains sample code which demonstrates how to implement the GuardedActions in combination with different IoC containers.

 - [.NET Core](#net-core)
 - [MvvmCross](#mvvmcross)

:construction: The rest is to coming soon! :construction:

## .NET Core (Xamarin.Forms example)

To support `.NET Core` you need to implement the [GuardedActions.NetCore NuGet](https://www.nuget.org/packages/GuardActions.NetCore/) package. An example is shown in the `.NET Core / Xamarin.Forms` solution folder.

## MvvmCross

To support `MvvmCross` you need to implement the [GuardedActions.MvvmCross NuGet](https://www.nuget.org/packages/GuardActions.MvvmCross/) package. An example is shown in the `MvvmCross` solution folder.

# Contributing code

We are happy to receive Pull Requests adding new features and solving bugs. As for new features, please contact us before doing major work. To ensure you are not working on something that will be rejected due to not fitting into the roadmap or ideal of the library.

## Git setup

Since Windows and UNIX-based systems differ in terms of line endings, it is a very good idea to configure git autocrlf settings.

On *Windows* we recommend setting `core.autocrlf` to `true`.

```
git config --global core.autocrlf true
```

On *Mac* we recommend setting `core.autocrlf` to `input`.

```
git config --global core.autocrlf input
```

## Code style guidelines

Please use 4 spaces for indentation.

Otherwise default ReSharper C# code style applies.

## Project Workflow

Our workflow is loosely based on [Github Flow](http://scottchacon.com/2011/08/31/github-flow.html).
We actively do development on the **develop** branch. This means that all pull requests by contributors need to be develop and requested against the develop branch.
The master branch contains tags reflecting what is currently on NuGet.org.

## Submitting Pull Requests

Make sure you can build the code. Familiarize yourself with the project workflow and our coding conventions. If you don't know what a pull request is
read this https://help.github.com/articles/using-pull-requests.

Before submitting a feature or substantial code contribution please discuss it with the team and ensure it follows the GuardedAction roadmap.
Note that code submissions will be reviewed and tested. Only code that meets quality and design/roadmap appropriateness will be merged into the source. [Don't "Push" Your Pull Requests](https://www.igvita.com/2011/12/19/dont-push-your-pull-requests/)
