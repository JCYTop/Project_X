set CurDir = %~dp0
set Libname = %1
xcopy %Libname%.dll %CurDir%..\..\SGF\Assets\Plugins\ManagedLib\ /y