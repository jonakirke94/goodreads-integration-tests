using GTL_Integration.API;
using GTL_Integration.Controllers;
using GTL_Integration.Library;
using GTL_Integration.Models;
using GTL_IntegrationTests.Helpers;
using Microsoft.Extensions.Configuration;
using Moq;
using System;
using Xunit;

namespace GTL_IntegrationTests
{
    public class BookProviderTests
    {
        [Theory]
        [InlineData(1)]
        public void Will_Return_One_Review(int reviewId)
        {
            var configuration = ConfigUtility.InitConfiguration();
            var review = new GoodReadsClient(configuration).GetBookReview(reviewId);
            Assert.IsType<Review>(review);
            Assert.Equal("Davids yndlingsbog", review.Title);
            Assert.Equal("Det var en fantastisk laesning", review.Body);


        }
    }
}
