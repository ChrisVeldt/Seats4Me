using Seats4Me.Model.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Seats4Me.ViewModel
{
    public class ScheduleViewModel
    {
        public int ScheduleId { get; set; }
        public int ShowId { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Description { get; set; }
        public DateTime ScheduleDate { get; set; }
        public TimeSpan Duration { get; set; }
        public decimal Price { get; set; }

        /// <summary>
        /// Maps a Schedule to the ViewModel
        /// </summary>
        /// <param name="schedule"></param>
        /// <returns></returns>
        public static ScheduleViewModel MapFromDbResult(Schedule schedule)
        {
            return new ScheduleViewModel
            {
                ScheduleId = schedule.ScheduleId,
                ShowId = schedule.Show.ShowId,
                Title = schedule.Show.Title,
                SubTitle = schedule.Show.SubTitle,
                Description = schedule.Show.Description,
                ScheduleDate = schedule.ScheduleDate,
                Duration = schedule.Show.Duration,
                Price = schedule.Show.Price
            };
        }

        /// <summary>
        /// Maps the ViewModel to a Schedule
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        public static Schedule MapToDbResult(ScheduleViewModel viewModel)
        {
            return new Schedule
            {
                ScheduleId = viewModel.ScheduleId,
                ScheduleDate = viewModel.ScheduleDate,
                Show = new Show()
                {
                    ShowId = viewModel.ShowId,
                    Title = viewModel.Title,
                    SubTitle = viewModel.SubTitle,
                    Description = viewModel.Description,
                    Duration = viewModel.Duration,
                    Price = viewModel.Price
                }
            };
        }
    }
}
