@ECHO OFF
ECHO Demo Automation Executed Started.



set dllpath=C:\Users\karamjun\source\repos\SeleniumQuiz\SeleniumQuiz\bin\Debug\SeleniumQuiz.dll

set SummaryReportPath=C:\Users\karamjun\source\repos\SeleniumQuiz\SeleniumQuiz\SummaryReportPath


call "C:\Program Files\Microsoft Visual Studio\2022\Community\Common7\Tools\VsDevCmd.bat"


VSTest.Console.exe  %dllpath% /Logger:"trx;LogFileName=%SummaryReportPath%\seleniumQuizReport.trx"

cd C:\Users\karamjun\source\repos\SeleniumQuiz\SeleniumQuiz\bin\Debug

TrxToHTML %SummaryReportPath%

PAUSE

