using FakeItEasy;
using GTL_Integration.Controllers;
using GTL_Integration.Library;
using GTL_Integration.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace GTL_IntegrationTests.FakeItEasy
{
    public class BookControllerTests
    {
        [Theory]
        [InlineData(1, "LOTR", "A great story about a ring")]
        public void Will_Return_One_Review(int reviewId, string title, string body)
        {
            var fakeReview = A.Fake<Review>();
            var bookServiceStub = A.Fake<IBookProvider>();

            A.CallTo(() => bookServiceStub.GetBookReview(A<int>._)).Returns(fakeReview);
         

            var sut = new BookController(bookServiceStub);

            var review = sut.GetBookReview(reviewId);

            var manager = Fake.GetFakeManager(review);
            Assert.Equal(typeof(Review), manager.FakeObjectType);
            A.CallTo(() => bookServiceStub.GetBookReview(A<int>._)).MustHaveHappened();

        }
    }
}
