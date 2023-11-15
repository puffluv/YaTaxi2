using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Work_WPF.ViewModels
{
	class GeoInfoViewModel
	{
		[JsonProperty("country_code")]

		public string CountryCode { get; set; }


		[JsonProperty("country_name")]

		public string CountryName { get; set; }


		[JsonProperty("region_code")]

		public string RegionCode { get; set; }


		[JsonProperty("region_name")]

		public string RegionName { get; set; }


		[JsonProperty("city")]

		public string City { get; set; }


		[JsonProperty("zip_code")]

		public string ZipCode { get; set; }


		[JsonProperty("latitude")]

		public decimal Latitude { get; set; }


		[JsonProperty("longitude")]

		public string Longitude { get; set; }

	}
}
