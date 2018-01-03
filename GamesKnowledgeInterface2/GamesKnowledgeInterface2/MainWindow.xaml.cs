using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GamesKnowledgeInterface2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        public class GameInformation
        {
            //File storing all information
            public string InfoFile { get; set; }
            //Title of the video game
            public string GameTitle { get; set; }
            //Date added to database
            public DateTime DateAdded { get; set; }
            //Text value of UPC
            public string GameUPCs { get; set; }
            //Description of game
            public string GameDescription { get; set; }
            //Date game was purchased
            public string PurchaseDate { get; set; }
            //Amount game was purchased for
            public double PurchaseAmount { get; set; }
            //Where the purchase took place
            public string PurchaseLocation { get; set; }
            //Original retail value of the game
            public double RetailValue { get; set; }
            //Calculated discount value of the game
            public double DiscountValue { get; set; }
            //Date game was originally release on entered platform
            public string ReleaseDate { get; set; }
            //Platform game released/purchased on
            public string GamePlatform { get; set; }
        }
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            //Confirm if anything exists within the game title
            if (tbGameTitle.Text != null)
            {
                //string infoFile = @"C:\Users\dross\source\repos\GKI\GamesKnowledgeInterface2\LetEmKnowThings.txt";
                GameInformation gameInfo = new GameInformation
                {
                    InfoFile = @"C:\Users\dross\source\repos\GKI\GamesKnowledgeInterface2\LetEmKnowThings.txt",
                    GameTitle = tbGameTitle.Text,
                    DateAdded = DateTime.Now,
                    GameUPCs = tbGameUPC.Text,
                    GameDescription = tbGameDescription.Text,
                    PurchaseDate = tbPurchaseDate.Text,
                    PurchaseAmount = Convert.ToDouble(tbPurchaseAmount.Text),
                    PurchaseLocation = tbPurchaseLocation.Text,
                    RetailValue = Convert.ToDouble(tbRetailValue.Text),
                    DiscountValue = Convert.ToDouble(tbDiscountValue.Text),
                    ReleaseDate = tbReleaseDate.Text,
                    GamePlatform = tbGamePlatform.Text
                };
                /* Moved to public class instead of declaring in private void action
                string gameTitle;
                //Date added to database
                DateTime dateAdded; //change into date
                //Int value of UPC
                //int gameUPCi;
                //Text value of UPC
                string gameUPCs;
                //Description of game
                string gameDescription;
                //Date game was purchased
                string purchaseDate; //change into date
                //Amount game was purchased for
                double purchaseAmount = 0.0d;
                //Where the purchase took place
                string purchaseLocation;
                //Original retail value of the game
                double retailValue = 0.0d;
                //Calculated discount value of the game
                double discountValue = 0.0d;
                //Date game was originally release on entered platform
                string releaseDate; //change into date
                //Platform game released/purchased on
                string gamePlatform;
                //Assign the values from xaml
                gameTitle = tbGameTitle.Text;
                dateAdded = DateTime.Now;
                gameUPCs = tbGameUPC.Text;
                //Error given of either too large or too small for an Int32
                /*gameUPCi = Convert.ToInt32(gameUPCs); //DecimalUpDown/DoubleUpDown/IntegerUpdown exists in Extended WPF ToolKit, Need to Update*/
                /*gameDescription = tbGameDescription.Text;
                purchaseDate = tbPurchaseDate.Text;
                purchaseAmount = Convert.ToDouble(tbPurchaseAmount.Text); //DecimalUpDown/DoubleUpDown/IntegerUpdown exists in Extended WPF ToolKit, Need to Update
                purchaseLocation = tbPurchaseLocation.Text;
                retailValue = Convert.ToDouble(tbRetailValue.Text); //DecimalUpDown/DoubleUpDown/IntegerUpdown exists in Extended WPF ToolKit, Need to Update
                discountValue = Convert.ToDouble(tbDiscountValue.Text); //DecimalUpDown/DoubleUpDown/IntegerUpdown exists in Extended WPF ToolKit, Need to Update
                releaseDate = tbReleaseDate.Text;
                gamePlatform = tbGamePlatform.Text;*/
                //Assign information to send
                string[] infoToWrite = {gameInfo.GameUPCs + "," + 
                                        (Convert.ToString(gameInfo.DateAdded)) + "," +
                                        gameInfo.GameTitle + "," + 
                                        gameInfo.GameDescription + "," +
                                        gameInfo.PurchaseDate + "," + 
                                        Convert.ToString(gameInfo.PurchaseAmount) + "," + 
                                        gameInfo.PurchaseLocation + "," + 
                                        Convert.ToString(gameInfo.RetailValue) + "," +
                                        Convert.ToString(gameInfo.DiscountValue) + "," +
                                        gameInfo.ReleaseDate + "," +
                                        gameInfo.GamePlatform};
                //Send information to predetermined file
                System.IO.File.WriteAllLines(gameInfo.InfoFile,infoToWrite);
                //Need to write to end of file instead of overriding whole file
                //Need to clear form for new entry
                //Notify user that the information has been saved
                MessageBox.Show("Information has been recorded successfully!", "GKI");
            }
        }
        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }
    }
}
