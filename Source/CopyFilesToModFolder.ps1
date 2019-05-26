Param(
    #Relative filepath to the folder in the local rimworld 'Mods' folder to use for output. 
    #The default value uses the default Rimworld installation path
    [string]$localModDir = "C:\Program Files (x86)\Steam\steamapps\common\RimWorld\Mods\LifeSupport"
)

function Copy-Modfiles()
{
    $switches = @("/MIR", "/COPY:DAT", "/XO", "/NP", "/R:5", "/W:5")
    If (Test-Path "..\About") {
        Robocopy.exe "..\About" "$localModDir\About" *.* $switches
    }
    Else {
        Write-Output "Mod sub-directories not found! Verify your current Powershell directory is the mod project folder"
        return
    }
    
    If (Test-Path "..\Assemblies") {
        Robocopy.exe "..\Assemblies" "$localModDir\Assemblies" *.* $switches
    }
    If (Test-Path "..\Defs") {
        Robocopy.exe "..\Defs" "$localModDir\Defs" *.* $switches
    }
    If (Test-Path "..\Languages") {
        Robocopy.exe "..\Languages" "$localModDir\Languages" *.* $switches
    }
    If (Test-Path "..\Patches") {
        Robocopy.exe "..\Patches" "$localModDir\Patches" *.* $switches
    }
    If (Test-Path "..\Textures") {
        Robocopy.exe "..\Textures" "$localModDir\Textures" *.* $switches
    }
    

}
Copy-Modfiles