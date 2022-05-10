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
         stage('Generate Report'){            
            steps {          
               sh 'dotnet tool restore && dotnet reportgenerator "-reports:TestsResult/**/*.xml" "-targetDir:_ResultHTML"'
            }
         }
         stage('Publish HTML report') {
            steps {
                  publishHTML(target: [allowMissing: false, alwaysLinkToLastBuild: false, keepAll: false, reportDir: '_ResultHTML', reportFiles: 'index.html', reportName: 'HTML Report', reportTitles: 'Code Coverage Report'])
            }
         }
         stage('Build docker image'){
            steps{
               sh 'docker build -t crudwithdddlayers .'
            }
         }
    }
    post {
    always {
      xunit (testDataPublishers: [[$class: 'ClaimTestDataPublisher']], thresholds: [ skipped(failureThreshold: '0'), failed(failureThreshold: '0')], tools: [[$class: 'MSTestJunitHudsonTestType', pattern: 'TestsResult/**/*.xml']])
    }
  }
}