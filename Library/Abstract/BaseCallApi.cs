using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using Library.Interfaces;
using Library.Models;
using Library.Settings;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace Library.Abstract
{
    public class BaseCallApi<T> : ICallApi<T> where T : IEntity
    {
        protected readonly HttpClient _httpClient;
        protected readonly IOptions<SettingsCallApi> _options;

        public BaseCallApi(HttpClient client, IOptions<SettingsCallApi> options)
        {
            _options = options;
            _httpClient = client;

            _httpClient.BaseAddress = new Uri($"{_options.Value.Adress}{GetTypeName()}/");
        }

        public string GetTypeName() => typeof(T).Name;

        public async Task DropCollectionAsync()
        {
            await _httpClient
                .DeleteAsync($@"DropCollectionAsync")
                .ConfigureAwait(false);
        }

        public async Task<long> CountDataAsync()
        {
            var response = await _httpClient
                .GetAsync($@"CountDataAsync")
                .ConfigureAwait(false);

            var returnJson = await response.Content
                .ReadAsStringAsync()
                .ConfigureAwait(false);

            return JsonConvert.DeserializeObject<long>(returnJson);
        }

        public async Task<T> CreateAsync(T entity)
        {
            var json = new StringContent(JsonSerializer.Serialize(entity), Encoding.UTF8, MediaTypeNames.Application.Json);

            using var response = await _httpClient
                .PostAsync($@"CreateAsync", json)
                .ConfigureAwait(false);

            response.EnsureSuccessStatusCode();

            var returnJson = await response.Content
                .ReadAsStringAsync()
                .ConfigureAwait(false);

            return JsonConvert.DeserializeObject<T>(returnJson);
        }

        public async Task<IEnumerable<T>> CreateManyAsync(IEnumerable<T> entities)
        {
            var json = new StringContent(JsonSerializer.Serialize(entities), Encoding.UTF8, MediaTypeNames.Application.Json);

            using var response = await _httpClient
                .PostAsync($@"CreateManyAsync", json)
                .ConfigureAwait(false);

            response.EnsureSuccessStatusCode();

            var returnJson = await response.Content
                .ReadAsStringAsync()
                .ConfigureAwait(false);

            return JsonConvert.DeserializeObject<IEnumerable<T>>(returnJson)!;
        }

        public async Task<IEnumerable<T>?> GetAllAsync()
        {
            return await _httpClient
                .GetFromJsonAsync<IEnumerable<T>>($"GetAllAsync")
                .ConfigureAwait(false);
        }

        public async Task<T?> GetOneFullAsync(string id)
        {
            return await _httpClient
                .GetFromJsonAsync<T>($"GetOneFullAsync/{id}")
                .ConfigureAwait(false);
        }

        public async Task<T?> GetOneSimpleAsync(string id)
        {
            return await _httpClient
                .GetFromJsonAsync<T>($"GetOneSimpleAsync/{id}")
                .ConfigureAwait(false);
        }

        public async Task DeleteOneAsync(string id)
        {
            using var response = await _httpClient
                .DeleteAsync($@"DeleteOneAsync/{id}")
                .ConfigureAwait(false);

            response.EnsureSuccessStatusCode();
        }

        public async Task<T> UpdateAsync(T entityUpdate)
        {
            var json = new StringContent(JsonSerializer.Serialize(entityUpdate), Encoding.UTF8, MediaTypeNames.Application.Json);

            using var response = await _httpClient
                .PutAsync($@"UpdateAsync", json)
                .ConfigureAwait(false);

            response.EnsureSuccessStatusCode();

            var returnJson = await response.Content
                .ReadAsStringAsync()
                .ConfigureAwait(false);

            return JsonConvert.DeserializeObject<T?>(returnJson);
        }
    }
}
