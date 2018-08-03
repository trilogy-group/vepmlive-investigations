function SetAssemblyFileVersion ($assemblyInfoFile, $version) {
    $regexp = "AssemblyFileVersion\(\""(\d+)\.(\d+)\.(\d+)\.(\d+)\""\)"
    $replacement = "AssemblyFileVersion(""$version"")"
    (Get-Content $assemblyInfoFile) | ForEach-Object { $_ -replace $regexp, $replacement } | Set-Content $assemblyInfoFile
}

function SetBuildVersion ($buildVersionFile, $version) {
    $regexp = "Version(""@BuildVersion@"")"
    $replacement = "Version(""$version"")"
    (Get-Content $buildVersionFile) | ForEach-Object { $_ -replace $regexp, $replacement } | Set-Content $buildVersionFile
}