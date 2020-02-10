using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;

namespace Contrib.MSBuild.TypeLibrary
{
  public sealed class TlbExp : ToolTask
  {
    [Required]
    public ITaskItem Assembly { get; set; }

    [Output]
    public ITaskItem TlbFile { get; set; }

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
      commandLineBuilder.AppendSwitchIfNotNull("/out:", TlbExp.GetTlbFileTaskItem(this.Assembly));

      var result = commandLineBuilder.ToString();

      return result;
    }

    /// <inheritdoc/>
    public override bool Execute()
    {
      var result = base.Execute();
      if (result)
      {
        this.TlbFile = TlbExp.GetTlbFileTaskItem(this.Assembly);
      }

      return result;
    }

    private static ITaskItem GetTlbFileTaskItem(ITaskItem assembly)
    {
      var result = new TaskItem(assembly)
                   {
                     ItemSpec = System.IO.Path.ChangeExtension(assembly.ItemSpec, ".tlb")
                   };

      return result;
    }
  }
}
