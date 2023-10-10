using Microsoft.AspNetCore.Razor.TagHelpers;

[HtmlTargetElement("custom-section")]
public class SectionTagHelper : TagHelper
{
    public string Id { get; set; }
    public string Header { get; set; }

    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        output.TagName = "section";
        output.Attributes.SetAttribute("class", "section-format");
        if (!string.IsNullOrEmpty(Id))
        {
            output.Attributes.SetAttribute("id", Id);
        }

        var childContent = output.GetChildContentAsync().Result.GetContent();

        output.Content.SetHtmlContent($@"
            <div class=""section-header-wrapper"">
                <h1 class=""section-header"">{Header}</h1>
            </div>
            <div class=""content-wrapper"">
                {childContent}
            </div>
        ");
    }
}
