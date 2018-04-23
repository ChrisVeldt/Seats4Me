using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Seats4Me.BusinessLogic.Interfaces;
using Seats4Me.DataAccess.Interfaces;
using Seats4Me.Model.Result;

namespace Seats4Me.BusinessLogic.Services
{
    public class ShowService : IShowService
    {
        private readonly IShowRepository _repository;

        public ShowService(IShowRepository repository)
        {
            _repository = repository;
        }

        public async Task<Show> GetShowAsync(int showId)
        {
            return await _repository.GetShowAsync(showId);
        }
    }
}
