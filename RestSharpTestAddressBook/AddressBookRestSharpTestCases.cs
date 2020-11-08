using AddressBookSystem;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System.Collections.Generic;
using System.Net;

namespace RestSharpTestAddressBook
{
    [TestClass]
    public class AddressBookRestSharpTestCases
    {
        RestClient client;

        [TestInitialize]
        public void SetUp()
        {
            client = new RestClient("http://localhost:7000");
        }

        private IRestResponse GetAddressList()
        {
            // arrange
            RestRequest request = new RestRequest("/address", Method.GET);

            // act
            IRestResponse response = client.Execute(request);
            return response;
        }

        [TestMethod]
        public void OnCallingGETApi_ReturnAddressList()
        {
            IRestResponse response = GetAddressList();

            // assert
            Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);
            List<ContactDatabase> dataResponse = JsonConvert.DeserializeObject<List<ContactDatabase>>(response.Content);
            Assert.AreEqual(3, dataResponse.Count);
        }
        [TestMethod]
        public void GivenAddressBook_DoPost_ShouldReturnAddedAddressDetails()
        {
            // arrange
            RestRequest request = new RestRequest("/address", Method.POST);
            JObject objectBody = new JObject
            {
                { "FirstName", "Kylie" },
                { "LastName", "McMiller" },
                { "Address", "Sidewalk 3/41" },
                { "City", "Lockenwille" },
                { "State", "WoodLer" },
                { "Zip", "521432" },
                { "PhoneNumber", "7548965265" },
                { "Email", "kylie@gmail.com" }
            };

            request.AddParameter("application/json", objectBody, ParameterType.RequestBody);

            // act
            IRestResponse response = client.Execute(request);

            // assert
            Assert.AreEqual(response.StatusCode, HttpStatusCode.Created);
            ContactDatabase dataResponse = JsonConvert.DeserializeObject<ContactDatabase>(response.Content);
            Assert.AreEqual("Kylie", dataResponse.firstname);
            Assert.AreEqual("McMiller", dataResponse.lastname);
            Assert.AreEqual("Sidewalk 3/41", dataResponse.address);
            Assert.AreEqual("Lockenwille", dataResponse.city);
            Assert.AreEqual("WoodLer", dataResponse.state);
            Assert.AreEqual("521432", dataResponse.zip);
            Assert.AreEqual("7548965265", dataResponse.phone);
            Assert.AreEqual("kylie@gmail.com", dataResponse.email);
        }
        [TestMethod]
        public void GivenAddressBook_OnPut_ShouldReturnUpdatedAddressDetails()
        {
            // arrange
            RestRequest request = new RestRequest("/address/5", Method.PUT);
            JObject objectBody = new JObject();
            objectBody.Add("FirstName", "lyka");
            objectBody.Add("LastName", "krab");
            objectBody.Add("Address", "UnderWater");
            objectBody.Add("City", "OceanStreet");
            objectBody.Add("State", "Middlleton");
            objectBody.Add("Zip", "912405");
            objectBody.Add("PhoneNumber", "8565555489");
            objectBody.Add("Email", "lyka@gmail.com");

            request.AddParameter("application/json", objectBody, ParameterType.RequestBody);

            // act
            IRestResponse response = client.Execute(request);

            // assert
            Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);
            ContactDatabase dataResponse = JsonConvert.DeserializeObject<ContactDatabase>(response.Content);
            Assert.AreEqual("lyka", dataResponse.firstname);
            Assert.AreEqual("lyka@gmail.com", dataResponse.email);
        }
        [TestMethod]
        public void GivenEmployee_OnDelete_ShouldReturnSuccess()
        {
            // arrange
            RestRequest request = new RestRequest("/address/3", Method.DELETE);

            // act
            IRestResponse response = client.Execute(request);

            // assert
            Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);
        }
    }
}
