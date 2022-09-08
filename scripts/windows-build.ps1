Write-Output "Installing client packages...
"
Push-Location client_packages_dev\js_packages
npm i
Write-Output "Building client packages...
"
npm run build

Write-Output "Installing CEF packages...
"
Pop-Location
Push-Location client_packages_dev\web_packages\alternativa-cef
npm i
Write-Output "Building CEF packages...
"
npm run build

Write-Output "Building server resources...
"
Pop-Location
Push-Location dotnet\resources
dotnet clean
dotnet build

Pop-Location