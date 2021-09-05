<h4>Approach</h4>
<p>Page object model implementation using Selenium web driver to control the browser and NUnit for the test execution framework. The website pages are represented as C# pages where the repetative part (the stuff that appears on more than one page) is described in the BasePage.cs. Helpers class that holds common stuff that is called throughout the different tests.</p> 

<h4>Instructions to run tests</h4>

<h4>Requirements</h4>
Firefox web browser<br>
.NET Core 3.1<br>
Option 1 or option 2 from below<br>

<h4>Running the tests</h4>

<h5>Option 1 - without visual studio</h5>
dotnet build
dotnet test -v m -l "console;verbosity=detailed"

<h5>Option 2 - with visual studio</h5>
1. Open the solution file
<br> 2. Right click on project and select Rebuild
<br> 3. Open test explorer -> Test from the Visual Studio menu -> Test Explorer
<br> 4. Click on Run All Tests In View -> available in the test explorer window


<br> [Image_instructions](docs/selenium.png) - Note the scrollbar of the opened page
<br> [Gif_instructions](docs/state.gif) - Note the scrollbar of the opened page
