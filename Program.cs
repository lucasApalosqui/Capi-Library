using CapiLibrary;
using Microsoft.Data.SqlClient;

const string CONNECTION_STRING = "Server=DESKTOP-BVKU5HC;Database=CapiLibrary;Trusted_Connection=True;TrustServerCertificate=True";
Database.Connection = new SqlConnection(CONNECTION_STRING);
Database.Connection.Open();


Database.Connection.Close();

