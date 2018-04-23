using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Seats4Me.Model.Result;

namespace Seats4Me.ViewModel
{
    public class ShowViewModel
    {
        public int ShowId { get; set; }

        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public TimeSpan Duration { get; set; }

        /// <summary>
        /// Maps a show to the viewmodel
        /// </summary>
        /// <param name="show"></param>
        /// <returns></returns>
        public static ShowViewModel MapFromDbResult(Show show)
        {
            return new ShowViewModel
            {
                ShowId = show.ShowId,
                Title = show.Title,
                Description = show.Description,
                Duration = show.Duration,
                Price = show.Price
            };
        }

        /// <summary>
        /// Maps a viewmodel to a show
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        public static Show MapToDbResult(ShowViewModel viewModel)
        {
            return new Show
            {
                ShowId = viewModel.ShowId,
                Title = viewModel.Title,
                Description = viewModel.Description,
                Duration = viewModel.Duration,
                Price = viewModel.Price
            };

        }
    }
}
