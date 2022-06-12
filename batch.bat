@ECHO OFF
SET prs=%*
SET /P branch=What would you like to name the new branch? 

FOR %%a in (%prs%) do (
    ECHO %%a|findstr /r /c:"^[0-9][0-9]*$" >nul
    IF errorlevel 1 goto E_INVALIDINPUT
)

ECHO Pulling prs...
ECHO -----------------------------------------------
git fetch origin master:%branch%
git checkout %branch%
FOR %%a in (%prs%) do (
    git pull origin pull/%%a/head >nul
    IF errorlevel 1 goto E_BADPULL
)
ECHO -----------------------------------------------
ECHO Job completed!
goto EOF

:E_INVALIDINPUT
echo One of those PRs isn't a number!

:E_BADPULL
ECHO -----------------------------------------------
ECHO Unable to finish job. Removing %branch%
git checkout master >nul
git branch -D %branch% >nul

:EOF