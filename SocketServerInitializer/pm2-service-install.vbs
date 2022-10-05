Set WshShell = WScript.CreateObject("WScript.Shell")
WshShell.Run "pm2-service-install -n FixelSerialPortCommSocketServer"
WScript.Sleep 1000 

WshShell.SendKeys "{ENTER}"
WScript.Sleep 1000

WshShell.SendKeys "n"
WshShell.SendKeys "{ENTER}"
WScript.Sleep 1000

WshShell.SendKeys "{ENTER}"
WScript.Sleep 1000

WshShell.SendKeys "{ENTER}"
WScript.Sleep 1000

WshShell.SendKeys "{ENTER}"
WScript.Sleep 1000

WshShell.SendKeys "{ENTER}"
WScript.Sleep 1000
