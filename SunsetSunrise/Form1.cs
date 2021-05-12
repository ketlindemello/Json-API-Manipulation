using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Documents;
using System.Windows.Forms;

namespace SunsetSunrise
{
    public partial class Form1 : Form
    {
        public Location selectedLocation;
        public List<Location> allLocations = new List<Location>();

        public Form1()
        {
            InitializeComponent();

            Location Chattanooga = new Location();
            Chattanooga.City = "Chattanooga";
            Chattanooga.State = "TN";
            Chattanooga.Latitude = "35.0457219";
            Chattanooga.Longitude = "-85.3094883";
            allLocations.Add(Chattanooga);

            Location Dallas = new Location();
            Dallas.City = "Dallas";
            Dallas.State = "TX";
            Dallas.Latitude = "35.04563";
            Dallas.Longitude = "-85.309677";
            allLocations.Add(Dallas);

            Location SanDiego = new Location();
            SanDiego.City = "San Diego";
            SanDiego.State = "CA";
            SanDiego.Latitude = "32.71574";
            SanDiego.Longitude = "-117.161087";
            allLocations.Add(SanDiego);

            Location Altus = new Location();
            Altus.City = "Altus";
            Altus.State = "OK";
            Altus.Latitude = "34.6378";
            Altus.Longitude = "-99.334";
            allLocations.Add(Altus);

            Location Miami = new Location();
            Miami.City = "Miami";
            Miami.State = "FL";
            Miami.Latitude = "25.76168";
            Miami.Longitude = "-80.191788";
            allLocations.Add(Miami);

            Location London = new Location();
            London.City = "London";
            London.State = "UK";
            London.Latitude = "51.50853";
            London.Longitude = "-0.12574";
            allLocations.Add(London);

            Location RioDeJaneiro = new Location();
            RioDeJaneiro.City = "Rio de Janeiro";
            RioDeJaneiro.State = "Brazil";
            RioDeJaneiro.Latitude = "-22.9014";
            RioDeJaneiro.Longitude = "-43.17892";
            allLocations.Add(RioDeJaneiro);

            Location Jerusalem = new Location();
            Jerusalem.City = "Jerusalem";
            Jerusalem.State = "Israel";
            Jerusalem.Latitude = "31.76832";
            Jerusalem.Longitude = "35.213711";
            allLocations.Add(Jerusalem);

            Location Paris = new Location();
            Paris.City = "Paris";
            Paris.State = "France";
            Paris.Latitude = "48.85661";
            Paris.Longitude = "2.352222";
            allLocations.Add(Paris);

            Location Berlin = new Location();
            Berlin.City = "Berlin";
            Berlin.State = "Germany";
            Berlin.Latitude = "52.52001";
            Berlin.Longitude = "13.404954";
            allLocations.Add(Berlin);

            dataGridView1.DataSource = allLocations;
            DisplayDefault();
        }

        private void DisplayDefault()
        {
            string defaultCity = SelectCity(location: allLocations[0]);

            richTextBox2.Text = defaultCity;
            DefaultCityDate();

            label4.Text = "Date: " + DateTime.Now.DayOfWeek + ", " + DateTime.Now.ToString("MMMM") + " " + DateTime.Now.Day + ", " + DateTime.Now.Year + "\nLocation: " + allLocations[0].City + ", " + allLocations[0].State;
        }

        private void DefaultCityDate()
        {            
            string defaultyCityDate = SelectCity(location: allLocations[0]);

            richTextBox3.Text = defaultyCityDate;

            label4.Text = $"Date: {dateTimePicker1.Text}\nLocation: {allLocations[0].City}, {allLocations[0].State}";
         }


        private string SelectCity(Location location)
        {
            SunProcessor sunriseSunsetService = new SunProcessor();
            Task<SunModel> task =
                Task.Run(async () => await sunriseSunsetService.GetRiseInfo(
                    latitude: location.Latitude,
                    longitude: location.Longitude,
                    date: dateTimePicker1.Value.Date));

            task.Wait();
            SunModel results = task.Result;
            
            return results.ToString();           
            
        }

        private void DisplayInfo(int select)
        {            
            try
            {              
                string cityInfo = SelectCity(location: allLocations[select]);

                richTextBox1.Text = cityInfo;
            }
            catch (FormatException e)
            {
                MessageBox.Show("Error");
            }
        }

        private void PopulateLabels(int allCitiesIndex)
        {
            label1.Text = "Date: " + dateTimePicker1.Text + "\nLocation: " + allLocations[allCitiesIndex].City + ", " + allLocations[allCitiesIndex].State;
        }

        private void dataGridView1_RowContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DefaultCityDate();
            Int32 selectedRowCount =
                dataGridView1.Rows.GetRowCount(DataGridViewElementStates.Selected);
            for (int i = 0; i < selectedRowCount; i++)
            {
                int select = dataGridView1.SelectedRows[i].Index;
                DisplayInfo(select);
                PopulateLabels(select);
            }
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.S))
            {
                DialogResult result;
                result = MessageBox.Show("Do you want to save data to file?", "Submit Today", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.No)
                {
                    return true;
                }
                if (result == DialogResult.Yes)
                {
                    ReceiveS();
                }
            }
            if (keyData == (Keys.Control | Keys.D))
            {
                DialogResult result;
                result = MessageBox.Show("Do you want to save data to file?", "Submit Date", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.No)
                {
                    return true;
                }
                if (result == DialogResult.Yes)
                {
                    ReceiveD();
                }
            }
            if (keyData == (Keys.Control | Keys.P))
            {

                DialogResult result;
                result = MessageBox.Show("Do you want to save data to file?", "Submit Place", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.No)
                {
                    return true;
                }
                if (result == DialogResult.Yes)
                {
                    ReceiveP();

                }
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
        private void SaveToFile(RichTextBox boxContent)
        {
            RichTextBox _boxContent = boxContent;
            string path = Environment.CurrentDirectory + "/" + "sunriseSunset.txt";

            File.WriteAllText(path, boxContent.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result;
            result = MessageBox.Show("Do you want to save data to file?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                return;
            }
            if (result == DialogResult.Yes)
            {
                ReceiveS();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult result;
            result = MessageBox.Show("Do you want to save data to file?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                return;
            }
            if (result == DialogResult.Yes)
            {
                ReceiveD();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult result;
            result = MessageBox.Show("Do you want to save data to file?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                return;
            }
            if (result == DialogResult.Yes)
            {
                ReceiveP();
            }
        }

        private void ReceiveS()
        {
            RichTextBox rbox = new RichTextBox();
            rbox.Text = label3.Text + "\n" + richTextBox2.Text;
            SaveToFile(rbox);
        }

        private void ReceiveD()
        {
            RichTextBox rbox = new RichTextBox();
            rbox.Text = label4.Text + "\n" + richTextBox3.Text;
            SaveToFile(rbox);
        }

        private void ReceiveP()
        {
            RichTextBox rbox = new RichTextBox();
            rbox.Text = label1.Text + "\n" + richTextBox1.Text;
            SaveToFile(rbox);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("1. Select the row to display data for the specific city. \n2. Choose a date from the calendar to display specific data for choosen city and default city 'Chattanooga'. " +
                "*Reselect row to update data.\n3. HotKeys and Submit buttons save data to file.", "Program Instruction");
        }
    }
}
