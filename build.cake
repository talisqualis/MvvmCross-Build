var target = Argument<string>("target", "Default");
var configuration = Argument<string>("configuration", "Release");

Task("Restore-MvvmCross-NuGets")
	.Does(() =>
	{
		NuGetRestore("./MvvmCross/MvvmCross_All.sln");
	});

Task("Build-MvvmCross")
	.IsDependentOn("Restore-MvvmCross-NuGets")
	.Does(() =>
	{
		// WP8 / UWP / VSIX
		MSBuild("./MvvmCross/MvvmCross_All.sln", 
			settings => {
				settings.SetConfiguration(configuration);
				settings.SetPlatformTarget(PlatformTarget.x86);
			});
			
		MSBuild("./MvvmCross/MvvmCross_All.sln", 
			settings => settings.SetConfiguration(configuration));
	});

Task("Default")
	.IsDependentOn("Build-MvvmCross");
	
RunTarget(target);