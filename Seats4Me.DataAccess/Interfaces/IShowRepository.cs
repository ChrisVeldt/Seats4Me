using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Seats4Me.Model.Result;

namespace Seats4Me.DataAccess.Interfaces
{
    public interface IShowRepository
    {
        Task<Show> GetShowAsync(int ShowId);
    }
}
