using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using System.ServiceProcess;
using System.Management;
using System.Data.OleDb;

namespace ClearingActualisation
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void tabPageClearing_Enter(object sender, EventArgs e)
        {
            ServiceController[] scServices = ServiceController.GetServices();
            //scServices.OrderBy(var tmp in scServices.Select(Ser)
            foreach (ServiceController scTemp in scServices)
            {
                if (scTemp.ServiceName.Contains("ClearingServicePars_"))
                {
                    comboBoxPartnerClearing.Items.Add(scTemp.ServiceName.Replace("ClearingServicePars_", ""));
                }
            }
        }

        private void tabPageTerminals_Enter(object sender, EventArgs e)
        {
            //string sqlQuery = "SELECT * FROM sys.databases where [database_id] not in ('1','2','3','4','16','18','19','20','21','16','34') order by [name]";
            //using (SqlConnection dBConnection = new SqlConnection(ConfigurationManager.AppSettings["connectionString"]))
            //{
            //    dBConnection.Open();
            //    SqlDataAdapter adapter = new SqlDataAdapter(sqlQuery, dBConnection);
            //    DataSet ds = new DataSet();
            //    // Заполняем Dataset
            //    adapter.Fill(ds);
            //    // Отображаем данные
            //    comboBoxPartnerDB.DisplayMember = "name";
            //    comboBoxPartnerDB.DataSource = ds.Tables[0];
            //}
        }

        private void comboBoxClearing_SelectedIndexChanged(object sender, EventArgs e)
        {
            SendQuery(comboBoxPartnerDB.GetItemText(comboBoxPartnerDB.SelectedItem));            
        }

        private void comboBoxPartnerDB_SelectedIndexChanged(object sender, EventArgs e)
        {
            //string sqlQuery = "SELECT [UID_AZS],[TerminalID] FROM [" + comboBoxPartnerDB.GetItemText(comboBoxPartnerDB.SelectedItem) + "].[dbo].[tTerminals] ";
            ////    //"where [TerminalID] in ('283679283','215462691','305758931','285619649','285237981','285621827','285452978','215884260','215455949')";

            //using (SqlConnection dBConnection = new SqlConnection(ConfigurationManager.AppSettings["connectionString"]))
            //{
            //    dBConnection.Open();
            //    SqlDataAdapter adapter = new SqlDataAdapter(sqlQuery, dBConnection);
            //    DataSet ds = new DataSet();
            //    // Заполняем Dataset
            //    adapter.Fill(ds);
            //    // Отображаем данные
            //    terminalsDataGrid.DataSource = ds.Tables[0];
            //}
        }

        private void SendQuery(string baseName)
        {
            if (baseName != string.Empty)
            {
                string sqlQuery = "SELECT [UID_AZS],[TerminalID] FROM [" + baseName + "_hive_ks].[dbo].[tTerminals]";
                using (SqlConnection dBConnectionPL = new SqlConnection(ConfigurationManager.AppSettings["connectionStringPL"]))
                {
                    dBConnectionPL.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(sqlQuery, dBConnectionPL);
                    DataSet ds = new DataSet();
                    // Заполняем Dataset
                    adapter.Fill(ds);
                    // Отображаем данные
                    clearingDataGrid.DataSource = ds.Tables[0];
                }
            }
        }

        private void AutoSaveButton_Click(object sender, EventArgs e)
        {

            //ServiceController[] scServices = ServiceController.GetServices();
            //ManagementScope msServicePath = new ManagementScope("\\\\localhost\\root\\cimv2");
            //msServicePath.Connect();
            //ObjectQuery query = new ObjectQuery("SELECT * FROM Win32_OperatingSystem");
            //ManagementObjectSearcher searcher = new ManagementObjectSearcher(msServicePath, query);
            //ManagementObjectCollection queryCollection = searcher.Get();
            //foreach (ManagementObject moService in queryCollection)
            //{
            //    int ProcessID = Convert.ToInt32(moService["ProcessID"]);
            //    string State = moService.GetPropertyValue("State").ToString();
            //    string ServiceName = moService.GetPropertyValue("Name").ToString();
            //    clearingDataGrid.Rows.Add(ServiceName, State, ProcessID, moService.GetPropertyValue("PathName").ToString().Substring(1, moService.GetPropertyValue("PathName").ToString().Length - 2));
            //}
        }

        private void ManualSaveButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog SaveDialog = new SaveFileDialog();
            SaveDialog.Filter = "Mapping File|*.dat";
            var dialogResult = SaveDialog.ShowDialog();
            if (dialogResult != DialogResult.OK)
                return;
            StreamWriter sW = new StreamWriter(SaveDialog.FileName);
            //Формируем хедер для файла мапинга
            string lines = "E100," + comboBoxPartnerClearing.GetItemText(comboBoxPartnerClearing.SelectedItem);
            sW.WriteLine(lines);

            //Запись данных из dataGridView в выбраный файл
            for (int row = 0; row < clearingDataGrid.RowCount - 1; row++)
            {
                lines = string.Empty;
                lines += clearingDataGrid.Rows[row].Cells[0].Value.ToString() + "," + clearingDataGrid.Rows[row].Cells[1].Value.ToString();
                sW.WriteLine(lines);
            }

            sW.Close();
            MessageBox.Show("Прогружено " + (clearingDataGrid.RowCount - 1).ToString() + " терминалов");
        }

        private void AnyButton_Click(object sender, EventArgs e)
        {
            //Открываем файл с терминалами
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.Filter = "Книга Excel|*.xlsx";
            var dialogResult = openDialog.ShowDialog();
            if (dialogResult != DialogResult.OK)
                return;
            //Парсим файл и заполняем Grid
            OleDbConnection xlsxConn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" +
                        openDialog.FileName + ";Extended Properties='Excel 12.0 XML;HDR=YES;';");
            OleDbCommand xlsxSelect = new OleDbCommand("Select * From [Лист1$]", xlsxConn);
            xlsxConn.Open();
            OleDbDataAdapter xlsxAdapter = new OleDbDataAdapter(xlsxSelect);
            DataTable data = new DataTable();
            xlsxAdapter.Fill(data);
            terminalsDataGrid.DataSource = data;
            terminalsDataGrid.Refresh();

            //Получаем список партнерских баз
            string sqlDatabaseQuery = "SELECT * FROM sys.databases where [name] like '%_hive_ks%' order by [name]";
            using (SqlConnection dBConnectionPL = new SqlConnection(ConfigurationManager.AppSettings["connectionStringPL"]), 
                dBConnectionEE = new SqlConnection(ConfigurationManager.AppSettings["connectionStringEE"]))
            {
                dBConnectionPL.Open();
                dBConnectionEE.Open();
                SqlDataAdapter adapterDatabase = new SqlDataAdapter(sqlDatabaseQuery, dBConnectionPL);
                DataSet dataSetDatabase = new DataSet();
                // Заполняем Dataset
                adapterDatabase.Fill(dataSetDatabase);

                progressBarTerminals.Maximum = dataSetDatabase.Tables[0].Rows.Count;
                progressBarTerminals.Step = 1;

                for (int row = 0; row < dataSetDatabase.Tables[0].Rows.Count; row++)
                {
                    string sqlTerminalsFromPartnerQuery = "SELECT [UID_AZS] FROM [" + dataSetDatabase.Tables[0].Rows[row].ItemArray[0] + "].[dbo].[tTerminals] where [UID_AZS] in (";
                    string sqlTerminalsFromPartnerQueryAll = "SELECT * FROM [" + dataSetDatabase.Tables[0].Rows[row].ItemArray[0] + "].[dbo].[tTerminals] where [UID_AZS] in (";
                    for (int iter = 0; iter < data.Rows.Count; iter++)
                    {
                        if(iter > 0)
                        {
                            sqlTerminalsFromPartnerQuery += ",'" + data.Rows[iter].ItemArray[0] + "'";
                            sqlTerminalsFromPartnerQueryAll += ",'" + data.Rows[iter].ItemArray[0] + "'";

                        }
                        else
                        {
                            sqlTerminalsFromPartnerQuery += "'" + data.Rows[iter].ItemArray[0] + "'";
                            sqlTerminalsFromPartnerQueryAll += "'" + data.Rows[iter].ItemArray[0] + "'";
                        }
                        
                    }
                    sqlTerminalsFromPartnerQuery += ")";
                    sqlTerminalsFromPartnerQueryAll += ")";

                    SqlDataAdapter adapterTerminals = new SqlDataAdapter(sqlTerminalsFromPartnerQueryAll, dBConnectionPL);
                    DataSet dataSetTerminalsFromPartner = new DataSet();
                    adapterTerminals.Fill(dataSetTerminalsFromPartner);

                    int updatedTerminalsNumberPL = 0;
                    int updatedTerminalsNumberEE = 0;

                    if (dataSetTerminalsFromPartner.Tables[0].Rows.Count > 0)
                    {
                        String sqlTerminalsFromQueenQuery = $"SELECT * FROM [queen].[dbo].[tTerminals] where [DateEnd] is null and uidazs in ({sqlTerminalsFromPartnerQuery})";
                        adapterTerminals = new SqlDataAdapter(sqlTerminalsFromQueenQuery, dBConnectionPL);
                        DataSet dataSetTerminalsFromQueen = new DataSet();
                        adapterTerminals.Fill(dataSetTerminalsFromQueen);
                        //terminalsDataGrid.DataSource = dataSetTerminalsFromPartner.Tables[0];
                        //terminalsDataGrid.Refresh();

                        for(int queenRow = 0; queenRow < dataSetTerminalsFromQueen.Tables[0].Rows.Count; queenRow++)
                        {
                            if(dataSetTerminalsFromQueen.Tables[0].Rows[queenRow].ItemArray[2].ToString() != dataSetTerminalsFromPartner.Tables[0].Rows[queenRow].ItemArray[2].ToString())
                            {
                                string sqlTerminalsUpdate = "UPDATE [" + dataSetDatabase.Tables[0].Rows[row].ItemArray[0] + "].[dbo].[tTerminals] SET [TerminalID] = '" + dataSetTerminalsFromQueen.Tables[0].Rows[queenRow].ItemArray[2] +
                                "' WHERE [TerminalID] = '" + dataSetTerminalsFromPartner.Tables[0].Rows[queenRow].ItemArray[2] + "' AND [DateEnd] is null";

                                SqlCommand commandTerminalsUpdatePL = new SqlCommand(sqlTerminalsUpdate, dBConnectionPL);
                                SqlCommand commandTerminalsUpdateEE = new SqlCommand(sqlTerminalsUpdate, dBConnectionEE);
                                updatedTerminalsNumberPL += commandTerminalsUpdatePL.ExecuteNonQuery();
                                updatedTerminalsNumberEE += commandTerminalsUpdateEE.ExecuteNonQuery();
                            }
                            
                        }
                        if(updatedTerminalsNumberEE > 0)
                        {
                            MessageBox.Show($"В базе {dataSetDatabase.Tables[0].Rows[row].ItemArray[0]} обновлено терминалов: {updatedTerminalsNumberEE}");

                        }
                                                
                    }
                    progressBarTerminals.PerformStep();
                }

            }

            //using (SqlConnection dBConnection = new SqlConnection(ConfigurationManager.AppSettings["connectionString"]))
            //{
            //    dBConnection.Open();
            //    DataSet ds = new DataSet();

            //    for (int row = 0; row < terminalsDataGrid.RowCount - 1; row++)
            //    {
            //        string sqlQuery;
            //        SqlCommand command;



            //        switch (terminalsDataGrid.Rows[row].Cells[1].Value.ToString())
            //        {
            //            case "283679283":
            //                sqlQuery = "UPDATE [" + comboBoxPartnerDB.GetItemText(comboBoxPartnerDB.SelectedItem) + "].[dbo].[tTerminals] SET [TerminalID] = '286308119' WHERE [TerminalID] = '" + terminalsDataGrid.Rows[row].Cells[1].Value.ToString() + "'";
            //                command = new SqlCommand(sqlQuery, dBConnection);
            //                command.ExecuteNonQuery();
            //                break;
            //            case "215462691":
            //                sqlQuery = "UPDATE [" + comboBoxPartnerDB.GetItemText(comboBoxPartnerDB.SelectedItem) + "].[dbo].[tTerminals] SET [TerminalID] = '215456123' WHERE [TerminalID] = '" + terminalsDataGrid.Rows[row].Cells[1].Value.ToString() + "'";
            //                command = new SqlCommand(sqlQuery, dBConnection);
            //                command.ExecuteNonQuery();
            //                break;
            //            case "305758931":
            //                sqlQuery = "UPDATE [" + comboBoxPartnerDB.GetItemText(comboBoxPartnerDB.SelectedItem) + "].[dbo].[tTerminals] SET [TerminalID] = 215457746 WHERE [TerminalID] = '" + terminalsDataGrid.Rows[row].Cells[1].Value.ToString() + "'";
            //                command = new SqlCommand(sqlQuery, dBConnection);
            //                command.ExecuteNonQuery();
            //                break;
            //            case "285619649":
            //                sqlQuery = "UPDATE [" + comboBoxPartnerDB.GetItemText(comboBoxPartnerDB.SelectedItem) + "].[dbo].[tTerminals] SET [TerminalID] = '286308119' WHERE [TerminalID] = '" + terminalsDataGrid.Rows[row].Cells[1].Value.ToString() + "'";
            //                command = new SqlCommand(sqlQuery, dBConnection);
            //                command.ExecuteNonQuery();
            //                break;
            //            case "285237981":
            //                sqlQuery = "UPDATE [" + comboBoxPartnerDB.GetItemText(comboBoxPartnerDB.SelectedItem) + "].[dbo].[tTerminals] SET [TerminalID] = '285619602' WHERE [TerminalID] = '" + terminalsDataGrid.Rows[row].Cells[1].Value.ToString() + "'";
            //                command = new SqlCommand(sqlQuery, dBConnection);
            //                command.ExecuteNonQuery();
            //                break;
            //            case "285621827":
            //                sqlQuery = "UPDATE [" + comboBoxPartnerDB.GetItemText(comboBoxPartnerDB.SelectedItem) + "].[dbo].[tTerminals] SET [TerminalID] = '286303762' WHERE [TerminalID] = '" + terminalsDataGrid.Rows[row].Cells[1].Value.ToString() + "'";
            //                command = new SqlCommand(sqlQuery, dBConnection);
            //                command.ExecuteNonQuery();
            //                break;
            //            case "285452978":
            //                sqlQuery = "UPDATE [" + comboBoxPartnerDB.GetItemText(comboBoxPartnerDB.SelectedItem) + "].[dbo].[tTerminals] SET [TerminalID] = '289558704' WHERE [TerminalID] = '" + terminalsDataGrid.Rows[row].Cells[1].Value.ToString() + "'";
            //                command = new SqlCommand(sqlQuery, dBConnection);
            //                command.ExecuteNonQuery();
            //                break;
            //            case "215884260":
            //                sqlQuery = "UPDATE [" + comboBoxPartnerDB.GetItemText(comboBoxPartnerDB.SelectedItem) + "].[dbo].[tTerminals] SET [TerminalID] = '286308081' WHERE [TerminalID] = '" + terminalsDataGrid.Rows[row].Cells[1].Value.ToString() + "'";
            //                command = new SqlCommand(sqlQuery, dBConnection);
            //                command.ExecuteNonQuery();
            //                break;
            //            case "215455949":
            //                sqlQuery = "UPDATE [" + comboBoxPartnerDB.GetItemText(comboBoxPartnerDB.SelectedItem) + "].[dbo].[tTerminals] SET [TerminalID] = '215457941' WHERE [TerminalID]= '" + terminalsDataGrid.Rows[row].Cells[1].Value.ToString() + "'";
            //                command = new SqlCommand(sqlQuery, dBConnection);
            //                command.ExecuteNonQuery();
            //                break;
            //        }
            //    }
            //    dBConnection.Close();
            //}
        }

    }
}
