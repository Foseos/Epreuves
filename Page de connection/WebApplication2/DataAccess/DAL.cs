using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;

namespace WebApplication2.DataAccess
{
	public class DAL
	{
		static SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyMvcDbConnectionString"].ToString());

		public static bool Utilisateur_Valide(string username, string mot_de_passe)
		{
			bool authentifier = false;

			string query = string.Format("SELECT * FROM [User] WHERE Utilisateur = '{0}' And Mot_de_Passe = '{1}'", username, mot_de_passe);

			SqlCommand cmd = new SqlCommand(query, connection);
			connection.Open();
			SqlDataReader sdr = cmd.ExecuteReader();
			authentifier = sdr.HasRows;
			connection.Close();

			return authentifier;
		}
	}
}