using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace TheX10_web_app.Pages.Clients
{
    class Check_in_allModel : PageModel
    {
        public List<ClientInfo> listClients = new List<ClientInfo>();

        public void OnGet()
        {
            try
            {
                String connectionString = "Data Source=192.168.1.19,1031;Initial Catalog=SmartHMS;Persist Security Info=True;User ID=max;Password=0935328285n";
                using (SqlConnection connection_a1 = new SqlConnection(connectionString))
                {
                    connection_a1.Open();
                    String sql = "SELECT * FROM [ZAP_DA_THISDAY_CHECKIN]";
                    using (SqlCommand command = new SqlCommand(sql, connection_a1))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())


                        {
                            while (reader.Read())
                            {
                                ClientInfo clientInfo = new ClientInfo();
                                clientInfo.RECORD_ID = "" + reader.GetInt32(0);
                                clientInfo.RSV_NAME1 = reader.GetString(2);
                                clientInfo.ROOM_NO = reader.GetString(6);
                                clientInfo.NINGHT = "" + reader.GetInt32(12);
                                clientInfo.CHECK_IN = "" + reader.GetDateTime(4);
                                clientInfo.PEOPLE = "" + reader.GetInt32(7);


                                listClients.Add(clientInfo);

                            }


                        }
                        connection_a1.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.ToString());
            }
        }
    }


    public class ClientInfo
    {
        public String RECORD_ID;
        public String RSV_NAME1;
        public String ROOM_NO;
        public String NINGHT;
        public String CHECK_IN;
        public String PEOPLE;
    }

}