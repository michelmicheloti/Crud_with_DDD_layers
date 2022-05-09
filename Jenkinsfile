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
               sh 'dotnet test --collect:"XPlat Code Coverage" -r \\TestsResult --configuration Release --no-restore'
            }
         }
         stage('Install ReportGenerator'){
            steps {
               sh 'dotnet new tool-manifest'
               sh 'dotnet tool install --local dotnet-reportgenerator-globaltool --version 5.1.6'
            }
         }
         stage('Generate Report'){
            steps {
               sh 'dotnet reportgenerator "-reports:TestsResult/**/*.xml" "-targetDir:_ResultHTML"'
            }
         }
         stage('Publish HTML report') {
            steps {
                  publishHTML(target: [allowMissing: false, alwaysLinkToLastBuild: false, keepAll: false, reportDir: '_ResultHTML', reportFiles: 'index.html', reportName: 'HTML Report', reportTitles: 'Code Coverage Report'])
            }
         }
         stage('Publish'){
            steps{
               sh 'dotnet publish Application/Application.csproj --configuration Release --no-restore'
            }
         }
    }
}