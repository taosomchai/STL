using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using System.IO;

namespace RocketS11B
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void btnRefresh_Click(object sender, EventArgs e)
        {
            btnRefresh.Enabled = false;
            try
            {
                laser_sql.connectString = "Data source="+laser_sql.dbServerName  + "\\SQLEXPRESS;Initial Catalog=TechWeb;User Id=sa;Password=s@;MultipleActiveResultSets=True";
                laser_sql.cnn = new SqlConnection(laser_sql.connectString);
                laser_sql.cnn.Open();

                SqlCommand command;
                SqlDataReader dataReader;
                string StrSql;

                //update cobIR
                StrSql = "SELECT * FROM Products";
                command = new SqlCommand(StrSql, laser_sql.cnn);
                dataReader = command.ExecuteReader();
                cobIR.Items.Clear();
                while (dataReader.Read()) {
                    cobIR.Items.Add(dataReader.GetValue(2));
                    //laser_sql.ProductsInit((IDataRecord)dataReader);
                }
                dataReader.Close();
                command.Dispose();
                laser_sql.cnn.Close();



            }
            catch (Exception err)
            {
                MessageBox.Show("btnRefresh_click: " + err.Message);
            }
            btnRefresh.Enabled = true;
        }

        private void cobIR_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idLaser = 0;
            laser_sql.cnn = new SqlConnection(laser_sql.connectString);
            laser_sql.cnn.Open();

            SqlCommand command;
            SqlDataReader dataReader;
            string StrSql;

            StrSql = "SELECT * FROM [Products] WHERE [Products].name ='" + cobIR.Text + "'";
            command = new SqlCommand(StrSql, laser_sql.cnn);
            dataReader = command.ExecuteReader();

            if(dataReader.Read())
            {
                txtDescription.Text = dataReader["designation"].ToString();
                txtSensitivity.Text = dataReader["sensitivity"].ToString();
                txtRating.Text = dataReader["rating"].ToString();
                txtPoleNum.Text = dataReader["poleCount"].ToString();
                txtId.Text = dataReader["id"].ToString();
                txtIdLaser.Text = dataReader["idLaser"].ToString();
                idLaser = int.Parse(dataReader["idLaser"].ToString());
                txtIdVision.Text = dataReader["idVision"].ToString();
            }
            dataReader.Close();
            command.Dispose();

            StrSql = "SELECT * FROM [LaserMarking] WHERE [LaserMarking].id ='" + idLaser + "'";
            command = new SqlCommand(StrSql, laser_sql.cnn);
            dataReader = command.ExecuteReader();
            if(dataReader.Read())
            {
                txtLaserMark.Text = dataReader["name"].ToString();
                txtLaserDescription.Text = dataReader["description"].ToString();
            }
            dataReader.Close();
            command.Dispose();

            if (idLaser>0)
            {
                StrSql = "SELECT * FROM [LaserElements] WHERE [LaserElements].idLaser ='" + idLaser + "'";
                command = new SqlCommand(StrSql, laser_sql.cnn);
                dataReader = command.ExecuteReader();
                listBox1.Items.Clear();
                //clear txtType
                txtType1.Text = "";
                txtType2.Text = "";
                txtType3.Text = "";
                txtType4.Text = "";
                txtType5.Text = "";
                txtType6.Text = "";
                txtType7.Text = "";
                txtType8.Text = "";
                txtType9.Text = "";
                txtType10.Text = "";
                txtType11.Text = "";
                txtType12.Text = "";
                txtType13.Text = "";
                txtType14.Text = "";
                txtType15.Text = "";
                txtProductValue1.Text = "";
                txtProductValue2.Text = "";
                txtProductValue3.Text = "";
                txtProductValue4.Text = "";
                txtProductValue5.Text = "";
                txtProductValue6.Text = "";
                txtProductValue7.Text = "";
                txtProductValue8.Text = "";
                txtProductValue9.Text = "";
                txtProductValue10.Text = "";
                txtProductValue11.Text = "";
                txtProductValue12.Text = "";
                txtProductValue13.Text = "";
                txtProductValue14.Text = "";
                txtProductValue15.Text = "";

                while (dataReader.Read())
                {
                    //listBox1.Items.Add(dataReader["data"].ToString());
                    string data = dataReader["data"].ToString();
                    string strType = "";
                    string strValue = "";
                    if (GetLaserIdValue(data, "idLaser")=="4")
                    {
                        string idField = GetLaserIdValue(data, "idField");
                        if (GetLaserLocalName(data) == "TEXT")
                        {
                            strType = "TEXT";
                            strValue = GetLaserIdValue(data, "text");
                        }
                        else if (GetLaserLocalName(data) == "LOGO")
                        {
                            strType = "LOGO";
                            strValue = GetLaserIdValue(data, "logoFilename");
                        }
                        else if (GetLaserLocalName(data) == "BARCD")
                        {
                            strType = "BARCD";
                            strValue = GetLaserIdValue(data, "barcodeValue");
                        }

                        //listBox1.Items.Add(idField + ":"+strType+"="+strValue);
                        switch  (idField)
                        {
                            case "401":
                                txtType1.Text = strType;
                                txtProductValue1.Text = strValue;
                                break;
                            case "414":
                                txtType2.Text = strType;
                                txtProductValue2.Text = strValue;
                                break;
                            case "403":
                                txtType3.Text = strType;
                                txtProductValue3.Text = strValue;
                                break;
                            case "404":
                                txtType4.Text = strType;
                                txtProductValue4.Text = strValue;
                                break;
                            case "405":
                                txtType5.Text = strType;
                                txtProductValue5.Text = strValue;
                                break;
                            case "406":
                                txtType6.Text = strType;
                                txtProductValue6.Text = strValue;
                                break;
                            case "413":
                                txtType7.Text = strType;
                                txtProductValue7.Text = strValue;
                                break;
                            case "407":
                                txtType8.Text = strType;
                                txtProductValue8.Text = strValue;
                                break;
                            case "415":
                                txtType9.Text = strType;
                                txtProductValue9.Text = strValue;
                                break;
                            case "409":
                                txtType10.Text = strType;
                                txtProductValue10.Text = strValue;
                                break;
                            case "411":
                                txtType11.Text = strType;
                                txtProductValue11.Text = strValue;
                                break;
                            case "416":
                                txtType12.Text = strType;
                                txtProductValue12.Text = strValue;
                                break;
                            case "412":
                                txtType13.Text = strType;
                                txtProductValue13.Text = strValue;
                                break;
                            case "408":
                                txtType14.Text = strType;
                                txtProductValue14.Text = strValue;
                                break;
                            case "417":
                                txtType15.Text = strType;
                                txtProductValue15.Text = strValue;
                                break;
                        }
                    } 
                }
                dataReader.Close();
                command.Dispose();

                //S112_DB
                laser_sql.S11_connectString = "Data source=" + laser_sql.dbServerName + "\\SQLEXPRESS;Initial Catalog=S112_BDD;User Id=sa;Password=s@;MultipleActiveResultSets=True";
                using (var connection = new SqlConnection(laser_sql.S11_connectString))
                {
                    connection.Open();
                    //read [S112_BDD].[dbo].LaserMarking
                    string strCommand = "SELECT * FROM LaserMarking WHERE id=@id";
                    using (var cmdProducts = new SqlCommand(strCommand, connection))
                    {
                        cmdProducts.Parameters.AddWithValue("@id", idLaser);
                        var s11_products = cmdProducts.ExecuteReader();
                        if (s11_products.Read())
                        {
                            chkEnable.Checked = int.Parse(s11_products["S112_Enable"].ToString()) > 0;
                            txtLaserProNo.Text = s11_products["S112_LaserProNo"].ToString();
                            txtLaserFileName.Text = s11_products["S112_LaserFileName"].ToString();

                            chkField401.Checked = int.Parse(s11_products["S112_Field401"].ToString()) > 0;
                            chkField414.Checked = int.Parse(s11_products["S112_Field414"].ToString()) > 0;
                            chkField403.Checked = int.Parse(s11_products["S112_Field403"].ToString()) > 0;
                            chkField404.Checked = int.Parse(s11_products["S112_Field404"].ToString()) > 0;
                            chkField405.Checked = int.Parse(s11_products["S112_Field405"].ToString()) > 0;
                            chkField406.Checked = int.Parse(s11_products["S112_Field406"].ToString()) > 0;
                            chkField413.Checked = int.Parse(s11_products["S112_Field413"].ToString()) > 0;
                            chkField407.Checked = int.Parse(s11_products["S112_Field407"].ToString()) > 0;
                            chkField415.Checked = int.Parse(s11_products["S112_Field415"].ToString()) > 0;
                            chkField409.Checked = int.Parse(s11_products["S112_Field409"].ToString()) > 0;
                            chkField411.Checked = int.Parse(s11_products["S112_Field411"].ToString()) > 0;
                            chkField416.Checked = int.Parse(s11_products["S112_Field416"].ToString()) > 0;
                            chkField412.Checked = int.Parse(s11_products["S112_Field412"].ToString()) > 0;
                            chkField408.Checked = int.Parse(s11_products["S112_Field408"].ToString()) > 0;
                            chkField417.Checked = int.Parse(s11_products["S112_Field417"].ToString()) > 0;
                        }
                        else
                        {
                            //create new
                            string query = "INSERT INTO LaserMarking(id,name,description," +
                                                                "S112_Enable,S112_Field401,S112_Field414,S112_Field403,S112_Field404,S112_Field405,S112_Field406,S112_Field407,S112_Field408,S112_Field409," +
                                                                "S112_Field411,S112_Field412,S112_Field413,S112_Field415,S112_Field416,S112_Field417,S112_LaserProNo,S112_LaserFileName) " +
                                           "VALUES(@id,@name,@description," +
                                                                "@S112_Enable,@S112_Field401,@S112_Field414,@S112_Field403,@S112_Field404,@S112_Field405,@S112_Field406,@S112_Field407,@S112_Field408,@S112_Field409," +
                                                                "@S112_Field411,@S112_Field412,@S112_Field413,@S112_Field415,@S112_Field416,@S112_Field417,@S112_LaserProNo,@S112_LaserFileName)";
                            using (var cmdAddProductToS112 = new SqlCommand(query, connection))
                            {
                                cmdAddProductToS112.Parameters.AddWithValue("@id", idLaser);
                                cmdAddProductToS112.Parameters.AddWithValue("@name", txtLaserMark.Text);
                                cmdAddProductToS112.Parameters.AddWithValue("@description", txtLaserDescription.Text);
                                cmdAddProductToS112.Parameters.AddWithValue("@S112_Enable", 0);
                                cmdAddProductToS112.Parameters.AddWithValue("@S112_Field401", 0);
                                cmdAddProductToS112.Parameters.AddWithValue("@S112_Field414", 0);
                                cmdAddProductToS112.Parameters.AddWithValue("@S112_Field403", 0);
                                cmdAddProductToS112.Parameters.AddWithValue("@S112_Field404", 0);
                                cmdAddProductToS112.Parameters.AddWithValue("@S112_Field405", 0);
                                cmdAddProductToS112.Parameters.AddWithValue("@S112_Field406", 0);
                                cmdAddProductToS112.Parameters.AddWithValue("@S112_Field407", 0);
                                cmdAddProductToS112.Parameters.AddWithValue("@S112_Field408", 0);
                                cmdAddProductToS112.Parameters.AddWithValue("@S112_Field409", 0);
                                cmdAddProductToS112.Parameters.AddWithValue("@S112_Field411", 0);
                                cmdAddProductToS112.Parameters.AddWithValue("@S112_Field412", 0);
                                cmdAddProductToS112.Parameters.AddWithValue("@S112_Field413", 0);
                                cmdAddProductToS112.Parameters.AddWithValue("@S112_Field415", 0);
                                cmdAddProductToS112.Parameters.AddWithValue("@S112_Field416", 0);
                                cmdAddProductToS112.Parameters.AddWithValue("@S112_Field417", 0);
                                cmdAddProductToS112.Parameters.AddWithValue("@S112_LaserProNo", 0);
                                cmdAddProductToS112.Parameters.AddWithValue("@S112_LaserFileName", "");

                                var rowsAffected = cmdAddProductToS112.ExecuteNonQuery();
                            }
                        }
                     }
                    //


                    string script = "SELECT * FROM[S112_BDD].[dbo].LaserElements WHERE idLaser=@idLaser";
        
                    using (var cmdLaserElements = new SqlCommand(script, connection))
                    {
                        cmdLaserElements.Parameters.AddWithValue("@idLaser", idLaser);
                        var s11_LaserElement = cmdLaserElements.ExecuteReader();
                        //clear txtField;
                        txtField401.Text = "";
                        txtField401.BackColor = chkField401.Checked && chkEnable.Checked ? Color.Yellow : Color.White;
                        txtField414.Text = "";
                        txtField414.BackColor = chkField414.Checked && chkEnable.Checked ? Color.Yellow : Color.White;
                        txtField403.Text = "";
                        txtField403.BackColor = chkField403.Checked && chkEnable.Checked ? Color.Yellow : Color.White;
                        txtField404.Text = "";
                        txtField404.BackColor = chkField404.Checked && chkEnable.Checked ? Color.Yellow : Color.White;
                        txtField405.Text = "";
                        txtField405.BackColor = chkField405.Checked && chkEnable.Checked ? Color.Yellow : Color.White;
                        txtField406.Text = "";
                        txtField406.BackColor = chkField406.Checked && chkEnable.Checked ? Color.Yellow : Color.White;
                        txtField407.Text = "";
                        txtField407.BackColor = chkField407.Checked && chkEnable.Checked ? Color.Yellow : Color.White;
                        txtField408.Text = "";
                        txtField408.BackColor = chkField408.Checked && chkEnable.Checked ? Color.Yellow : Color.White;
                        txtField409.Text = "";
                        txtField409.BackColor = chkField409.Checked && chkEnable.Checked ? Color.Yellow : Color.White;
                        txtField411.Text = "";
                        txtField411.BackColor = chkField411.Checked && chkEnable.Checked ? Color.Yellow : Color.White;
                        txtField412.Text = "";
                        txtField412.BackColor = chkField412.Checked && chkEnable.Checked ? Color.Yellow : Color.White;
                        txtField413.Text = "";
                        txtField413.BackColor = chkField413.Checked && chkEnable.Checked ? Color.Yellow : Color.White;
                        txtField415.Text = "";
                        txtField415.BackColor = chkField415.Checked && chkEnable.Checked ? Color.Yellow : Color.White;
                        txtField416.Text = "";
                        txtField416.BackColor = chkField416.Checked && chkEnable.Checked ? Color.Yellow : Color.White;
                        txtField417.Text = "";
                        txtField417.BackColor = chkField417.Checked && chkEnable.Checked ? Color.Yellow : Color.White;

                        txtType1.BackColor = txtProductValue1.BackColor = txtProductValue1.Text=="" && chkField401.Checked && chkEnable.Checked ? Color.Yellow : Color.White;
                        txtType2.BackColor = txtProductValue2.BackColor = txtProductValue2.Text == "" && chkField414.Checked && chkEnable.Checked ? Color.Yellow : Color.White;
                        txtType3.BackColor = txtProductValue3.BackColor = txtProductValue3.Text == "" && chkField403.Checked && chkEnable.Checked ? Color.Yellow : Color.White;
                        txtType4.BackColor = txtProductValue4.BackColor = txtProductValue4.Text == "" && chkField404.Checked && chkEnable.Checked ? Color.Yellow : Color.White;
                        txtType5.BackColor = txtProductValue5.BackColor = txtProductValue5.Text == "" && chkField405.Checked && chkEnable.Checked ? Color.Yellow : Color.White;
                        txtType6.BackColor = txtProductValue6.BackColor = txtProductValue6.Text == "" && chkField406.Checked && chkEnable.Checked ? Color.Yellow : Color.White;
                        txtType7.BackColor = txtProductValue7.BackColor = txtProductValue7.Text == "" && chkField413.Checked && chkEnable.Checked ? Color.Yellow : Color.White;
                        txtType8.BackColor = txtProductValue8.BackColor = txtProductValue8.Text == "" && chkField407.Checked && chkEnable.Checked ? Color.Yellow : Color.White;
                        txtType9.BackColor = txtProductValue9.BackColor = txtProductValue9.Text == "" && chkField415.Checked && chkEnable.Checked ? Color.Yellow : Color.White;
                        txtType10.BackColor = txtProductValue10.BackColor = txtProductValue10.Text == "" && chkField409.Checked && chkEnable.Checked ? Color.Yellow : Color.White;
                        txtType11.BackColor = txtProductValue11.BackColor = txtProductValue11.Text == "" && chkField411.Checked && chkEnable.Checked ? Color.Yellow : Color.White;
                        txtType12.BackColor = txtProductValue12.BackColor = txtProductValue12.Text == "" && chkField416.Checked && chkEnable.Checked ? Color.Yellow : Color.White;
                        txtType13.BackColor = txtProductValue13.BackColor = txtProductValue13.Text == "" && chkField412.Checked && chkEnable.Checked ? Color.Yellow : Color.White;
                        txtType14.BackColor = txtProductValue14.BackColor = txtProductValue14.Text == "" && chkField408.Checked && chkEnable.Checked ? Color.Yellow : Color.White;
                        txtType15.BackColor = txtProductValue15.BackColor = txtProductValue15.Text == "" && chkField417.Checked && chkEnable.Checked ? Color.Yellow : Color.White;

                        while (s11_LaserElement.Read())
                        {
                            string strId = s11_LaserElement["id"].ToString();
                            string strIdLaser = s11_LaserElement["idLaser"].ToString();
                            string data = s11_LaserElement["data"].ToString();
                            string strType = "";
                            string strValue = "";
                            if (GetLaserIdValue(data, "idLaser") == "4")
                            {
                                string idField = GetLaserIdValue(data, "idField");

                                if (GetLaserLocalName(data) == "TEXT")
                                {
                                    strType = "TEXT";
                                    strValue = GetLaserIdValue(data, "text");
                                }
                                else if (GetLaserLocalName(data) == "LOGO")
                                {
                                    strType = "LOGO";
                                    strValue = GetLaserIdValue(data, "logoFilename");
                                }
                                else if (GetLaserLocalName(data) == "BARCD")
                                {
                                    strType = "BARCD";
                                    strValue = GetLaserIdValue(data, "barcodeValue");
                                }

                                switch (idField)
                                {
                                    case "401":
                                        txtField401.Text = strId + "," + strIdLaser + "," + data;
                                        break;
                                    case "414":
                                        txtField414.Text = strId + "," + strIdLaser + "," + data;
                                        break;
                                    case "403":
                                        txtField403.Text = strId + "," + strIdLaser + "," + data;
                                        break;
                                    case "404":
                                        txtField404.Text = strId + "," + strIdLaser + "," + data;
                                        break;
                                    case "405":
                                        txtField405.Text = strId + "," + strIdLaser + "," + data;
                                        break;
                                    case "406":
                                        txtField406.Text = strId + "," + strIdLaser + "," + data;
                                        break;
                                    case "413":
                                        txtField413.Text = strId + "," + strIdLaser + "," + data;
                                        break;
                                    case "407":
                                        txtField407.Text = strId + "," + strIdLaser + "," + data;
                                        break;
                                    case "415":
                                        txtField415.Text = strId + "," + strIdLaser + "," + data;
                                        break;
                                    case "409":
                                        txtField409.Text = strId + "," + strIdLaser + "," + data;
                                        break;
                                    case "411":
                                        txtField411.Text = strId + "," + strIdLaser + "," + data;
                                        break;
                                    case "416":
                                        txtField416.Text = strId + "," + strIdLaser + "," + data;
                                        break;
                                    case "412":
                                        txtField412.Text = strId + "," + strIdLaser + "," + data;
                                        break;
                                    case "408":
                                        txtField408.Text = strId + "," + strIdLaser + "," + data;
                                        break;
                                    case "417":
                                        txtField417.Text = strId + "," + strIdLaser + "," + data;
                                        break;
                                }
                            }
                        }

                    }

                }
            }

            laser_sql.cnn.Close();
        }

        public string GetLaserIdValue(string data, string idKey)
        {
            try
            {
                XElement elementXML = XElement.Parse(data);
                return elementXML.Attribute(idKey).Value;
            }
            catch
            {
                return "";
            }
        }
        public string GetLaserLocalName(string data)
        {
            try
            {
                XElement elementXML = XElement.Parse(data);
                return elementXML.Name.LocalName.ToUpper();
            }
            catch
            {
                return "";
            }
        }

        //  string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        //  string sql = "SELECT * FROM Customers";
        //  DataTable dt = this.GetData(sql, constr);
        private DataTable GetDataTable(string SqlStr, string conStr)
        {
            DataTable dt = new DataTable();
            using(SqlConnection conn = new SqlConnection(conStr))
            {
                using(SqlCommand cmd = new SqlCommand(SqlStr))
                {
                    cmd.Connection = conn;
                    using(SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        sda.Fill(dt);
                    }
                }
            }

            return dt;
        }


        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            //txtData.Text = listBox1.Text;
            //string input = listBox1.Text;
            /*
            string[] output = Regex.Split(input,"(?=<)|(?<=/>)");
            listBox2.Items.Clear();
            //string[] output = input.Split(' ');
            for(int i=0;i<output.Length;i++)
            {
                listBox2.Items.Add(output[i]);
            }
            */
            //Regex.Split(input, @"(?<=')\s*,\s*");
            /*
            Dictionary<string, string> results = new Dictionary<string, string>();
            foreach (string kvp in input.Split(' '))
            //foreach (string kvp in Regex.Split(input, @"(?<=')\s*,\s*"))
            {
                if (kvp.Contains('<'))
                    results.Add("type", kvp.Substring(1));
                if(kvp.Contains('='))
                    results.Add(kvp.Split('=')[0], kvp.Split('=')[1]);
            }
            listBox2.Items.Clear();
            for(int i=0;i<results.Count;i++)
            {
                listBox2.Items.Add(results.ElementAt(i));
            }
            */
            /*
            XElement elementXML = XElement.Parse(input);
            string strValue = "";
            if(elementXML.Name.LocalName.ToUpper()=="TEXT") {
                strValue = elementXML.Attribute("text").Value;
            }else if(elementXML.Name.LocalName.ToUpper()=="LOGO")
            {
                strValue = elementXML.Attribute("logoFilename").Value;
            }
            else if (elementXML.Name.LocalName.ToUpper() == "BARCD")
            {
                strValue = elementXML.Attribute("barcodeValue").Value;
            }
            */
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            btnUpdate.Enabled = false;

            //S112_DB
             laser_sql.S11_connectString = "Data source=" + laser_sql.dbServerName + "\\SQLEXPRESS;Initial Catalog=S112_BDD;User Id=sa;Password=s@;MultipleActiveResultSets=True";
            using (var connection = new SqlConnection(laser_sql.S11_connectString))
            {
                connection.Open();
                string strCommand = "UPDATE LaserMarking SET S112_Enable=@Enable, S112_Field401=@Field401, S112_Field414=@Field414, S112_Field403=@Field403, S112_Field404=@Field404, " + 
                                                    "S112_Field405=@Field405, S112_Field406=@field406, S112_Field407=@Field407, S112_Field408=@Field408, S112_Field409=@Field409, " +
                                                    "S112_Field411=@Field411, S112_Field412=@Field412, S112_Field413=@Field413, S112_Field415=@Field415, S112_Field416=@Field416, " +
                                                    "S112_Field417=@Field417, S112_LaserProNo=@LaserProNo, S112_LaserFileName=@LaserFileName " +
                                    "WHERE id=@id";
                using (var cmdProducts = new SqlCommand(strCommand, connection))
                {
                    cmdProducts.Parameters.AddWithValue("@Enable", chkEnable.Checked ? 1 : 0 );

                    cmdProducts.Parameters.AddWithValue("@Field401", chkField401.Checked ? 1 : 0);
                    cmdProducts.Parameters.AddWithValue("@Field414", chkField414.Checked ? 1 : 0);
                    cmdProducts.Parameters.AddWithValue("@Field403", chkField403.Checked ? 1 : 0);
                    cmdProducts.Parameters.AddWithValue("@Field404", chkField404.Checked ? 1 : 0);
                    cmdProducts.Parameters.AddWithValue("@Field405", chkField405.Checked ? 1 : 0);
                    cmdProducts.Parameters.AddWithValue("@Field406", chkField406.Checked ? 1 : 0);
                    cmdProducts.Parameters.AddWithValue("@Field407", chkField407.Checked ? 1 : 0);
                    cmdProducts.Parameters.AddWithValue("@Field408", chkField408.Checked ? 1 : 0);
                    cmdProducts.Parameters.AddWithValue("@Field409", chkField409.Checked ? 1 : 0);
                    cmdProducts.Parameters.AddWithValue("@Field411", chkField411.Checked ? 1 : 0);
                    cmdProducts.Parameters.AddWithValue("@Field412", chkField412.Checked ? 1 : 0);
                    cmdProducts.Parameters.AddWithValue("@Field413", chkField413.Checked ? 1 : 0);
                    cmdProducts.Parameters.AddWithValue("@Field415", chkField415.Checked ? 1 : 0);
                    cmdProducts.Parameters.AddWithValue("@Field416", chkField416.Checked ? 1 : 0);
                    cmdProducts.Parameters.AddWithValue("@Field417", chkField417.Checked ? 1 : 0);

                    cmdProducts.Parameters.AddWithValue("@LaserProNo", txtLaserProNo.Text);
                    cmdProducts.Parameters.AddWithValue("@LaserFileName", txtLaserFileName.Text);

                    cmdProducts.Parameters.AddWithValue("@id", txtIdLaser.Text);

                    cmdProducts.ExecuteNonQuery();
                }
            }

            //
            if(chkEnable.Checked)
            {
                //copy onely select idField from [TechWeb].[LaserElements] to [S112_BDD].[LaserElements]
                using (var connection = new SqlConnection(laser_sql.connectString))
                {
                    connection.Open();
                    string script = "DELETE [TechWeb].[dbo].LaserElements WHERE id=@id";

                    if (chkField401.Checked && txtField401.Text != "")    //Field401
                    {
                        using (var cmdTechWebLaserElements = new SqlCommand(script, connection))
                        {
                            cmdTechWebLaserElements.Parameters.AddWithValue("@id", txtField401.Text.Split(',')[0]);
                            cmdTechWebLaserElements.ExecuteNonQuery();
                        }
                    }
                    if (chkField414.Checked && txtField414.Text != "")    //Field414
                    {
                        using (var cmdTechWebLaserElements = new SqlCommand(script, connection))
                        {
                            cmdTechWebLaserElements.Parameters.AddWithValue("@id", txtField414.Text.Split(',')[0]);
                            cmdTechWebLaserElements.ExecuteNonQuery();
                        }
                    }
                    if (chkField403.Checked && txtField403.Text != "")    //Field403
                    {
                        using (var cmdTechWebLaserElements = new SqlCommand(script, connection))
                        {
                            cmdTechWebLaserElements.Parameters.AddWithValue("@id", txtField403.Text.Split(',')[0]);
                            cmdTechWebLaserElements.ExecuteNonQuery();
                        }
                    }
                    if (chkField404.Checked && txtField404.Text != "")    //Field404
                    {
                        using (var cmdTechWebLaserElements = new SqlCommand(script, connection))
                        {
                            cmdTechWebLaserElements.Parameters.AddWithValue("@id", txtField404.Text.Split(',')[0]);
                            cmdTechWebLaserElements.ExecuteNonQuery();
                        }
                    }
                    if (chkField405.Checked && txtField405.Text != "")    //Field405
                    {
                        using (var cmdTechWebLaserElements = new SqlCommand(script, connection))
                        {
                            cmdTechWebLaserElements.Parameters.AddWithValue("@id", txtField405.Text.Split(',')[0]);
                            cmdTechWebLaserElements.ExecuteNonQuery();
                        }
                    }
                    if (chkField406.Checked && txtField406.Text != "")    //Field406
                    {
                        using (var cmdTechWebLaserElements = new SqlCommand(script, connection))
                        {
                            cmdTechWebLaserElements.Parameters.AddWithValue("@id", txtField406.Text.Split(',')[0]);
                            cmdTechWebLaserElements.ExecuteNonQuery();
                        }
                    }
                    if (chkField413.Checked && txtField413.Text != "")    //Field413
                    {
                        using (var cmdTechWebLaserElements = new SqlCommand(script, connection))
                        {
                            cmdTechWebLaserElements.Parameters.AddWithValue("@id", txtField413.Text.Split(',')[0]);
                            cmdTechWebLaserElements.ExecuteNonQuery();
                        }
                    }
                    if (chkField407.Checked && txtField407.Text != "")    //Field407
                    {
                        using (var cmdTechWebLaserElements = new SqlCommand(script, connection))
                        {
                            cmdTechWebLaserElements.Parameters.AddWithValue("@id", txtField407.Text.Split(',')[0]);
                            cmdTechWebLaserElements.ExecuteNonQuery();
                        }
                    }
                    if (chkField415.Checked && txtField415.Text != "")    //Field415
                    {
                        using (var cmdTechWebLaserElements = new SqlCommand(script, connection))
                        {
                            cmdTechWebLaserElements.Parameters.AddWithValue("@id", txtField415.Text.Split(',')[0]);
                            cmdTechWebLaserElements.ExecuteNonQuery();
                        }
                    }
                    if (chkField409.Checked && txtField409.Text != "")    //Field409
                    {
                        using (var cmdTechWebLaserElements = new SqlCommand(script, connection))
                        {
                            cmdTechWebLaserElements.Parameters.AddWithValue("@id", txtField409.Text.Split(',')[0]);
                            cmdTechWebLaserElements.ExecuteNonQuery();
                        }
                    }
                    if (chkField411.Checked && txtField411.Text != "")    //Field411
                    {
                        using (var cmdTechWebLaserElements = new SqlCommand(script, connection))
                        {
                            cmdTechWebLaserElements.Parameters.AddWithValue("@id", txtField411.Text.Split(',')[0]);
                            cmdTechWebLaserElements.ExecuteNonQuery();
                        }
                    }
                    if (chkField416.Checked && txtField416.Text != "")    //Field416
                    {
                        using (var cmdTechWebLaserElements = new SqlCommand(script, connection))
                        {
                            cmdTechWebLaserElements.Parameters.AddWithValue("@id", txtField416.Text.Split(',')[0]);
                            cmdTechWebLaserElements.ExecuteNonQuery();
                        }
                    }
                    if (chkField412.Checked && txtField412.Text != "")    //Field412
                    {
                        using (var cmdTechWebLaserElements = new SqlCommand(script, connection))
                        {
                            cmdTechWebLaserElements.Parameters.AddWithValue("@id", txtField412.Text.Split(',')[0]);
                            cmdTechWebLaserElements.ExecuteNonQuery();
                        }
                    }
                    if (chkField408.Checked && txtField408.Text != "")    //Field408
                    {
                        using (var cmdTechWebLaserElements = new SqlCommand(script, connection))
                        {
                            cmdTechWebLaserElements.Parameters.AddWithValue("@id", txtField408.Text.Split(',')[0]);
                            cmdTechWebLaserElements.ExecuteNonQuery();
                        }
                    }
                    if (chkField417.Checked && txtField417.Text != "")    //Field417
                    {
                        using (var cmdTechWebLaserElements = new SqlCommand(script, connection))
                        {
                            cmdTechWebLaserElements.Parameters.AddWithValue("@id", txtField417.Text.Split(',')[0]);
                            cmdTechWebLaserElements.ExecuteNonQuery();
                        }
                    }
                }
            }
            else
            {
                //copy all [S112_BDD].[LaserElements] to [TechWeb].[LaserElements] WHERE idLaser=???
                string script_on = "SET IDENTITY_INSERT [TechWeb].[dbo].LaserElements ON";
                string script = "INSERT INTO[TechWeb].[dbo].LaserElements (id,idLaser,data) SELECT id,idLaser,data FROM[S112_BDD].[dbo].[LaserElements] WHERE id=@id";
                string script_off = "SET IDENTITY_INSERT [TechWeb].[dbo].LaserElements OFF";
                string sqlstr = script_on + "\n" + script + "\n" + script_off;
                using (var connection = new SqlConnection(laser_sql.connectString))
                {
                    connection.Open();
                    if(chkField401.Checked && txtField401.Text!="") //Field401
                    {
                        using (var command = new SqlCommand(sqlstr, connection))
                        {
                            command.Parameters.AddWithValue("@id", txtField401.Text.Split(',')[0]);
                            command.ExecuteNonQuery();
                        }
                    }
                    if (chkField414.Checked && txtField414.Text != "") //Field414
                    {
                        using (var command = new SqlCommand(sqlstr, connection))
                        {
                            command.Parameters.AddWithValue("@id", txtField414.Text.Split(',')[0]);
                            command.ExecuteNonQuery();
                        }
                    }
                    if (chkField403.Checked && txtField403.Text != "") //Field403
                    {
                        using (var command = new SqlCommand(sqlstr, connection))
                        {
                            command.Parameters.AddWithValue("@id", txtField403.Text.Split(',')[0]);
                            command.ExecuteNonQuery();
                        }
                    }
                    if (chkField404.Checked && txtField404.Text != "") //Field404
                    {
                        using (var command = new SqlCommand(sqlstr, connection))
                        {
                            command.Parameters.AddWithValue("@id", txtField404.Text.Split(',')[0]);
                            command.ExecuteNonQuery();
                        }
                    }
                    if (chkField405.Checked && txtField405.Text != "") //Field405
                    {
                        using (var command = new SqlCommand(sqlstr, connection))
                        {
                            command.Parameters.AddWithValue("@id", txtField405.Text.Split(',')[0]);
                            command.ExecuteNonQuery();
                        }
                    }
                    if (chkField406.Checked && txtField406.Text != "") //Field406
                    {
                        using (var command = new SqlCommand(sqlstr, connection))
                        {
                            command.Parameters.AddWithValue("@id", txtField406.Text.Split(',')[0]);
                            command.ExecuteNonQuery();
                        }
                    }
                    if (chkField413.Checked && txtField413.Text != "") //Field413
                    {
                        using (var command = new SqlCommand(sqlstr, connection))
                        {
                            command.Parameters.AddWithValue("@id", txtField413.Text.Split(',')[0]);
                            command.ExecuteNonQuery();
                        }
                    }
                    if (chkField407.Checked && txtField407.Text != "") //Field407
                    {
                        using (var command = new SqlCommand(sqlstr, connection))
                        {
                            command.Parameters.AddWithValue("@id", txtField407.Text.Split(',')[0]);
                            command.ExecuteNonQuery();
                        }
                    }
                    if (chkField415.Checked && txtField415.Text != "") //Field415
                    {
                        using (var command = new SqlCommand(sqlstr, connection))
                        {
                            command.Parameters.AddWithValue("@id", txtField415.Text.Split(',')[0]);
                            command.ExecuteNonQuery();
                        }
                    }
                    if (chkField409.Checked && txtField409.Text != "") //Field409
                    {
                        using (var command = new SqlCommand(sqlstr, connection))
                        {
                            command.Parameters.AddWithValue("@id", txtField409.Text.Split(',')[0]);
                            command.ExecuteNonQuery();
                        }
                    }
                    if (chkField411.Checked && txtField411.Text != "") //Field411
                    {
                        using (var command = new SqlCommand(sqlstr, connection))
                        {
                            command.Parameters.AddWithValue("@id", txtField411.Text.Split(',')[0]);
                            command.ExecuteNonQuery();
                        }
                    }
                    if (chkField416.Checked && txtField416.Text != "") //Field416
                    {
                        using (var command = new SqlCommand(sqlstr, connection))
                        {
                            command.Parameters.AddWithValue("@id", txtField416.Text.Split(',')[0]);
                            command.ExecuteNonQuery();
                        }
                    }
                    if (chkField412.Checked && txtField412.Text != "") //Field412
                    {
                        using (var command = new SqlCommand(sqlstr, connection))
                        {
                            command.Parameters.AddWithValue("@id", txtField412.Text.Split(',')[0]);
                            command.ExecuteNonQuery();
                        }
                    }
                    if (chkField408.Checked && txtField408.Text != "") //Field408
                    {
                        using (var command = new SqlCommand(sqlstr, connection))
                        {
                            command.Parameters.AddWithValue("@id", txtField408.Text.Split(',')[0]);
                            command.ExecuteNonQuery();
                        }
                    }
                    if (chkField417.Checked && txtField417.Text != "") //Field417
                    {
                        using (var command = new SqlCommand(sqlstr, connection))
                        {
                            command.Parameters.AddWithValue("@id", txtField417.Text.Split(',')[0]);
                            command.ExecuteNonQuery();
                        }
                    }
                }

            }

            cobIR_SelectedIndexChanged(sender, e);
            cobIR.Focus();

            btnUpdate.Enabled = true;
        }

        private void timer_logout_Tick(object sender, EventArgs e)
        {
            btnCopy.Visible = false;

            chkField401.Enabled = false;
            chkField414.Enabled = false;
            chkField403.Enabled = false;
            chkField404.Enabled = false;
            chkField405.Enabled = false;
            chkField406.Enabled = false;
            chkField407.Enabled = false;
            chkField408.Enabled = false;
            chkField409.Enabled = false;
            chkField411.Enabled = false;
            chkField412.Enabled = false;
            chkField413.Enabled = false;
            chkField415.Enabled = false;
            chkField416.Enabled = false;
            chkField417.Enabled = false;

            timer_logout.Enabled = false;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Alt && e.KeyCode == Keys.F)
            {
                btnCopy.Visible = true;
                timer_logout.Enabled = true;
            }
            if (e.Alt && e.KeyCode == Keys.E)
            {
                chkField401.Enabled = true;
                chkField414.Enabled = true;
                chkField403.Enabled = true;
                chkField404.Enabled = true;
                chkField405.Enabled = true;
                chkField406.Enabled = true;
                chkField407.Enabled = true;
                chkField408.Enabled = true;
                chkField409.Enabled = true;
                chkField411.Enabled = true;
                chkField412.Enabled = true;
                chkField413.Enabled = true;
                chkField415.Enabled = true;
                chkField416.Enabled = true;
                chkField417.Enabled = true;
                timer_logout.Enabled = true;
            }

        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            string sqlConnectionString = "Data source=" + laser_sql.dbServerName + "\\SQLEXPRESS;Initial Catalog=master;User Id=sa;Password=s@;MultipleActiveResultSets=True";

            string script1 = "DELETE [S112_BDD].[dbo].LaserElements";
            string script2 = "INSERT INTO[S112_BDD].[dbo].LaserElements SELECT[id],[idLaser],[data]  FROM[TechWeb].[dbo].[LaserElements]";
            using (var connection = new SqlConnection(sqlConnectionString))
            {
                connection.Open();
                using (var command = new SqlCommand(script1, connection))
                {
                    try
                    {
                        command.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {
                        string spError = script1.Length > 100 ? script1.Substring(0, 100) + " ...\n..." : script1;
                        MessageBox.Show(string.Format("Please check the SqlServer script.\nFile: \nError: {0} \nSQL Command: \n{1}", ex.Message, spError), "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                using (var command = new SqlCommand(script2, connection))
                {
                    try
                    {
                        command.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {
                        string spError = script2.Length > 100 ? script2.Substring(0, 100) + " ...\n..." : script2;
                        MessageBox.Show(string.Format("Please check the SqlServer script.\nError: {0} \nSQL Command: \n{1}", ex.Message, spError), "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            btnCopy.Visible = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            btnRefresh_Click(sender,e);
        }
    }
}
