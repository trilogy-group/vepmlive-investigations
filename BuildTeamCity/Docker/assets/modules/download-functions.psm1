Import-Module "$PSScriptRoot\common-functions.psm1"

function DownloadWebClient ([string] $url, [string] $filePath) {
    Write-Verbose "Downloading $url with WebClient"
    (New-Object System.Net.WebClient).DownloadFile($url, $filePath)
}

function DownloadWebRequest ([string] $url, [string] $filePath) {
    Write-Verbose "Downloading $url with Invoke-WebRequest"
    Invoke-WebRequest -Uri $url -OutFile $filePath
}

function DownloadJob ([string] $url, [string] $filePath) {
    Write-Verbose "Downloading $url with Start-BitsTransfer"
    Start-BitsTransfer -Source $url -Destination $filePath
}

function DownloadFromWeb {
    [CmdletBinding()]
    param(
        [string] $url,
        [string] $filePath,
        [ValidateSet('WebClient', 'WebRequest', 'Bits', 'NewMethod')]
        [string] $downloadType = 'WebClient'
    )
    Log "Downloading $url ..."
    [System.Diagnostics.Stopwatch] $sw = [System.Diagnostics.Stopwatch]::StartNew()
    switch ($downloadType) {
        WebClient { DownloadWebClient $url $filePath }
        WebRequest { DownloadWebRequest $url $filePath }
        Bits { DownloadJob $url $filePath }
    }
    $sw.Stop()
    Write-Verbose "Download completed in $($sw.Elapsed)"
}

function DownloadFromS3 {
    [CmdletBinding()]
    param(
        [string] $key,
        [string] $filePath,
        [string] $bucket,
        [string] $accessKey,
        [string] $secretKey,
        [string] $region
    )
    Log "Downloading $key from $bucket ..."
    Read-S3Object -Key $key -File $filePath -BucketName $bucket -AccessKey $accessKey -SecretKey $secretKey -Region $region | Out-Null
}

Export-ModuleMember -Function DownloadFromWeb, DownloadFromS3
