using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace AspNetCoreMVCApp.TagHelpers
{
    [HtmlTargetElement("image", TagStructure = TagStructure.WithoutEndTag)]
    public class ImageTagHelper:TagHelper
    {
        public string Src { get; set; }
        public string FallbackUrl { get; set; }
        private static IHttpContextAccessor httpContextAccessor;
        public ImageTagHelper(IHttpContextAccessor _httpContextAccessor)
        {
            httpContextAccessor = _httpContextAccessor;
        }
        
        
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "img";
            output.TagMode = TagMode.SelfClosing;
            HttpClient httpClient = new HttpClient();
            string fileUrl = "";
            if(Src.StartsWith("http") || FallbackUrl.StartsWith("https"))
            {
                var webUrl = new Uri(Src);
                httpClient.BaseAddress = new Uri($"{webUrl.Scheme}://{webUrl.Host}");
                Src = webUrl.LocalPath;
            }
            else
            {
                var baseUrl = httpContextAccessor.HttpContext.Request.GetDisplayUrl();
                httpClient.BaseAddress = new Uri(baseUrl);
            }
            using (HttpResponseMessage response = await httpClient.GetAsync(Src))
            {
                if (response.IsSuccessStatusCode)
                    output.Attributes.SetAttribute("src", Src);
                else
                    output.Attributes.SetAttribute("src", FallbackUrl);
            }              
            
        }
    }
}
