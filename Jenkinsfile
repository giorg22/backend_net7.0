pipeline {
  agent any
  stages {
    stage('Dotnet Restore') {
      when {
        branch 'Dev'
      }
      steps {
        bat 'powershell -NoExit -Command dotnet restore'
      }
    }

    stage('Dotnet Clean') {
      when {
        branch 'Dev'
      }
      steps {
        bat 'powershell -NoExit -Command dotnet clean'
      }
    }

    stage('Build') {
      when {
        branch 'Dev'
      }
      steps {
        bat 'powershell -NoExit -Command "Set-Location .\\backend_net7.0"; dotnet publish backend_net7.0.csproj -c Release -r win-x64 --self-contained false -o D:\\PublishFoldersAndScripts\\Mort_BackEnd'
      }
    }

    stage('Publish_Development') {
      when {
        branch 'Dev'
      }
      steps {
        bat 'powershell.exe -ExecutionPolicy Bypass -Command "D:\\PublishFoldersAndScripts\\Publish_Mort_Dev_Back.ps1"'
     }
    }

    stage('ClearWorkSpase') {
      steps {
        powershell 'Invoke-RestMethod "http://bi.msg.ge/sendsms.php?username=admi&password=84cGQ14zvN&client_id=664&service_id=2208&to=+995574777707&text=MortApp BackEnd Publish on Dev is Done" -Method "GET"'
        powershell 'Invoke-RestMethod "http://bi.msg.ge/sendsms.php?username=admi&password=84cGQ14zvN&client_id=664&service_id=2208&to=+995598912128&text=MortApp BackEnd Publish on Dev is Done" -Method "GET"'
        powershell 'Invoke-RestMethod "http://bi.msg.ge/sendsms.php?username=admi&password=84cGQ14zvN&client_id=664&service_id=2208&to=+995598250510&text=MortApp BackEnd Publish on Dev is Done" -Method "GET"'
        deleteDir()
      }
    }
  }
}