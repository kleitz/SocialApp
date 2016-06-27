using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SocialApp.Models;
using System.ComponentModel.DataAnnotations;

namespace SocialApp.ViewModels
{
    //the view model is used for presentation purposes and breaks down the presentation of data so it is easier to read
    public class GigFormViewModel
    {
        [Required]
        public string Venue { get; set; }
        [Required]
        [DateValidation]
        public string Date { get; set; }
        [Required]
        [TimeValidation]
        public string Time { get; set; }
        [Required]
        public byte Genre { get; set; }
        //enum of values pulled from the Genres model
        [Required]
        public IEnumerable<Genre> Genres { get; set; }
        public DateTime GetDateTime()
        {
           return DateTime.Parse(string.Format("{0}, {1}", Date, Time));
        }
    }
}