using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace TheX10_web_app.Pages.Clients
{
    public class a1Model : PageModel
    {
        public List<ClientInfo_a1> listClients_a1 = new List<ClientInfo_a1>();
        public ClientInfo clientInfo = new ClientInfo();

        public void OnGet()
        {
            try
            {
                String connectionString = "Data Source=192.168.1.19,1031;Initial Catalog=SmartHMS;Persist Security Info=True;User ID=max;Password=0935328285n";
                using (SqlConnection connection_a1 = new SqlConnection(connectionString))
                {
                    connection_a1.Open();
                    String sql = "SELECT * FROM ZAP_DA_THISDAY_CHECKIN WHERE ROOM_NO = 'A1'";
                    using (SqlCommand command = new SqlCommand(sql, connection_a1))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                            if (!reader.HasRows)
                            {
                                ClientInfo_a1 clientInfo_a1 = new ClientInfo_a1();
                                clientInfo_a1.RSV_NAME1 = "บ้านว่าง";
                                // clientInfo_a1.ROOM_NO = "บ้านว่าง";
                                listClients_a1.Add(clientInfo_a1);
                            }
                            else
                            {

                                {
                                    while (reader.Read())
                                    {
                                        ClientInfo_a1 clientInfo_a1 = new ClientInfo_a1();
                                        clientInfo_a1.RECORD_ID = "" + reader.GetInt32(0);
                                        clientInfo_a1.RSV_NAME1 = reader.GetString(2);
                                        clientInfo_a1.ROOM_NO = reader.GetString(6);
                                        clientInfo_a1.NINGHT = "" + reader.GetInt32(12);
                                        clientInfo_a1.CHECK_IN = "" + reader.GetDateTime(4);
                                        clientInfo_a1.PEOPLE = "" + reader.GetInt32(7);


                                        listClients_a1.Add(clientInfo_a1);

                                    }
                                    connection_a1.Close();
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
        public void OnPost()
        {
            clientInfo.set1 = Request.Form["set1"];
        }



    }


    public class ClientInfo_a1
    {
        public String RECORD_ID;
        public String RSV_NAME1;
        public String ROOM_NO;
        public String NINGHT;
        public String CHECK_IN;
        public String PEOPLE;



    }



}

