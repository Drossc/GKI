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
using System.IO;

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
            public string DateAdded { get; set; }
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
            if (tbGameTitle.Text != "")
            {
                GameInformation pullGameInfo = new GameInformation
                {
                    //Where to store information
                    InfoFile = @"C:\Users\dross\source\repos\GKI\GamesKnowledgeInterface2\LetEmKnowThings.txt",
                    //Assign the values from xaml
                    //Name of game
                    GameTitle = tbGameTitle.Text,
                    //Date added to database
                    DateAdded = DateTime.Now.ToString(format: "MM/dd/yyyy"),
                    //Text value of UPC
                    GameUPCs = tbGameUPC.Text,
                    //Description of game
                    GameDescription = tbGameDescription.Text,
                    //Date game was purchased
                    PurchaseDate = tbPurchaseDate.Text,
                    //Amount game was purchased for
                    PurchaseAmount = Convert.ToDouble(tbPurchaseAmount.Text),
                    //Where the purchase took place
                    PurchaseLocation = tbPurchaseLocation.Text,
                    //Original retail value of the game
                    RetailValue = Convert.ToDouble(tbRetailValue.Text),
                    //Calculated discount value of the game
                    DiscountValue = Convert.ToDouble(tbDiscountValue.Text),
                    //Date game was originally release on entered platform
                    ReleaseDate = tbReleaseDate.Text,
                    //Platform game released/purchased on
                    GamePlatform = tbGamePlatform.Text
                };
                //Assign information to send
                string[] infoToWrite = {pullGameInfo.GameUPCs + "," + 
                                        pullGameInfo.DateAdded + "," +
                                        pullGameInfo.GameTitle + "," +
                                        pullGameInfo.GameDescription + "," +
                                        pullGameInfo.PurchaseDate + "," + 
                                        Convert.ToString(pullGameInfo.PurchaseAmount) + "," +
                                        pullGameInfo.PurchaseLocation + "," + 
                                        Convert.ToString(pullGameInfo.RetailValue) + "," +
                                        Convert.ToString(pullGameInfo.DiscountValue) + "," +
                                        pullGameInfo.ReleaseDate + "," +
                                        pullGameInfo.GamePlatform};
                //Send information to predetermined file

                //Texted added only once to a file
                if (!File.Exists(pullGameInfo.InfoFile))
                {
                    using (StreamWriter infoToWriteTo = File.CreateText(pullGameInfo.InfoFile))
                    {
                        infoToWriteTo.WriteLine("Game Knowledge Information");
                    }
                }
                using (StreamWriter infoToWriteTo = File.AppendText(pullGameInfo.InfoFile))
                {
                    //infoToWriteTo.WriteLine("UPC,DateAdded,GameTitle,GameDescription,PurchaseDate,PurchaseAmount,PurchaseLocation,RetailValue,DiscountValue,ReleaseDate,GamePlatform");
                    infoToWriteTo.WriteLine(infoToWrite[0]);
                }
                /*using (StreamReader infoToRead = File.OpenText(pullGameInfo.InfoFile))
                {
                    string something = "";
                    while ((something = infoToRead.ReadLine()) != null)
                    {
                        Console.WriteLine(something);
                    }
                }*/
                //System.IO.File.WriteAllLines(pullGameInfo.InfoFile,infoToWrite);
                //Need to write to end of file instead of overriding whole file
                //Need to clear form for new entry
                //Notify user that the information has been saved
                //MessageBox.Show("Information has been recorded successfully!", "GKI");
                tbDateAdded.Text = pullGameInfo.DateAdded;
                lblCursorPostion.Text = "Information successfully recorded!";
            }
        }
        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }
    }
}
