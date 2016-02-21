#cs ----------------------------------------------------------------------------

 AutoIt Version: 3.3.15.0 (Beta)
 Author:         RattletraPM

 Script Function:
	This script functions as an open-source SFXCAB tool. It is automatically
	modified by UDTRebuildSFXCAB as needed.

	Part of UDTranslation Kit.

	This script has been commented in english so that other translators will be
	able to understand how it works and modify it to their own needs.

#ce ----------------------------------------------------------------------------

#include <Crypt.au3>

;We don't need the tray icon
Opt("TrayIconHide",1)

;Define the temp directory this script will be using
$tempdir=@TempDir&"\UDTSFXCAB"
$runexe=$tempdir&"\UNDERTALE.exe"
$namever="UDTSFXCAB v0.7"
$dir=DirCreate($tempdir)

;Include 7z.exe and 7z.dll in the compiled script and extract them in $tempdir
;7ZEXE and 7ZDLL gets automatically replaced with a valid path by UDTRebuildSFXCAB
;Uncomment the two lines below after debug
FileInstall("<7ZEXE>",$tempdir&"\7z.exe")
FileInstall("<7ZDLL>",$tempdir&"\7z.dll")

;First of all, we check if the directory was created succesfully
If $dir==0 Then
	MsgBox(16,$namever,"UDTSFXCAB has encountered an error while extracting the files (The directory couldn't be created).")
	Exit
EndIf

;Extract the appended CAB's files to $tempdir using 7z
$exitcode = RunWait(@ComSpec & ' /C 7z x "'&@ScriptFullPath&'" -y -o"'&$tempdir,$tempdir,@SW_HIDE)

;Now we check that everything went correctly using 7z.exe's exit codes
If Not $exitcode==0 Then
	MsgBox(16,$namever,"UDTSFXCAB has encountered an error while extracting the files (7z exit code "&$exitcode&").")
	RemoveExit()
EndIf
;If there's no UNDERTALE.exe there's no point in running it
If Not FileExists($runexe) Then
	MsgBox(16,$namever,"UDTSFXCAB has encountered an error while extracting the files (UNDERTALE.exe not found).")
	RemoveExit()
EndIf
;We check UNDERTALE.exe's MD5 hash to see if it has been altered. Of course, we do this for security reasons
;EXEMD5 gets automatically replaced with UNDERTALE.exe's MD5 by UDTRebuildSFXCAB
If _Crypt_HashFile($runexe, $CALG_MD5)<>"<EXEMD5>" Then
	MsgBox(16,$namever,"UNDERTALE.exe MD5 hash mismatch.")
	RemoveExit()
EndIf
RunWait($runexe)
RemoveExit()

Func RemoveExit()
	DirRemove($tempdir,1)
	Exit
EndFunc