param(
    [String]$username = "$Env:DB_USERNAME",
    [String]$password = "$Env:DB_PASSWORD",
    [String]$catalog = "$Env:DB_CATALOG",
    [String]$source = "$Env:DB_SOURCE",
    [String]$secret_var = "$Env:SECRET_VAR",
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
