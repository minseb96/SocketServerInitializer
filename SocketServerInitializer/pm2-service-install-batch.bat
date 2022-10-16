@echo off
pushd %~dp0
cscript pm2-service-install.vbs
popd %~dp0
@echo on
