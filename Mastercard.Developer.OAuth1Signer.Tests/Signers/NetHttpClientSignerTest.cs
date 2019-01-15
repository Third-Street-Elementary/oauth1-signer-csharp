﻿using System;
using System.Net.Http;
using Mastercard.Developer.OAuth1Signer.Core.Signers;
using Mastercard.Developer.OAuth1Signer.Tests.Test;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Mastercard.Developer.OAuth1Signer.Tests.Signers
{
    [TestClass]
    public class NetHttpClientSignerTest
    {
        [TestMethod]
        public void TestSign_ShouldAddOAuth1HeaderToRequest()
        {
            // GIVEN
            var signingKey = TestUtils.GetTestPrivateKey();
            const string consumerKey = "Some key";
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri("https://api.mastercard.com/service"),
                Content = new StringContent("{\"foo\":\"bår\"}") // "application/json; charset=utf-8"
            };

            // WHEN
            var instanceUnderTest = new NetHttpClientSigner(consumerKey, signingKey);
            instanceUnderTest.Sign(request);

            // THEN
            Assert.IsNotNull(request.Headers.Authorization);
        }
    }
}
