﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (https://www.specflow.org/).
//      SpecFlow Version:3.9.0.0
//      SpecFlow Generator Version:3.9.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace Test_Book_lib.StepDefinitions
{
    using TechTalk.SpecFlow;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.9.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("Add new book to library")]
    public partial class AddNewBookToLibraryFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
        private static string[] featureTags = ((string[])(null));
        
#line 1 "PostNewBook.feature"
#line hidden
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "StepDefinitions", "Add new book to library", null, ProgrammingLanguage.CSharp, featureTags);
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [NUnit.Framework.OneTimeTearDownAttribute()]
        public virtual void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        [NUnit.Framework.SetUpAttribute()]
        public void TestInitialize()
        {
        }
        
        [NUnit.Framework.TearDownAttribute()]
        public void TestTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public void ScenarioInitialize(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioInitialize(scenarioInfo);
            testRunner.ScenarioContext.ScenarioContainer.RegisterInstanceAs<NUnit.Framework.TestContext>(NUnit.Framework.TestContext.CurrentContext);
        }
        
        public void ScenarioStart()
        {
            testRunner.OnScenarioStart();
        }
        
        public void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Post new book")]
        [NUnit.Framework.CategoryAttribute("TodoApp")]
        public void PostNewBook()
        {
            string[] tagsOfScenario = new string[] {
                    "TodoApp"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Post new book", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 4
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
                TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                            "UserName",
                            "EmailAddress",
                            "Password"});
                table1.AddRow(new string[] {
                            "specflowTest",
                            "spec@spec.flow",
                            "specflowTest"});
#line 6
 testRunner.Given("[User data is read]", ((string)(null)), table1, "Given ");
#line hidden
#line 10
 testRunner.And("[HTTP client is initialized]", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 11
 testRunner.And("[Valid token obtained]", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
                TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                            "title",
                            "author.lastName",
                            "author.firstName",
                            "author.dateOfBirth",
                            "publisher",
                            "releaseDate"});
                table2.AddRow(new string[] {
                            "Harry Potter - Philosopher\'s Stone",
                            "Joanne",
                            "Rowling",
                            "2002-06-07T14:15:22.630Z",
                            "Bloomsbury Publishing",
                            "2007-07-21T00:00:00.000Z"});
                table2.AddRow(new string[] {
                            "Test Driven Development: By Example",
                            "Kent",
                            "Beck",
                            "2003-06-07T14:15:22.630Z",
                            "Addison-Wesley Professional",
                            "2002-10-01T00:00:00.000Z"});
                table2.AddRow(new string[] {
                            "CSharp-Principles-Book-Nakov-v2018",
                            "Svetlin",
                            "Nakov",
                            "2004-06-07T14:15:22.630Z",
                            "unknown",
                            "2018-05-01T00:00:00.000Z"});
#line 12
 testRunner.And("the books are not present in the library", ((string)(null)), table2, "And ");
#line hidden
#line 18
 testRunner.When("[I login]", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 19
 testRunner.Then("[I get authorization token]", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
