using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using foursquare.Models;

namespace foursquare.Models
{
    public class HomeModel
    {
        foursquareconfEntities database = new foursquareconfEntities();

        public Welcome welcome { get; set; }
        public About about { get; set; }
        public Hosts hosts { get; set; }
        public Venue venue { get; set; }
        public Contact contact { get; set; }
        public List<WelcomeTeam> welcomeTeam { get; set; }
        public WelcomeTeam Member { get; set; }
      
        public List<Speakers> speakers { get; set; }

        public List<Moderators> moderators { get; set; }
        public List<Program> program { get; set; }
        public Speakers speakerYear { get; set; }

        public int firstYear { get; set; }

        public Speakers speakerssBio { get; set; }
        public Moderators moderatorsBio { get; set; }

        //conference
        public IList<Speakers> NewsList { get; set; }
        public Speakers Archive { get; set; }
        
        public IList<int> Years { get; set; }


        //load conference bio Speakers
        internal void loadconfBio(object id)
        {
            speakerssBio = database.Speakers.Find(id);
        }
        //load conference bio Moderators
        internal void loadconfBioModerators(int id)
        {
            moderatorsBio = database.Moderators.Find(id);
        }


        #region//constructure 1
        /// <summary>
        /// This is the default constructure
        /// </summary>
        public HomeModel()
        {
            welcome = database.Welcome.FirstOrDefault();
            about = database.About.FirstOrDefault();
            hosts = database.Hosts.FirstOrDefault();
            venue = database.Venue.FirstOrDefault();
            contact = database.Contact.FirstOrDefault();
            welcomeTeam = database.WelcomeTeam.ToList();
           
          
            //conference
            NewsList = database.Speakers.OrderByDescending(n => n.Year).ToList();

            Years = SetYears(NewsList);
            Archive = null;

        }
        #endregion
        #region //constructure 2 takes an int year
        /// <summary>
        /// This initialize my object
        /// </summary>
        /// <param name="year">This is an year parameter</param>
        public HomeModel(int year)
        {
            
            NewsList = database.Speakers.OrderByDescending(n => n.Year).ToList();
            //Years = SetYears(ManageNews.GetAllNews());
            Archive = null;
            Years = SetYears(NewsList);

            speakers = database.Speakers.Where(spk => spk.Year == year ).ToList();
            moderators = database.Moderators.Where(spk => spk.Year == year).ToList();
            program = database.Program.Where(spk => spk.Year == year).OrderBy(n => n.Date).ToList();
            firstYear = SetYears(NewsList).First();
        }
        #endregion

        internal void loadmember(int id)
        {
            Member = database.WelcomeTeam.Find(id);
        }



       

        public void setArticle(int id)
        {
            Archive = database.Speakers.Find(id);
            var count = database.Speakers.OrderByDescending(n => n.Year).ToList();
            Years = SetYears(count);
        }

        private IList<int> SetYears(IList<Speakers> newsList)
        {
            IList<int> result = new List<int>();

            foreach (var news in newsList.Select(n => new { n.Year }).Distinct())
            {
                result.Add((int)news.Year);
            }

            return result;
        }

        internal void loadArchive()
        {
            NewsList = database.Speakers.OrderByDescending(n => n.Year).ToList();
            Years = SetYears(NewsList);
        }

        internal void loadArchive(int year)
        {
            var count = database.Speakers.OrderByDescending(n => n.Year).ToList();
            Years = SetYears(count);
        }


        //internal void loadbyID(int id) {
        //    Home = database.tbl_user.Find(id);
        //    Home = database.tbl_user.Where(c=> c.user_id == id).First();
        //    Home = database.tbl_user.FirstOrDefault();
        //    var a = database.tbl_user.Where(c => c.user_id == id).Select(c => new { ID = c.user_id }).First();


        //}
    }
   
}