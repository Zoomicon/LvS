@echo off
if ""=="%1" goto syntax

echo Processing translations spreadsheets from folder: %1
for %%l in (es,hu,pt,ro) do call %1\..\translateFiles %%l %1\..

call %1\..\copyTranslatedFiles %1\..
goto end

:syntax
echo Drag-drop the "excel" subfolder onto this icon to do the resources' translation and copy them to appropriate project locations automatically

:end
pause