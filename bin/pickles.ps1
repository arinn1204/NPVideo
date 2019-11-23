$pickles = "$Env:home\.nuget\packages\pickles.commandline\2.20.1\tools\pickles.exe"
$features = "--feature-directory=$Env:home\RiderProjects\Evo\src\Evo.WebApi.Tests.Integration\Features"
$reportDir = "--output-directory=$Env:home\RiderProjects\Evo\Reports\"
$testFormat = "--test-results-format=mstest"
$documentFormat = "--documentation-format=dhtml"
$testResults = "--link-results-file=$Env:home\RiderProjects\Evo\src\Evo.WebApi.Tests.Integration\TestResults\*.trx"
$projectName = "--system-under-test-name=Evo"

Get-ChildItem "$Env:home\RiderProjects\Evo\src\Evo.WebApi.Tests.Integration\TestResults\*" | Remove-Item

dotnet clean -c Debug

dotnet test --logger:trx

. $pickles `
    $projectName `
    $features `
    $reportDir `
    $testFormat `
    $documentFormat `
    $testResults