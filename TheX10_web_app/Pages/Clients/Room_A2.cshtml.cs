using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace TheX10_web_app.Pages.Clients
{
    public class a2Model : PageModel
    {
        public List<ClientInfo_a2> listClients_a2 = new List<ClientInfo_a2>();

        public void OnGet()
        {
            try
            {
                String connectionString = "Data Source=192.168.1.19,1031;Initial Catalog=SmartHMS;Persist Security Info=True;User ID=max;Password=0935328285n";
                using (SqlConnection connection_a2 = new SqlConnection(connectionString))
                {
                    connection_a2.Open();
                    String sql = "SELECT * FROM ZAP_DA_THISDAY_CHECKIN WHERE ROOM_NO = 'A2'";
                    using (SqlCommand command = new SqlCommand(sql, connection_a2))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                            if (!reader.HasRows)
                            {
                                ClientInfo_a2 clientInfo_a2 = new ClientInfo_a2();
                                clientInfo_a2.RSV_NAME1 = "บ้านว่าง";
                                clientInfo_a2.ROOM_NO = "บ้านว่าง";
                                listClients_a2.Add(clientInfo_a2);
                            }
                            else
                            {

                                {
                                    while (reader.Read())
                                    {
                                        ClientInfo_a2 clientInfo_a2 = new ClientInfo_a2();
                                        clientInfo_a2.RECORD_ID = "" + reader.GetInt32(0);
                                        clientInfo_a2.RSV_NAME1 = reader.GetString(2);
                                        clientInfo_a2.ROOM_NO = reader.GetString(6);
                                        clientInfo_a2.NINGHT = "" + reader.GetInt32(12);
                                        clientInfo_a2.CHECK_IN = "" + reader.GetDateTime(4);
                                        clientInfo_a2.PEOPLE = "" + reader.GetInt32(7);



                                        listClients_a2.Add(clientInfo_a2);
                                    }
                                }
                            }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.ToString());
            }
        }
    }

    public class ClientInfo_a2
    {
        public String RECORD_ID;
        public String RSV_NAME1;
        public String ROOM_NO;
        public String NINGHT;
        public String CHECK_IN;
        public String PEOPLE;



    }
}