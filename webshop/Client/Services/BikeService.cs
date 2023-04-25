using System;
using System.Net.Http.Json;
using webshop.Client.Pages;
using webshop.Shared;
using static System.Net.WebRequestMethods;

namespace webshop.Client.Services
{
	public class BikeService : IBikeService
	{
        HttpClient http;
		public BikeService(HttpClient http)	{
            this.http = http;
        }

        public async Task<IEnumerable<BEBike>> GetAll() {
            var bikes = await http.GetFromJsonAsync<BEBike[]>("api/bike");

            return bikes;

        }

        public async Task AddBike(BEBike bike){
            await http.PostAsJsonAsync<BEBike>("api/bike", bike);
        }
    }
}

