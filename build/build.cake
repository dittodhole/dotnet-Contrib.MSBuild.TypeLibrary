#tool "nuget:?package=GitVersion.CommandLine&version=3.6.5"

var sourceDirectory = Directory("../src");
var nuspecFilePath = sourceDirectory + File("Contrib.MSBuild.TypeLibrary.nuspec");
var artifactsDirectory = Directory("../artifacts");

//////////////////////////////////////////////////////////////////////
// ARTIFACTS TASKS
//////////////////////////////////////////////////////////////////////

Task("Clean:Artifacts")
  .Does(() =>
{
  Information($"Cleaning '{MakeAbsolute(artifactsDirectory)}'.");

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

  Information($"Packaging '{MakeAbsolute(nuspecFilePath)}' ({version}) to '{MakeAbsolute(artifactsDirectory)}'.");

  var nuGetPackSettings = new NuGetPackSettings
  {
    Id = "Contrib.MSBuild.TypeLibrary",
    Version = version,
    DevelopmentDependency = true,
    OutputDirectory = artifactsDirectory,
    KeepTemporaryNuSpecFile = true
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
