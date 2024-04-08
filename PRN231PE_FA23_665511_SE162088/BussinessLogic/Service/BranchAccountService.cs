using Azure.Core;
using BussinessLogic.IService;
using Enities.IRepository;
using Enities.Models;
using Google.Apis.Auth;
using Microsoft.Extensions.Configuration;
using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BussinessLogic.Service
{
    public class BranchAccountService : IBranchAccountService
    {
        IBranchAccountRepository _repo;

        public BranchAccountService(IBranchAccountRepository repo)
        {
            _repo = repo;
        }

        public BranchAccount? Login(string username, string password)
        {
            var user = GetAll();

            if (user != null)
            {
                var result = (from u in user where u.EmailAddress == username && u.AccountPassword == password select u).FirstOrDefault();
                if (result != null) return result;
            }
            return null;
        }

        public async Task<string> LoginGoogle(string token)
        {
            string result = "fail";
            try
            {
                /*var client = new HttpClient();
               client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
               HttpResponseMessage response = await client.GetAsync("https://www.googleapis.com/oauth2/v3/userinfo");

               if (response.IsSuccessStatusCode)
               {
                   string json = await response.Content.ReadAsStringAsync();
                   var userInfo = JsonSerializer.Deserialize<UserInfoResponse>(json);

                   // Extract user information from the response
                   string email = userInfo.email;
                   string pictureUrl = userInfo.picture;
                   result = email + pictureUrl;
               }
               else
               {
                   result = "Failed to retrieve user information from Google API";
               }*/
                var payload = await GoogleJsonWebSignature.ValidateAsync(token);
                string email = payload.Email;
                string firstName = payload.GivenName;
                string lastName = payload.FamilyName;
                string pictureUrl = payload.Picture;
                result = email+firstName+lastName+pictureUrl;
            }
            catch (Exception ex)
            {
                // Handle exceptions
                result = ex.Message;
            }
            return result;
        }

        private List<BranchAccount> GetAll()
        {
            return _repo.GetAll().ToList();
        }
    }
}
