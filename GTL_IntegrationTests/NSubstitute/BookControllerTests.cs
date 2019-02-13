using GTL_Integration.Controllers;
using GTL_Integration.Library;
using GTL_Integration.Models;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace GTL_IntegrationTests.NSubstitute
{

    public class BookControllerTests
    {
        [Theory]
        [InlineData(1, "LOTR", "A great story about a ring")]
        public void Will_Return_One_Review(int reviewId, string title, string body)
        {
            var fakeReview = Substitute.For<Review>();
            fakeReview.Id = reviewId;
            fakeReview.Title = title;
            fakeReview.Body = body;

            var bookServiceStub = Substitute.For<IBookProvider>();

            bookServiceStub.GetBookReview(Arg.Any<int>()).Returns(fakeReview);
            var sut = new BookController(bookServiceStub);

            var review = sut.GetBookReview(reviewId);

            Assert.Equal(reviewId, review.Id);
            Assert.Equal(title, review.Title);
            Assert.Equal(body, review.Body);
            bookServiceStub.Received().GetBookReview(Arg.Any<int>());
        }
    }
}
