Function DeGZip-File{
    Param(
        $infile,
        $outfile = ($infile -replace '\.gz$','')
        )

    $input = New-Object System.IO.FileStream $inFile, ([IO.FileMode]::Open), ([IO.FileAccess]::Read), ([IO.FileShare]::Read)
    $output = New-Object System.IO.FileStream $outFile, ([IO.FileMode]::Create), ([IO.FileAccess]::Write), ([IO.FileShare]::None)
    $gzipStream = New-Object System.IO.Compression.GzipStream $input, ([IO.Compression.CompressionMode]::Decompress)

    $buffer = New-Object byte[](1024)
    while($true){
        $read = $gzipstream.Read($buffer, 0, 1024)
        if ($read -le 0){break}
        $output.Write($buffer, 0, $read)
        }

    $gzipStream.Close()
    $output.Close()
    $input.Close()
}

Invoke-WebRequest -Uri https://cdn.rage.mp/updater/prerelease/server-files/linux_x64.tar.gz -OutFile ./linux_x64.tar.gz

tar xfz ./linux_x64.tar.gz
Remove-Item -Force -Recurse linux_release
Rename-Item ragemp-srv linux_release
Robocopy.exe ./client_packages ./linux_release/client_packages /s
Robocopy.exe ./dotnet/resources ./linux_release/dotnet/resources /s /xd obj bin .idea

Copy-Item ./dotnet/settings.xml ./linux_release/dotnet/settings.xml
Copy-Item ./conf.json ./linux_release/conf.json 

Push-Location ./linux_release/dotnet/resources
dotnet build
Pop-Location