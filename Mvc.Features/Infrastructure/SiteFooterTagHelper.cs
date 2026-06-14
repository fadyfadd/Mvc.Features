using System;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Mvc.Features.Infrastructure;


[HtmlTargetElement("site-footer")]
public class SiteFooterTagHelper : TagHelper
{
    private readonly IWebHostEnvironment env;
    private readonly string environmentName;
    public SiteFooterTagHelper(IWebHostEnvironment env)
    {
        this.env = env;
        this.environmentName = env.EnvironmentName;
    }

    [ViewContext]
    [HtmlAttributeNotBound]
    public ViewContext ViewContext { get; set; }


    [HtmlAttributeName("company-name")]
    public string CompanyName { get; set; } = "My Company";

    public override void Process(TagHelperContext context, TagHelperOutput output)
    {

        output.TagName = "footer";
        output.Attributes.SetAttribute("class", "border-top footer text-muted bg-light p-3 mt-5");

        int currentYear = DateTime.Now.Year;

        TagBuilder containerDiv = new TagBuilder("div");
        containerDiv.AddCssClass("container d-flex justify-content-between align-items-center");

        TagBuilder leftDiv = new TagBuilder("div");
        TagBuilder copyrightSpan = new TagBuilder("span");
        copyrightSpan.InnerHtml.AppendHtml($"&copy; {currentYear} - ");

        TagBuilder strongCompany = new TagBuilder("strong");
        strongCompany.InnerHtml.Append(CompanyName);
        copyrightSpan.InnerHtml.AppendHtml(strongCompany);
        copyrightSpan.InnerHtml.Append(" All Rights Reserved.");
        leftDiv.InnerHtml.AppendHtml(copyrightSpan);

        TagBuilder rightDiv = new TagBuilder("div");
        TagBuilder badgeSpan = new TagBuilder("span");
        badgeSpan.AddCssClass("badge bg-secondary");
        badgeSpan.InnerHtml.Append($"Env: {this.env.EnvironmentName}");
        rightDiv.InnerHtml.AppendHtml(badgeSpan);

        containerDiv.InnerHtml.AppendHtml(leftDiv);
        containerDiv.InnerHtml.AppendHtml(rightDiv);
        output.Content.AppendHtml(containerDiv);
    }



}
