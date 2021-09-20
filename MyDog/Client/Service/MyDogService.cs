using MyDog.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace MyDog.Client.Service
{
    public class MyDogService : IMyDogService
    {
        private readonly HttpClient _httpClient;

        public MyDogService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public List<MyDog.Shared.Breed> Breed { get; set; } = new List<Breed>();
        public List<MyDog.Shared.MyDog> Dogs { get; set; } = new List<MyDog.Shared.MyDog>();

        public event Action OnChange;

        public async Task<List<MyDog.Shared.MyDog>> CreateDog(MyDog.Shared.MyDog dog)
        {
            var result = await _httpClient.PostAsJsonAsync<MyDog.Shared.MyDog>($"api/MyDog", dog);
            Dogs = await result.Content.ReadFromJsonAsync<List<MyDog.Shared.MyDog>>();
            OnChange.Invoke();
            return Dogs;
        }

        public async Task<List<MyDog.Shared.MyDog>> DeleteDog(int id)
        {
            var result = await _httpClient.DeleteAsync($"api/MyDog/{id}");
            Dogs = await result.Content.ReadFromJsonAsync<List<MyDog.Shared.MyDog>>();
            OnChange.Invoke();
            return Dogs;
        }

        public async Task GetBreed()
        {
            Breed = await _httpClient.GetFromJsonAsync<List<MyDog.Shared.Breed>>($"api/MyDog/breed");
        }

        public async Task<MyDog.Shared.MyDog> GetMyDog(int id)
        {
            return await _httpClient.GetFromJsonAsync<MyDog.Shared.MyDog>($"api/MyDog/{id}");
        }


        public async Task<List<MyDog.Shared.MyDog>> GetMyDogs()
        {
            Dogs = await _httpClient.GetFromJsonAsync<List<MyDog.Shared.MyDog>>("api/MyDog");
            return Dogs;
        }

        public async Task<List<MyDog.Shared.MyDog>> UpdateDog(MyDog.Shared.MyDog dog, int id)
        {
            var result = await _httpClient.PutAsJsonAsync<MyDog.Shared.MyDog>($"api/MyDog/{id}", dog);
            Dogs = await result.Content.ReadFromJsonAsync<List<MyDog.Shared.MyDog>>();
            OnChange.Invoke();
            return Dogs;
        }
    }
}
