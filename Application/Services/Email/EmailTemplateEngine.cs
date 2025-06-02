using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Email
{
    public class EmailTemplateEngine
    {
        private readonly IWebHostEnvironment _env;

        public EmailTemplateEngine(IWebHostEnvironment env)
        {
            _env = env;
        }

        public async Task<string> LoadTemplateAsync(string templateName, Dictionary<string, string> placeholders)
        {
            var path = Path.Combine(_env.ContentRootPath, "Templates", templateName);
            string template = await File.ReadAllTextAsync(path);

            foreach (var placeholder in placeholders)
            {
                template = template.Replace($"{{{{{placeholder.Key}}}}}", placeholder.Value);
            }

            return template;
        }
    }
}
