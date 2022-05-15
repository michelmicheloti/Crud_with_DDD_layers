pipeline {
  agent any
  options {
    allowBrokenBuildClaiming()
  }
  stages {
    stage('Restore packages') {
      steps {
        sh 'heroku auth:token'
        sh 'dotnet restore API.sln'
        sh 'dotnet clean API.sln --configuration Release'
        sh 'dotnet build API.sln --configuration Release --no-restore'
      }
    }
    stage('Test: Unit Test') {
      steps {
        sh 'dotnet test --collect:"XPlat Code Coverage" -r \\TestsResult --configuration Release --no-restore'
        sh 'dotnet test -l:trx'
        sh 'dotnet tool restore && dotnet reportgenerator "-reports:TestsResult/**/*.xml" "-targetDir:_ResultHTML"'
      }
    }
    stage('Publish HTML report') {
      steps {
        publishHTML([allowMissing: false, alwaysLinkToLastBuild: false, keepAll: false, reportDir: '_ResultHTML', reportFiles: 'index.html', reportName: 'HTML Report', reportTitles: 'Code Coverage Report'])
      }
    }
    stage('Build docker image'){
      steps{
        sh 'docker build -t crudwithdddlayers .'
      }
    }
    stage('Push image to Heroku'){
      steps{
        sh 'heroku container:push -a crud-eng-soft2 web'
        sh 'heroku container:release -a crud-eng-soft2 web'
      }
    }
  }
  post {
    always {
      xunit (testDataPublishers: [[$class: 'ClaimTestDataPublisher']], thresholds: [ skipped(failureThreshold: '0'), failed(failureThreshold: '0')], tools: [[$class: 'MSTestJunitHudsonTestType', pattern: '**/*.trx']])
    }
  }
}