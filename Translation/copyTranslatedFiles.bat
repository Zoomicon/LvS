@echo off
echo Copying resources into appropriate project folders...
echo:
copy /Y %1\resources\AudioVolumeController.* %1\..\LvS\controls\player > nul
copy /Y %1\resources\Controller.* %1\..\LvS\controls\player > nul
copy /Y %1\resources\MainForm.* %1\..\LvS\screens > nul
copy /Y %1\resources\ActivityView.* %1\..\LvS\screens > nul
copy /Y %1\resources\SplashScreen.* %1\..\LvS\dialogs > nul
copy /Y %1\resources\Resources.* "%1\..\LvS\My Project" > nul
copy /Y %1\resources\utilities\Resources.* "%1\..\LvS_utilities\My Project" > nul
