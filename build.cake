 
#module nuget:?package=Cake.DotNetTool.Module

var target = Argument("target", "default");
var configuration = Argument("configuration", "Release");
var solution = Argument("solution", "MLambda.sln");
var artifacts = Argument("artifacts", "./.artifacts");
var sonarKey = EnvironmentVariable("SONARKEY") ?? "";
var ApiKey = EnvironmentVariable("APIKEY") ?? "";
var branch = EnvironmentVariable("TRAVIS_BRANCH") ?? "master";
var version = "0.0.1";



Task("analysis-begin").Does(()=> {
    var setting = new DotNetCoreToolSettings {
        ArgumentCustomization = 
            args => args.Append("begin")
                        .Append("/k:RoyGI_MLambda")
                        .Append("/n:MLambda")
                        .Append("/v:{0}",version )
                        .Append("/d:sonar.cs.opencover.reportsPaths=./TestResults/coverage.opencover.xml")
                        .Append("/d:sonar.test.exclusions=test/**")
                        .Append("/d:sonar.exclusions=data/**,examples/**")
                        .Append("/d:sonar.branch.name={0}", branch)
                        .Append("/d:sonar.links.ci=https://travis-ci.com/RoyGI/MLambda")
                        .Append("/d:sonar.host.url=https://sonarcloud.io")
                        .Append("/d:sonar.login={0}",sonarKey)
                        .Append("/o:roygi")
    };
    
    DotNetCoreTool("sonarscanner", setting);
});

Task("analysis-end").Does(()=> {
   var setting = new DotNetCoreToolSettings {
        ArgumentCustomization = 
           args => args.Append("end")
                       .Append("/d:sonar.login={0}",sonarKey)
    };
    
    DotNetCoreTool("sonarscanner", setting);
});


Task("test").Does(() => {
    var setting = new DotNetCoreTestSettings{
        ArgumentCustomization = args => {
                return args.Append("/p:CollectCoverage=true")
                           .Append("/p:CoverletOutputFormat=opencover")
                           .Append("/p:CoverletOutput=../../TestResults/");
        },
        Configuration = configuration,
        Logger = "trx",
        ResultsDirectory="./TestResults"
    };
    
    DotNetCoreTest(solution, setting);    
});

Task("version").Does(() => {
    try {
    
        var settings = new ProcessSettings { 
            Arguments = "gitversion /showvariable NuGetVersion", 
            RedirectStandardOutput = true 
        };

        using(var process = StartAndReturnProcess("dotnet",settings)) {
            version = process.GetStandardOutput().First();
        };
                   
    }
    catch(Exception e) {
        Information("version error {0}", e.Message);
    }
  
});


Task("pack").Does(() => {
    
      var settings = new DotNetCorePackSettings
         {
            ArgumentCustomization = 
                                args => args.Append($"/p:Version={version}")
                                            .Append($"/p:IncludeSymbols=false")
                                            .Append("/p:SymbolPackageFormat=snupkg"),
            Configuration = configuration,
            OutputDirectory = artifacts
         };

        DotNetCorePack(solution, settings);
});


Task("push").Does(() => {
   var settings = new DotNetCoreNuGetPushSettings
       {
           Source = "https://api.bintray.com/nuget/roygi/mlibrary",
           ApiKey = $"roygi:{ApiKey}"
       };
       
    DotNetCoreNuGetPush( "./.artifacts/*.nupkg", settings);
});


Task("restore").Does(()=> { 
     var settings = new DotNetCoreRestoreSettings
     {
         Sources = new[] {"https://api.nuget.org/v3/index.json", "https://api.bintray.com/nuget/roygi/mlibrary"},
         PackagesDirectory = "./packages",
         Verbosity = DotNetCoreVerbosity.Quiet,
         Force = true,
         DisableParallel = false,
     };
     
    DotNetCoreRestore(solution, settings); 
});

Task("clean").Does(() =>{
    CleanDirectories("./.artifacts");
    CleanDirectories("./.migration");
    CleanDirectories(string.Format("./**/obj/{0}", configuration));
    CleanDirectories(string.Format("./**/bin/{0}", configuration));
});

Task("build").Does(()=> {
    var setting = new DotNetCoreBuildSettings {
        Configuration = configuration,
        NoRestore = true
    };
    
    DotNetCoreBuild(solution, setting);
});
    
Task("default")
        .IsDependentOn("clean")
        .IsDependentOn("restore")
        .IsDependentOn("version")
        .IsDependentOn("analysis-begin")
        .IsDependentOn("build")
        .IsDependentOn("test")
        .IsDependentOn("analysis-end");

Task("deploy")
    .IsDependentOn("pack")
    .IsDependentOn("push");
        
Task("check")
        .IsDependentOn("clean")
        .IsDependentOn("restore")
        .IsDependentOn("build")
        .IsDependentOn("test");
        
RunTarget(target);