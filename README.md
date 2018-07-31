![](assets/noun_181229_cc.png)

# dotnet-Contrib.MSBuild.TypeLibrary

> Create _.tlb_-files ([Type Library](https://msdn.microsoft.com/en-us/library/windows/desktop/aa366757)) upon compilation.

## Installing

### [myget.org][1]

[![](https://img.shields.io/appveyor/ci/dittodhole/dotnet-contrib-msbuild-typelibrary/develop.svg)][2]
[![](https://img.shields.io/myget/dittodhole/vpre/Contrib.MSBuild.TypeLibrary.svg)][1]

```powershell
PM> Install-Package -Id Contrib.MSBuild.TypeLibrary -pre --source https://www.myget.org/F/dittodhole/api/v2
```

### [nuget.org][3]

[![](https://img.shields.io/appveyor/ci/dittodhole/dotnet-contrib-msbuild-typelibrary/master.svg)][4]
[![](https://img.shields.io/nuget/v/Contrib.MSBuild.TypeLibrary.svg)][3]

```powershell
PM> Install-Package -Id Contrib.MSBuild.TypeLibrary
```

## Developing & Building

```cmd
> git clone https://github.com/dittodhole/dotnet-Contrib.MSBuild.TypeLibrary.git
> cd dotnet-Contrib.MSBuild.TypeLibrary
dotnet-Contrib.MSBuild.TypeLibrary> cd build
dotnet-Contrib.MSBuild.TypeLibrary/build> build.bat
```

This will create the following artifacts:

- `artifacts/Contrib.MSBuild.TypeLibrary.{version}.nupkg`
- `artifacts/Contrib.MSBuild.TypeLibrary.{version}.symbols.nupkg`

## License

dotnet-Contrib.MSBuild.TypeLibrary is published under [WTFNMFPLv3](https://github.com/dittodhole/WTFNMFPLv3).

## Icon

[Interoperability](https://thenounproject.com/term/interoperability/181229) by [anbileru adaleru](https://thenounproject.com/pronoun) from the Noun Project.

[1]: https://www.myget.org/feed/dittodhole/package/nuget/Contrib.MSBuild.TypeLibrary
[2]: https://ci.appveyor.com/project/dittodhole/dotnet-contrib-msbuild-typelibrary/branch/develop
[3]: https://www.nuget.org/packages/Contrib.MSBuild.TypeLibrary
[4]: https://ci.appveyor.com/project/dittodhole/dotnet-contrib-msbuild-typelibrary/branch/master