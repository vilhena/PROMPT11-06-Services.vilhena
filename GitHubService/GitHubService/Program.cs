using System;
using System.Collections.Generic;
using System.Json;
using System.Linq;
using System.Net.Http;
using System.Text;

namespace GitHubService
{
    public class Issue
    {
        public string title { get; set; }
        public User user { get; set; }
    }


    public class User
    {
        public string login { get; set; }
        public string url { get; set; }
        public int? public_repos { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var client = new HttpClient();

            var res = client.GetAsync("https://api.github.com/repos/NancyFx/Nancy/issues").Result;

            var content = res.Content.ReadAsAsync<IEnumerable<Issue>>().Result;

            var list = new List<int>();
            foreach (var issue in content)
            {
                var userResult = client.GetAsync(issue.user.url).Result;
                Console.WriteLine(issue.user.login);
                var userDetail = userResult.Content.ReadAsAsync<User>().Result;
                Console.WriteLine(userDetail.public_repos);
                list.Add(userDetail.public_repos.GetValueOrDefault());
            }

            Console.WriteLine(list.Average(i => i));

        }
    }
}
