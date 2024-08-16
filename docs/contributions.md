Contributing to the Microsoft Graph .NET Client Library
=====

The Microsoft Graph .NET Client Library is avaliable for all manner of contribution. There are a few different recommended paths to get contributions into the released version of this library.

**NOTE** A signed a contribution license agreement is required for all contributions and is checked automatically on new pull requests. Please read and sign the agreement https://cla.microsoft.com/ before starting any work for this repository.

## File issues

The best way to get started with a contribution is to start a dialog with the owners of the repository. Sometimes features will be under development or out of scope for this library and it's best to check before starting work on contribution.

## Pull requests

If you are making documentation changes, feel free to submit a pull request against the **main** or a specific **feature** branch. The **main** branch is intended to represent the code released in the most-recent Nuget package.

## Submit pull requests for trivial changes

If you are making a change that does not affect the interface components and does not affect other downstream callers, feel free to make a pull request against the **main** branch.

Revisions of this nature will result in a 0.0.X change of the version number.

## Submit pull requests for features

If major functionality is being added it should be submitted against the **main** branch. If the functionality will require multiple changes or iterations before it is ready for **main**, feel free to submit pull requests into a dedicated **feature** branch until the whole change is ready.

Revisions of this nature will result in a 0.X.X change of the version number.