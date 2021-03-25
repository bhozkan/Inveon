using InveonWebUI.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace InveonWebUI.Business
{
    public class ProductBusiness
    {
        public async Task<List<Product>> GetProducts(string token)
        {
            try
            {

                using (var client = new HttpClient())
                {
                    string AccessToken = token;
                    client.BaseAddress = new Uri("http://localhost:5000/api/");
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    HttpRequestMessage requestMessage = new HttpRequestMessage();
                    var response = client.GetAsync("Product/Products").Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var jwt = await response.Content.ReadAsStringAsync();
                        List<Product> products = JsonConvert.DeserializeObject<List<Product>>(jwt);
                        return products;
                    }
                    else { return null; }
                }

            }
            catch (Exception ex)
            {
                throw;

            }

        }

        public async Task<Product> GetProduct(Product productViewModel,string token)
        {
            try
            {

                using (var client = new HttpClient())
                {
                    string AccessToken = token;
                    client.BaseAddress = new Uri("http://localhost:5000/api/");
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    HttpRequestMessage requestMessage = new HttpRequestMessage();
                    var data = JsonConvert.SerializeObject(productViewModel);
                    requestMessage.Content = new StringContent(data, Encoding.UTF8, "application/json");
                    var response = client.PostAsync("Product/Product",requestMessage.Content).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var jwt = await response.Content.ReadAsStringAsync();
                        Product products = JsonConvert.DeserializeObject<Product>(jwt);
                        return products;
                    }
                    else { return null; }
                }

            }
            catch (Exception ex)
            {
                throw;

            }

        }

        public async Task<ProductViewModel> GetProductViewModel(ProductViewModel productViewModel, string token)
        {
            try
            {

                using (var client = new HttpClient())
                {
                    string AccessToken = token;
                    client.BaseAddress = new Uri("http://localhost:5000/api/");
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    HttpRequestMessage requestMessage = new HttpRequestMessage();
                    var data = JsonConvert.SerializeObject(productViewModel);
                    requestMessage.Content = new StringContent(data, Encoding.UTF8, "application/json");
                    var response = client.PostAsync("Product/Product", requestMessage.Content).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var jwt = await response.Content.ReadAsStringAsync();
                        ProductViewModel products = JsonConvert.DeserializeObject<ProductViewModel>(jwt);
                        return products;
                    }
                    else { return null; }
                }

            }
            catch (Exception ex)
            {
                throw;

            }

        }

        public async Task<bool> AddProduct(Product product, string token)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    string AccessToken = token;
                    client.BaseAddress = new Uri("http://localhost:5000/api/");
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    HttpRequestMessage requestMessage = new HttpRequestMessage();
                    var data = JsonConvert.SerializeObject(product);
                    requestMessage.Content = new StringContent(data, Encoding.UTF8, "application/json");
                    var response = client.PostAsync("Product/AddProduct",requestMessage.Content).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var jwt = await response.Content.ReadAsStringAsync();
                        bool isOk = JsonConvert.DeserializeObject<bool>(jwt);
                        return isOk;
                    }
                    else { return false; }
                }

            }
            catch (Exception ex)
            {
                throw;

            }

        }

        public async Task<Product> EditProduct(Product product, string token)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    string AccessToken = token;
                    client.BaseAddress = new Uri("http://localhost:5000/api/");
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    HttpRequestMessage requestMessage = new HttpRequestMessage();
                    var data = JsonConvert.SerializeObject(product);
                    requestMessage.Content = new StringContent(data, Encoding.UTF8, "application/json");
                    var response = client.PostAsync("Product/EditProduct", requestMessage.Content).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var jwt = await response.Content.ReadAsStringAsync();
                        Product isOk = JsonConvert.DeserializeObject<Product>(jwt);
                        return isOk;
                    }
                    else { return null; }
                }

            }
            catch (Exception ex)
            {
                throw;

            }

        }

        public async Task<bool> DeleteProduct(Product product, string token)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    string AccessToken = token;
                    client.BaseAddress = new Uri("http://localhost:5000/api/");
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    HttpRequestMessage requestMessage = new HttpRequestMessage();
                    var data = JsonConvert.SerializeObject(product);
                    requestMessage.Content = new StringContent(data, Encoding.UTF8, "application/json");
                    var response = client.PostAsync("Product/DeleteProduct", requestMessage.Content).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var jwt = await response.Content.ReadAsStringAsync();
                        bool isOk = JsonConvert.DeserializeObject<bool>(jwt);
                        return isOk;
                    }
                    else { return false; }
                }

            }
            catch (Exception ex)
            {
                throw;

            }

        }
    }
}
