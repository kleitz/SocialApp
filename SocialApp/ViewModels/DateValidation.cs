using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Web;

namespace SocialApp.ViewModels
{
    public class DateValidation : ValidationAttribute
    {
        //date object is passed into here from view model
        public override bool IsValid (object value)
        {
            DateTime dateTime;
            //valid var stores validation
            var isValid = DateTime.TryParseExact
            (
                //date converts value to string
                Convert.ToString(value), 
                //string params set here
                "d MMM YYYY", 
                //culture is set
                CultureInfo.CurrentCulture, 
                DateTimeStyles.None, 
                //date time is output
                out dateTime
            );
            //validation is returned and datetime is returned
            return (isValid && dateTime > DateTime.Now);
        }
    }
}