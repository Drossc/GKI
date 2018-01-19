using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesKnowledgeInterface2
{
    public class VideoGame
    {
        /// <summary>
        /// File Storing Video Game Information
        /// </summary>
        public string InfoFile;
        /// <summary>
        /// Title of the Video Game
        /// </summary>
        public string GameTitle;
        /// <summary>
        /// Date Added to Storage File
        /// </summary>
        public string DateAdded;
        /// <summary>
        /// UPC as Text
        /// </summary>
        public string GameUPCs;
        /// <summary>
        /// Brief Description of Video Game
        /// </summary>
        public string GameDescription;
        /// <summary>
        /// Date of Purchase
        /// </summary>
        public string PurchaseDate;
        /// <summary>
        /// Amount Video Game Purchase For
        /// </summary>
        public double PurchaseAmount;
        /// <summary>
        /// Store Purchase Made At
        /// </summary>
        public string PurchaseLocation;
        /// <summary>
        /// Video Game Release Retail Value
        /// </summary>
        public double RetailValue;
        /// <summary>
        /// Discount Value of Video Game at Time of Purchase
        /// </summary>
        ///<remarks>Value should be a calculation of Purchase Amount Divided by Retail Value</remarks>
        public double DiscountValue;
        /// <summary>
        /// U.S. Release Date of the Video Game
        /// </summary>
        public string ReleaseDate;
        /// <summary>
        /// Platform Video Game Purchased On
        /// </summary>
        public string GamePlatform;
    }
}
