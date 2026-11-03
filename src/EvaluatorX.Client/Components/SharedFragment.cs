using EvaluatorX.Domain.Models;

using Microsoft.AspNetCore.Components;

namespace EvaluatorX.Client.Components;

public static class SharedFragment
{
    /// <summary>Result template for user typeahead items.</summary>
    public static RenderFragment<UserReadModel> UserResult => item => builder =>
    {
        builder.OpenElement(0, "div");
        builder.AddContent(1, item.Name);
        builder.CloseElement(); // div

        builder.OpenElement(2, "div");
        builder.AddAttribute(3, "style", "font-size: .75rem; opacity: .75");
        builder.AddContent(4, item.Email);
        builder.CloseElement(); // div
    };
}
