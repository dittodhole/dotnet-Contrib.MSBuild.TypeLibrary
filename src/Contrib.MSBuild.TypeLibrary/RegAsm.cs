using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;
using JetBrains.Annotations;

namespace Contrib.MSBuild.TypeLibrary
{
  public sealed class RegAsm : ToolTask
  {
    [Required]
    [NotNull]
    public string Target { get; set; }

    /// <inheritdoc/>
    protected override string GenerateFullPathToTool()
    {
      return ToolLocationHelper.GetPathToDotNetFrameworkFile(this.ToolExe,
                                                             TargetDotNetFrameworkVersion.VersionLatest,
                                                             DotNetFrameworkArchitecture.Current);
    }

    /// <inheritdoc/>
    protected override string ToolName
    {
      get
      {
        return "RegAsm.exe";
      }
    }

    /// <inheritdoc/>
    protected override string GenerateCommandLineCommands()
    {
      var commandLineBuilder = new CommandLineBuilder();

      commandLineBuilder.AppendFileNameIfNotNull(this.Target);
      commandLineBuilder.AppendSwitchIfNotNull("/regfile:", System.IO.Path.ChangeExtension(this.Target, ".reg"));

      var result = commandLineBuilder.ToString();

      return result;
    }
  }
}
