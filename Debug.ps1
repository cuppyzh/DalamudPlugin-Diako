$SourcePath = "Cuppyzh.DalamudPlugin.Diako\bin\Debug\net5.0\"
$DestinationPath = "D:\_Dev\_Project\Diako.build"
Copy-Item -Path $SourcePath"Cuppyzh.DalamudPlugin.Diako.deps.json" -Destination $DestinationPath
Copy-Item -Path $SourcePath"Cuppyzh.DalamudPlugin.Diako.json" -Destination $DestinationPath
Copy-Item -Path $SourcePath"Cuppyzh.DalamudPlugin.Diako.dll" -Destination $DestinationPath
Copy-Item -Path $SourcePath"Cuppyzh.DalamudPlugin.Diako.pdb" -Destination $DestinationPath