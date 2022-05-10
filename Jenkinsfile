pipeline {
  agent any
  options {
    allowBrokenBuildClaiming()
  }
  stages {
    stage('Restore packages') {
      steps {
        sh 'dotnet restore API.sln'
        sh 'dotnet clean API.sln --configuration Release'
        sh 'dotnet build API.sln --configuration Release --no-restore'
      }
    }

    stage('Test: Unit Test') {
      steps {
        sh 'dotnet test --collect:"XPlat Code Coverage" -r \\TestsResult --configuration Release --no-restore'
        sh 'dotnet tool restore && dotnet reportgenerator "-reports:TestsResult/**/*.xml" "-targetDir:_ResultHTML"'
      }
    }
    stage('Publish HTML report') {
      steps {
        publishHTML([allowMissing: false, alwaysLinkToLastBuild: false, keepAll: false, reportDir: '_ResultHTML', reportFiles: 'index.html', reportName: 'HTML Report', reportTitles: 'Code Coverage Report'])
      }
    }
    stage('Test: xUnit') {
      steps {
            sh 'dotnet test -l:trx'
         }  
      }
   }
   post {
      always {
         xunit (testDataPublishers: [[$class: 'ClaimTestDataPublisher']], thresholds: [ skipped(failureThreshold: '0'), failed(failureThreshold: '0')], tools: [[$class: 'MSTestJunitHudsonTestType', pattern: '**/*.trx']])
      }
   }
}