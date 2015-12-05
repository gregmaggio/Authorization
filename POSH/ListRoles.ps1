$apiUrl = 'http://localhost:4394'
$loginSessionApi = 'api/LoginSession'
$postParameters = @{
    email = 'gregorymaggio@gmail.com'
    password ='MhfSlcNPFmiy8L7sYZQw'
}
$json = ($postParameters | ConvertTo-Json -Compress)
$url = "$apiUrl/$loginSessionApi/"
$response = Invoke-WebRequest -Uri $url -Method Post -ContentType 'application/json' -Body $json
$location = $response.Headers["location"]
Write-Host "location: $location"
$response = Invoke-WebRequest -Uri $location -Method Get
$responseText = $response.Content
Write-Host "loginSession: $responseText"
$loginSession = ($responseText | ConvertFrom-Json)
$sessionId = $loginSession.sessionId
$roleApi = 'api/Role'
$url = [string]::Format("{0}/{1}/?sessionId={2}", $apiUrl, $roleApi, $sessionId)
$response = Invoke-WebRequest -Uri $url -Method Get
$responseText = $response.Content
Write-Host "roles: $responseText"


