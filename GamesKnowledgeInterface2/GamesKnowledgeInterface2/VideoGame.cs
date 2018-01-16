using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesKnowledgeInterface2
{
    class VideoGame
    {
        //File storing all information
        public string InfoFile;
        //Title of the video game
        public string GameTitle;
        //Date added to database
        public string DateAdded;
        //Text value of UPC
        public string GameUPCs;
        //Description of game
        public string GameDescription;
        //Date game was purchased
        public string PurchaseDate;
        //Amount game was purchased for
        public double PurchaseAmount;
        //Where the purchase took place
        public string PurchaseLocation;
        //Original retail value of the game
        public double RetailValue;
        //Calculated discount value of the game
        public double DiscountValue;
        //Date game was originally release on entered platform
        public string ReleaseDate;
        //Platform game released/purchased on
        public string GamePlatform;
    }
}
