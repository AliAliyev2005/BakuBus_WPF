using Microsoft.Maps.MapControl.WPF;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BakuBus_WPF.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public string Key { get; set; } = "DX49ep9XuHkbagf4eprm~XyahHINgtXqmjsVmPO90Wg~AjsJfKFsP9wQg-zHgYLsdYReCDMmuzzIgCsAjfwrBHGhn34td3KFvamCnxwsUJ2Y";
        public ApplicationIdCredentialsProvider Provider { get; set; }

        private string text;
        public string Text
        {
            get { return text; }
            set { text = value; OnPropertyChanged(); }
        }


        public MainViewModel()
        {
            Provider = new ApplicationIdCredentialsProvider(Key);
            GetBusses();
        }

        public void GetBusses()
        {
            HttpClient client = new HttpClient();
            string link = "https://www.bakubus.az/az/ajax/apiNew1";
            dynamic buses = JsonConvert.DeserializeObject(client.GetAsync(link)
                .Result.Content.ReadAsStringAsync().Result);
            foreach (var item in buses.BUS)
            {
                MessageBox.Show(item["@attributes"]["DRIVER_NAME"]);
                break;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
