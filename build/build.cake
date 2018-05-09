#tool "nuget:?package=GitVersion.CommandLine"

var sourceDirectory = Directory("../src");
var nuspecFilePath = sourceDirectory + File("Contrib.MSBuild.TypeLibrary.nuspec");
var artifactsDirectory = Directory("../artifacts");

//////////////////////////////////////////////////////////////////////
// ARTIFACTS TASKS
//////////////////////////////////////////////////////////////////////

Task("Clean:Artifacts")
  .Does(() =>
{
  Information($"Cleaning {MakeAbsolute(artifactsDirectory)}.");

  if (DirectoryExists(artifactsDirectory)) {
    DeleteDirectory(artifactsDirectory,
                    new DeleteDirectorySettings {
                      Recursive = true,
                      Force = true
                    });
  }

  CreateDirectory(artifactsDirectory);
});

Task("Build:Artifacts")
  .Does(() =>
{
  var gitVersion = GitVersion();
  var version = gitVersion.NuGetVersionV2;

  Information($"Packaging {MakeAbsolute(nuspecFilePath)} ({version}) to {MakeAbsolute(artifactsDirectory)}.");

  var nuGetPackSettings = new NuGetPackSettings
  {
    OutputDirectory = artifactsDirectory,
    Properties = new Dictionary<string, string>
    {
      { "Version", version }
    },
    ArgumentCustomization = arguments => arguments.Append("-ForceEnglishOutput")
  };

  NuGetPack(nuspecFilePath,
            nuGetPackSettings);
});

//////////////////////////////////////////////////////////////////////
// TASK TARGETS
//////////////////////////////////////////////////////////////////////

Task("Clean")
  .IsDependentOn("Clean:Artifacts");

Task("Build")
  .IsDependentOn("Clean")
  .IsDependentOn("Build:Artifacts");

//////////////////////////////////////////////////////////////////////
// EXECUTION
//////////////////////////////////////////////////////////////////////

var targetArgument = Argument("target", "Build");
RunTarget(targetArgument);
