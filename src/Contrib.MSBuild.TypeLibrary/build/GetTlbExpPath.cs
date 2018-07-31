using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;

// ReSharper disable CheckNamespace

namespace Contrib.MSBuild.TypeLibrary
{
  public partial class GetTlbExpPath : Task
  {
    public const string TlbExpFileName = "TlbExp.exe";

    [Output]
    public virtual string Path { get; set; }

    /// <inheritdoc />
    public override bool Execute()
    {
      this.Path = ToolLocationHelper.GetPathToDotNetFrameworkSdkFile(GetTlbExpPath.TlbExpFileName,
                                                                     TargetDotNetFrameworkVersion.VersionLatest,
                                                                     VisualStudioVersion.VersionLatest,
                                                                     DotNetFrameworkArchitecture.Current);

      var result = !string.IsNullOrEmpty(this.Path);

      return result;
    }
  }
}
