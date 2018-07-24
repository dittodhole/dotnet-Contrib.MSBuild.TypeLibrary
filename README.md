![](assets/noun_181229_cc.png)

# msbuild-Contrib.MSBuild.TypeLibrary

> Create _.tlb_-files ([Type Library](https://msdn.microsoft.com/en-us/library/windows/desktop/aa366757)) upon compilation.

## Installing

### [myget.org][1]

[![](https://img.shields.io/appveyor/ci/dittodhole/msbuild-contrib-msbuild-typelibrary/develop.svg)][2]
[![](https://img.shields.io/myget/dittodhole/vpre/Contrib.MSBuild.TypeLibrary.svg)][1]

```powershell
PM> Install-Package -Id Contrib.MSBuild.TypeLibrary -pre --source https://www.myget.org/F/dittodhole/api/v2
```

### [nuget.org][3]

[![](https://img.shields.io/appveyor/ci/dittodhole/msbuild-contrib-msbuild-typelibrary/master.svg)][4]
[![](https://img.shields.io/nuget/v/Contrib.MSBuild.TypeLibrary.svg)][3]

```powershell
PM> Install-Package -Id Contrib.MSBuild.TypeLibrary
```

## Developing & Building

```cmd
PS \> git clone https://github.com/dittodhole/msbuild-Contrib.MSBuild.TypeLibrary.git
PS \> cd msbuild-Contrib.MSBuild.TypeLibrary
PS \msbuild-Contrib.MSBuild.TypeLibrary> cd build
PS \msbuild-Contrib.MSBuild.TypeLibrary\build> ./build.ps1
```

This will create the following artifacts:

- `artifacts/Contrib.MSBuild.TypeLibrary.{version}.nupkg`

## License

msbuild-Contrib.MSBuild.TypeLibrary is published under [WTFNMFPLv3](https://github.com/dittodhole/WTFNMFPLv3).

## Icon

[Interoperability](https://thenounproject.com/term/interoperability/181229) by [anbileru adaleru](https://thenounproject.com/pronoun) from the Noun Project.

[1]: https://www.myget.org/feed/dittodhole/package/nuget/Contrib.MSBuild.TypeLibrary
[2]: https://ci.appveyor.com/project/dittodhole/msbuild-contrib-msbuild-typelibrary/branch/develop
[3]: https://www.nuget.org/packages/Contrib.MSBuild.TypeLibrary
[4]: https://ci.appveyor.com/project/dittodhole/msbuild-contrib-msbuild-typelibrary/branch/master