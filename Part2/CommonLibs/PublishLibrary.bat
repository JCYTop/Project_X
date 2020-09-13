set CurDir=%~dp0
set LibName=%1
print "%LibName%"
if "%LibName%"=="ILRScript" (xcopy %LibName%.dll %CurDir%..\SGF\Assets\StreamingAssets\ILR\ /y) else (xcopy %LibName%.dll %CurDir%..\SGF\Assets\Plugins\ManagedLib\ /y)