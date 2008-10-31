@echo off
if ""=="%1" goto syntax

bin\XSLTransform "%1" stylesheets\keepOnlyStrings.xsl "%1.OnlyStrings.xml"
::excel "%1.OnlyStrings.xml"
goto end

:syntax
echo Drag-drop a .resx file onto this icon to create an xml file with only the strings in a form directly importable from Excel which can then be exported as .xls

:end
pause