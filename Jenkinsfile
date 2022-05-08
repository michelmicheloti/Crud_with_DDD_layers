pipeline {
    agent any    
    stages {
         stage('Restore packages'){
            steps{
               sh 'dotnet restore API.sln'
            }
         }
         stage('Clean'){
            steps{
               sh 'dotnet clean API.sln --configuration Release'
            }
         }
         stage('Build'){
            steps{
               sh 'dotnet build API.sln --configuration Release --no-restore'
            }
         }
         stage('Test: Unit Test'){
            steps {
               sh 'dotnet test API.sln --collect:"XPlat Code Coverage" --configuration Release --no-restore'
            }
         }
         stage('Install ReportGenerator'){
            steps {
               sh 'dotnet tool install -g dotnet-reportgenerator-globaltool'
            }
         }
         stage('Generate Report'){
            steps {
               sh 'reportgenerator -reports:".\\TestResults\\{guid}\\coverage.cobertura.xml" -targetdir:"coveragereport" -reporttypes:Html'
            }
         }
         stage('Publish HTML report') {
            steps {
                  publishHTML(target: [allowMissing: false, alwaysLinkToLastBuild: false, keepAll: false, reportDir: 'coveragereport', reportFiles: 'index.html', reportName: 'HTML Report', reportTitles: 'Code Coverage Report'])
            }
         }
         stage('Publish'){
            steps{
               sh 'dotnet publish Application/Application.csproj --configuration Release --no-restore'
            }
         }
    }
}