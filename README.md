# Formula1Standings

A tool that parses, presents, and manipulates Formula 1 standings and timing data.

## Testing

Requirements:
  - .NET 9 runtime

To test a release build:
  1. Download the [latest release (0.2.0)](https://github.com/DanStevens/Formula1Standings/releases/tag/0.2.0).
  2. extract the ZIP file to a folder.
  3. Run _Formula1Standings.UI.exe_.

## Building

Requirements:
  - Visual Studio 2022 with _.NET desktop development_ workload installed
  - .NET 9 runtime

To build and debug:
  1. Download the source code or checkout the repository.
  2. Open _Formula1Standings.sln_ in Visual Studio.
  3. Build the solution; this should restore NuGet packages.
  4. Right-click on _Formula1Standings.UI_ project and select _Set as default project_.
  5. Click `Debug` > `Start Debugging` to run with debugging enabled.
  6. Optionally, open the _Text Explorer_ to run unit tests.
