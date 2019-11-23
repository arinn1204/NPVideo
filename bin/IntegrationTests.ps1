param(
    [String]$username = "",
    [String]$password = "",
    [String]$catalog = "",
    [String]$source = "",
    [String]$secret_var = "",
    [String]$Configuration="Debug",
    [String]$DebugPreference="SilentlyContinue"
);

Write-Host "Secret Variable: $secret_var"
Write-Host "Secret Variable is hunter2: "($secret_var -eq "hunter2")

Push-Location src\test\integration

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