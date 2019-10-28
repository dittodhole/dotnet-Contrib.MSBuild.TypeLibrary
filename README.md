![](assets/noun_181229_cc.png)

# dotnet-Contrib.MSBuild.TypeLibrary

> Create _.tlb_-files ([Type Library](https://msdn.microsoft.com/en-us/library/windows/desktop/aa366757)) upon compilation.

## Build status

[![](https://img.shields.io/appveyor/ci/dittodhole/dotnet-contrib-msbuild-typelibrary.svg)](https://ci.appveyor.com/project/dittodhole/dotnet-contrib-msbuild-typelibrary)

## Installing

### myget.org

[![](https://img.shields.io/myget/dittodhole/vpre/Contrib.MSBuild.TypeLibrary.svg)](https://www.myget.org/feed/dittodhole/package/nuget/Contrib.MSBuild.TypeLibrary)

```powershell
PM> Install-Package -Id Contrib.MSBuild.TypeLibrary -pre --source https://www.myget.org/F/dittodhole/api/v2
```

### nuget.org

[![](https://img.shields.io/nuget/v/Contrib.MSBuild.TypeLibrary.svg)](https://www.nuget.org/packages/Contrib.MSBuild.TypeLibrary)

```powershell
PM> Install-Package -Id Contrib.MSBuild.TypeLibrary
```

## Configuration

You can override following properties with `Directory.Build.props`:

- `ContribMSBuildTypeLibrary_Active` (default: `true` on release builds, otherwise `false`)
- `ContribMSBuildTypeLibrary_RegAsmExe`
- `ContribMSBuildTypeLibrary_RegAsmPath`
- `ContribMSBuildTypeLibrary_TlbExpExe`
- `ContribMSBuildTypeLibrary_TlbExpPath`


## Developing & Building

```cmd
> git clone https://github.com/dittodhole/dotnet-Contrib.MSBuild.TypeLibrary.git
> cd dotnet-Contrib.MSBuild.TypeLibrary
dotnet-Contrib.MSBuild.TypeLibrary> cd build
dotnet-Contrib.MSBuild.TypeLibrary/build> build.bat
```

This will create the following artifacts:

- `artifacts/Contrib.MSBuild.TypeLibrary.{version}.nupkg`

## License

dotnet-Contrib.MSBuild.TypeLibrary is published under [WTFNMFPLv3](https://github.com/dittodhole/WTFNMFPLv3).

## Icon

[Interoperability](https://thenounproject.com/term/interoperability/181229) by [anbileru adaleru](https://thenounproject.com/pronoun) from the Noun Project.
