using GTL_Integration.Controllers;
using GTL_Integration.Library;
using GTL_Integration.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace GTL_IntegrationTests
{
    public class BookControllerTests
    {
        [Theory]
        [InlineData(1, "LOTR", "A great story about a ring")]
        public void Will_Return_One_Review(int reviewId, string title, string body)
        {
            var bookServiceStub = new Mock<IBookProvider>();

            bookServiceStub.Setup(x => x.GetBookReview(It.IsAny<int>())).Returns(() =>
            new Review
            {
                Id = reviewId,
                Title = title,
                Body = body
            });

            var sut = new BookController(bookServiceStub.Object);

            var review = sut.GetBookReview(reviewId);

            Assert.IsType<Review>(review);

        }
    }
}
