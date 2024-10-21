ResultPattern
ResultPattern is a .NET library that provides a generic result pattern for handling success and error responses in a clean and consistent way.

Installation
You can install the package via NuGet Package Manager Console:

bash
Install-Package ResultPattern
Or via .NET CLI:

bash
dotnet add package ResultPattern
Usage
Creating a Successful Result
You can create a successful result using the Succeed method. The Succeed method takes a data parameter of type T and returns a Result<T> object with IsSuccesfull set to true.

csharp
````
var result = Result<string>.Succeed("Operation completed successfully.");
````
Creating a Failure Result
To create a failure result, use the Failure method. The Failure method takes an error message and optionally a status code, and returns a Result<T> object with IsSuccesfull set to false.

csharp
````
var errorResult = Result<string>.Failure("An error occurred during the operation.");
````
You can also pass a list of error messages:

csharp
```
var errorMessages = new List<string> { "Error 1", "Error 2" };
var errorResult = Result<string>.Failure(errorMessages);
```
Accessing Result Properties
You can access the properties of the Result<T> object as follows:

csharp
```
if (result.IsSuccesfull)
{
    Console.WriteLine($"Success: {result.Data}");
}
else
{
    Console.WriteLine($"Error: {string.Join(", ", result.ErrorMessages)}");
}
```
Example
Here is a complete example that demonstrates how to use the Result<T> class:

csharp
```
using ResultPattern.ResultPattern;

var successResult = Result<string>.Succeed("Data processed successfully.");

if (successResult.IsSuccesfull)
{
    Console.WriteLine(successResult.Data);
}
else
{
    Console.WriteLine($"Errors: {string.Join(", ", successResult.ErrorMessages)}");
}

var failureResult = Result<string>.Failure("Data processing failed.");

if (!failureResult.IsSuccesfull)
{
    Console.WriteLine($"Errors: {string.Join(", ", failureResult.ErrorMessages)}");
}
````
License
This project is licensed under the MIT License. See the LICENSE file for more details.