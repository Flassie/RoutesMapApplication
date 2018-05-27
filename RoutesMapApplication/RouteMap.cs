using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace RoutesMapApplication
{
    public partial class RouteMap : Form
    {
        private DB db;
        private UTMConverter converter = new UTMConverter(null);

        public RouteMap(DB db)
        {
            this.db = db;
            db.Open();

            InitializeComponent();

            Browser.DocumentCompleted += Browser_DocumentCompleted;
        }

        private void Browser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            var coords = new List<String>();

            UTMConverter.LatLng startCoord = null;

            using (var reader = db.Execute("SELECT id, x, y FROM koordinat ORDER BY id"))
            {
                while (reader.Read())
                {
                    var utmx = reader.GetDouble(1);
                    var utmy = reader.GetDouble(2);

                    var latlng = converter.ConvertUtmToLatLng(utmy, utmx, 36, "N");

                    if (startCoord == null)
                    {
                        startCoord = latlng;
                    }

                    var stringLatLng = String.Format("{0}|{1}", latlng.Lat, latlng.Lng)
                        .Replace(",", ".");

                    coords.Add(stringLatLng);
                }
            }
            
            Browser.Document.InvokeScript("setMarker", new object[] { startCoord.Lat, startCoord.Lng, "Start" });
            Browser.Document.InvokeScript("createPath", coords.ToArray());
            Browser.Document.InvokeScript("moveToLocation", new object[] { startCoord.Lat, startCoord.Lng });
        }

        private void RouteMap_Load(object sender, EventArgs e)
        {
            var html = Properties.Resources.gmaps_page;
            Browser.DocumentText = html;
        }
    }
}
