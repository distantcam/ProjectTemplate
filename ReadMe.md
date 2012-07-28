This is a set of scripts to help set up a new project quickly.

To use it:

    msbuild Template.proj /p:Namespace="MyNewProjectName"

There is also a WPF base project.

    msbuild TemplateWPF.proj /p:Namespace="MyNewWPFProject"

The WPF project uses the following libraries:

- [Autofac](http://code.google.com/p/autofac/)
- [Caliburn.Micro](http://caliburnmicro.codeplex.com/)
- [Caliburn.Micro.Autofac](https://github.com/dbuksbaum/Caliburn.Micro.Autofac)
- [NLog](http://nlog-project.org/)
- [PropertyChanged](https://github.com/SimonCropp/PropertyChanged)/[PropertyChanging](https://github.com/SimonCropp/PropertyChanging)/[ModuleInit](https://github.com/SimonCropp/ModuleInit) from [Fody](https://github.com/SimonCropp/Fody)
- [ReactiveUI](https://github.com/xpaulbettsx/ReactiveUI)

The tests use:

- [ApprovalTests](http://approvaltests.sourceforge.net/)
- [XUnit + Extensions](http://xunit.codeplex.com/)
