# csharp-cucumber-selenium-example
A sample implementation of BDD UI tests with C# / NUnit / Reqnroll

## Application under test
The feature files, step definitions and page objects were written for https://github.com/andreasneuber/automatic-test-sample-site.
Readme in that repo has further details how to set it up.

### IDE used
Microsoft Visual Studio Community 2022 (with .NET desktop development workload)

### Setup 
- git clone 
- Double-click file `csharp-cucumber-selenium-framework.sln`
- Solution opens in Visual Studio
- Right-click on solution, build solution
- Go to "View" and open the "Test Explorer" window
- Click green "Run All Tests In View" button

### Updating
Especially ChromeDriver needs frequent updating.
- Go to "Tools > NuGet Package Manager > Manage NuGet Packages for Solution..."
- Go to tab "Updates"
- Update
- Right-click on solution, build solution
- Close and reopen solution

### Set Browser
Open file `app.config` and find key "Browser". You can choose between:
- chrome
- chrome_headless
- firefox
- edge
- safari
After changing the browser, rebuild the solution.

### Helpful VS keyboard shortcuts
- Duplicate line: `CTRL + E + V`
- Go to definition: `F12`
- Quick code formatting: `Ctrl + K , Ctrl + D`


### FAQ
#### Where can I change the Base Url?
See app.config > appSettings

#### How can I switch browser to "headless"?
See app.config > appSettings

#### Error "csharp-cucumber-selenium-framework\bin\Debug\chromedriver.exe". Access to the path 'csharp-cucumber-selenium-framework\bin\Debug\chromedriver.exe' is denied.
- Run `taskkill /f /im chromedriver.exe`
- Clean solution

### Links
- [Reqnroll Documentation](https://docs.reqnroll.net/latest/index.html)