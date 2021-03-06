$sourceNugetExe = "http://nuget.org/nuget.exe"
$targetNugetExe = $PSScriptRoot + "\nuget.exe"

if (-Not(Test-Path ("nuget.exe")))
{
	Invoke-WebRequest $sourceNugetExe -OutFile $targetNugetExe
}

Set-Alias nuget $targetNugetExe -Scope Global -Verbose

del *.nupkg

nuget pack MvvmCross.HotTuna.Plugin.Accelerometer.nuspec -Symbols
nuget pack MvvmCross.HotTuna.Plugin.All.nuspec -Symbols
nuget pack MvvmCross.HotTuna.Plugin.Bookmarks.nuspec -Symbols
nuget pack MvvmCross.HotTuna.Plugin.Color.nuspec -Symbols
nuget pack MvvmCross.HotTuna.Plugin.DownloadCache.nuspec -Symbols
nuget pack MvvmCross.HotTuna.Plugin.Email.nuspec -Symbols
nuget pack MvvmCross.HotTuna.Plugin.FieldBinding.nuspec -Symbols
nuget pack MvvmCross.HotTuna.Plugin.File.nuspec -Symbols
nuget pack MvvmCross.HotTuna.Plugin.Json.nuspec -Symbols
nuget pack MvvmCross.HotTuna.Plugin.JsonLocalisation.nuspec -Symbols
nuget pack MvvmCross.HotTuna.Plugin.Location.nuspec -Symbols
nuget pack MvvmCross.HotTuna.Plugin.Messenger.nuspec -Symbols
nuget pack MvvmCross.HotTuna.Plugin.MethodBinding.nuspec -Symbols
nuget pack MvvmCross.HotTuna.Plugin.Network.nuspec -Symbols
nuget pack MvvmCross.HotTuna.Plugin.PhoneCall.nuspec -Symbols
nuget pack MvvmCross.HotTuna.Plugin.PictureChooser.nuspec -Symbols
nuget pack MvvmCross.HotTuna.Plugin.ReflectionEx.nuspec -Symbols
nuget pack MvvmCross.HotTuna.Plugin.ResourceLoader.nuspec -Symbols
nuget pack MvvmCross.HotTuna.Plugin.Share.nuspec -Symbols
nuget pack MvvmCross.HotTuna.Plugin.SoundEffects.nuspec -Symbols
nuget pack MvvmCross.HotTuna.Plugin.SQLitePCL.nuspec -Symbols
nuget pack MvvmCross.HotTuna.Plugin.ThreadUtils.nuspec -Symbols
nuget pack MvvmCross.HotTuna.Plugin.Visibility.nuspec -Symbols
nuget pack MvvmCross.HotTuna.Plugin.WebBrowser.nuspec -Symbols

pause
