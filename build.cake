var target = Argument<string>("target", "Default");
var configuration = Argument<string>("configuration", "Release");

var nugetFolder = "./nuget";

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
	
Task("Create-MvvmCross-NuGets")
	.IsDependentOn("Build-MvvmCross")
	.Does(() =>
	{
		var nugetSettings = new NuGetPackSettings {
			Version = "4.0.0-beta7",
			Symbols = true,
			OutputDirectory = nugetFolder
		};
		if (!DirectoryExists(nugetFolder))
			CreateDirectory(nugetFolder);
			
		NuGetPack("./MvvmCross/nuspec/MvvmCross.HotTuna.Binding.nuspec", nugetSettings);
		NuGetPack("./MvvmCross/nuspec/MvvmCross.HotTuna.CrossCore.nuspec", nugetSettings);
		NuGetPack("./MvvmCross/nuspec/MvvmCross.HotTuna.MvvmCrossLibraries.nuspec", nugetSettings);
		NuGetPack("./MvvmCross/nuspec/MvvmCross.HotTuna.Tests.nuspec", nugetSettings);
		NuGetPack("./MvvmCross/nuspec/MvvmCross.HotTuna.Touch.Dialog.nuspec", nugetSettings);
		NuGetPack("./MvvmCross/nuspec/MvvmCross.HotTuna.Droid.Dialog.nuspec", nugetSettings);
		NuGetPack("./MvvmCross/nuspec/MvvmCross.BindingEx.nuspec", nugetSettings);
		NuGetPack("./MvvmCross/nuspec/MvvmCross.HotTuna.AutoViews.nuspec", nugetSettings);
		NuGetPack("./MvvmCross/nuspec/MvvmCross.HotTuna.Touch.AutoViews.nuspec", nugetSettings);
		NuGetPack("./MvvmCross/nuspec/MvvmCross.HotTuna.Droid.AutoViews.nuspec", nugetSettings);
		NuGetPack("./MvvmCross/nuspec/MvvmCross.HotTuna.Droid.FullFragging.nuspec", nugetSettings);
		
		// No symbols
		nugetSettings.Symbols = false;
		NuGetPack("./MvvmCross/nuspec/MvvmCross.nuspec", nugetSettings);
		NuGetPack("./MvvmCross/nuspec/MvvmCross.HotTuna.StarterPack.nuspec", nugetSettings);
	});
	
Task("Create-Temporary-Local-NuGet-Repo")
	.Does(() =>
	{
		NuGetAddSource("mvvmcross-local", nugetFolder);
	});
	
Task("Remove-Temporary-Local-NuGet-Repo")
	.Does(() =>
	{
	
	});

Task("Default")
	.IsDependentOn("Build-MvvmCross")
	.IsDependentOn("Create-MvvmCross-NuGets");
	
RunTarget(target);