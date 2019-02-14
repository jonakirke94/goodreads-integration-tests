using Castle.DynamicProxy;
using GTL_Integration.Controllers;
using GTL_Integration.Library;
using GTL_Integration.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace GTL_IntegrationTests.Moq
{
    public class BookControllerTests
    {
        [Theory]
        [InlineData(1, "LOTR", "A great story about a ring")]
        public void Will_Return_One_Review(int reviewId, string title, string body)
        {
            var fakeReview = new Mock<Review>();
            fakeReview.Object.Id = reviewId;
            fakeReview.Object.Title = title;
            fakeReview.Object.Body = body;

            var bookServiceStub = new Mock<IBookProvider>();

            bookServiceStub.Setup(x => x.GetBookReview(It.IsAny<int>())).Returns(() => fakeReview.Object);

            var sut = new BookController(bookServiceStub.Object);

            var review = sut.GetBookReview(reviewId);

            Assert.Equal(reviewId, review.Id);
            Assert.Equal(title, review.Title);
            Assert.Equal(body, review.Body);
            // Asserting that the type of fakeReview is a Mock of Review
            Assert.Equal(fakeReview.GetType(), new Mock<Review>().GetType());
            // Asserting the review-proxy have the same fields as a new Review
            Assert.Equal(review.GetType().GetFields(), new Review().GetType().GetFields());
            bookServiceStub.Verify(x => x.GetBookReview(It.IsAny<int>()), Times.Once());
        }
    }
}
