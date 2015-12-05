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
