..\\..\\packages\\OpenCover.4.6.519\\tools\\OpenCover.Console.exe -target:runtests.bat -register:user
..\\..\\packages\\ReportGenerator.2.5.8\\tools\\ReportGenerator.exe -reports:results.xml -targetdir:coverage

start "report" "%~dp0\coverage\index.htm"