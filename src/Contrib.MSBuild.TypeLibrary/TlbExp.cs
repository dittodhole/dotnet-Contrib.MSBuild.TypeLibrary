using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;
using JetBrains.Annotations;

namespace Contrib.MSBuild.TypeLibrary
{
  public sealed class TlbExp : ToolTask
  {
    [Required]
    [NotNull]
    public ITaskItem Assembly { get; set; }

    [Output]
    [NotNull]
    public ITaskItem OutputFile { get; set; }

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

      commandLineBuilder.AppendFileNameIfNotNull(this.Assembly);
      commandLineBuilder.AppendSwitchIfNotNull("/out:", System.IO.Path.ChangeExtension(this.Assembly.ItemSpec, ".tlb"));

      var result = commandLineBuilder.ToString();

      return result;
    }
  }
}
