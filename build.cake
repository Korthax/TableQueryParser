#tool "nuget:?package=NUnit.ConsoleRunner"

var target = Argument("target", "Default");
var configuration = Argument("configuration", "Release");
var frameworks = new string[] { "net45", "net46" };

Task("Restore")
    .Does(() =>
    {
        foreach(var solution in GetFiles("./**/*.sln"))
            NuGetRestore(solution);
    });

Task("Build")
    .IsDependentOn("Restore")
    .Does(() =>
    {
        foreach(var framework in frameworks)
        {
            var settings = new MSBuildSettings 
            {
                Verbosity = Verbosity.Minimal,
                ToolVersion = MSBuildToolVersion.VS2017,
                Configuration = "Release"
            };

            settings.Properties.Add("Framework", new List<string> { framework });

            foreach(var solution in GetFiles("./**/*.sln"))
                MSBuild(solution, settings);
        }
    });

Task("Test")
    .IsDependentOn("Build")
    .Does(() =>
    {
        var testAssemblies = GetFiles("./tests/**/bin/Release/*.Tests.dll");
        NUnit3(testAssemblies, new NUnit3Settings { NoResults = true, NoHeader = true });
    });

Task("Pack")
    .IsDependentOn("Test")
    .Does(() =>
    {
        var nuGetPackSettings   = new NuGetPackSettings 
        {
            Version = "1.0.1",
            OutputDirectory = "./artifacts/"
        };

        foreach(var nuspec in GetFiles("./src/**/*.nuspec"))
            NuGetPack(nuspec, nuGetPackSettings);
    });

Task("Default")
    .IsDependentOn("Pack");

RunTarget(target);