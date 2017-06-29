pipeline {
  agent any
  stages {
    stage('Prepare') {
      steps {
        bat(script: 'dotnet restore', returnStatus: true, returnStdout: true)
      }
    }
    stage('Build') {
      steps {
        parallel(
          "Win10-x64": {
            bat(script: 'dotnet publish -c Release -r win10-x64', returnStatus: true, returnStdout: true)
            
          },
          "Win10-x86": {
            bat(script: 'dotnet publish -c Release -r win10-x86', returnStatus: true, returnStdout: true)
            
          },
          "Win81-x64": {
            bat(script: 'dotnet publish -c Release -r win81-x64', returnStatus: true, returnStdout: true)
            
          },
          "Win81-x86": {
            bat(script: 'dotnet publish -c Release -r win81-x86', returnStatus: true, returnStdout: true)
            
          },
          "Win8-x64": {
            bat(script: 'dotnet publish -c Release -r win8-x64', returnStatus: true, returnStdout: true)
            
          },
          "Win8-x86": {
            bat(script: 'dotnet publish -c Release -r win8-x86', returnStatus: true, returnStdout: true)
            
          },
          "Win7-x64": {
            bat(script: 'dotnet publish -c Release -r win7-x64', returnStatus: true, returnStdout: true)
            
          },
          "Win7-x86": {
            bat(script: 'dotnet publish -c Release -r win7-x86', returnStatus: true, returnStdout: true)
            
          }
        )
      }
    }
    stage('Build Mac') {
      steps {
        parallel(
          "OSX10.12": {
            bat(script: 'dotnet publish -c Release -r osx.10.12-x64', returnStatus: true, returnStdout: true)
            
          },
          "OSX10.11": {
            bat(script: 'dotnet publish -c Release -r osx.10.11-x64', returnStatus: true, returnStdout: true)
            
          },
          "OSX10.10": {
            bat(script: 'dotnet publish -c Release -r osx.10.10-x64', returnStatus: true, returnStdout: true)
            
          }
        )
      }
    }
    stage('Build Linux') {
      steps {
        parallel(
          "Ubuntu16.10-x64": {
            bat(script: 'dotnet publish -c Release -r ubuntu.16.10-x64', returnStatus: true, returnStdout: true)
            
          },
          "Ubuntu16.04-x64": {
            bat(script: 'dotnet publish -c Release -r ubuntu.16.04-x64', returnStatus: true, returnStdout: true)
            
          },
          "Ubuntu15.10-x64": {
            bat(script: 'dotnet publish -c Release -r ubuntu.15.10-x64', returnStatus: true, returnStdout: true)
            
          },
          "Ubuntu15.04-x64": {
            bat(script: 'dotnet publish -c Release -r ubuntu.15.04-x64', returnStdout: true, returnStatus: true)
            
          },
          "Ubuntu14.10-x64": {
            bat(script: 'dotnet publish -c Release -r ubuntu.14.10-x64', returnStatus: true, returnStdout: true)
            
          },
          "Ubuntu14.04-x64": {
            bat(script: 'dotnet publish -c Release -r ubuntu.14.04-x64', returnStatus: true, returnStdout: true)
            
          },
          "CentOS7-x64": {
            bat(script: 'dotnet publish -c Release -r centos.7-x64', returnStatus: true, returnStdout: true)
            
          },
          "Fedora24-x64": {
            bat(script: 'dotnet publish -c Release -r fedora.24-x64', returnStatus: true, returnStdout: true)
            
          },
          "OpenSUSE42.1": {
            bat(script: 'dotnet publish -c Release -r opensuse.42.1-x64', returnStatus: true, returnStdout: true)
            
          }
        )
      }
    }
    stage('Gather Artifacts') {
      steps {
        parallel(
          "Windows": {
            archiveArtifacts 'bin/Release/netcoreapp1.1/win10-x64/publish/*'
            archiveArtifacts 'bin/Release/netcoreapp1.1/win10-x86/publish/*'
            archiveArtifacts 'bin/Release/netcoreapp1.1/win81-x64/publish/*'
            archiveArtifacts 'bin/Release/netcoreapp1.1/win81-x86/publish/*'
            archiveArtifacts 'bin/Release/netcoreapp1.1/win8-x64/publish/*'
            archiveArtifacts 'bin/Release/netcoreapp1.1/win8-x86/publish/*'
            archiveArtifacts 'bin/Release/netcoreapp1.1/win7-x64/publish/*'
            archiveArtifacts 'bin/Release/netcoreapp1.1/win7-x86/publish/*'
            
          },
          "OSX": {
            archiveArtifacts 'bin/Release/netcoreapp1.1/osx.10.10-x64/publish/*'
            archiveArtifacts 'bin/Release/netcoreapp1.1/osx.10.11-x64/publish/*'
            archiveArtifacts 'bin/Release/netcoreapp1.1/osx.10.12-x64/publish/*'
            
          },
          "Ubuntu": {
            archiveArtifacts 'bin/Release/netcoreapp1.1/ubuntu.16.10-x64/publish/*'
            archiveArtifacts 'bin/Release/netcoreapp1.1/ubuntu.16.04-x64/publish/*'
            archiveArtifacts 'bin/Release/netcoreapp1.1/ubuntu.15.10-x64/publish/*'
            archiveArtifacts 'bin/Release/netcoreapp1.1/ubuntu.15.04-x64/publish/*'
            archiveArtifacts 'bin/Release/netcoreapp1.1/ubuntu.14.10-x64/publish/*'
            archiveArtifacts 'bin/Release/netcoreapp1.1/ubuntu.14.04-x64/publish/*'
            
          },
          "Misc Linux": {
            archiveArtifacts 'bin/Release/netcoreapp1.1/centos.7-x64/publish/*'
            archiveArtifacts 'bin/Release/netcoreapp1.1/fedora.24-x64/publish/*'
            archiveArtifacts 'bin/Release/netcoreapp1.1/opensuse.42.1-x64/publish/*'
            
          }
        )
      }
    }
    stage('Cleanup') {
      steps {
        cleanWs(cleanWhenAborted: true, cleanWhenFailure: true, cleanWhenNotBuilt: true, cleanWhenSuccess: true, cleanWhenUnstable: true, cleanupMatrixParent: true)
      }
    }
  }
}