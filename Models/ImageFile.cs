using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace AutoLookBackend.Models
{
    public class ImageFile
    {
        #region Variables
        Conexion conexionM = new Conexion();
        #endregion

        public ImageFile()
        {
        }

        public string Path
        {
            get;
            set;
        }

        public Byte[] Image
        {
            get;
            set;
        }

        public string SaveImageFile(Byte[] NewImage, int vehicleID)
        {
            try
            {
                List<ParameterSchema> lstParams = new List<ParameterSchema>();
                string query = string.Empty;

                lstParams.Add(new ParameterSchema("Picture", NewImage));
                lstParams.Add(new ParameterSchema("Vehicles_id", vehicleID));

                query = "INSERT INTO Pictures (Picture,Vehicles_id) " +
                    "values(@Picture,@Vehicles_id)";

                return conexionM.setExecuteQuery(query, lstParams);
            }
            catch (Exception ex)
            {
                //throw ex;
                return ex.Message;
            }
        }

        public string SaveRImageFile(Byte[] NewImage, int vehicleID)
        {
            try
            {
                List<ParameterSchema> lstParams = new List<ParameterSchema>();
                string query = string.Empty;

                lstParams.Add(new ParameterSchema("Picture", NewImage));
                lstParams.Add(new ParameterSchema("Received_id", vehicleID));

                query = "INSERT INTO Pictures (Picture,Received_id) " +
                    "values(@Picture,@Received_id)";

                return conexionM.setExecuteQuery(query, lstParams);
            }
            catch (Exception ex)
            {
                //throw ex;
                return ex.Message;
            }
        }

        public ObservableCollection<ImageFile> GetImageFile(int vehicleID)
        {

            ObservableCollection<ImageFile> lstPictures = new ObservableCollection<ImageFile>();

            try
            {
                string query = "Select * from Pictures where Vehicles_id='" + vehicleID + "'";

                MySqlDataReader reader = conexionM.getExecuteQuery(query);
                
                while (reader.Read())
                {
                    lstPictures.Add(new ImageFile {Image= (Byte[])reader["Picture"]});
                }
                
                return lstPictures;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ObservableCollection<ImageFile> GetRImageFile(int vehicleID)
        {

            ObservableCollection<ImageFile> lstPictures = new ObservableCollection<ImageFile>();

            try
            {
                string query = "Select * from Pictures where Received_id='" + vehicleID + "'";

                MySqlDataReader reader = conexionM.getExecuteQuery(query);

                while (reader.Read())
                {
                    lstPictures.Add(new ImageFile { Image = (Byte[])reader["Picture"] });
                }

                return lstPictures;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
