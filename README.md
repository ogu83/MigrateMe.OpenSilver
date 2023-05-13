# MIGRATE ME POC APPLICATION
## An example how to migrate silverlight to opensilver

In this example we will migrate a simple silverlight app to OpenSilver.

* Lets open MigrateMe App in Visual Studio 2015.

This app is indeed a sample app with at least one custom user control, one templated control and generic styles for it.
When we run it we will see a running clock a login control, cancel is working like clear out the form. 
Also we could see the login button has a vector xaml path triangle icon too. Pretty good looking xaml design. 
We could say this POC could represent some level of common silverlight applications with custom styles.

* Lets migrate this one to the opensilver. 
1. Create a new OpenSilver project In this step we are going to create a separate OpenSilver project having the same name as Silverlight application has but in a different location.
2. Add a new OpenSilver Class Library
We need to keep our new OpenSilver project consistent with the Silverlight. Since the project has a Silverlight Class Library we are going to create a new OpenSilver Class Library with the same name.
3. Add This Class library as a Project Reference
4. Rename OpenSilver projects
5. Copy files and directories from OpenSilver project to Silverlight project
* Copy MigrateMe.Browser, MigrateMe.Simulator folders and MigrateMe.OpenSilver.sln file to Silverlight's root directory
* Copy MigrateMe.OpenSilver.csproj and MigrateMe.Controls.OpenSilver.csproj files to Silverlight's according projects directory

6. Lets check the OpenSilver version with Visual Studio 2022.

7. align csproj files
8. remove the assembly info
9. fix the namespace and assemblyname for class libraries.
10. update the osf
11. add a nuget.config file to be able to upgrade the opensilver package to the latest develop branch.
```xml
<?xml version="1.0" encoding="utf-8"?>
<configuration>
  <solution>
    <add key="disableSourceControlIntegration" value="true" />
    <add key="dependencyversion" value="Highest" />
  </solution>
  <packageSources>
    <clear />
    <add key="PrivatePackages" value="PrivatePackages" />
    <add key="Nightly" value ="https://www.myget.org/F/opensilver/api/v3/index.json" />
    <add key="nuget.org" value="https://api.nuget.org/v3/index.json" />
  </packageSources>
</configuration>
```
11. Use IWebAssemblyExecutionHandler

```csharp
public class UnmarshalledJavaScriptExecutionHandler : IWebAssemblyExecutionHandler
{
    private const string MethodName = "callJSUnmarshalled";
    private readonly WebAssemblyJSRuntime _runtime;
    public UnmarshalledJavaScriptExecutionHandler(IJSRuntime runtime)
    {
        _runtime = runtime as WebAssemblyJSRuntime;
    }
    public void ExecuteJavaScript(string javaScriptToExecute)
    {
        _runtime.InvokeUnmarshalled<string, object>(MethodName, javaScriptToExecute);
    }
    public object ExecuteJavaScriptWithResult(string javaScriptToExecute)
    {
        return _runtime.InvokeUnmarshalled<string, object>(MethodName, javaScriptToExecute);
    }
    public TResult InvokeUnmarshalled<T0, TResult>(string identifier, T0 arg0)
    {
        return _runtime.InvokeUnmarshalled<T0, TResult>(identifier, arg0);
    }
    public TResult InvokeUnmarshalled<T0, T1, TResult>(string identifier, T0 arg0, T1 arg1)
    {
        return _runtime.InvokeUnmarshalled<T0, T1, TResult>(identifier, arg0, arg1);
    }
    public TResult InvokeUnmarshalled<T0, T1, T2, TResult>(string identifier, T0 arg0, T1 arg1, T2 arg2)
    {
        return _runtime.InvokeUnmarshalled<T0, T1, T2, TResult>(identifier, arg0, arg1, arg2);
    }
}
```
