param(
    [string] $projectKey = $(throw "Must specify projectKey. e.g., -projectKey SKYVERA"),
    [string] $jobName = $(throw "Must specify jobName. e.g., -jobName CI Build"),
    [string] $jobUrl = $(throw "Must specify jobUrl. e.g., -jobUrl http://jenkins.aureacentral.com/job/SkyVera/job/CI%20Builds/job/EPM%20CI%20Build/job/develop/"),
    [string] $error = $(throw "Must specify error. e.g., -error 'something went wrong'")
)

$params =@{
	project_key=$projectKey
	job_name=$jobName
	job_url=$jobUrl
	error=$error
}|ConvertTo-Json

Invoke-WebRequest -Uri http://private.central-eks.aureacentral.com/pca-qe/api/create/cicd_failure -Method POST -Body $params -ContentType "application/json"


