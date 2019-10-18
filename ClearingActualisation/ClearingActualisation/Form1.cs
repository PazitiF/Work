using System;
using System.Data;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using System.ServiceProcess;
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
            string sqlQuery = "SELECT * FROM sys.databases where [database_id] not in ('1','2','3','4','20','21','32','35','36','37','38') order by [name]";
            using (SqlConnection dBConnection = new SqlConnection(ConfigurationManager.AppSettings["connectionStringPL"]))
            {
                dBConnection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(sqlQuery, dBConnection);
                DataSet ds = new DataSet();
                // Заполняем Dataset
                adapter.Fill(ds);
                // Отображаем данные
                comboBoxPartnerClearing.DisplayMember = "name";
                comboBoxPartnerClearing.DataSource = ds.Tables[0];
                comboBoxPartnerClearing.Refresh();
            }
        }

        private void comboBoxPartnerClearing_SelectedItemChanged(object sender, EventArgs e)
        {
            string sqlQuery = $"SELECT [UID_AZS], [TerminalID] FROM [{comboBoxPartnerClearing.Text}].[dbo].[tTerminals] ORDER BY [sqlid]";
            string sqlQueryForGPN = "SELECT [tTerminals].[TerminalID],[tAZS].[gmt],[tTerminals].[UID_AZS] " +
                                    "FROM [GPN_hive_ks].[dbo].[tTerminals] " +
                                    "LEFT JOIN [GPN_hive_ks].[dbo].[tAZS] " +
                                    "ON tTerminals.UID_AZS = tAZS.UIDAZS " +
                                    "WHERE [GMT] is not null " +
                                    "ORDER BY [UID_AZS]";
            string sqlQuerryForRosneft = "SELECT [uidazs], [terminalid] FROM [queen].[dbo].[tterminals] WHERE [uidazs] in (SELECT uid_azs FROM RosNeft_hive_ks.dbo.tTerminals) and [DateEnd] is null and [partner] = 'e100'";
            using (SqlConnection dBConnection = new SqlConnection(ConfigurationManager.AppSettings["connectionStringPL"]))
            {
                dBConnection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter();
                switch(comboBoxPartnerClearing.Text)
                {
                    case "RosNeft_hive_ks":
                        adapter = new SqlDataAdapter(sqlQuerryForRosneft, dBConnection);
                        break;
                    case "GPN_hive_ks":
                        adapter = new SqlDataAdapter(sqlQueryForGPN, dBConnection);
                        break;
                    default:
                        adapter = new SqlDataAdapter(sqlQuery, dBConnection);
                        break;
                }
                //if (comboBoxPartnerClearing.Text == "GPN_hive_ks")
                //{
                //    adapter = new SqlDataAdapter(sqlQueryForGPN, dBConnection);
                //}
                //else
                //{
                //    adapter = new SqlDataAdapter(sqlQuery, dBConnection);
                //}
                DataTable ds = new DataTable();
                // Заполняем Dataset
                adapter.Fill(ds);
                // Отображаем данные
                clearingDataGrid.DataSource = ds;
                clearingDataGrid.Refresh();
                //comboBoxPartnerClearing.DisplayMember = "name";
                //comboBoxPartnerClearing.DataSource = ds.Tables[0];
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
        private void SendQuery(string baseName)
        {
            if (baseName != string.Empty)
            {
                string sqlQuery = $"SELECT [UID_AZS],[TerminalID] FROM [{baseName}_hive_ks].[dbo].[tTerminals]";
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
            SaveDialog.FileName = "mappingAZS.dat";
            var dialogResult = SaveDialog.ShowDialog();
            if (dialogResult != DialogResult.OK)
                return;
            StreamWriter sW = new StreamWriter(SaveDialog.FileName);
            //Формируем хедер для файла мапинга
            string lines = $"E100,{comboBoxPartnerClearing.Text.Replace("_hive_ks","")}";
            
            switch(comboBoxPartnerClearing.Text)
            {
                case "GPN_hive_ks":
                    lines = $"GPN,E100";
                    sW.WriteLine(lines);
                    for (int row = 0; row < clearingDataGrid.RowCount - 1; row++)
                    {
                        lines = string.Empty;
                        lines += $"{clearingDataGrid.Rows[row].Cells[0].Value}:{clearingDataGrid.Rows[row].Cells[1].Value},{clearingDataGrid.Rows[row].Cells[2].Value}";
                        lines = lines.Replace("\0", "").Replace("\a", "").Replace("\b", "").Replace("\t", "")
                            .Replace("\n", "").Replace("\v", "").Replace("\f", "").Replace("\r", "").Replace(" ","");
                        sW.WriteLine(lines);
                    }
                    break;

                case "SBANK_hive_ks":
                    lines = $"E100,Sberbank";
                    sW.WriteLine(lines);
                    for (int row = 0; row < clearingDataGrid.RowCount - 1; row++)
                    {
                        lines = string.Empty;
                        lines += $"{clearingDataGrid.Rows[row].Cells[0].Value},{clearingDataGrid.Rows[row].Cells[1].Value}";
                        lines = lines.Replace("\0", "").Replace("\a", "").Replace("\b", "").Replace("\t", "")
                            .Replace("\n", "").Replace("\v", "").Replace("\f", "").Replace("\r", "").Replace(" ", "");
                        sW.WriteLine(lines);
                    }
                    break;

                default:
                    sW.WriteLine(lines);
                    for (int row = 0; row < clearingDataGrid.RowCount - 1; row++)
                    {
                        lines = string.Empty;
                        lines += $"{clearingDataGrid.Rows[row].Cells[0].Value},{clearingDataGrid.Rows[row].Cells[1].Value}";
                        lines = lines.Replace("\0", "").Replace("\a", "").Replace("\b", "").Replace("\t", "")
                            .Replace("\n", "").Replace("\v", "").Replace("\f", "").Replace("\r", "").Replace(" ", "");
                        sW.WriteLine(lines);
                    }
                    break;
            }
            //if (comboBoxPartnerClearing.Text == "GPN_hive_ks")
            //{
            //    lines = $"GPN,E100";
            //    for (int row = 0; row < clearingDataGrid.RowCount - 1; row++)
            //    {
            //        lines = string.Empty;
            //        lines += $"{clearingDataGrid.Rows[row].Cells[0].Value}:{clearingDataGrid.Rows[row].Cells[1].Value},{clearingDataGrid.Rows[row].Cells[2].Value}";
            //        lines = lines.Replace("\0", "").Replace("\a", "").Replace("\b", "").Replace("\t", "")
            //            .Replace("\n", "").Replace("\v", "").Replace("\f", "").Replace("\r", "");
            //        sW.WriteLine(lines);
            //    }
            //}

            //else
            //{
            //    for (int row = 0; row < clearingDataGrid.RowCount - 1; row++)
            //    {
            //        lines = string.Empty;
            //        lines += $"{clearingDataGrid.Rows[row].Cells[0].Value},{clearingDataGrid.Rows[row].Cells[1].Value}";
            //        lines = lines.Replace("\0", "").Replace("\a", "").Replace("\b", "").Replace("\t", "")
            //            .Replace("\n", "").Replace("\v", "").Replace("\f", "").Replace("\r", "");
            //        sW.WriteLine(lines);
            //    }
            //}
            //Запись данных из dataGridView в выбраный файл
            sW.Close();
            MessageBox.Show($"Прогружено терминалов: {(clearingDataGrid.RowCount - 1).ToString()}");
        }

        private void AnyButton_Click(object sender, EventArgs e)
        {
            if (progressBarTerminals.Value != 0)
            {
                progressBarTerminals.Value = 0;
                terminalsDataGrid.DataSource = null;
            }
            

            #region Открытие и парсинг файла
            //Открываем файл с терминалами
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.Filter = "Книга Excel|*.xlsx";
            var dialogResult = openDialog.ShowDialog();
            if (dialogResult != DialogResult.OK)
                return;

            //Парсим файл и заполняем Grid
            OleDbConnection xlsxConn = new OleDbConnection($"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={openDialog.FileName};Extended Properties='Excel 12.0 XML;HDR=YES;';");
            OleDbCommand xlsxSelect = new OleDbCommand("Select * From [Лист1$]", xlsxConn);
            xlsxConn.Open();
            OleDbDataAdapter xlsxAdapter = new OleDbDataAdapter(xlsxSelect);
            DataTable data = new DataTable();
            xlsxAdapter.Fill(data);
            terminalsDataGrid.DataSource = data;
            terminalsDataGrid.Refresh();
            #endregion

            //Открываем SQL-соединение с PL и EE
            using (SqlConnection dBConnectionPL = new SqlConnection(ConfigurationManager.AppSettings["connectionStringPL"]))
            {
                dBConnectionPL.Open();

                //Получаем список партнерских баз
                string sqlDatabaseQuery = "SELECT * FROM sys.databases where [name] like '%_hive_ks%' order by [name]";
                SqlDataAdapter adapterDatabase = new SqlDataAdapter(sqlDatabaseQuery, dBConnectionPL);

                // Заполняем полученными данными Dataset
                DataSet dataSetDatabase = new DataSet();
                adapterDatabase.Fill(dataSetDatabase);

                //Настраиваем Progress Bar
                progressBarTerminals.Maximum = dataSetDatabase.Tables[0].Rows.Count;
                progressBarTerminals.Step = 1;  

                //Проходим по всем полученным базам партнеров
                for (int row = 0; row < dataSetDatabase.Tables[0].Rows.Count; row++)
                {
                    // TODO: переписать формирование строки, что бы не формировался лист станций для каждого партнера. 
                    #region  Получаем список терминалов прогруженных партнера из имеющихся в файле
                    string sqlTerminalsFromPartnerQuery = $"SELECT [UID_AZS] FROM [{dataSetDatabase.Tables[0].Rows[row].ItemArray[0]}].[dbo].[tTerminals] where [UID_AZS] in (";
                    string sqlTerminalsFromPartnerQueryAll = $"SELECT * FROM [{dataSetDatabase.Tables[0].Rows[row].ItemArray[0]}].[dbo].[tTerminals] where [UID_AZS] in (";
                    for (int iter = 0; iter < data.Rows.Count; iter++)
                    {
                        if (iter > 0)
                        {
                            if (data.Rows[iter].ItemArray[0].ToString() != "")
                            {
                                sqlTerminalsFromPartnerQuery += $",'{data.Rows[iter].ItemArray[0]}'";
                                sqlTerminalsFromPartnerQueryAll += $",'{data.Rows[iter].ItemArray[0]}'";
                            }
                        }
                        else
                        {
                            sqlTerminalsFromPartnerQuery += $"'{data.Rows[iter].ItemArray[0]}'";
                            sqlTerminalsFromPartnerQueryAll += $"'{data.Rows[iter].ItemArray[0]}'";
                        }
                    }
                    sqlTerminalsFromPartnerQuery += ")";
                    sqlTerminalsFromPartnerQueryAll += ") order by [uid_azs]";

                    SqlDataAdapter adapterTerminals = new SqlDataAdapter(sqlTerminalsFromPartnerQueryAll, dBConnectionPL);
                    DataSet dataSetTerminalsFromPartner = new DataSet();
                    adapterTerminals.Fill(dataSetTerminalsFromPartner);
                    #endregion

                    int updateStatePL = 0;
                    int updatedTerminalsNumberPL = 0;

                    if (dataSetTerminalsFromPartner.Tables[0].Rows.Count > 0)
                    {
                        string sqlTerminalsFromQueenQuery = $"SELECT * FROM [queen].[dbo].[tTerminals] where [DateEnd] is null and [uidazs] in ({sqlTerminalsFromPartnerQuery}) and partner = 'e100' order by [uidazs]";
                        adapterTerminals = new SqlDataAdapter(sqlTerminalsFromQueenQuery, dBConnectionPL);
                        DataSet dataSetTerminalsFromQueen = new DataSet();
                        adapterTerminals.Fill(dataSetTerminalsFromQueen);

                        for(int queenRow = 0; queenRow < dataSetTerminalsFromQueen.Tables[0].Rows.Count; queenRow++)
                        {
                            updatedTerminalsNumberPL = 0;
                            var queen = dataSetTerminalsFromQueen.Tables[0].Rows[queenRow].ItemArray[2].ToString();
                            var partner = dataSetTerminalsFromPartner.Tables[0].Rows[queenRow].ItemArray[2].ToString();

                            if (queen != partner)
                            {
                                string sqlTerminalsUpdate = $"UPDATE [{dataSetDatabase.Tables[0].Rows[row].ItemArray[0]}].[dbo].[tTerminals] SET [TerminalID] = '{dataSetTerminalsFromQueen.Tables[0].Rows[queenRow].ItemArray[2]}' WHERE [TerminalID] = '{dataSetTerminalsFromPartner.Tables[0].Rows[queenRow].ItemArray[2]}' AND [DateEnd] is null";

                                SqlCommand commandTerminalsUpdatePL = new SqlCommand(sqlTerminalsUpdate, dBConnectionPL);
                                //SqlCommand commandTerminalsUpdateEE = new SqlCommand(sqlTerminalsUpdate, dBConnectionEE);
                                updateStatePL = commandTerminalsUpdatePL.ExecuteNonQuery();
                                //updateStateEE = commandTerminalsUpdateEE.ExecuteNonQuery();
                                updatedTerminalsNumberPL += updateStatePL;
                                //updatedTerminalsNumberEE += updateStateEE;
                            }
                        }
                        if(updatedTerminalsNumberPL > 0)
                        {
                            richTextBoxTerminals.AppendText($"В базе {dataSetDatabase.Tables[0].Rows[row].ItemArray[0]} обновлено терминалов: {updatedTerminalsNumberPL}\n");
                        }                                                
                    }
                    progressBarTerminals.PerformStep();
                }
            }            
        }
    }
}
