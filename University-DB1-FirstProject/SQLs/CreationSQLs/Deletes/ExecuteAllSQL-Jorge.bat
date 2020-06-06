for %%G in (*.sql) do sqlcmd /S LAPTOP-5URQT67L\SQLEXPRESS /d DB1-FirstProject -E -i"%%G"
pause