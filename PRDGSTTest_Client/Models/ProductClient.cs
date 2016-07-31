using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Text;

namespace PRDGSTTest_Client.Models
{
    public class ProductClient
    {
        private string BaseURL = "http://localhost:49858/api/";

        private const string controllerProduct = "product";

        private const string userName = "user1";

        private const string password = "123";
        public IEnumerable<Product> findAll()
        {
            try
            {
                HttpClient client = new HttpClient();
                var authInfo = Convert.ToBase64String(Encoding.Default.GetBytes(userName + ":" + password));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authInfo);
                client.BaseAddress = new Uri(BaseURL);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.GetAsync(controllerProduct).Result;
                if (response.IsSuccessStatusCode)
                {
                    return  response.Content.ReadAsAsync<IEnumerable<Product>>().Result;
                }
                return null;
            }
            catch 
            {

                return null;
            }
        }

        internal Product Create()
        {
            Product product = new Product();
            product.ListProductCategory = FillProductCategory();
            product.ListProductModel = FillProductModel();
            product.SellStartDate = DateTime.Now;
            return product;
        }

        internal Product FillList(Product product)
        {          
            product.ListProductCategory = FillProductCategory();
            product.ListProductModel = FillProductModel();
            return product;
        }

        public Product Find(int id)
        {
            try
            {
                HttpClient client = new HttpClient();
                var authInfo = Convert.ToBase64String(Encoding.Default.GetBytes(userName + ":" + password));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authInfo);
                client.BaseAddress = new Uri(BaseURL);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.GetAsync(controllerProduct + "/" + id.ToString()).Result;
                if (response.IsSuccessStatusCode)
                {
                    Product product = response.Content.ReadAsAsync<Product>().Result;
                    product.ListProductCategory = FillProductCategory();
                    product.ListProductModel = FillProductModel();
                    return product;
                }
                return null;
            }
            catch
            {

                return null;
            }
        }

        private List<ProductModel> FillProductModel()
        {
            try
            {
                HttpClient client = new HttpClient();
                var authInfo = Convert.ToBase64String(Encoding.Default.GetBytes(userName + ":" + password));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authInfo);
                client.BaseAddress = new Uri(BaseURL);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.GetAsync("ProductModel").Result;
                if (response.IsSuccessStatusCode)
                {
                    return response.Content.ReadAsAsync<List<ProductModel>>().Result;
                }
                return null;
            }
            catch
            {

                return null;
            }
        }

        private List<ProductCategory> FillProductCategory()
        {
            try
            {
                HttpClient client = new HttpClient();
                var authInfo = Convert.ToBase64String(Encoding.Default.GetBytes(userName + ":" + password));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authInfo);
                client.BaseAddress = new Uri(BaseURL);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.GetAsync("ProductCategory").Result;
                if (response.IsSuccessStatusCode)
                {
                    return response.Content.ReadAsAsync<List<ProductCategory>>().Result;
                }
                return null;
            }
            catch
            {

                return null;
            }
        }

        public bool Create(Product product)
        {
            try
            {
                HttpClient client = new HttpClient();
                var authInfo = Convert.ToBase64String(Encoding.Default.GetBytes(userName + ":" + password));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authInfo);
                client.BaseAddress = new Uri(BaseURL);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.PostAsJsonAsync(controllerProduct, product).Result;
                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }

        public bool Edit(Product product)
        {
            try
            {
                HttpClient client = new HttpClient();
                var authInfo = Convert.ToBase64String(Encoding.Default.GetBytes(userName + ":" + password));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authInfo);
                client.BaseAddress = new Uri(BaseURL);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.PutAsJsonAsync(controllerProduct + "/" + product.ProductID.ToString(), product).Result;
                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }


        public bool Delete(int id)
        {
            try
            {
                HttpClient client = new HttpClient();
                var authInfo = Convert.ToBase64String(Encoding.Default.GetBytes(userName + ":" + password));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authInfo);
                client.BaseAddress = new Uri(BaseURL);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.DeleteAsync(controllerProduct + "/" + id.ToString()).Result;
                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }


     
    }
}