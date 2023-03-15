function MakeController([string]$className) {

    dotnet-aspnet-codegenerator controller -name "$($className)Controller" -async -api -m $($className) -dc "$($className)Context" -outDir Controllers
}

# MakeController "BasicSetting"
MakeController "PracticeSetting"
MakeController "AppointmentType"
MakeController "Provider"
MakeController "AppointmentPurpose"
MakeController "Location"