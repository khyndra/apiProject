### Prerequisites

- .NET SDK 8.0

### Installation

Run the following command:

```
dotnet build
```

### Run tests

To run all the tests use the following command:

```
dotnet test
```

### Run all tests and get report

To run all tests and get report use the following command:

```
dotnet test --logger html
```

Reports are stored in TestResults folder. If you want you can use the following command to open them all:

```
open TestResult/*.html
```
