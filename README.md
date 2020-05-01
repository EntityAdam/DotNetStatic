# DotNetStatic

[![Build Status](https://dev.azure.com/entityadam/Master/_apis/build/status/EntityAdam.DotNetStatic?branchName=master)](https://dev.azure.com/entityadam/Master/_build/latest?definitionId=16&branchName=master)

DotNetStatic is a simple tool to spin up a web server on your local machine to host static web files.

After starting the application you can open a broswer window and navigate to `http://localhost:8080`

Default documents are:
  - index.htm
  - index.html
  - default.htm
  - default.html
  
If no default document is found, it will show a directory browser.

To exit the application use "CTRL+C" or close the command prompt.

## Install
`dotnet tool install --global DotNetStatic`

## Uninstall
`dotnet tool uninstall -g DotNetStatic`

## Usage

Command Line:
`dotnetstatic start [options]`

```
Options:
  -p|--port <port>       Set port number [default: 8080]
  -d|--directory <path>  Set content path [default: where the command was executed from]
```

## Examples:

### Command Prompt

```
> cd C:\mysite\wwwroot
> dotnetstatic start
```

### Output:
```
info: Microsoft.Hosting.Lifetime[0]
      Now listening on: http://[::]:8080
info: Microsoft.Hosting.Lifetime[0]
      Application started. Press Ctrl+C to shut down.
info: Microsoft.Hosting.Lifetime[0]
      Hosting environment: Production
info: Microsoft.Hosting.Lifetime[0]
      Content root path: C:\mysite\wwwroot
```

### Implementation Details

DotNetStatic is written in C# 7.3 with AspNetCore 3.1.
