using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace ClassLibrary1.StepDefinition
{
    [Binding]
    public sealed class RestStepDefinition
    {
        //GET REQUEST WITHOUT PARAMS
        [Given(@"I have a resource (.*)")]
        public void GivenIHaveAResourceResource(string resource)
        {
            RestAPIHelper.GetUrl(resource);
        }


        [When(@"I do GET request on the end point")]
        public void WhenIDoGETRequestOnTheEndPoint()
        {
            Console.WriteLine("Request : " + RestAPIHelper.GetRequest());
        }

        [Then(@"the response should be in json format")]
        public void ThenTheResponseShouldBeInJsonFormat()
        {
            var response = RestAPIHelper.GetResponse();
            Console.WriteLine("response : " + response.Content);

        }

        //GET REQUEST WITH PARAMS
        [Given(@"I have an url")]
        public void GivenIHaveAnUrl()
        {
            RestAPIHelper.GetUrl("");
        }

        [When(@"I call the GET method on this endpoint using parameters (.*),(.*),(.*)")]
        public void WhenICallTheGETMethodOnThisEndpointUsingParametersUsBeabfae(string p1, string p2, string p3)
        {
            RestAPIHelper.GetRequestWithParams(p1, p2, p3);
        }


        [Then(@"I need to get the user information in json format")]
        public void ThenINeedToGetTheUserInformationInJsonFormat()
        {
            var response = RestAPIHelper.GetResponse();
            Console.WriteLine("response : " + response.Content);
        }


        //POST REQUEST WITH PARAMS
        [Given(@"I have a new resource (.*)")]
        public void GivenIHaveANewResourceMapsApiPlaceAddJson(string resource)
        {
            RestAPIHelper.GetPostUrl(resource);
        }

        [When(@"I call the POST method on this endpoint using a key qaclick(.*)")]
        public void WhenICallThePOSTMethodOnThisEndpointUsingAKeyQaclick(string p0)
        {
            RestAPIHelper.PostRequest(p0);
        }

        [Then(@"the post response should be in json format")]
        public void ThenThePostResponseShouldBeInJsonFormat()
        {
            var response = RestAPIHelper.GetResponse();
            Console.WriteLine("response : " + response.Content);
        }

        //DELETE REQUEST WITH PARAMS
        [Given(@"I have a delete resource (.*)")]
        public void GivenIHaveADeleteResourceMapsApiPlaceDeleteJson(string resource)
        {
            RestAPIHelper.GetPostUrl(resource);
        }

        [When(@"I call the POST method on this endpoint to delete using a key qaclick(.*)")]
        public void WhenICallThePOSTMethodOnThisEndpointToDeleteUsingAKeyQaclick(string p0)
        {
            RestAPIHelper.DeleteRequest(p0);
        }

        [Then(@"the delete response should be in json format")]
        public void ThenTheDeleteResponseShouldBeInJsonFormat()
        {
            var response = RestAPIHelper.GetResponse();
            Console.WriteLine("response : " + response.Content);
        }



    }
}
