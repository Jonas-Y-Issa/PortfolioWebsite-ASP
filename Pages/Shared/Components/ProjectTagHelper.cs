using Microsoft.AspNetCore.Razor.TagHelpers;

[HtmlTargetElement("ProjectItem")]
public class ProjectTagHelper : TagHelper
{
    public string? Id { get; set; }
    public string? Title { get; set; }
    public string? Preface { get; set; }
    public string? Description { get; set; }
    public string? ExtLink { get; set; }
    public string? ImgSrc { get; set; }

    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        output.TagName = "div";
        output.Attributes.SetAttribute("class", "project-wrapper fade-right");
        if (!string.IsNullOrEmpty(Id))
        {
            output.Attributes.SetAttribute("id", Id);
            output.Attributes.SetAttribute("display", "flex");
        }

        output.Content.SetHtmlContent($@"
            <div class=""project-content"">
                <div style=""padding: 5%"">{Preface}<a href={ExtLink} target=""_blank""
                    rel=""noopener noreferrer"">{Title}</a>
{Description}
                </div>
            </div>
            <div class=""project-content-img""><img src=""{ImgSrc}""></img>
            </div>
        ");
    }
}
