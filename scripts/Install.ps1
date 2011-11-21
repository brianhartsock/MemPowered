
$global_fgColor = "green"
$global_bgColor = "black"

function write-welcome{
    
    write-break
    Write-Host "MemPowered/LearnMemPowered installation                  " -foregroundcolor $global_fgColor -backgroundcolor $global_bgColor
    write-empty
    Write-Host "Created by Brian Hartsock (http://blog.brianhartsock.com)" -foregroundcolor $global_fgColor -backgroundcolor $global_bgColor
    write-empty
    write-host "This script will install two Powershell modules in the   " -foregroundcolor $global_fgColor -backgroundcolor $global_bgColor
    write-host "directory of your choice                                 " -foregroundcolor $global_fgColor -backgroundcolor $global_bgColor
    write-break
    write-empty
}

function write-empty($char=57){
    write-host (" "*57) -foregroundcolor $global_fgColor -backgroundcolor $global_bgColor
}

function write-break($char=57){
    write-host ("-"*57) -foregroundcolor $global_fgColor -backgroundcolor $global_bgColor
}

function write-InstallationInfo($modules){
    write-host "Installing the following modules:"
    $modules | %{ write-host "`t$_" }
}

function write-success(){
    write-host "Successfully installed." -foregroundcolor $global_fgColor -backgroundcolor $global_bgColor
}

function get-installationpath(){
    $modulePaths = $env:PSModulePath.split(';')
    
    while($true){
        write-host "Please select your installation path from the following directories:"
        for($i=0;$i -lt $modulePaths.count;$i++){
            write-host "[$i] $($modulePaths[$i])  "
        }

        write-host "Enter the option you want:" -nonewline    
        $selectedValue = read-host
        
        if($modulePaths[$selectedValue]){
            return $modulePaths[$selectedValue]
        }else{
            write-host "Invalid selection, try again..." -foregroundcolor red -backgroundcolor black
        }
    }
}

#Get a list of modules to install (all the folders in the currect directory)
$modules = "MemPowered", "LearnMemPowered"

Write-Welcome
Write-InstallationInfo $modules
write-break
$installationPath = Get-InstallationPath


#Remove pre-existing modules (confirm for safety)
write-break
write-host "Removing pre-existing modules (if they exist)..."  -foregroundcolor $global_fgColor -backgroundcolor $global_bgColor
$modules | 
    %{ join-path $installationPath $_ } |
    ?{ test-path $_ } | 
    remove-item -confirm -recurse

#Copy item's to installation path
write-break
write-host "Copying files..."  -foregroundcolor $global_fgColor -backgroundcolor $global_bgColor
copy-item $modules $installationPath -recurse

write-success
sleep 3