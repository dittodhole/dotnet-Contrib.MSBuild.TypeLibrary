using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;
using JetBrains.Annotations;

namespace Contrib.MSBuild.TypeLibrary
{
  public sealed class TlbExp : ToolTask
  {
    [Required]
    [NotNull]
    public string Target { get; set; }

    /// <inheritdoc/>
    protected override string GenerateFullPathToTool()
    {
      return ToolLocationHelper.GetPathToDotNetFrameworkSdkFile(this.ToolExe,
                                                                TargetDotNetFrameworkVersion.VersionLatest,
                                                                DotNetFrameworkArchitecture.Current);
    }

    /// <inheritdoc/>
    protected override string ToolName
    {
      get
      {
        return "TlbExp.exe";
      }
    }

    /// <inheritdoc/>
    protected override string GenerateCommandLineCommands()
    {
      var commandLineBuilder = new CommandLineBuilder();

      commandLineBuilder.AppendFileNameIfNotNull(this.Target);
      commandLineBuilder.AppendSwitchIfNotNull("/out:", System.IO.Path.ChangeExtension(this.Target, ".tlb"));

      var result = commandLineBuilder.ToString();

      return result;
    }
  }
}
