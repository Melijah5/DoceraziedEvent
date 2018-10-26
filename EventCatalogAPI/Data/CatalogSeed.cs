using EventCatalogAPI.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventCatalogAPI.Data
{
    public class CatalogSeed
    {
        public static async Task SeedAsync(CatalogContext context)
        {
            context.Database.Migrate();
            if (!context.Catagories.Any())
            {
                context.Catagories.AddRange
                    (GetPreConfigeredCatagories());
               await context.SaveChangesAsync();
            }
            if (!context.SubCatagories.Any())
            {
                context.SubCatagories.AddRange
                    (GetPreConfigeredsubCatagories());
                context.SaveChanges();
            }
            if (!context.Events.Any())
            {
                context.Events.AddRange
                    (GetPreConfigeredEvents());
               context.SaveChanges();
            }
            
      
        }
        private static IEnumerable<Catagory> GetPreConfigeredCatagories()
        {
            return new List<Catagory>()
            {
                new Catagory() { Name = "Music"},
                new Catagory() { Name = "Food & Drink"},
                new Catagory() { Name = "Arts"},
                new Catagory() { Name = "Business"},
                new Catagory() { Name = "Parties"},
                new Catagory() { Name = "Classes"},
                new Catagory() { Name = "Sport"}
            };
        }
            private static IEnumerable<SubCatagory> GetPreConfigeredsubCatagories()
            {
                return new List<SubCatagory>()
            {
                new SubCatagory() { Type = "Confrence"},
                new SubCatagory() { Type = "Concert"},
                new SubCatagory() { Type = "Festival"},
                new SubCatagory() { Type = "Screening"},
                new SubCatagory() { Type = "Siminar"},
                new SubCatagory() { Type = "Tour"},
                new SubCatagory() { Type = "Tournament"}
            };
        }

       
        private static IEnumerable<Event> GetPreConfigeredEvents()
        {
            return new List<Event>()
            {
                new Event() {EventCategoryId=1, EventSubCatagoryId=2,  Location= "WA" ,EventName="Music & top 40 tunes Consert" ,Description = "Cocktails, dancing & music in a multi-floor night spot with moody, modern decor", EventStartDate = "11/12/2018", EventEndDate="11/12/2018", EventStartTime = "8PM", EventEndTime="12am", Fee= 50, Address= "2946 1st Ave S, Seattle, WA 98134",Created="10/12/2018", EventImageUrl= "http://externalcatalogbaseurltobereplaced/api/Pic/1" },
                new Event() { EventCategoryId=1, EventSubCatagoryId=3, Location= "WA", EventName = "Cocktails, dancing & music", Description = "Colorful, airy locale featuring Latin American & Caribbean fare, plus live music & dancing.", EventStartDate = "11/12/2018", EventEndDate="11/16/2018", EventStartTime = "8AM", EventEndTime="6PM", Fee= 25, Address= "1524 Rainer Ave S, Seattle, WA 98118",Created="10/12/2018", EventImageUrl= "http://externalcatalogbaseurltobereplaced/api/Pic/3" },
                new Event() {EventCategoryId=2, EventSubCatagoryId=3,  Location= "CA", EventName = "Taste Seattle Food Tours", Description = "Taste Seattle Food Tours", EventStartDate = "12/1/2018", EventEndDate="12/2/2018", EventStartTime = "2PM", EventEndTime="9pm", Fee= 39, Address= "405 Roy Ave S, Seattle, CA 98010",Created="10/12/2018", EventImageUrl= "http://externalcatalogbaseurltobereplaced/api/Pic/5" },
                new Event() {EventCategoryId=2, EventSubCatagoryId=7,  Location= "WA" , EventName = "Holiday Food & Gift Festival", Description = "Food writer Julia Turshen will demonstrate how to make a Sunday Morning Bangladeshi Breakfast" , EventStartDate = "12/16/2018", EventEndDate="1/12/2018", EventStartTime = "1PM", EventEndTime="8pm", Fee= 20, Address= "5147 1st Ave S, Seattle, WA 98108",Created="10/12/2018", EventImageUrl= "http://externalcatalogbaseurltobereplaced/api/Pic/6" },
                new Event() {EventCategoryId=3, EventSubCatagoryId=1,  Location= "WA" , EventName = "Art Galary" ,Description = "Art Galary", EventStartDate = "11/24/2018", EventEndDate="11/28/2018", EventStartTime = "8PM", EventEndTime="12am", Fee= 50, Address= "1415 4st Ave S, Seattle, WA 98147",Created="10/12/2018", EventImageUrl= "http://externalcatalogbaseurltobereplaced/api/Pic/11" },
                new Event() { EventCategoryId=3, EventSubCatagoryId=5, Location= "WA" , EventName = "Moisture Festival", Description = "Performing Arts Theater", EventStartDate = "1/12/2019", EventEndDate="1/09/2019", EventStartTime = "8PM", EventEndTime="12am", Fee= 20, Address= "4301 Leary Way NW, Seattle, WA 98107",Created="10/12/2018", EventImageUrl= "http://externalcatalogbaseurltobereplaced/api/Pic/18" },

                new Event() {EventCategoryId=5, EventSubCatagoryId=3,  Location= "WA" , EventName = "Trinity",Description = "Sprawling house-music spot with 2 dance floors, Asian-themed cocktail lounge & plush VIP room.", EventStartDate = "11/12/2018", EventEndDate="11/12/2018", EventStartTime = "9PM", EventEndTime="12am", Fee= 150, Address= "7428 68st Ave W, Seattle, WA 98698",Created="10/12/2018", EventImageUrl= "http://externalcatalogbaseurltobereplaced/api/Pic/12" },
                new Event() {EventCategoryId=6, EventSubCatagoryId=3,  Location= "WA" , EventName = "Miss Charlotte's Music Classe", Description = "Music School", EventStartDate = "2/2/2019", EventEndDate="8/1/2019", EventStartTime = "3pm", EventEndTime="12am", Fee= 20, Address= "Rose Bowl Stadium, Pasadena, CA",Created="10/12/2018", EventImageUrl= "http://externalcatalogbaseurltobereplaced/api/Pic/15" },
                new Event() {EventCategoryId=6, EventSubCatagoryId=3,  Location= "CA" , EventName = "Programming", Description = "Detail about c#", EventStartDate = "1/4/2019", EventEndDate="9/19/2019", EventStartTime = "2pm", EventEndTime="7pm", Fee= 30, Address= "Downtown Burbank , Burbank, CA",Created="10/12/2018", EventImageUrl= "http://externalcatalogbaseurltobereplaced/api/Pic/5" },
                new Event() {EventCategoryId=7, EventSubCatagoryId=7,  Location= "WA" , EventName = "Football", Description = "Seattle vs Tennessee", EventStartDate = "1/5/2018", EventEndDate="1/5/2018", EventStartTime = "12pm", EventEndTime="2pm", Fee= 45, Address= "1458 11st Ave S, Seattle, WA 98254",Created="10/12/2018", EventImageUrl= "http://externalcatalogbaseurltobereplaced/api/Pic/17" },
                new Event() {EventCategoryId=5, EventSubCatagoryId=2,  Location= "CA" , EventName = "Q Nightclub",Description = "Big-name DJs spinning a spectrum ", EventStartDate = "11/12/2018", EventEndDate="11/12/2018", EventStartTime = "11am", EventEndTime="8pm", Fee= 10, Address= "Glendale Galleria, Glendale, CA",Created="10/12/2018", EventImageUrl= "http://externalcatalogbaseurltobereplaced/api/Pic/13" },
                new Event() { EventCategoryId=7, EventSubCatagoryId=7, Location= "WA" , EventName = "HipHop", Description = "Live Music ", EventStartDate = "11/12/2018", EventEndDate="11/12/2018", EventStartTime = "10am", EventEndTime="10pm", Fee= 60, Address= "4442 31st Ave SW, Seattle, WA 98457",Created="10/12/2018", EventImageUrl= "http://externalcatalogbaseurltobereplaced/api/Pic/12" },


                new Event() {EventCategoryId=1, EventSubCatagoryId=2,  Location= "WA" , EventName = "Slim's Last Chance",Description = " Live Music Casual Texas-style bar with a patio & outdoor stage offering burgers, chili & live music.live music & dancing.", EventStartDate = "12/7/2018", EventEndDate="12/9/2018", EventStartTime = "8PM", EventEndTime="12am", Fee= 50, Address= "2946 1st Ave S, Seattle, WA 98134",Created="10/12/2018", EventImageUrl= "http://externalcatalogbaseurltobereplaced/api/Pic/14" },
                new Event() { EventCategoryId=1, EventSubCatagoryId=3, Location= "WA" , EventName = "Neumos", Description = "Midsize venue for indie rock, plus hip-hop, country & other genres", EventStartDate = "12/22/2018", EventEndDate="12/2/2018", EventStartTime = "8PM", EventEndTime="12am", Fee= 60, Address= "2547 9st Ave W, Seattle, WA 98256",Created="10/12/2018", EventImageUrl= "http://externalcatalogbaseurltobereplaced/api/Pic/2" },
                new Event() {EventCategoryId=7, EventSubCatagoryId=3,  Location= "WA" , EventName = "Olompic", Description = "2018 Olmpice Game", EventStartDate = "5/3/2019", EventEndDate="5/5/2019", EventStartTime = "8PM", EventEndTime="12am", Fee= 30, Address= "4645 20st Ave N, Seattle, WA 98210",Created="10/12/2018", EventImageUrl= "http://externalcatalogbaseurltobereplaced/api/Pic/5" },
                new Event() {EventCategoryId=6, EventSubCatagoryId=7,  Location= "WA" , EventName = "Designing class", Description = "Modern cloth stype", EventStartDate = "2/2/2019", EventEndDate="9/1/2019", EventStartTime = "8PM", EventEndTime="12am", Fee= 75, Address= "3526 11st Ave S, Seattle, WA 98547",Created="10/12/2018", EventImageUrl= "http://externalcatalogbaseurltobereplaced/api/Pic/15" },
                new Event() {EventCategoryId=3, EventSubCatagoryId=1,  Location= "WA" , EventName = "ArtsWest",Description = "Gallery with rotating exhibits & an intimate theater focusing on challenging contemporary pieces.s", EventStartDate = "12/9/2018", EventEndDate="12/9/2018", EventStartTime = "8PM", EventEndTime="12am", Fee= 50, Address= "4711 California Ave SW, Seattle, WA 98116",Created="10/12/2018", EventImageUrl= "http://externalcatalogbaseurltobereplaced/api/Pic/11" },
                new Event() { EventCategoryId=4, EventSubCatagoryId=5, Location= "WA" , EventName = "Intereperners", Description = "Topic on changing the world", EventStartDate = "7/12/2018", EventEndDate="7/12/2018", EventStartTime = "8PM", EventEndTime="12am", Fee= 55, Address= "2541 56st Ave SW, Seattle, WA 98547",Created="10/12/2018", EventImageUrl= "http://externalcatalogbaseurltobereplaced/api/Pic/18" },

                //new Event() {EventCategoryId=2, EventSubCatagoryId=2,  Location= "WA" ,  EventName = "SEATTLE WINTER CIDERFEST - Ciders of the Season",Description = "THIS IS A TASTING EVENT", EventStartDate = "12/1/2018", EventEndDate="12/12/2018", EventStartTime = "8PM", EventEndTime="12am", Fee= 20, Address= "3526 44st Ave S, Seattle, WA 96854",Created="10/12/2018", EventImageUrl= "http://externalcatalogbaseurltobereplaced/api/Pic/1" },
                //new Event() { EventCategoryId=2, EventSubCatagoryId=3, Location= "WA" , EventName = "Fresh Hop Dinner with Fremont Brewing Food & Drinkr",Description = "Chefs Bradley Layfield and Brendon Bain", EventStartDate = "2/4/2019", EventEndDate="2/4/2019", EventStartTime = "2pm", EventEndTime="7pm", Fee= 40, Address= "310 Terry Ave N, Seattle, WA 98109 ",Created="10/12/2018", EventImageUrl= "http://externalcatalogbaseurltobereplaced/api/Pic/3" },
                //new Event() {EventCategoryId=3, EventSubCatagoryId=3,  Location= "WA" , EventName = "Party Hat",Description = "Art Gallery", EventStartDate = "11/30/2018", EventEndDate="11/30/2018", EventStartTime = "9PM", EventEndTime="11pm", Fee= 50, Address= "312 S Washington St Suite G, Seattle, WA 98104",Created="10/12/2018", EventImageUrl= "http://externalcatalogbaseurltobereplaced/api/Pic/5" },
                //new Event() {EventCategoryId=5, EventSubCatagoryId=7,  Location= "WA" , EventName = "Club Sur",Description = "Dark, intimate nightclub with a goth/industrial atmosphere, open to members & their guests.", EventStartDate = "12/1/2018", EventEndDate="12/1/2018", EventStartTime = "8PM", EventEndTime="12am", Fee= 29, Address= "4441 4st Ave S, Seattle, WA 98741",Created="10/12/2018", EventImageUrl= "http://externalcatalogbaseurltobereplaced/api/Pic/6" },
                //new Event() {EventCategoryId=6, EventSubCatagoryId=1,  Location= "WA" ,EventName = "Dance class",Description = "Complete dance class", EventStartDate = "11/12/2018", EventEndDate="3/1/2019", EventStartTime = "8PM", EventEndTime="10pm", Fee= 180, Address= "1124 25st Ave W, Seattle, WA 98547",Created="10/12/2018", EventImageUrl= "http://externalcatalogbaseurltobereplaced/api/Pic/11" },
                //new Event() { EventCategoryId=7, EventSubCatagoryId=7, Location= "WA" , EventName = "football Event",Description = "Man vs Ars", EventStartDate = "4/4/2019", EventEndDate="4/4/2019", EventStartTime = "8PM", EventEndTime="10pm", Fee= 42, Address= "7711 3st Ave N, Seattle, WA 98564",Created="10/12/2018", EventImageUrl= "http://externalcatalogbaseurltobereplaced/api/Pic/18" }
            };

        }
        
    }
}
