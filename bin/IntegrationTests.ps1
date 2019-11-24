param(
    [String]$username = "$Env:DB_USERNAME",
    [String]$password = "$Env:DB_PASSWORD",
    [String]$catalog = "$Env:DB_CATALOG",
    [String]$source = "$Env:DB_SOURCE",
    [String]$workingDirectory = "",
    [String]$Configuration="Debug",
    [String]$DebugPreference="SilentlyContinue"
);

if ([String]::IsNullOrWhiteSpace($workingDirectory)) {
    Push-Location src\test\integration
} else {
    Push-Location $workingDirectory\src\test\integration
}

$Env:db_username = $username;
$Env:db_password = $password;
$Env:db_catalog = $catalog;
$Env:db_source = $source;

$testProjects = Get-ChildItem -Recurse *.csproj

foreach ($project in $testProjects) {
    dotnet restore $project
    dotnet clean -c $Configuration $project
    dotnet build -c $Configuration $project
    dotnet test -c $Configuration --no-build $project
    
    if (-Not $?) {
        Pop-Location
        throw "Test run failed. See earlier for errors"
    }
}


Pop-Location
