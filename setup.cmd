@echo off
cd /d "%~dp0"
powershell.exe -NoProfile -ExecutionPolicy ByPass ".\setup\SetupProject.ps1 -url 'simpleweb.signup.local' -name 'SimpleWeb.SignupDemo' -location '.\AwesomeThing' "

SQLCMD -i "setup\database.sql" -S ".\SQLEXPRESS" -E
