# Contributing to the Microsoft Graph .Net Client Library
Thanks for considering making a contribution! Read over our guidelines and we will do our best to see your PRs merged successfully.

**NOTE**: A signed a contribution license agreement is required for all contributions and is checked automatically on new pull requests. You will be asked to read and sign the agreement https://cla.microsoft.com/ after submitting a request to this repository.

There are a few different recommended paths to get contributions into the released version of this library.

## File issues
The best way to get started with a contribution is to start a dialog with us. Sometimes features will be under development or out of scope for this library and it's best to check before starting work on contribution, especially for large work items.

## Pull requests
If major functionality is being added it should be submitted against the **dev** branch. If the functionality will require multiple changes or iterations before it is ready for **dev**, feel free to submit pull requests into a dedicated **feature** branch until the whole change is ready.

If you are making a change that does not affect the interface components and does not affect other downstream callers, feel free to make a pull request against the **dev** branch.

The master branch is intended to represent the code released in the most-recent Nuget package.

When a new package is about to be released, changes in **dev** will be merged into **master**. The package will be generated from **master**.

Some things to note about this project:

### How the library is built
The .Net client library has a handwritten set of core files and two folders of generated models and request builders. These models and request builders are generated using the [MSGraph SDK Code Generator](https://github.com/microsoftgraph/MSGraph-SDK-Code-Generator). **Changes made to the ```Models``` and ```Requests``` folders will be overwritten** the next time the generator is run.

### How the generator works
You can view the [README](https://github.com/microsoftgraph/MSGraph-SDK-Code-Generator/blob/master/README.md) for a full run-through of its capabilities.

For the purposes of the .Net client library, the generator runs through an OData-compliant metadata file published by Microsoft Graph (https://graph.microsoft.com/v1.0/$metadata) and builds up an in-memory list of models. These models are converted into C# code files using T4 templates.

### When new features are added to the library
Generation happens as part of a manual process that occurs once a significant change or set of changes has been added to the Graph. This may include:
 - A new workload comes to v1.0 of Graph (Microsoft Teams, Batching, etc.)
 - There is significant addition of functionality (Delta Queries, etc.)

However, this is evaluated on a case-by-case basis. If the library is missing v1.0 Graph functionality that you wish to utilize, please [file an issue](https://github.com/microsoftgraph/msgraph-sdk-dotnet/issues).

We do our best to prevent breaking changes from being introduced into the library during this process. If you find a breaking change, please file an issue and we will work to get this resolved ASAP.