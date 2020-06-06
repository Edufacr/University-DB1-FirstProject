for %%G in (*.sql) do sqlcmd /S ServerName /d DB1-FirstProject-E -i"%%G"
pause