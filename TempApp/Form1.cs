namespace TempApp
{
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Windows.Forms;
    using AutoJobFinder.Scraping.HAP;
    using AutoJobFinder.Searching;
    using AutoJobFinder.Searching.Seek;
    using AutoJobFinder.Sourcing.HttpClient;
    using AutoJobFinder.Sourcing.HttpClient.Invoking;

    public partial class form : Form
    {
        public form()
        {
            this.InitializeComponent();
        }

        private async void buttonSearch_Click(object sender, System.EventArgs e)
        {
            this.listView.Clear();

            string what = this.textBoxWhat.Text;
            string where = this.textBoxWhere.Text;

            var client = new HttpClientInvoker(new HttpClient());
            var sourcer = new HttpClientSourcer(client);

            var factory = new HAPWebScraperFactory();

            var jobSearcher = new SeekJobSearcher(factory, sourcer);
            var searchInfo = new JobSearchInformation(what, where);

            IReadOnlyCollection<JobInformation> results = await jobSearcher.Search(searchInfo);

            int i = 0;

            foreach (JobInformation result in results)
            {
                string[] row = { i.ToString(), result.Title, result.CompanyName, result.URL };

                var item = new ListViewItem(row);
                this.listView.Items.Add(item);

                i++;
            }
        }
    }
}