for %%G in (*.sql) do sqlcmd /S DESKTOP-FM67O2I /d DB1-FirstProjectDB -E -i"%%G"
pause