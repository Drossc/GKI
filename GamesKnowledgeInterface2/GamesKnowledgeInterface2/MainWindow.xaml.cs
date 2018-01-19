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
//Add in for using SQL Server Namespaces
using System.Data.SqlClient;
using System.Configuration;

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

        public void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            //Confirm Length of Game Title in UI to determine execution needs
            if (tbGameTitle.Text.Length > 0)
            {
                // Video Game Details Loaded From UI
                VideoGame pullGameInfo = new VideoGame
                {
                    InfoFile = @"C:\Users\dross\source\repos\GKI\GamesKnowledgeInterface2\LetEmKnowThings.txt",
                    GameTitle = tbGameTitle.Text,
                    DateAdded = DateTime.Now.ToString(format: "MM/dd/yyyy"),
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
                
                //Assign Information to Send
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
                
                //Send Information to Storage File
                if (!File.Exists(pullGameInfo.InfoFile))
                {
                    using (StreamWriter infoToWriteTo = File.CreateText(pullGameInfo.InfoFile))
                    {
                        infoToWriteTo.WriteLine("Game Knowledge Information");
                    }
                }
                using (StreamWriter infoToWriteTo = File.AppendText(pullGameInfo.InfoFile))
                {
                    infoToWriteTo.WriteLine(infoToWrite[0]);
                }

                //Show Detail Storage Date
                tbDateAdded.Text = pullGameInfo.DateAdded;
                //Notify Use of Completion
                lblCursorPostion.Text = "Information successfully recorded!";
            }
        }
        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            //Closes Application
            System.Windows.Application.Current.Shutdown();
        }
    }
}
