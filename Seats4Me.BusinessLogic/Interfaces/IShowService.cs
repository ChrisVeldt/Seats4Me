using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Seats4Me.Model.Result;

namespace Seats4Me.BusinessLogic.Interfaces
{
    public interface IShowService
    {
        Task<Show> GetShowAsync(int showId);
    }
}
