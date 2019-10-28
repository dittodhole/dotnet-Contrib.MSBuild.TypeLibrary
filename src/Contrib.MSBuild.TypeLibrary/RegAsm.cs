using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;
using JetBrains.Annotations;

namespace Contrib.MSBuild.TypeLibrary
{
  public sealed class RegAsm : ToolTask
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

      commandLineBuilder.AppendFileNameIfNotNull(this.Assembly);
      commandLineBuilder.AppendSwitchIfNotNull("/regfile:", RegAsm.GetRegFileTaskItem(this.Assembly));

      var result = commandLineBuilder.ToString();

      return result;
    }

    /// <inheritdoc/>
    public override bool Execute()
    {
      var result = base.Execute();
      if (result)
      {
        this.OutputFile = RegAsm.GetRegFileTaskItem(this.Assembly);
      }

      return result;
    }

    [NotNull]
    private static ITaskItem GetRegFileTaskItem([NotNull] ITaskItem assembly)
    {
      var result = new TaskItem(assembly)
                   {
                     ItemSpec = System.IO.Path.ChangeExtension(assembly.ItemSpec, ".reg")
                   };

      return result;
    }
  }
}
