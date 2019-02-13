using GTL_Integration.Library;
using GTL_Integration.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GTL_Integration.Controllers
{
    public class BookController : IBookController
    {
        private readonly IBookProvider _bookProvider;

        public BookController(IBookProvider bookProvider)
        {
            _bookProvider = bookProvider;
        }

        public Review GetBookReview(int reviewId)
        {
            return _bookProvider.GetBookReview(reviewId);
        }
    }
}
