// ------------------------------------------------------------------------------
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.  Licensed under the MIT License.  See License in the project root for license information.
// ------------------------------------------------------------------------------

using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Graph.Users.Item;
using Microsoft.Graph.Users.Item.SendMail;
using Microsoft.Kiota.Abstractions;
using Microsoft.Kiota.Abstractions.Authentication;
using Microsoft.Kiota.Http.HttpClientLibrary.Middleware;
using Moq;
using Xunit;

namespace Microsoft.Graph.DotnetCore.Test.Models;

public class GraphServiceClientTests
{
    [Fact]
    public void InitializesClient()
    {
        // Arrange
        var graphClient = new GraphServiceClient(new AnonymousAuthenticationProvider());
        
        // Act
        var userRequestInformation = graphClient.Me.ToGetRequestInformation();
        
        // Assert
        Assert.Contains("https://graph.microsoft.com", userRequestInformation.URI.OriginalString);
    }
    
    [Fact]
    public void InitializesClientWithCustomBaseUrl()
    {
        // Arrange
        var customBaseUrl = "https://graph.microsoft-ppe.com";
        var graphClient = new GraphServiceClient(new AnonymousAuthenticationProvider(), customBaseUrl);
        
        // Act
        var userRequestInformation = graphClient.Me.ToGetRequestInformation();
        
        // Assert
        Assert.Contains(customBaseUrl, userRequestInformation.URI.OriginalString);
    }

    [Fact]
    public void MeReusesUserRequestBuildersWithoutChangingOtherPaths()
    {
        using var graphClient = new GraphServiceClient(new AnonymousAuthenticationProvider());

        Assert.IsType<UserItemRequestBuilder>(graphClient.Me);
        var meRequest = graphClient.Me.ToGetRequestInformation();
        Assert.Equal(CoreConstants.ReplacementConstants.UserIdTokenToReplace, meRequest.PathParameters["user%2Did"]);
        Assert.Equal("https://graph.microsoft.com/v1.0/users/TokenToReplace", meRequest.URI.AbsoluteUri);
        Assert.Equal("https://graph.microsoft.com/v1.0/users/another-user",
            graphClient.Users["another-user"].ToGetRequestInformation().URI.AbsoluteUri);
        Assert.Equal("https://graph.microsoft.com/v1.0/users/TokenToReplace",
            graphClient.Me.ToGetRequestInformation().URI.AbsoluteUri);
    }

    [Fact]
    public void MePreservesCustomAdapterAndBaseUrl()
    {
        var adapter = new Mock<IRequestAdapter>();
        adapter.SetupProperty(value => value.BaseUrl);
        using var graphClient = new GraphServiceClient(adapter.Object, "https://graph.microsoft.us/v1.0");

        var request = graphClient.Me.Messages["message-id"].ToGetRequestInformation();

        Assert.Same(adapter.Object, graphClient.RequestAdapter);
        Assert.Equal("https://graph.microsoft.us/v1.0/users/TokenToReplace/messages/message-id",
            request.URI.AbsoluteUri);
    }

    [Fact]
    public void MePreservesRawUrls()
    {
        using var graphClient = new GraphServiceClient(new AnonymousAuthenticationProvider());
        const string nextLink = "https://graph.microsoft.com/v1.0/me/messages?$skiptoken=next";

        var request = graphClient.Me.Messages.WithUrl(nextLink).ToGetRequestInformation();

        Assert.Equal(nextLink, request.URI.OriginalString);
    }

    [Theory]
    [InlineData(false, "https://graph.microsoft.com/v1.0/me/messages/message-id?%24select=id")]
    [InlineData(true, "https://graph.microsoft.com/v1.0/me/sendMail")]
    public async Task MeRemapsRequestsWithConfiguredCustomHttpClient(bool sendMail, string expectedUrl)
    {
        using var capture = new CaptureRequestHandler();
        using var replacement = new UriReplacementHandler<GraphUriReplacementHandlerOption>(
            new GraphUriReplacementHandlerOption()) { InnerHandler = capture };
        using var httpClient = new HttpClient(replacement);
        using var graphClient = new GraphServiceClient(httpClient);

        if (sendMail)
        {
            await graphClient.Me.SendMail.PostAsync(new SendMailPostRequestBody
            {
                Message = new Microsoft.Graph.Models.Message { Subject = "test" }
            });
        }
        else
        {
            await graphClient.Me.Messages["message-id"].GetAsync(
                configuration => configuration.QueryParameters.Select = new[] { "id" });
        }

        Assert.Equal(expectedUrl, capture.RequestUri?.AbsoluteUri);
        Assert.Equal(sendMail ? HttpMethod.Post : HttpMethod.Get, capture.Method);
    }

    [Fact]
    public async Task MeRemapsRequestsWithDefaultHandlerPipeline()
    {
        using var capture = new CaptureRequestHandler();
        using var httpClient = GraphClientFactory.Create(new GraphClientOptions(), finalHandler: capture);
        using var graphClient = new GraphServiceClient(httpClient);

        await graphClient.Me.GetAsync();

        Assert.Equal("https://graph.microsoft.com/v1.0/me", capture.RequestUri?.AbsoluteUri);
    }

    [Fact]
    public async Task MeRemapsBatchStepsWithoutAnHttpReplacementHandler()
    {
        using var httpClient = new HttpClient(new CaptureRequestHandler());
        using var graphClient = new GraphServiceClient(httpClient);
        var batch = new BatchRequestContentCollection(graphClient);

        var stepId = await batch.AddBatchRequestStepAsync(
            graphClient.Me.Messages["message-id"].ToGetRequestInformation());

        Assert.Equal("https://graph.microsoft.com/v1.0/me/messages/message-id",
            batch.BatchRequestSteps[stepId].Request.RequestUri?.AbsoluteUri);
    }

    private sealed class CaptureRequestHandler : HttpMessageHandler
    {
        public Uri RequestUri { get; private set; }
        public HttpMethod Method { get; private set; }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            RequestUri = request.RequestUri;
            Method = request.Method;
            return Task.FromResult(new HttpResponseMessage(HttpStatusCode.NoContent));
        }
    }
}
