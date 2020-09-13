set CurDir=%~dp0
set LibName=%1
xcopy %LibName%.dll %CurDir%..\SGF\Assets\Plugins\ManagedLib\ /y