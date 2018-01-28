using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Data;
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
        private int parsedGameID;
        string connstr = GamesKnowledgeInterface2.Utility.GetConnectionString();

        public MainWindow()
        {
            InitializeComponent();
        }

        public void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            //Confirm Length of Game Title in UI to determine execution needs
            if (tbGameTitle.Text.Length > 0)
            {
                // Video Game Details Loaded From UI to SQL Database
                SqlConnection conn = new SqlConnection(connstr);
                SqlCommand cmdNewGame = new SqlCommand("vgAddNewGame", conn);
                cmdNewGame.CommandType = System.Data.CommandType.StoredProcedure;
                cmdNewGame.Parameters.Add(new SqlParameter("@GameTitle", SqlDbType.NVarChar,40));
                cmdNewGame.Parameters["@GameTitle"].Value = tbGameTitle.Text;
                cmdNewGame.Parameters.Add(new SqlParameter("@DateAdded", SqlDbType.Text));
                cmdNewGame.Parameters["@DateAdded"].Value = DateTime.Now;
                cmdNewGame.Parameters.Add(new SqlParameter("@GameUPC", SqlDbType.Text));
                cmdNewGame.Parameters["@GameUPC"].Value = tbGameUPC.Text;
                cmdNewGame.Parameters.Add(new SqlParameter("@GameDescription", SqlDbType.Text));
                cmdNewGame.Parameters["@GameDescription"].Value = tbGameDescription.Text;
                cmdNewGame.Parameters.Add(new SqlParameter("@PurchaseDate", SqlDbType.Text));
                cmdNewGame.Parameters["@PurchaseDate"].Value = tbPurchaseDate.Text;
                cmdNewGame.Parameters.Add(new SqlParameter("@PurchaseAmount", SqlDbType.Text));
                cmdNewGame.Parameters["@PurchaseAmount"].Value = tbPurchaseAmount.Text;
                cmdNewGame.Parameters.Add(new SqlParameter("@PurchaseLocation", SqlDbType.Text));
                cmdNewGame.Parameters["@PurchaseLocation"].Value = tbPurchaseAmount.Text;
                cmdNewGame.Parameters.Add(new SqlParameter("@RetailValue", SqlDbType.Text));
                cmdNewGame.Parameters["@RetailValue"].Value = tbRetailValue.Text;
                cmdNewGame.Parameters.Add(new SqlParameter("@DiscountValue", SqlDbType.Text));
                cmdNewGame.Parameters["@DiscountValue"].Value = tbDiscountValue.Text;
                cmdNewGame.Parameters.Add(new SqlParameter("@ReleaseDate", SqlDbType.Text));
                cmdNewGame.Parameters["@ReleaseDate"].Value = tbReleaseDate.Text;
                cmdNewGame.Parameters.Add(new SqlParameter("@GamePlatform", SqlDbType.Text));
                cmdNewGame.Parameters["@GamePlatform"].Value = tbGamePlatform.Text;
                cmdNewGame.Parameters.Add(new SqlParameter("@GameID", SqlDbType.Int));
                cmdNewGame.Parameters["@GameID"].Direction = ParameterDirection.Output;

                try
                {
                    conn.Open();
                    cmdNewGame.ExecuteNonQuery();
                    this.parsedGameID = (int)cmdNewGame.Parameters["@GameID"].Value;
                    this.tbDateAdded.Text = Convert.ToString(parsedGameID);
                }
                catch
                {
                    MessageBox.Show("ID was not returned");
                }
                finally
                {
                    conn.Close();
                }

                //Show Detail Storage Date
                //tbDateAdded.Text = pullGameInfo.DateAdded;
                tbDateAdded.Text = DateTime.Now.ToString("MM/dd/yyyy");
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
