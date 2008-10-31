@echo off

echo:
echo Translating: %1
echo:

cscript /nologo %2\bin\generateTranslatorXSLfromXLS.vbs %2\excel\%1.xls %2\stylesheets\%1.xsl

for %%f in (AudioVolumeController, Controller, MainForm, ActivityView, SplashScreen, Resources, utilities\Resources) do call %2\translateFile %%f %1 %2
