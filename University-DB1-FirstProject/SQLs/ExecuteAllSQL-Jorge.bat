for %%G in (*.sql) do sqlcmd /S DESKTOP-FM7O21 /d DB1-FirstProjectDB-E -i"%%G"
pause