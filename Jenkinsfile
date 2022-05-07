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
                sh 'dotnet test API.sln --configuration Release --no-restore'
             }
          }
        stage('Publish'){
             steps{
               sh 'dotnet publish API/Application.csproj --configuration Release --no-restore'
             }
        }
    }
}