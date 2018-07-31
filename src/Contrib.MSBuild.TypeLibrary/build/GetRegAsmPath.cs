using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;

// ReSharper disable CheckNamespace

namespace Contrib.MSBuild.TypeLibrary
{
  public partial class GetRegAsmPath : Task
  {
    public const string RegAsmFileName = "RegAsm.exe";

    [Output]
    public virtual string Path { get; set; }

    /// <inheritdoc />
    public override bool Execute()
    {
      this.Path = ToolLocationHelper.GetPathToDotNetFrameworkFile(GetRegAsmPath.RegAsmFileName,
                                                                  TargetDotNetFrameworkVersion.VersionLatest,
                                                                  DotNetFrameworkArchitecture.Current);

      var result = !string.IsNullOrEmpty(this.Path);

      return result;
    }
  }
}
