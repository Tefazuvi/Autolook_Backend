using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System.Linq;
using System.Collections.ObjectModel;

namespace AutoLookBackend.Models
{
    public class ReceiveModel: LoginModel
    {
        #region Variables
        Conexion conexionM = new Conexion();
        #endregion

        public ReceiveModel()
        {
        }

        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public int Miles { get; set; }
        public string Damage { get; set; }

        public ObservableCollection<ImageFile> lstImagenes { get; set; }
      
        public string SaveCar(ReceiveModel car, int userid)
        {
            try
            {
                List<ParameterSchema> lstParams = new List<ParameterSchema>();
                string query = string.Empty;

                lstParams.Add(new ParameterSchema("Brand", car.Brand));
                lstParams.Add(new ParameterSchema("Model", car.Model));
                lstParams.Add(new ParameterSchema("Year", car.Year));
                lstParams.Add(new ParameterSchema("Miles", car.Miles));
                lstParams.Add(new ParameterSchema("Damage", car.Damage));
                lstParams.Add(new ParameterSchema("User_id", userid));


                query = "INSERT INTO received (Brand,Model,Year,Miles,Damage,User_id) " +
                    "values(@Brand,@Model,@Year,@Miles,@Damage,@User_id)";
                string ans = conexionM.setExecuteQuery(query, lstParams);

                if (lstImagenes != null && lstImagenes.Count > 0)
                {
                    foreach (var Image in lstImagenes)
                    {
                        Image.SaveRImageFile(Image.Image, Int32.Parse(ans));
                    }
                }

                return ans;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string GetCars()
        {
            string query = "SELECT * FROM received INNER JOIN user ON received.User_id = user.id;";

            List<ReceiveModel> lstVehiculos = new List<ReceiveModel>();

            MySqlDataReader reader = conexionM.getExecuteQuery(query);

            while (reader.Read())
            {
                ReceiveModel car = new ReceiveModel();

                car.Id = Int32.Parse(reader["id"].ToString());
                car.Brand = reader["Brand"].ToString();
                car.Model = reader["Model"].ToString();
                car.Year = Int32.Parse(reader["Year"].ToString());
                car.Miles = Int32.Parse(reader["Miles"].ToString());
                car.Damage = reader["Damage"].ToString();
                car.Name = reader["Name"].ToString();
                car.LastName = reader["LastName"].ToString();
                car.Phone = reader["Phone"].ToString();
                car.Email = reader["Email"].ToString();

                ImageFile image = new ImageFile();
                car.lstImagenes = image.GetRImageFile(car.Id);

                lstVehiculos.Add(car);
            }

            var json = JsonConvert.SerializeObject(lstVehiculos);

            return json;
        }
    }
}
