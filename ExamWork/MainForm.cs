using ExamWork.DataAccess;
using ExamWork.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExamWork
{
    public partial class MainForm : Form
    {
        CountryTableDataService countryDataService;
        CityTableDataService cityDataService;
        StreetTableDataService streetDataService;

        public MainForm()
        {
            InitializeComponent();
            countryDataService = new CountryTableDataService();
            cityDataService = new CityTableDataService();
            streetDataService = new StreetTableDataService();
            LoadDataGridViewCountries();
        }

        private void DataGridViewCountriesSelectionChanged(object sender, EventArgs e)
        {
            LoadDataGridViewCities();
        }

        private void DataGridViewCitiesSelectionChanged(object sender, EventArgs e)
        {
            LoadDataGridViewStreets();
        }

        private void ButtonAddCountryClick(object sender, EventArgs e)
        {
            AddForm addForm = new AddForm();
            DialogResult result = addForm.ShowDialog(this);

            if (result == DialogResult.Cancel)
                return;

            if (addForm.textBoxName.Text.Count() < 1)
            {
                MessageBox.Show("Вы не ввели название");
                return;
            }
            Coutry coutry = new Coutry { Name = addForm.textBoxName.Text };
            countryDataService.Add(coutry);

            LoadDataGridViewCountries();
        }

        private void ButtonAddCityClick(object sender, EventArgs e)
        {
            AddForm addForm = new AddForm();
            DialogResult result = addForm.ShowDialog(this);

            if (result == DialogResult.Cancel)
                return;

            if (addForm.textBoxName.Text.Count() < 1)
            {
                MessageBox.Show("Вы не ввели название");
                return;
            }
            City city = new City { Name = addForm.textBoxName.Text, CountryId = new Guid(dataGridViewCountries.SelectedRows[0].Cells[0].Value.ToString())};
            cityDataService.Add(city);

            LoadDataGridViewCities();
        }

        private void ButtonAddStreetClick(object sender, EventArgs e)
        {
            AddForm addForm = new AddForm();
            DialogResult result = addForm.ShowDialog(this);

            if (result == DialogResult.Cancel)
                return;

            if (addForm.textBoxName.Text.Count() < 1)
            {
                MessageBox.Show("Вы не ввели название");
                return;
            }
            Street street = new Street { Name = addForm.textBoxName.Text, CityId = new Guid(dataGridViewCities.SelectedRows[0].Cells[0].Value.ToString()) };
            streetDataService.Add(street);

            LoadDataGridViewStreets();
        }

        private void LoadDataGridViewCountries()
        {
            var countries = countryDataService.GetAll();

            dataGridViewCountries.Rows.Clear();
            dataGridViewCountries.Columns.Clear();

            dataGridViewCountries.Columns.Add("Id", "Id");
            dataGridViewCountries.Columns.Add("Name", "Название страны");
            dataGridViewCountries.Columns[0].Visible = false;
            foreach (var country in countries)
            {
                List<string> data = new List<string>();
                data.Add(country.Id.ToString());
                data.Add(country.Name);
                dataGridViewCountries.Rows.Add(data.ToArray());
            }
        }

        private void LoadDataGridViewCities()
        {
            var cities = cityDataService.GetAll();

            dataGridViewCities.Rows.Clear();
            dataGridViewCities.Columns.Clear();

            dataGridViewCities.Columns.Add("Id", "Id");
            dataGridViewCities.Columns.Add("Name", "Название города");
            dataGridViewCities.Columns[0].Visible = false;

            foreach (var city in cities)
            {
                if (city.CountryId == new Guid(dataGridViewCountries.SelectedRows[0].Cells[0].Value.ToString()))
                {
                    List<string> data = new List<string>();
                    data.Add(city.Id.ToString());
                    data.Add(city.Name);
                    dataGridViewCities.Rows.Add(data.ToArray());
                }
            }
        }

        private void LoadDataGridViewStreets()
        {
            var streets = streetDataService.GetAll();

            dataGridViewStreets.Rows.Clear();
            dataGridViewStreets.Columns.Clear();
            
            dataGridViewStreets.Columns.Add("Name", "Название улицы");

            foreach (var street in streets)
            {
                if (street.CityId== new Guid(dataGridViewCities.SelectedRows[0].Cells[0].Value.ToString()))
                {
                    List<string> data = new List<string>();
                    data.Add(street.Name);
                    dataGridViewCities.Rows.Add(data.ToArray());
                }
            }
        }
    }
}
