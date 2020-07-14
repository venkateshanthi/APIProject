using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;
using RestSharpAPIConsoleApp.Base;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Text;
using TechTalk.SpecFlow;

namespace RestSharpAPIConsoleApp.Hooks
{
    [Binding]
    public class TestInitialize
    {
        //add global variable

        private static ExtentTest featureName;
        private static ExtentTest Scenario;
        private static AventStack.ExtentReports.ExtentReports extent;
        private readonly ScenarioContext scenarioContext;
        public FeatureContext featureContext;
        private static ExtentKlovReporter klov;

        private Settings settings;
        
        public TestInitialize(Settings settings, ScenarioContext scenarioContext, FeatureContext featureContext)
        {
            this.settings = settings;
            this.scenarioContext = scenarioContext;

            this.featureContext = featureContext;

        }

        [BeforeScenario]
        public void TestSetUp()
        {
            settings.BaseUrl = new Uri("http://localhost:3000/");
            //_settings.BaseUrl = new Uri(ConfigurationManager.AppSettings["baseUrl"].ToString());
            //  _settings.RestClient.BaseUrl = _settings.BaseUrl;

            Scenario = featureName.CreateNode<Scenario>(scenarioContext.ScenarioInfo.Title);
        }

        [BeforeTestRun]
        public static void InitializeReport()
        {
            string file = "ExtentReport.html";
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, file);
            var htmlReporter = new ExtentHtmlReporter(path);
            htmlReporter.Config.Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Dark;
            extent = new AventStack.ExtentReports.ExtentReports();
            //extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);
            klov = new ExtentKlovReporter();
           
                     klov.InitMongoDbConnection("localhost", 27017);
            klov.ProjectName = "RestsharpAPIConsoleApp";
              klov.ReportName = "shanthi" +DateTime.Now.ToString();
                   }

        [AfterTestRun]
        public static void TearDownReport()
        {
            extent.Flush();
        }


        [BeforeFeature]

        public static void BeforeFeatureRun(FeatureContext featureContext)
        {
            featureName = extent.CreateTest<Feature>(featureContext.FeatureInfo.Title);
        }

        [AfterStep]
        public void InsertReportteps()
        {

            var stepType = ScenarioStepContext.Current.StepInfo.StepDefinitionType.ToString();

            if (scenarioContext.TestError == null)
            {

                if (stepType == "Given")

                    Scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text);

                else if (stepType == "When")
                    Scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text);
                else if (stepType == "Then")
                    Scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text);

                else if (stepType == "And")
                    Scenario.CreateNode<And>(ScenarioStepContext.Current.StepInfo.Text);

            }

            else if (scenarioContext.TestError != null)
            {
                //var mediaEntity = settings.CaptureScreenshotAndReturnModel(scenarioContext.ScenarioInfo.Title.Trim());
                if (stepType == "Given")

                    Scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text).Fail(scenarioContext.TestError.Message);

                else if (stepType == "When")
                    Scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text).Fail(scenarioContext.TestError.Message);
                else if (stepType == "Then")
                    Scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text).Fail(scenarioContext.TestError.Message);

                else if (stepType == "And")
                    Scenario.CreateNode<And>(ScenarioStepContext.Current.StepInfo.Text).Fail(scenarioContext.TestError.Message);
            }
        }
    }
}
