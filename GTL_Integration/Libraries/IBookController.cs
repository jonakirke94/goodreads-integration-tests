using GTL_Integration.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GTL_Integration.Library
{
    public interface IBookController
    {
        Review GetBookReview(int reviewId);
    }
}
