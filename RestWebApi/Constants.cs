using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace RestWebApi
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum Category
    {
        Starter,
        MainCourse,
        Dessert, 
        Beverage
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum TimeOfDay
    {
        Breakfast,
        Lunch,
        Dinner, 
        Weekdays,
        Weekends
    }
}
