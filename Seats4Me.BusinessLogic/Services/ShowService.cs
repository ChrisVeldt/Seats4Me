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

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="repository"></param>
        public ShowService(IShowRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Get a show by Id
        /// </summary>
        /// <param name="showId"></param>
        /// <returns></returns>
        public async Task<Show> GetShowAsync(int showId)
        {
            return await _repository.GetShowAsync(showId);
        }
    }
}
