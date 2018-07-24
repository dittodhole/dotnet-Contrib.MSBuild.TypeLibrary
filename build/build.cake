#addin "Cake.Incubator&version=2.0.2"
#tool "nuget:?package=GitVersion.CommandLine&version=3.6.5"

var configuration = "Release";
var tokens = new Dictionary<string, string>
             {
               { "Configuration", configuration },
               { "branch", EnvironmentVariable("APPVEYOR_REPO_BRANCH") ?? "develop" },
               { "author", "Andreas Niedermair (@dittodhole)" },
               { "version", GitVersion().NuGetVersionV2 }
             };

var sourcePath = "../src/";
var sourceDirectory = Directory(sourcePath);
var artifactsPath = "../artifacts/";
var artifactsDirectory = Directory(artifactsPath);
var nuspecFilePath = sourceDirectory + File("Contrib.MSBuild.TypeLibrary.nuspec");

//////////////////////////////////////////////////////////////////////
// ENVIRONMENT
//////////////////////////////////////////////////////////////////////

Task("Setup:Environment")
  .Does(() =>
{
  ChocolateyInstall("VisualStudio2017Community");
});

//////////////////////////////////////////////////////////////////////
// TEMPLATES
//////////////////////////////////////////////////////////////////////

Task("Clean:Templates")
  .Does(() =>
{
  Information($"Cleaning output from templates.");

  var templateFilePaths = GetFiles(sourcePath + "**/*.tmpl");
  foreach (var templateFilePath in templateFilePaths) {
    var destinationFilePath = templateFilePath.ChangeExtension(string.Empty);
    if (FileExists(destinationFilePath)) {
      DeleteFile(destinationFilePath);
    }
  }
});

Task("Build:Templates")
  .DoesForEach(() => GetFiles(sourcePath + "**/*.tmpl"),
               templateFilePath =>
{
  var destinationFilePath = templateFilePath.ChangeExtension(string.Empty);

  Information($"Building template '{MakeAbsolute(templateFilePath)}' to '{MakeAbsolute(destinationFilePath)}'.");

  var textTransformation = TransformTextFile(templateFilePath, "$", "$");
  foreach (var kvp in tokens) {
    textTransformation.WithToken(kvp.Key, kvp.Value);
  }

  textTransformation.Save(destinationFilePath);
});

//////////////////////////////////////////////////////////////////////
// ARTIFACTS
//////////////////////////////////////////////////////////////////////

Task("Clean:Artifacts")
  .Does(() =>
{
  Information($"Cleaning '{MakeAbsolute(artifactsDirectory)}'.");

  if (DirectoryExists(artifactsDirectory)) {
    DeleteDirectory(artifactsDirectory,
                    new DeleteDirectorySettings
                    {
                      Recursive = true,
                      Force = true
                    });
  }

  CreateDirectory(artifactsDirectory);
});

Task("Build:Artifacts")
  .IsDependentOn("Build:Templates")
  .Does(() =>
{
  Information($"Packaging '{MakeAbsolute(nuspecFilePath)}' ({tokens["version"]}) to '{MakeAbsolute(artifactsDirectory)}'.");

  NuGetPack(nuspecFilePath,
            new NuGetPackSettings
            {
              Properties = tokens,
              OutputDirectory = artifactsDirectory,
              DevelopmentDependency = true
            });
});

//////////////////////////////////////////////////////////////////////
// TASK TARGETS
//////////////////////////////////////////////////////////////////////

Task("Clean")
  .IsDependentOn("Clean:Templates")
  .IsDependentOn("Clean:Artifacts");

Task("Build")
  .IsDependentOn("Clean")
  .IsDependentOn("Build:Templates")
  .IsDependentOn("Build:Artifacts");

//////////////////////////////////////////////////////////////////////
// EXECUTION
//////////////////////////////////////////////////////////////////////

var targetArgument = Argument("target", "Build");
RunTarget(targetArgument);
